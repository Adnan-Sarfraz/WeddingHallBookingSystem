using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.SignIn
{
    public class SignInResponse
    {
        public string Token { get; set; } = string.Empty; //which our system provide to us 
        public string UserName { get; set; }=string.Empty; //will get from our Gmail
        public Guid UserId{ get; set; }//from Gmail
        public string Role { get; set; } = string.Empty;    
    }
}
