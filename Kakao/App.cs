using System.Windows;
using Jamesnet.Wpf.Controls;
using Kakao.Forms.UI.Views;

namespace Kakao
{
    internal partial class App : JamesApplication
    {
        protected override Window CreateShell()
        {
            return new KakaoWIndow();
        }
    }
}
