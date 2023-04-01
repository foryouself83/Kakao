using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kakao.Core.Interfaces;

namespace Kakao.Core.Models
{
    public class MessageModel : IMessage
    {
        public string Type { get; set; }
        public string Message { get; set; }

        public MessageModel DataGen(string type, string message)
        {
            Type = type;
            Message = message;

            return this;
        }
    }
}
