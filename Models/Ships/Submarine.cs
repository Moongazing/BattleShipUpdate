using System.Xml.Linq;

namespace BattleShipUpdate.Models.Ships
{
    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            BattleShipType = ShipType.Submarine;
            Holes = 3;
            Hits = 0;
        }

    }
   
}
