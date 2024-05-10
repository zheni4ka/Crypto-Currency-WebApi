using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Profile // : IdentifyUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Balance { get; set; }
        public string AvatarPicture { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; } 
    }
}
