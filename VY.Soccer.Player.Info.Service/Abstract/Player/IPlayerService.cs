using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Soccer.Player.Info.Models.Player;

namespace VY.Soccer.Player.Info.Service.Player
{
    public interface IPlayerService
    {
        public PlayerDTO GetPlayerByID(int ID);
    }
}
