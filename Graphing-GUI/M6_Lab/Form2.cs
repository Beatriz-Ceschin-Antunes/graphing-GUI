using System;
using System.Drawing;
using System.Windows.Forms;

namespace M6_Lab
{
    public partial class Form2 : Form
    {
        Graphics g2;

        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Get instance of graph manager.
            Graph_Manager manager2 = Graph_Manager.getManager();

            // Add a new graph with ID 10.
            manager2.addGraph(10);

            // Add new vertex to graph, vertexID = 1.
            manager2.reviseGraphVertex(10, 1, 100, 200);
            // Add second vertex to graph, vertexID = 2.
            manager2.reviseGraphVertex(10, 2, 300, 200);
            // Add edge between 1 and 2.
            manager2.reviseGraphEdge(10, 1, manager2.graphs[10].vertices[1], manager2.graphs[10].vertices[2]);

            // Display created graph.
            g2 = panel1.CreateGraphics();
            manager2.graphs[10].display(e.Graphics);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}
