using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6_Lab
{
    // Define the Vertex class to represent a point in the graph
    public class Vertex
    {
        // Private fields for vertex attributes
        private int vertexId; // Unique identifier for the vertex
        private int x; // X-coordinate of the vertex
        private int y; // Y-coordinate of the vertex

        // Public property for vertexId
        public int VertexId
        {
            get { return vertexId; } // Get the vertex ID
            set { vertexId = value; } // Set the vertex ID
        }

        // Public property for x-coordinate
        public int X_coordinate
        {
            get { return x; } // Get the x-coordinate
            set { x = value; } // Set the x-coordinate
        }

        // Public property for y-coordinate
        public int Y_coordinate
        {
            get { return y; } // Get the y-coordinate
            set { y = value; } // Set the y-coordinate
        }

        // Constructor for Vertex class
        public Vertex(int id, int x, int y)
        {
            this.vertexId = id; // Initialize vertex ID
            this.x = x; // Initialize x-coordinate
            this.y = y; // Initialize y-coordinate
        }

        // Method to draw the vertex on a graphical interface
        public void drawing(Graphics g)
        {
            Pen pen = new Pen(Color.Black); // Create a black pen for drawing
            int s = 2; // Size of the vertex point

            // Create a rectangle to represent the vertex's boundary
            Rectangle r = new Rectangle(x - s, y - s, 2 * s, 2 * s);
            g.DrawEllipse(pen, r); // Draw outline of the ellipse for vertex
            g.FillEllipse(new SolidBrush(Color.Black), r); // Fill the ellipse with color to show a dot
        }
    }
}