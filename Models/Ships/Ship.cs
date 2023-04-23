using BattleShipUpdate.Models.Board;

namespace BattleShipUpdate.Models.Ships
{
    public class Ship
    {
        public string Name { get; set; }

        public ShipType BattleShipType { get; set; }

        public int Holes { get; set; }

        public int Hits { get; set; }

        public int Miss
        {
            get
            {
                return Hits;
            }
        }

        public bool IsSunk => Hits >= Holes;

        public List<Coordinates> ShipCoordinates { get; set; }
    }
}

