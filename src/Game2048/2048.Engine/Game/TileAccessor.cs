using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Engine.Game
{
    //internal unsafe struct TileVector
    //{
    //    int*[] tilePointerArray = new int*[4];
    //}

    public unsafe class TileAccessor: ITileAccessor 
    {                
        private int*[] tilePointerArray = new int*[4];
       
        private int _accessorId;
        private ReadDirection _readDirection;
        private TilesBuffer buffer;

        public TileAccessor( int accessorId, ReadDirection readDirection, ref TilesBuffer buffer)
        {
            this._accessorId = accessorId;
            this._readDirection = readDirection;
            AttachToTiles(ref buffer);
        }

        public void AttachToTiles(ref TilesBuffer buffer)
        {
            fixed (int* pbuffer = buffer.fixedBuffer)
            {
                for (int i = 0; i < 4; i++)
                {
                    tilePointerArray[i] = pbuffer + GetPointerOffset(_readDirection, _accessorId, i);
                }
            }
        }

        public int this[int i]
        {
            get
            {
                return *(this.tilePointerArray[i]);
            }
            set
            {
                *(this.tilePointerArray[i]) = value;
            }
        }

        private int GetPointerOffset(ReadDirection readDirection, int accessorId, int tileIndex)
        {
            int offSet = 0;
            switch (readDirection)
            {
                case ReadDirection.LeftToRight:
                    offSet = (4 * accessorId) + tileIndex;
                    break;
                case ReadDirection.RightToLeft:
                    offSet = (4 * accessorId) + (3 - tileIndex);
                    break;
                case ReadDirection.TopDown:
                    offSet = (4 * tileIndex) + accessorId;
                    break;
                case ReadDirection.BottomUp:
                    offSet = (4 * (3 - tileIndex)) + accessorId;
                    break;
                
            }
            return offSet;
        }

        
    }
}
