using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VY.Soccer.Player.Info.Models.Player;
using VY.Soccer.Player.Info.Service.Player;

namespace VY.Soccer.Player.Info.Service.Concreate
{
    public class PlayerManager : IPlayerService
    {
        private readonly IMapper mapper;
        private readonly IHttpClientFactory HttpClientFactory;

        public PlayerManager(IMapper mapper,IHttpClientFactory httpClientFactory)
        {
            this.mapper = mapper;
            HttpClientFactory = httpClientFactory;
        }
        public PlayerDTO GetPlayerByID(int Id)
        {
            //Veri tabanından kaydı getir...

            Data.Models.Player.Player dbP = getPlayerDatabase(Id);
            var client = HttpClientFactory.CreateClient("bankaapi");

            PlayerDTO playerDTO =  mapper.Map<PlayerDTO>(dbP);

            return playerDTO;
        }
        private Data.Models.Player.Player getPlayerDatabase(int Id)
        {
            return new Data.Models.Player.Player
            {
                Id = Id,
                FirstName = "VELİ",
                LastName = "yetisgengil"
            };
        }
    }
}
