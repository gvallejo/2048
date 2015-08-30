using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.AI
{   

    public class TileGenerator: ITileGenerator
    {
        private int[] _tileBin;
        private int _FoursProbability;
        private RandomGenerator _randomGen;

        public TileGenerator()
        {
            _tileBin = new int[100];
            _randomGen = new RandomGenerator();
            FoursProbability = 10;
            }

        public int FoursProbability
        {
            get
            {
               return this._FoursProbability;
            }
            set
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i < value)
                        _tileBin[i] = 4;
                    else
                        _tileBin[i] = 2;
                }
                this._FoursProbability = value;
            }
        }

        public int GetNextTile()
        {
            return _tileBin[_randomGen.GetNextInt(0, 99)];            
        }

        
    }
}
