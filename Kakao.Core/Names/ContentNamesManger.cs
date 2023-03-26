using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kakao.Core.Enums;

namespace Kakao.Core.Names
{
    public class ContentNamesManger
    {
        public static string Login => nameof(Contents.Login);
        public static string Main => nameof(Contents.Main);
        public static string Friends => nameof(Contents.Friends);
        public static string Chats => nameof(Contents.Chats);
        public static string More => nameof(Contents.More);
    }
}
