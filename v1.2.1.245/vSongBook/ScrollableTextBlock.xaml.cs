using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace vSongBook
{
    public class ScrollableTextBlock : Control
    {
        private StackPanel stackPanel;

        public ScrollableTextBlock()
        {
            // Get the style from generic.xaml
            this.DefaultStyleKey = typeof(ScrollableTextBlock);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ScrollableTextBlock),
                new PropertyMetadata("ScrollableTextBlock", OnTextPropertyChanged));

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScrollableTextBlock source = (ScrollableTextBlock)d;
            string value = (string)e.NewValue;
            source.ParseText(value);
        }

        private void ParseText(string value)
        {
            if (this.stackPanel == null)
            {
                return;
            }
            // Clear previous TextBlocks
            this.stackPanel.Children.Clear();
            // Calculate max char count
            int maxTexCount = this.GetMaxTextSize();

            if (value.Length < maxTexCount)
            {
                TextBlock textBlock = this.GetTextBlock();
                textBlock.Text = value;
                this.stackPanel.Children.Add(textBlock);
            }
            else
            {
                int n = value.Length / maxTexCount;
                int start = 0;
                // Add textblocks
                for (int i = 0; i < n; i++)
                {
                    TextBlock textBlock = this.GetTextBlock();
                    textBlock.Text = value.Substring(start, maxTexCount);
                    this.stackPanel.Children.Add(textBlock);
                    start = maxTexCount;
                }

                // Pickup the leftover text
                if (value.Length % maxTexCount > 0)
                {
                    TextBlock textBlock = this.GetTextBlock();
                    textBlock.Text = value.Substring(maxTexCount * n, value.Length - maxTexCount * n);
                    this.stackPanel.Children.Add(textBlock);
                }
            }
        }

    }
}
