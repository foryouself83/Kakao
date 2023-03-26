using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kakao.Friends.Local.Selector
{
    internal class FriendItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            if (container is not FrameworkElement frameworkElement) return null;
            if (item is not Kakao.Friends.Local.Models.Friend friend) return null;

            switch (friend.Types)
            {
                case Models.FriendsItemType.BirthDay:
                    return frameworkElement.FindResource("birthdayContent") as DataTemplate;
                case Models.FriendsItemType.Favorite:
                    return frameworkElement.FindResource("favoriteContent") as DataTemplate;
            }
            return null;
        }
    }
}
