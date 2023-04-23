namespace BattleShipUpdate.Models.Ships
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            BattleShipType = ShipType.Carrier;
            Holes = 5;
            Hits = 0;
        }
    }
}
