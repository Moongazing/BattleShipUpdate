namespace BattleShipUpdate.Models.Ships
{
    public class Battleship:Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            BattleShipType = ShipType.Battleship;
            Holes = 4;
            Hits = 0;
        }
      
    }
}
