namespace BattleShipUpdate.Models.Board
{
    public class Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Coordinates(int x, int y)
        {
            Row = x;
            Column = y;
        }
    }
}
