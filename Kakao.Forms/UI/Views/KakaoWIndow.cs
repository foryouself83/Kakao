using System.Windows;
using Jamesnet.Wpf.Controls;

namespace Kakao.Forms.UI.Views
{
    public class KakaoWIndow : JamesWindow
    {
        static KakaoWIndow()
        {
            // Generic.xaml 을 연결시켜준다.
            // AssemblyInfo.cs 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KakaoWIndow), new FrameworkPropertyMetadata(typeof(KakaoWIndow)));
        }

        public KakaoWIndow()
        {
            //WindowStyle = WindowStyle.None;
            //AllowsTransparency = true;
        }
    }
}
