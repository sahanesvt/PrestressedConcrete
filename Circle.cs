using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    public class Circle: Shape
    {
        public Circle() : base() { }

        public Circle(double radius, double cg_x, double cg_y, bool void_) : base(radius, cg_x, cg_y, void_)
        {

        }
    }
}
