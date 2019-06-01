using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.TileAttributes;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map
{
    [Serializable]
    public class Map
    {
        List<List<Tile>> Tiles;

        public Map()
        {
            Tiles = new List<List<Tile>>();
        }

        public int GetMovementCost(Vector2D position)
        {
            if (IsInBorders(position))
            {
                Tile tmp = Tiles[position.X][position.Y];
                int movementCost = TileBaseType.GetBaseType(tmp.Type).MovementCost;
                movementCost += Relief.GetRelief(tmp.Relief).MovementCost;
                movementCost += Vegetation.GetVegetation(tmp.Vegetation).MovementCost;
                return movementCost;
            }
            throw new IndexOutOfRangeException("Position not in MapBounds.");
        }

        public Tile GetTile(Vector2D position)
        {
            if (IsInBorders(position))
            {
                return Tiles[position.X][position.Y];
            }
            throw new IndexOutOfRangeException("Position not in MapBounds.");
        }

        public bool IsInBorders(Vector2D position)
        {
            if (position.X < Tiles.Count && position.Y < Tiles[position.X].Count)
            {
                return true;
            }
            return false;
        }

        public void AddNewRow(string baseType, string relief, string vegetation)
        {
            foreach (List<Tile> colum in Tiles)
            {
                Tile tmp = new Tile
                {
                    Type = baseType,
                    Relief = relief,
                    Vegetation = vegetation
                };
                colum.Add(tmp);
            }
        }

        public void AddNewColumn(string baseType, string relief, string vegetation)
        {
            int index = Tiles.Count;
            Tiles.Add(new List<Tile>());
            for (int y = 0; y < Tiles[0].Count; y++)
            {
                Tile tmp = new Tile
                {
                    Type = baseType,
                    Relief = relief,
                    Vegetation = vegetation
                };
                Tiles[index].Add(tmp);
            }
        }
    }
}
