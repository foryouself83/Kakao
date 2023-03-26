using System.Windows;
using Jamesnet.Wpf.Controls;

namespace Kakao.More.UI.Views
{
    public class MoreContent : JamesContent
    {
        static MoreContent()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MoreContent), new FrameworkPropertyMetadata(typeof(MoreContent)));
        }

        public MoreContent()
        {
        }
    }
}
