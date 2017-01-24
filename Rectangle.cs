using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    public class Rectangle: Shape
    {
        public Rectangle() : base() { }

        public Rectangle(double width, double depth, double cg_x, double cg_y, bool void_) : base(width,depth,cg_x,cg_y,false, void_)
        {
           
        }


    }
}
