using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LanguagePlus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Words : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public Words()
        {
            this.InitializeComponent();
            retrive_words();
        }

        private void retrive_words()
        {
            //new
            object saved_words = localSettings.Values["newWords_word"];
            var forstring = saved_words.ToString();
            string value1 = forstring;

            object saved_words1 = localSettings.Values["newWords_tran"];
            var forstring1 = saved_words1.ToString();
            string value2 = forstring1;

            if (saved_words != null)
            {
                var result = value1.Split(',');

                foreach (var word in result)
                {
                    word_cont.Children.Add(new word1(word, ""));
                }
            }

            if (saved_words1 != null)
            {
                var result1 = value2.Split(',');

                foreach (var word1 in result1)
                {
                    word_cont.Children.Add(new word1("", word1));
                }
            }
        }

        private void show_hide_AddPane(object sender, RoutedEventArgs e)
        {
            if (stackPanel.Visibility == Visibility.Visible)
            {
                stackPanel.Visibility = Visibility.Collapsed;
                hide.Begin();
            }

            else
            {
                stackPanel.Visibility = Visibility.Visible;
                show.Begin();
            }
        }

        public string new_words { get; set; }
        public string tra_words { get; set; }

        private void add_word(object sender, RoutedEventArgs e)
        {
            #region close after add
            if (stackPanel.Visibility == Visibility.Visible)
            {
                stackPanel.Visibility = Visibility.Collapsed;
                hide.Begin();
            }

            else
            {
                stackPanel.Visibility = Visibility.Visible;
                show.Begin();
            }
            #endregion

            #region check & add
            if (new_words.Contains(newW.Text)) //string has the ward
            {
                //shaw message
            }

            else //add
            {
                word_cont.Children.Add(new word1(newW.Text, traW.Text));
                tra_words += traW.Text + ",";
            }
            #endregion

            //save
            
            localSettings.Values["newWords_word"] = new_words;
            localSettings.Values["newWords_tran"] = tra_words;
        }
    }
}
