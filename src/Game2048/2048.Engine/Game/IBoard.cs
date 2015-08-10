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
        List<List<int>> Rows { get; }
        List<List<int>> Cols { get; }
        int[,] Tiles { get; }
        void SetTiles(int[,] tiles);
    }
}
