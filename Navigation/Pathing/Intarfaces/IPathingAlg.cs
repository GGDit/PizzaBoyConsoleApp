using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navigation.Mapping;

namespace Navigation.Pathing.Intarfaces
{
    public interface IPathingAlg
    {
        public List<LocationNode> Run(LocationNode start, LocationNode end);
    }
}
