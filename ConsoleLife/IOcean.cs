using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    public interface IOcean
    {
        Cell this[int i, int j] { get; set; }
    }
}
