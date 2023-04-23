namespace BattleShipUpdate.Models.Board
{
    public class GameBoard:Board
    {
        public GameBoard()
        {
            BoardType = BoardType.GameBoard;
            Cells = new List<Cell>();
        }
    }
}
