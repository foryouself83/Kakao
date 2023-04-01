using System.Windows;
using Jamesnet.Wpf.Controls;

namespace Kakao.Talk.UI.Views
{
    public class TalkContent : JamesContent
    {
        static TalkContent()
        {
            // Generic.xaml 을 연결시켜준다.
            // AssemblyInfo.cs 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TalkContent), new FrameworkPropertyMetadata(typeof(TalkContent)));
        }

        public TalkContent()
        {
            //WindowStyle = WindowStyle.None;
            //AllowsTransparency = true;
        }
    }
}
