using Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.TileAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeus.Metis.Pythagoras;

namespace Die_Legenden_der_Alten_Zeit_Lib.Universe.Map.Submaps
{
    [Serializable]
    public class TileMap
    {
        public List<List<Tile>> Tiles { get; set; }

        public TileMap()
        {
            Tiles = new List<List<Tile>>();
        }

        public Tile GetTile(Vector2D position)
        {
            return Tiles[position.x][position.y];
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

        public int GetMovementCost(Vector2D position)
        { 
            Tile tmp = Tiles[position.x][position.y];
            int movementCost = TileBaseType.GetBaseType(tmp.Type).MovementCost;
            movementCost += Relief.GetRelief(tmp.Relief).MovementCost;
            movementCost += Vegetation.GetVegetation(tmp.Vegetation).MovementCost;
            return movementCost;
        }
    }
}
