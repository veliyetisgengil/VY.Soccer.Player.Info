using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VY.Soccer.Player.Info.Models.Player;
using VY.Soccer.Player.Info.Service.Player;

namespace VY.Soccer.Player.Info.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public IPlayerService PlayerService { get; }

        public PlayerController(IConfiguration configuration,IPlayerService playerService)
        {
            Configuration = configuration;
            PlayerService = playerService;
        }


        [HttpGet]
        public string Get()
        {
            return Configuration["ReadMe"].ToString();
        }
        [ResponseCache(Duration = 10)]
        [HttpGet("Id")]
        public PlayerDTO GetPlayerById(int Id)
        {
            return PlayerService.GetPlayerByID(Id);
        }
        [HttpPost]
        public PlayerDTO CreatePlayer(PlayerDTO player)
        {
            return player;
        }
    }
}
