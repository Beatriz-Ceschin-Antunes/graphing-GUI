using System;
using System.Drawing;
using System.Windows.Forms;

namespace M6_Lab
{
    public partial class Form2 : Form
    {
        private Panel panel;

        public Form2()
        {
            InitializeComponent();
            InitializePanel();
            panel.Invalidate(); // force repaint
        }

        private void InitializePanel()
        {
            panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(panel);
            panel.Paint += panel_Paint;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            // Get instance of graph manager.
            Graph_Manager manager = Graph_Manager.getManager();

            // Displaying graph with ID 2
            if (manager.graphs.ContainsKey(2))
            {
                manager.graphs[2].display(e.Graphics);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
