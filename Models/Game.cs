using BattleShipUpdate.Models.Board;
using System.Numerics;

namespace BattleShipUpdate.Models
{
    public class Game
    {
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }
        public Player CurrentPlayer { get; set; }



    public Game()
        {
            FirstPlayer = new Player("Player 1");
            SecondPlayer = new Player("Player 2");
            CurrentPlayer = FirstPlayer;

        }
        public void SwitchTurn()
        {
            CurrentPlayer = (CurrentPlayer == FirstPlayer) ? SecondPlayer : FirstPlayer;
        }
        public Player GetCurrentPlayer()
        {
            return CurrentPlayer;
        }


        public string Attack(Coordinates coordinates)
        {
            var result = CurrentPlayer.ProcessShot(coordinates);
            if (result != ShotType.Miss)
            {
               
                return result.ToString();
            }

         
            SwitchTurn();
            return result.ToString();
        }
    }
}
