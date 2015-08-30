using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.AI
{
   

    public interface ITileGenerator
    {
        int FoursProbability { get; set; }
        int GetNextTile();
    }
}
