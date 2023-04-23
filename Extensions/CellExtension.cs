using BattleShipUpdate.Models.Board;

namespace BattleShipUpdate.Extensions
{

    public static class CellExtension
    {
        public static List<Cell> Range(this List<Cell> cells, int startRow, int startColumn, int endRow, int endColumn)
     => cells.Where(x => x.Coordinates.Row >= startRow
                      && x.Coordinates.Column >= startColumn
                      && x.Coordinates.Row <= endRow
                      && x.Coordinates.Column <= endColumn).ToList();

        public static Cell At(this List<Cell> cells, int row, int column)
            => cells.FirstOrDefault(x => x.Coordinates.Row == row && x.Coordinates.Column == column);

        public static Board DrawBoard(this Board board)
        {
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    board.Cells.Add(new Cell(row, column));
                }
            }
            return board;
        }
    }
}

