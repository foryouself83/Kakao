using System.Windows;
using System.Windows.Controls;
using Jamesnet.Wpf.Controls;
using Kakao.LayoutSupport.UI.Units;
using Kakao.Talk.TextMessage.UI.Units;

namespace Kakao.Talk.UI.Units
{
    public class ChatRichTextBox : CustomRichTextBox
    {
        protected override Control GetTextContainerItemForOverride()
        {
            return new TextMessageItem();
        }
    }
}
