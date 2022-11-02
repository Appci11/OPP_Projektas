using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.Chat
{
    public class Message
    {
        public string Username { get; set; } = string.Empty;
        public string Msg { get; set; } = string.Empty;

        public Message()
        {

        }
        public Message(string user, string msg)
        {
            Username = user;
            Msg = msg;
        }
    }
}
