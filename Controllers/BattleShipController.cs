using BattleShipUpdate.Models;
using BattleShipUpdate.Models.Board;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipUpdate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleShipController : ControllerBase
    {
        private readonly Game battleShipGame;

        public BattleShipController()
        {
            battleShipGame = new Game();
        }
        [HttpPost("create-board")]
        public IActionResult CreateBoard()
        {
            battleShipGame.FirstPlayer.CreateBoard();
            battleShipGame.SecondPlayer.CreateBoard();
            return Ok("Game board created successfully!");
        }

        [HttpPost("place-ships")]
        public IActionResult PlaceShips()
        {
            battleShipGame.FirstPlayer.PlaceShips();
            return Ok("Ships placed successfully!");
        }

        [HttpPost("attack")]
        public IActionResult Attack(Coordinates coordinates)
        {
            var player = battleShipGame.GetCurrentPlayer();
            Console.WriteLine(player.Name + $" fires shot at ({coordinates.Row}, {coordinates.Column})");
            var result = battleShipGame.Attack(coordinates);
            if (result == "Hit" || result == "Sunk")
            {
                battleShipGame.SwitchTurn();
                return Ok(result);

            }
            battleShipGame.SwitchTurn();
            return BadRequest(result);
        }
    }
}
