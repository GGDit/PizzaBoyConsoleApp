using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Mapping
{
    public class LocationNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Double G { get; set; }
        public Double H { get; set; }
        public Double F { get; set; }

        public LocationNode Parent { get; set; }
        public LocationNode Child { get; set; }

        public LocationNode()
        {
            X = -1; Y = -1;

            this.Parent = null;
            this.Child = null;
        }

        public LocationNode(int X, int Y)
        {
            this.X = X;
            this.Y = Y;

            this.Parent = null;
            this.Child = null;
        }

        public LocationNode(int X, int Y, LocationNode Parent)
        {
            this.X = X;
            this.Y = Y;

            this.Parent = Parent;
            this.Parent.Child = this;

            this.Child = null;
        }

        public static bool IsSameLocation(LocationNode first, LocationNode second)
        {
            if (first.X == second.X && first.Y == second.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        


    }
}
