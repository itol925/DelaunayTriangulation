using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelaunayTriangulation {
    public partial class Form1 : Form {
        private Render m_render;
        private Delaunay m_delaunay;
        private List<Node> m_nodeList;
        private bool m_triangulate;

        public Form1() {
            InitializeComponent();
            this.m_triangulate = false;

            this.m_render = new Render(this.gbx_canvas.CreateGraphics());
            this.m_delaunay = new Delaunay();

            this.m_nodeList = new List<Node>();
            this.gbx_canvas.MouseClick += gbx_canvas_MouseClick;

            //test
            //var n1 = new Node(0, 20,20);
            //var n2 = new Node(1, 20,300);
            //var n3 = new Node(2, 300,300);
            //var n4 = new Node(3, 300,20);
            //var n5 = new Node(4, 50,150);
            //var n6 = new Node(5, 250,150);
            //var n7 = new Node(6, 150,50);
            //var n8 = new Node(7, 150,250);
            //this.m_nodeList.Add(n1);
            //this.m_nodeList.Add(n2);
            //this.m_nodeList.Add(n3);
            //this.m_nodeList.Add(n4);
            //this.m_nodeList.Add(n5);
            //this.m_nodeList.Add(n6);
            //this.m_nodeList.Add(n7);
            //this.m_nodeList.Add(n8);

        }

        private void gbx_canvas_MouseClick(object sender, MouseEventArgs e) {
            this.m_nodeList.Add(new Node(this.m_nodeList.Count, e.X, e.Y));
            this.gbx_canvas.Invalidate();
        }
        
        private void gbx_canvas_Paint(object sender, PaintEventArgs e) {
            for (var i = 0; i < this.m_nodeList.Count; i++) {
                this.m_render.DrawNode(this.m_nodeList[i]);
            }
            if (this.m_triangulate) {
                this.triangulate();
            }
        }

        private void btn_triangulate_Click(object sender, EventArgs e) {
            this.triangulate();
        }

        private void btn_clear_Click(object sender, EventArgs e) {
            this.clear();
        }

        private void triangulate() {
            var edges = this.m_delaunay.Triangulate(this.m_nodeList.ToArray());
            if (edges == null) {
                return;
            }
            for (var i = 0; i < edges.Length; i++) {
                this.m_render.DrawEdge(edges[i]);
            }
            this.m_triangulate = true; 
        }

        private void clear() { 
            this.m_nodeList.Clear();
            this.gbx_canvas.Invalidate();
            this.m_triangulate = false; 
        }
    }
}
