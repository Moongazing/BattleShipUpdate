namespace BattleShipUpdate.Models.Board
{
    public class Cell
    {
        public ShipType ShipType { get; set; }
        public ShotType ShotType { get; set; }
        public Coordinates Coordinates { get; set; }

        public Cell(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
            ShipType = ShipType.Empty;
        }
        public bool IsOccupied => ShipType != ShipType.Empty;

        public bool IsRandomAvailable => Coordinates.Row % 2 == Coordinates.Column % 2;

    }
}
