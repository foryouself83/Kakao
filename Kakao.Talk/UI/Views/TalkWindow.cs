using System.Windows;
using Jamesnet.Wpf.Controls;

namespace Kakao.Talk.UI.Views
{
    public class TalkWindow : JamesWindow
    {
        static TalkWindow()
        {
            // Generic.xaml 을 연결시켜준다.
            // AssemblyInfo.cs 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TalkWindow), new FrameworkPropertyMetadata(typeof(TalkWindow)));
        }

        public TalkWindow()
        {
            //WindowStyle = WindowStyle.None;
            //AllowsTransparency = true;
        }
    }
}
