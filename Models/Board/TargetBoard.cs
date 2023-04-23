namespace BattleShipUpdate.Models.Board
{
    public class TargetBoard:Board
    {
        public TargetBoard()
        {
            BoardType = BoardType.TargetBoard;
            Cells = new List<Cell>();
        }


     
        public List<Coordinates> GetOpenRandomCells()
        {
            return Cells.Where(x => x.ShipType == ShipType.Empty && x.IsRandomAvailable).Select(x => x.Coordinates).ToList();
        }
    }
}

