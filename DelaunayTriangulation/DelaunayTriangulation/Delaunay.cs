using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation {

    public class Delaunay {
        /// <summary>
        /// 三角剖分
        /// </summary>
        /// <param name="nodes">结点集合</param>
        /// <returns>所有的三角边</returns>
        public Edge[] Triangulate(Node[] nodes) {
            if (nodes.Length < 3) {
                return null;
            }
            var allEdges = new List<Edge>();
            
            var outsideEdges = this.getOutsideEdges(nodes);
            allEdges.InsertRange(0, outsideEdges);

            for (var i = 0; i < allEdges.Count; i++) {
                var currentEdge = allEdges[i];
                //if (currentEdge.HasLeftTriangle) {
                //    continue;
                //}

                var leftNode = currentEdge.getMaxAngleLeftNode(nodes);
                if (leftNode == null) {
                    //currentEdge.HasLeftTriangle = true;
                    continue;
                }
                this.addEdge(allEdges, currentEdge.StartNode, leftNode);
                this.addEdge(allEdges, leftNode, currentEdge.EndNode);
                //currentEdge.HasLeftTriangle = true;
            }
            
            return allEdges.ToArray();
        }

        /// <summary>
        /// 往现有的边集中添加一条边，如果该边已经存在，则不处理
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="startNode">新边的起点</param>
        /// <param name="endNode">新边的终点</param>
        private void addEdge(List<Edge> edges, Node startNode, Node endNode) {
            for (var i = 0; i < edges.Count; i++) {
                if (edges[i].StartNode.Equal(startNode) && edges[i].EndNode.Equal(endNode)){
                    return;
                }
                if (edges[i].StartNode.Equal(endNode) && edges[i].EndNode.Equal(startNode)) {
                    //edges[i].StartNode = startNode;
                    //edges[i].EndNode = endNode;
                    //edges[i].HasLeftTriangle = false;
                    return;
                }
            }
            var newEdge = new Edge(startNode, endNode);
            edges.Add(newEdge);
            return;
        }
        
        /// <summary>
        /// 获取最外围的结点
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns>最外围结点数组</returns>
        private Edge[] getOutsideEdges(Node[] nodes) {
            if (nodes.Length < 3) {
                return null;
            }

            List<Edge> outsideEdges = new List<Edge>();

            var minXNode = this.getMinXNode(nodes);

            var startNode = minXNode;
            var endNode = new Node(-1, startNode.X, startNode.Y - 1);
            var relativeEdge = new Edge(startNode, endNode);

            Node nextOutsideNode = null;
            while (true) {
                nextOutsideNode = relativeEdge.getMaxAngleNode(nodes);
                outsideEdges.Add(new Edge(startNode, nextOutsideNode));
                if (nextOutsideNode.Equal(minXNode)) {
                    break;
                }

                endNode = startNode;
                startNode = nextOutsideNode;
                relativeEdge = new Edge(startNode, endNode);
            }

            return outsideEdges.ToArray();
        }

        /// <summary>
        /// 获取nodes中，x坐标最小的结点
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private Node getMinXNode(Node[] nodes) {
            var node = nodes[0];
            for (var i = 0; i < nodes.Length; i++) {
                if (nodes[i].X < node.X) {
                    node = nodes[i];
                }
            }
            return node;
        }

        
    }
}
