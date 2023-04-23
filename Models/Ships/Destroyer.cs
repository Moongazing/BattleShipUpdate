namespace BattleShipUpdate.Models.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            BattleShipType = ShipType.Destroyer;
            Holes = 2;
            Hits = 0;
        }
    }
}
