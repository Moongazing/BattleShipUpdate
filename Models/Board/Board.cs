namespace BattleShipUpdate.Models.Board
{
    public abstract class Board
    {
        public BoardType BoardType { get; set; }
        public List<Cell> Cells { get; set; }
    }
}
