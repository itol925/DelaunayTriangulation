using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation {
    public class Vector {
        private float x, y, z;

        public Vector() { 
            this.x = this.y = this.z = 0;
        }

        public Vector(float x, float y) {
            this.x = x; 
            this.y = y;
        } 

        public Vector(float x, float y, float z) {
            this.x = x; 
            this.y = y;
            this.z = z;
        }
        public bool IsZero() {
            if (this.x == 0 && this.y == 0 && this.z == 0) {
                return true;
            }
            return false;
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

        public double GetAngle(Vector otherVector) {
            var cosAngle = (this.x * otherVector.x + this.y * otherVector.y + this.z * otherVector.z) / 
                (Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2) + Math.Pow(this.z, 2)) * Math.Sqrt(Math.Pow(otherVector.x, 2) + Math.Pow(otherVector.y, 2) + Math.Pow(otherVector.z, 2)));
            
            var angle = Math.Acos(cosAngle);
            return angle;
        }

        /// <summary>
        /// 向量相乘
        /// </summary>
        /// <param name="otherVector"></param>
        /// <returns>结果向量</returns>
        public Vector Multiply(Vector otherVector) {
            float newX = this.y * otherVector.z - this.z * otherVector.y;
            float newY = this.z * otherVector.x - this.x * otherVector.z;
            float newZ = this.x * otherVector.y - this.y * otherVector.x;
            return new Vector(newX, newY, newZ);
        }
    }
}
