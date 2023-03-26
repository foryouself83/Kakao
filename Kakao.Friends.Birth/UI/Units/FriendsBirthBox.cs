using System.Windows;
using System.Windows.Controls;
using Jamesnet.Wpf.Controls;
using Kakao.LayoutSupport.UI.Units;

namespace Kakao.Friends.Birth.UI.Units
{
    public class FriendsBirthBox : FriendsBox
    {
        public FriendsBirthBox()
        {
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new BirthdayBoxItem();
        }
    }
}
