using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class User : IdentityUser
    {
        public long Balance { get; set; }
        public string AvatarPicture { get; set; }
        public DateTime Birthdate { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
    }
}
