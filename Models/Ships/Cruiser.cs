namespace BattleShipUpdate.Models.Ships
{
    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            BattleShipType = ShipType.Cruiser;
            Holes = 3;
            Hits = 0;
        }
    }
}
