using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using DelaunayTriangulation;


namespace DelaunayTriangulation {

    class Render
    {
        private const int nodeRadius = 2;

        private Graphics m_graphics;
        private Pen m_pen;

        public Render(Graphics graphics) 
        {
            this.m_graphics = graphics;

            this.m_pen = new Pen(Color.Red);
        }

        public void DrawNode(Node node) {
            this.m_graphics.DrawEllipse(this.m_pen, node.X - nodeRadius/2, node.Y - nodeRadius/2, nodeRadius, nodeRadius);
        }

        public void DrawEdge(Edge edge) {
            this.m_graphics.DrawLine(this.m_pen, edge.StartNode.X, edge.StartNode.Y, edge.EndNode.X, edge.EndNode.Y);
        }

        public void ConnectNodes(Node[] nodes, bool close = false) {
            for (var i = 0; i < nodes.Length; i++) {
                if (i < nodes.Length - 1) {
                    this.m_graphics.DrawLine(this.m_pen, nodes[i].X, nodes[i].Y, nodes[i + 1].X, nodes[i + 1].Y);
                } else {
                    if (close) {
                        this.m_graphics.DrawLine(this.m_pen, nodes[i].X, nodes[i].Y, nodes[0].X, nodes[0].Y);
                    }
                }
            }
        }
    }
}
