using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6_Lab
{
    public class Edge
    {
        private int id;
        private Vertex from;
        private Vertex to;
        public int edgeId
        {
            get { return id; }
            set { id = value; }
        }
        public Vertex from_vertex
        {
            get { return from; }
            set { from = value; }
        }
        public Vertex to_vertex
        {
            get { return to; }
            set { to = value; }
        }

        public Edge(int id, Vertex from,  Vertex to)
        {
            this.id = id;
            this.from = from;
            this.to = to;
        }

        public void drawing(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            // Draw line.
            g.DrawLine(pen, from_vertex.X_coordinate, from_vertex.Y_coordinate, to_vertex.X_coordinate, to_vertex.Y_coordinate);

            // Draw arrow.
            Point direction = new Point(to_vertex.X_coordinate - from_vertex.X_coordinate, to_vertex.Y_coordinate - from_vertex.Y_coordinate);
            double angle = Math.Atan2(direction.Y, direction.X);
            double arrowLength = 10;

            Point point1 = new Point(
                (int)(to_vertex.X_coordinate - arrowLength * Math.Cos(angle + Math.PI / 6)),
                (int)(to_vertex.Y_coordinate - arrowLength * Math.Sin(angle + Math.PI / 6))
            );
            Point point2 = new Point(
                (int)(to_vertex.X_coordinate - arrowLength * Math.Cos(angle - Math.PI / 6)),
                (int)(to_vertex.Y_coordinate - arrowLength * Math.Sin(angle - Math.PI / 6))
            );

            g.DrawLine(pen, to_vertex.X_coordinate, to_vertex.Y_coordinate, point1.X, point1.Y);
            g.DrawLine(pen, to_vertex.X_coordinate, to_vertex.Y_coordinate, point2.X, point2.Y);
        }
    }
}
