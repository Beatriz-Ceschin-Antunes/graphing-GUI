using System;
using System.Windows.Forms;

namespace M6_Lab
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create both forms
            Form1 form1 = new Form1();
            Form2 form2 = new Form2();

            // Run the application with Form1
            Application.Run(new MultiFormContext(form1, form2));
        }
    }
}
