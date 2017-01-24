using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestressedConcrete
{
    public abstract class Shape
    {
        public double Area { get; private set; }
        public double CG_x { get; set; }
        public double CG_y { get; set; }
        public double I_x { get; private set; }
        public double I_y { get; set; }

        public Shape()
        {
            Area = 0;
            CG_x = 0;
            CG_y = 0;
            I_x = 0;
            I_y = 0;
        }

        public Shape(double width, double depth, double cg_x, double cg_y, bool rightTriangle, bool void_)
        {
            CG_x = cg_x;
            CG_y = cg_y;
            if (void_)
            {
                if (rightTriangle)
                {
                    Area = -1 * width * depth / 2;
                    I_x = -1 * width * Math.Pow(depth, 3) / 36;
                    I_y = -1 * depth * Math.Pow(width, 3) / 36;
                }
                else
                {
                    Area = -1 * width * depth;
                    I_x = -1 * width * Math.Pow(depth, 3) / 12;
                    I_y = -1 * depth * Math.Pow(width, 3) / 12;
                }
            }
            else
            {
                if (rightTriangle)
                {
                    Area = width * depth / 2;
                    I_x = width * Math.Pow(depth, 3) / 36;
                    I_y = depth * Math.Pow(width, 3) / 36;
                }
                else
                {
                    Area = width * depth;
                    I_x = width * Math.Pow(depth, 3) / 12;
                    I_y = depth * Math.Pow(width, 3) / 12;
                }
            }
        }

        public Shape(double radius, double cg_x, double cg_y, bool void_)
        {
            if (void_)
            {
                Area = -1 * Math.PI * Math.Pow(radius, 2);
                CG_x = cg_x;
                CG_y = cg_y;
                I_x = -1 * Math.PI * Math.Pow(radius, 4) / 4;
                I_y = I_x;
            }
            else
            {
                Area = Math.PI * Math.Pow(radius, 2);
                CG_x = cg_x;
                CG_y = cg_y;
                I_x = Math.PI * Math.Pow(radius, 4) / 4;
                I_y = I_x;
            }
        }

        public Shape(List<double[]> coordinates, bool void_)
        {
            double[,] coords = new double[2, coordinates.Count + 1];
            double area = 0, cg_x = 0, cg_y = 0, i_x = 0, i_y = 0;
            int coordIndex = 0;
            foreach(double[] coord in coordinates)
            {
                coords[0, coordIndex] = coord[0];
                coords[1, coordIndex] = coord[1];
                coordIndex++;
            }
            coords[0, coordinates.Count] = coordinates[coordinates.Count - 1][0];
            coords[1, coordinates.Count] = coordinates[coordinates.Count - 1][1];
            int i = 0;
            while (i < coords.GetLength(1) - 1)
            {
                area += (coords[0, i + 1] * coords[1, i] - coords[0, i] * coords[1, i + 1]) / 2;
                cg_x += (coords[0, i] + coords[0, i + 1]) * (coords[0, i + 1] * coords[1, i] - coords[0, i] * coords[1, i + 1]);
                cg_y += (coords[1, i] + coords[1, i + 1]) * (coords[0, i + 1] * coords[1, i] - coords[0, i] * coords[1, i + 1]);
                i_x += (Math.Pow(coords[1, i], 2) + coords[1, i] * coords[1, i + 1] + Math.Pow(coords[1, i + 1], 2)) * (coords[0, i] * coords[1, i + 1] - coords[0, i + 1] * coords[1, i]) / 12;
                i_y += (Math.Pow(coords[0, i], 2) + coords[0, i] * coords[0, i + 1] + Math.Pow(coords[0, i + 1], 2)) * (coords[0, i] * coords[1, i + 1] - coords[0, i + 1] * coords[1, i]) / 12;
                i++;
            }
            Area = area;
            CG_x = cg_x;
            CG_y = cg_y;
            I_x = i_x;
            I_y = i_y;

        }

    }
}
