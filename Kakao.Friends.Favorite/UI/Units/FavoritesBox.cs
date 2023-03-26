using System.Windows;
using System.Windows.Controls;
using Jamesnet.Wpf.Controls;
using Kakao.LayoutSupport.UI.Units;

namespace Kakao.Friends.Favorites.UI.Units
{
    public class FavoriteBox : FriendsBox
    {
        public FavoriteBox()
        {
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new FavoriteBoxItem();
        }
    }
}
