using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.Submaps;
using Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.TileAttributes;
using Zeus.Metis.Pythagoras;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map
{
    public class Map
    {
        public Vector2D MapBounds
        {
            get;

            protected set;
        }

        private SourceMap sourceMap;
        private CreaturesMap creaturesMap;
        private TileMap tileMap;

        public WorldSpace WorldSpace { get; protected set; }
        public GameSpace GameSpace => WorldSpace.GameSpace;

        public Map()
        {
            tileMap = new TileMap();
        }

        public int GetMovementCost(Vector2D position)
        {
            if (IsInBorders(position))
            {
                return tileMap.GetMovementCost(position);
            }
            throw new IndexOutOfRangeException("Position not in MapBounds.");
        }

        public Tile GetTile(Vector2D position)
        {
            if (IsInBorders(position))
            {
                return tileMap.GetTile(position);
            }
            throw new IndexOutOfRangeException("Position not in MapBounds.");
        }

        public bool IsInBorders(Vector2D position)
        {
            if (position.X < MapBounds.X && position.Y < MapBounds.Y)
            {
                return true;
            }
            return false;
        }
        
    }
}
