using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{
    public interface ITileAccessor
    {
        int this[int i] { get; set;}

        void AttachToTiles(ref TilesBuffer buffer);
    }
}
