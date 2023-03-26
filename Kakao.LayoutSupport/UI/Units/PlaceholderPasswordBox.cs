using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kakao.LayoutSupport.UI.Units
{
    public class PlaceholderPasswordBox : TextBox
    {
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(PlaceholderPasswordBox)
            , new PropertyMetadata(""));


        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }

        static PlaceholderPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlaceholderPasswordBox), new FrameworkPropertyMetadata(typeof(PlaceholderPasswordBox)));
        }
        public PlaceholderPasswordBox()
        {
            this.GotFocus += CustomPasswordBox_GotFocus;
        }

        private void PasswordBoxPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is not PasswordBox pwd) return;
            
            SetValue(TextProperty, pwd.Password);
        }
        private void CustomPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == this)
            {
                if (GetTemplateChild("PART_PasswordBox") is not PasswordBox passwordBox) return;

                passwordBox.Focus();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("PART_PasswordBox") is not PasswordBox passwordBox) return;

            passwordBox.PasswordChanged += PasswordBoxPasswordChanged;
        }

    }
}
