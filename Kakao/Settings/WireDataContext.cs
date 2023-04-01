using Jamesnet.Wpf.Global.Location;
using Kakao.Chats.Local.ViewModels;
using Kakao.Chats.UI.Views;
using Kakao.Forms.Local.ViewModels;
using Kakao.Forms.UI.Views;
using Kakao.Friends.Local.ViewModels;
using Kakao.Friends.UI.Views;
using Kakao.Login.Local.ViewModels;
using Kakao.Login.UI.Views;
using Kakao.Main.Local.ViewModels;
using Kakao.Main.UI.Views;
using Kakao.More.Local.ViewModels;
using Kakao.More.UI.Views;
using Kakao.Talk.Local.ViewModels;
using Kakao.Talk.UI.Views;
using Kakao.Tests.Local.ViewModels;
using Kakao.Tests.UI.Views;

namespace Kakao.Settings
{
    internal class WireDataContext : ViewModelLocationScenario
    {
        protected override void Match(ViewModelLocatorCollection items)
        {
            items.Register<KakaoWIndow, kakaoWindowViewModel>();
            items.Register<LoginContent, LoginContentViewModel>();
            items.Register<MainContent, MainContentViewModel>();
            items.Register<FriendsContent, FriendsContentViewModel>();
            // DataTemaplate Exampale
            //items.Register<FriendsContent, FriendsContentDataTemplateViewModel>();
            items.Register<ChatsContent, ChatsContentViewModel>();
            items.Register<MoreContent, MoreContentViewModel>();

            items.Register<TalkWindow, TalkWindowViewModel>();
            items.Register<TalkContent, TalkContentViewModel>();
            items.Register<SimulatorWindow, SimulatorWindowViewModel>();
        }
    }
}
