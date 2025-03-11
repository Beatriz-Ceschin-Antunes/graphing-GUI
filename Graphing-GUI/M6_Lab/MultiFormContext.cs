using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M6_Lab
{
    // MultiFormContext class inherits from ApplicationContext
    // It manages multiple forms and exits the application when all forms are closed
    public class MultiFormContext : ApplicationContext
    {
        private int openForms; // Keeps track of the number of open forms

        // Constructor that takes an array of forms as parameters
        public MultiFormContext(params Form[] forms)
        {
            // Initialize openForms to the number of forms provided
            openForms = forms.Length;

            // Iterate through each form
            foreach (Form form in forms)
            {
                // Attach an event handler to FormClosed event
                form.FormClosed += (s, args) =>
                {
                    // Thread-safe decrement of openForms count
                    // If all forms are closed (count reaches 0), exit the application
                    if (Interlocked.Decrement(ref openForms) == 0)
                    {
                        ExitThread(); // Terminates the message loop of the application
                    }
                };

                form.Show(); // Display the form
            }
        }
    }
}