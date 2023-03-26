using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jamesnet.Wpf.Controls;
using Kakao.Chats.UI.Views;
using Kakao.Core.Names;
using Kakao.Friends.UI.Views;
using Kakao.Login.UI.Views;
using Kakao.Main.UI.Views;
using Kakao.More.UI.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Kakao.Settings
{
    internal class ViewModuels : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        // Prism에서 UI 객체들을 등록을 시켜놓고 불러옴. (IOC)
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IViewable, LoginContent>(ContentNamesManger.Login);
            containerRegistry.RegisterSingleton<IViewable, MainContent>(ContentNamesManger.Main);
            containerRegistry.RegisterSingleton<IViewable, FriendsContent>(ContentNamesManger.Friends);
            containerRegistry.RegisterSingleton<IViewable, ChatsContent>(ContentNamesManger.Chats);
            containerRegistry.RegisterSingleton<IViewable, MoreContent>(ContentNamesManger.More);
        }
    }
}
