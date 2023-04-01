using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kakao.Core.Models;

namespace Kakao.Core.Interfaces
{
    public interface IReceiverInfo
    {
        void InitReceiver(FriendsModel data);
    }
}
