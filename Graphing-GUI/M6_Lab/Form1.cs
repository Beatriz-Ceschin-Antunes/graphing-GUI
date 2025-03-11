using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M6_Lab
{
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            // Get instance of graph manager.
            Graph_Manager manager = Graph_Manager.getManager();

            // Add a new graph, with ID 1. 
            manager.addGraph(1);
            // Add a vertex to graphID 1, with vertexID 1.
            manager.reviseGraphVertex(1, 1, 10, 10);
            // Modify first vertex (vertexID 1) of graphID 1.
            manager.reviseGraphVertex(1, 1, 200, 180);
            // Add new vertex, vertexID 2, to graphID 1.
            manager.reviseGraphVertex(1, 2, 300, 10);
            // Add new vertex, vertexID 3, to graphID 1.
            manager.reviseGraphVertex(1, 3, 300, 40); // adds new vertex, id = 2
            // Draw 2 directed edges in graphID 1 that connect vertex 1 and 2, and 1 and 3.
            manager.reviseGraphEdge(1, 1, manager.graphs[1].vertices[1], manager.graphs[1].vertices[2]);
            manager.reviseGraphEdge(1, 2, manager.graphs[1].vertices[1], manager.graphs[1].vertices[3]);

            manager.copyGraph(1, 2); // Clone graph, graphID 1, assign new graphID 2.

            // Make modification to graphID 2. Connect vertices 2 and 1.
            manager.reviseGraphEdge(2, 1, manager.graphs[2].vertices[2], manager.graphs[2].vertices[1]);

            // Display graph with graphID 2.
            //g = panel.CreateGraphics();
            manager.graphs[2].display(e.Graphics);
        }
    }
}
