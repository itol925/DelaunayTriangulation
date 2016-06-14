using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation {
    public class Triangle {
        private Node m_startNode, m_middleNode, m_endNode;

        public Triangle(Node startNode, Node middleNode, Node endNode) {
            this.m_startNode = startNode;
            this.m_middleNode = middleNode;
            this.m_endNode = endNode;
        }

        public Node StartNode {
            get {
                return this.m_startNode;
            }
        }

        public Node Middle {
            get {
                return this.m_middleNode;
            }
        }

        public Node EndNode {
            get {
                return this.m_endNode;
            }
        }
    }
}
