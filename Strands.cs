using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    public class Strands
    {
        public int NoStrands { get; set; }
        public double AreaPerStrand { get; set; }
        public double Area { get; private set; }
        public double Location { get; set; }

        public Strands()
        {
            NoStrands = 0;
            AreaPerStrand = 0;
            Area = 0;
            Location = 0;
        }

        public Strands(int noStrands, double areaPerStrand,double location)
        {
            NoStrands = noStrands;
            AreaPerStrand = areaPerStrand;
            Area = noStrands * areaPerStrand;
            Location = location;
        }

    }
}
