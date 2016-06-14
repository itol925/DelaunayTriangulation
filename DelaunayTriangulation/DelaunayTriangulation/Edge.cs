using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation {
    public class Edge {
        private Node m_startNode, m_endNode;
        //private bool m_hasLeftTriangle;

        public Edge(Node startNode, Node endNode) {
            this.m_startNode = startNode;
            this.m_endNode = endNode;
            //this.m_hasLeftTriangle = false;
        }

        public Node StartNode {
            get {
                return this.m_startNode;
            }
            set {
                this.m_startNode = value;
            }
        }

        public Node EndNode {
            get {
                return this.m_endNode;
            }
            set {
                this.m_endNode = value;
            }
        }

        //public bool HasLeftTriangle {
        //    get { 
        //        return this.m_hasLeftTriangle;
        //    }
        //    set {
        //        this.m_hasLeftTriangle = value;
        //    }
        //}

        public Vector GetVector() {
            Vector vector = new Vector(this.m_endNode.X - this.m_startNode.X, this.m_endNode.Y - this.m_startNode.Y, this.m_endNode.Z - this.m_startNode.Z);
            return vector;
        }

        /// <summary>
        /// 获取一个结点n，使得向量vector(m_startNode, n)与向量(m_endNode, n)夹角最大
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public Node getMaxAngleLeftNode(Node[] nodes) {
            var leftNodes = this.GetLeftNodes(nodes);

            List<Node> maxAngleNodes = new List<Node>();

            double maxAngle = 0;
            for (var i = 0; i < leftNodes.Length; i++) {
                var startVector = new Edge(this.m_startNode, leftNodes[i]).GetVector();
                var endVector = new Edge(this.m_endNode, leftNodes[i]).GetVector();

                var angle = startVector.GetAngle(endVector);
                if (angle > maxAngle) {
                    maxAngleNodes.Clear();
                    maxAngleNodes.Add(leftNodes[i]);
                    maxAngle = angle;
                } else if (angle == maxAngle) {
                    maxAngleNodes.Add(leftNodes[i]);
                }
            }
            if (maxAngleNodes.Count == 0) {
                return null;
            } else if (maxAngleNodes.Count == 1) {
                return maxAngleNodes[0];
            } else if (maxAngleNodes.Count == 2) {
                var edge0 = new Edge(this.m_startNode, maxAngleNodes[0]);
                var edge1 = new Edge(this.m_startNode, maxAngleNodes[1]);
                
                var vector0 = edge0.GetVector();
                var vector1 = edge1.GetVector();
                
                var selfVector = this.GetVector();
                var angle0 = selfVector.GetAngle(vector0);
                var angle1 = selfVector.GetAngle(vector1);

                if (angle0 > angle1) {
                    return maxAngleNodes[0];
                } else {
                    return maxAngleNodes[1];
                }
            }
            return null;           
        }
        
        /// <summary>
        /// 获取一个结点n，使得向量vector(m_startNode, n)与自身向量夹角最大
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns>夹角</returns>
        public Node getMaxAngleNode(Node[] nodes) {
            double maxAngle = 0;
            Node maxAngleNode = null;
            for (var i = 0; i < nodes.Length; i++) {
                if (this.m_startNode.Equal(nodes[i])) {
                    continue;
                }
                var edge = new Edge(this.m_startNode, nodes[i]);

                var selfVec = this.GetVector();
                var edgeVec = edge.GetVector();
                                
                var angle = selfVec.GetAngle(edgeVec);
                if (angle > maxAngle) {
                    maxAngle = angle;
                    maxAngleNode = nodes[i];
                }
            }
            return maxAngleNode;
        }

        /// <summary>
        /// 获取向量左边的结点
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private Node[] GetLeftNodes(Node[] nodes) {
            List<Node> leftNodes = new List<Node>();
            for (var i = 0; i < nodes.Length; i++) {
                if (nodes[i].Equal(this.m_startNode) || nodes[i].Equal(this.m_endNode)) {
                    continue;
                }
                if (!this.NodeLeftOfEdge(nodes[i])) {
                    continue;
                }
                leftNodes.Add(nodes[i]);
            }
            return leftNodes.ToArray();
        }

        /// <summary>
        /// 指定的结点是否在边的左边
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool NodeLeftOfEdge(Node node) {
            var otherEdge = new Edge(this.m_startNode, node);
            var selfVec = this.GetVector();
            var otherVec = otherEdge.GetVector();
            var multiplyVec = selfVec.Multiply(otherVec);
            if (multiplyVec.Z < 0) {    // y轴向下时<0， y轴向上时>0
                return true;
            }
            return false;
        }

    }
}
