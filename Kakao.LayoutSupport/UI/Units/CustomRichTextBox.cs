using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using Kakao.Core.Interfaces;
using Kakao.Core.Models;

namespace Kakao.LayoutSupport.UI.Units
{
    public class CustomRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CustomRichTextBox), new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public CustomRichTextBox()
        {
            Document = new FlowDocument();
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomRichTextBox richTextBox = d as CustomRichTextBox;

            if (e.OldValue is INotifyCollectionChanged oldCollection)
            {
                oldCollection.CollectionChanged -= richTextBox.OnCollectionChanged;
            }

            if (e.NewValue is INotifyCollectionChanged newCollection)
            {
                newCollection.CollectionChanged += richTextBox.OnCollectionChanged;
            }

            richTextBox.UpdateFlowDocument();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateFlowDocument();
        }

        private void UpdateFlowDocument()
        {
            FlowDocument document = new();

            // 로직
            if (ItemsSource is null) return;

            foreach (var item in ItemsSource)
            {
                var control = GetTextContainerItemForOverride();
                control.DataContext = item;

                //BlockUIContainer container = new BlockUIContainer();
                //container.Child = control;

                InlineUIContainer inline = new();
                inline.Child = control;

                Paragraph paragraph = new Paragraph();
                paragraph.Margin = new(0);

                if (item is IMessage message)
                {
                    paragraph.TextAlignment =
                        message.Type == "Send" ? TextAlignment.Right : TextAlignment.Left;
                }
                paragraph.Inlines.Add(inline);

                document.Blocks.Add(paragraph);
            }

            Document = document;

            ScrollToEnd();
        }

        protected virtual Control GetTextContainerItemForOverride()
        {
            Control control = new();
            return control;
        }
    }
}
