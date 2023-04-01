using System.Windows;
using Jamesnet.Wpf.Controls;
using Kakao.Core.Talks;
using Kakao.Forms.UI.Views;
using Prism.Ioc;

namespace Kakao
{
    internal partial class App : JamesApplication
    {
        protected override Window CreateShell()
        {
            return new KakaoWIndow();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterTypes(containerRegistry);
            containerRegistry.RegisterInstance<TalkWindowManager>(new TalkWindowManager());
            containerRegistry.RegisterInstance<ChatStorage>(new ChatStorage());
        }
    }
}
