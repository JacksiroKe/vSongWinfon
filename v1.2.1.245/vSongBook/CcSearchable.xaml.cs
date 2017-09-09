﻿using System;
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
    public partial class CcSearchable : PhoneApplicationPage
    {
        private AppSettings settings = new AppSettings();
        TextBlock textBlock1;
        string prevText = "";
        bool LayoutUpdateFlag = true;

        public CcSearchable()
        {
            InitializeComponent();
            DataContext = App.VirtualSongBook;
            this.Loaded += new RoutedEventHandler(CcSearchable_Loaded);
            if (!settings.Hint1Setting) ShowHintOne();
        }

        private void CcSearchable_Loaded(object sender, RoutedEventArgs e)
        {
            /*if (!App.ViewSong.IsDataLoaded)
            {
                App.ViewSong.LoadData();
            }*/
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Focus();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            SearchBox.Focus();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SearchBox.Focus();
            //this.MainListBox.ItemsSource = App.ViewSong.SongList.Where(w => w.Title.ToUpper().Contains(SearchBox.Text.ToUpper()) || w.Content.ToUpper().Contains(SearchBox.Text.ToUpper()));
            //LayoutUpdateFlag = true;
        }

        private void ShowHintOne()
        {
            MessageBoxResult HintMeNow = MessageBox.Show("God bless you! You can now search for a song quickly if you know its number by "
            + "simply typing like this:\n\n space + number + hash key i.e \" 56#\" \n\n Press \"OKAY\" to prevent this hint "
            + "from showing in future or press \"CANCEL\" to see this hint in future again!",
            "Search Quickly By Song Number", MessageBoxButton.OKCancel);
            if (HintMeNow == MessageBoxResult.OK) settings.Hint1Setting = true;
            else if (HintMeNow == MessageBoxResult.Cancel) settings.Hint1Setting = false;
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainListBox.SelectedIndex == -1)
                return;
            vsb_songbook myresults = MainListBox.SelectedItem as vsb_songbook;
            //settings.CurrSongSetting = myresults.ID - 1;
            NavigationService.Navigate(new Uri("/DdSongView.xaml?selectedSong=" + (myresults.ID - 1).ToString(), UriKind.Relative));
            
            MainListBox.SelectedIndex = -1;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainListBox.ItemsSource = App.VirtualSongBook.SongList.Where(w => w.Content.ToUpper().Contains(SearchBox.Text.ToUpper()));
            LayoutUpdateFlag = true;

        }

        private void MainListBox_LayoutUpdated(object sender, EventArgs e)
        {
            if (LayoutUpdateFlag)
            {
                SearchVisualTree(MainListBox);
            }
            LayoutUpdateFlag = false;
        }

        private void SearchVisualTree(DependencyObject targetElement)
        {
            var count = VisualTreeHelper.GetChildrenCount(targetElement);

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(targetElement, i);
                if (child is TextBlock)
                {
                    textBlock1 = (TextBlock)child;
                    prevText = textBlock1.Text;
                    if ((textBlock1.Name == "Title" || textBlock1.Name == "Content") && textBlock1.Text.ToUpper().Contains(SearchBox.Text))
                    {
                        HighlightText();
                    }
                }
                else
                {
                    SearchVisualTree(child);
                }
            }
        }

        private void HighlightText()
        {
            if (textBlock1 != null)
            {
                string text = textBlock1.Text.ToUpper();
                textBlock1.Text = text;
                textBlock1.Inlines.Clear();

                int index = text.IndexOf(SearchBox.Text);
                int lenth = SearchBox.Text.Length;

                if (!(index < 0))
                {

                    Run run = new Run() { Text = prevText.Substring(index, lenth) };
                    run.Foreground = new SolidColorBrush(Colors.Black);
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(0, index) });
                    textBlock1.Inlines.Add(run);
                    textBlock1.Inlines.Add(new Run() { Text = prevText.Substring(index + lenth) });
                }
            }
        }

    }
}