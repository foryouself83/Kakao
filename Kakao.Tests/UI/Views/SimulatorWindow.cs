using System.Windows;
using Jamesnet.Wpf.Controls;

namespace Kakao.Tests.UI.Views
{
    public class SimulatorWindow : JamesWindow
    {
        static SimulatorWindow()
        {
            // Generic.xaml 을 연결시켜준다.
            // AssemblyInfo.cs 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SimulatorWindow), new FrameworkPropertyMetadata(typeof(SimulatorWindow)));
        }

        public SimulatorWindow()
        {
            //WindowStyle = WindowStyle.None;
            //AllowsTransparency = true;
        }
    }
}
