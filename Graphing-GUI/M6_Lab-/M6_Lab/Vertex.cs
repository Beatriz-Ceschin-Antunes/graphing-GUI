using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6_Lab
{
    public class Vertex
    {
        private int vertexId;
        private int x;
        private int y;
        public int VertexId 
        {
            get {  return vertexId; }
            set {  vertexId = value; }
        }
        public int X_coordinate
        {
            get { return x; }
            set { x = value; }
        }
        public int Y_coordinate
        {
            get { return y; }
            set { y = value; }
        }

        public Vertex(int id, int x, int y)
        {
            this.vertexId = id;
            this.x = x;
            this.y = y;
        }

        public void drawing(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            int s = 2;

            Rectangle r = new Rectangle(x - s, y - s, 2 * s, 2 * s);
            g.DrawEllipse(pen, r); // Draw outline of the ellipse for vertex
            g.FillEllipse(new SolidBrush(Color.Black), r); // Fill the ellipse with color to show a dot
        }
    }
}
