using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation {
    public class Node {
        private float x, y, z;
        private int m_index;

        public Node(int index) { 
            this.x = this.y = this.z = 0;
            this.m_index = index;
        }

        public Node(int index, float x, float y) {
            this.x = x; 
            this.y = y;
            this.z = 0;
            this.m_index = index;
        }
        
        public Node(int index, float x, float y, float z) {
            this.x = x; 
            this.y = y;
            this.z = z;
            this.m_index = index;
        }
        public int GetIndex() {
            return this.m_index;
        }

        public float X{
            get{
                return this.x;
            }
            set{
                this.x = value;
            }
        }
        public float Y{
            get {
                return this.y;
            }
            set {
                this.y = value;
            }
        }
        public float Z{
            get {
                return this.z;
            }
            set {
                this.z = value;
            }
        }
        
        /// <summary>
        /// 根据结点的index判定结点是不是相同
        /// </summary>
        /// <param name="otherNode"></param>
        /// <returns></returns>
        public bool Equal(Node otherNode) {
            if (this.m_index == otherNode.m_index) {
                return true;
            }
            //if (this.x == otherNode.X && this.y == otherNode.Y) {
            //    return true;
            //}
            return false;
        }
    }
}
