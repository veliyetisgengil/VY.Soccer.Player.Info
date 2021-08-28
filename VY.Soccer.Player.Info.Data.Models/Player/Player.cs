using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.Soccer.Player.Info.Data.Models.Base;

namespace VY.Soccer.Player.Info.Data.Models.Player
{
    public class Player :BaseData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
