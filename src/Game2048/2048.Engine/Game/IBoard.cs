using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{
    public interface IBoard
    {
        List<ITileAccessor> RowsLeftToRight { get; }
        List<ITileAccessor> RowsRightToLeft { get; }
        List<ITileAccessor> ColsTopDown { get; }
        List<ITileAccessor> ColsBottomUp { get; }

        List<Tuple<int, int>> BlankTiles { get; }

        int[,] Tiles { get; }
        void SetTiles(int[,] tiles);
        void SetTile(int r, int c, int value);
    }
}
