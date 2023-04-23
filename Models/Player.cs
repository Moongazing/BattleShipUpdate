using BattleShipUpdate.Extensions;
using BattleShipUpdate.Models.Board;
using BattleShipUpdate.Models.Ships;
using System.Threading;

namespace BattleShipUpdate.Models
{
    public class Player
    {

        public string Name { get; set; }
        public TargetBoard TargetBoard { get; set; }
        public GameBoard GameBoard { get; set; }
        public List<Ship> Fleet { get; set; }

        public Player(string name)
        {
            Name = name;
            GameBoard = new GameBoard();
            TargetBoard = new TargetBoard();
            Fleet = new List<Ship>(){
          new Battleship(),
          new Carrier(),
          new Cruiser(),
          new Destroyer(),
          new Submarine()
        };
        }

        public void CreateBoard()
        {
            GameBoard.DrawBoard();
            TargetBoard.DrawBoard();
        }

        public void PlaceShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Fleet)
            {
               
                bool isOpen = true;
                while (isOpen)
                {
                   
                    var startcolumn = rand.Next(1, 11);
                    var startrow = rand.Next(1, 11);
                    int endrow = startrow, endcolumn = startcolumn;
                    var orientation = rand.Next(1, 101) % 2; 

                    List<int> cellNumbers = new List<int>();
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Holes; i++)
                        {
                            endrow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < ship.Holes; i++)
                        {
                            endcolumn++;
                        }
                    }

                    
                    if (endrow > 10 || endcolumn > 10)
                    {
                        isOpen = true;
                        continue; 
                    }

                    
                    var affectedCells = GameBoard.Cells.Range(startrow, startcolumn, endrow, endcolumn);
                    if (affectedCells.Any(x => x.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }
                    
                    ship.ShipCoordinates = new List<Coordinates>();
                    if (orientation == 0)
                    {
                        for (int i = startrow; i <= endrow; i++)
                        {
                            Console.WriteLine(Name + " says: \"" + ship.Name + " with " + ship.Holes + " Holes is placed at Row-" + i.ToString() + " and Column-" + startcolumn.ToString() + ".");
                            ship.ShipCoordinates.Add(new Coordinates(i, startcolumn));
                        }
                    }
                    else
                    {
                        for (int i = startcolumn; i <= endcolumn; i++)
                        {
                            Console.WriteLine(Name + " says: \"" + ship.Name + " with " + ship.Holes + " Holes is placed at Row-" + i.ToString() + " and Column-" + startcolumn.ToString() + ".");
                            ship.ShipCoordinates.Add(new Coordinates(i, startcolumn));
                        }
                    }
                    foreach (var cell in affectedCells)
                    {
                        cell.ShipType = ship.BattleShipType;
                    }
                    isOpen = false;
                }
            }
        }

        
        public ShotType ProcessShot(Coordinates coords)
        {
            var cell = GameBoard.Cells.At(coords.Row, coords.Column);
            if (!cell.IsOccupied)
            {
                Console.WriteLine($"{Name} says: \"Miss!\"");
                return ShotType.Miss;
            }

            var ship = Fleet.FirstOrDefault(x => x.BattleShipType == cell.ShipType);
            if (ship != null)
            {
                ship.Hits++;
                Console.WriteLine($"{Name} says: \"Hit!\"");
                return ShotType.Hit;
            }

            // Handle the case where the cell has a ship, but the fleet doesn't have a matching ship type
            Console.WriteLine($"{Name} says: \"Hit, but the fleet doesn't have a matching ship type!\"");
            return ShotType.Hit;
        }

    }
}

