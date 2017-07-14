using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
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
    public sealed partial class settings : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public settings()
        {
            //localSettings.Values["lang_app"] = "";
            //localSettings.Values["lang_l"] = "";
            //localSettings.Values["lang_s"] = "";

            this.InitializeComponent();

            try
            {
                if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
                {
                    var color = new UISettings().GetColorValue(UIColorType.AccentLight3);
                    Windows.UI.Xaml.Media.AcrylicBrush myBrush = new Windows.UI.Xaml.Media.AcrylicBrush();
                    myBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
                    myBrush.TintColor = color;
                    myBrush.FallbackColor = color;
                    myBrush.TintOpacity = 0.6;

                    spv.PaneBackground = myBrush;
                    d_grid.Background = myBrush;
                }
                else
                {
                    SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 225, 225, 225));

                    //prog_master.Background = myBrush;
                }
            }
            catch { }

            load_picked();
        }
        
        private void load_picked()
        {
            #region app language (lang_app)
            string value_l_app = localSettings.Values["lang_app"].ToString();

            if (value_l_app != "") //load pre
            {
                string[] split1 = value_l_app.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                //string new_str = string.Empty;

                foreach (var new_word in split1)
                {
                    lan_pane_0.Children.Add(new MyUserControl1("0", "en", "n", new_word, "o")); //en = (new_word)
                }
            }

            else //load new
            {
                lan_pane_0.Children.Add(new MyUserControl1("0", "en", "n", "e", "n"));
            }
            #endregion 

            #region my language (lang_l)
            string value_l_l = localSettings.Values["lang_l"].ToString();

            if (value_l_l != "") //load pre
            {
                string[] split1 = value_l_l.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                //string new_str = string.Empty;

                foreach (var new_word in split1)
                {
                    lan_pane_1.Children.Add(new MyUserControl1("1", "bg,nl,en,fr,de,ru,es", "n", new_word, "o")); //fr = (new_word)
                }
            }

            else //load new
            {
                lan_pane_1.Children.Add(new MyUserControl1("1", "bg,nl,en,fr,de,ru,es", "n", "e", "n"));
            }
            #endregion

            #region new language (lang_s)
            string value_l_s = localSettings.Values["lang_s"].ToString();

            if (value_l_s != "") //load pre
            {
                string[] split1 = value_l_s.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                //string new_str = string.Empty;

                foreach (string new_word in split1)
                {
                    lan_pane_2.Children.Add(new MyUserControl1("2", "bg,nl,fr,de,ru,es", "y", new_word, "o"));
                }
            }

            else if (value_l_s == "")//load new
            {
                lan_pane_2.Children.Add(new MyUserControl1("2", "bg,nl,fr,de,ru,es", "y", "e", "n"));
            }
            #endregion
        }
        
        private void open_splt(object sender, RoutedEventArgs e)
        {
            spv.IsPaneOpen = !spv.IsPaneOpen;
        }

        private void slc_chn(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem nav = (sender as ListBox).SelectedItem as ListBoxItem;

            if (home.IsSelected)
            {
                scr_home1.Visibility = Visibility.Visible;
                scr_langu.Visibility = Visibility.Collapsed;
                scr_coloe.Visibility = Visibility.Collapsed;
            }
            if (languages.IsSelected)
            {
                scr_home1.Visibility = Visibility.Collapsed;
                scr_langu.Visibility = Visibility.Visible;
                scr_coloe.Visibility = Visibility.Collapsed;
            }
            if (Color10.IsSelected)
            {
                scr_home1.Visibility = Visibility.Collapsed;
                scr_langu.Visibility = Visibility.Collapsed;
                scr_coloe.Visibility = Visibility.Visible;
            }
        }

        private void add_l(object sender, RoutedEventArgs e)
        {
            // check if there
            string value_l_s = localSettings.Values["lang_s"].ToString();
            string value_l_l = localSettings.Values["lang_l"].ToString();

            string new_l_s_toAdd = string.Empty;

            #region check existance
            if ((!value_l_s.Contains("bg")) && (!value_l_l.Contains("bg")))
            {
                new_l_s_toAdd += "bg" + ",";
            }
            if ((!value_l_s.Contains("nl")) && (!value_l_l.Contains("nl")))
            {
                new_l_s_toAdd += "nl" + ",";
            }
            if ((!value_l_s.Contains("en")) && (!value_l_l.Contains("en")))
            {
                //no en
            }
            if ((!value_l_s.Contains("fr")) && (!value_l_l.Contains("fr")))
            {
                new_l_s_toAdd += "fr" + ",";
            }
            if ((!value_l_s.Contains("de")) && (!value_l_l.Contains("de")))
            {
                new_l_s_toAdd += "de" + ",";
            }
            if ((!value_l_s.Contains("ru")) && (!value_l_l.Contains("ru")))
            {
                new_l_s_toAdd += "ru" + ",";
            }
            if ((!value_l_s.Contains("es")) && (!value_l_l.Contains("es")))
            { 
                new_l_s_toAdd += "es" + ",";
            }
            #endregion

            lan_pane_2.Children.Add(new MyUserControl1((lan_pane_2.Children.Count() + 2).ToString(), new_l_s_toAdd, "y", "e", "n"));

            delay.Visibility = Visibility.Visible;
        }

        private void dell_all(object sender, RoutedEventArgs e)
        {
            localSettings.Values["lang_s"] = "";
        }

        private void show_all(object sender, RoutedEventArgs e)
        {
            string strings = $"{"App language: "+localSettings.Values["lang_app"] + "\n" + "My language: "+ localSettings.Values["lang_l"] + "\n" +"New language(s): "+ localSettings.Values["lang_s"]}";
            show_message("Check", strings);
        }

        private async void show_message(string title, string message)
        {
            MessageDialog msgDialog = new MessageDialog(message, title);

            //OK Button
            UICommand okBtn = new UICommand("OK");
            okBtn.Invoked = OkBtnClick;
            msgDialog.Commands.Add(okBtn);

            //Cancel Button
            UICommand cancelBtn = new UICommand("Cancel");
            cancelBtn.Invoked = CancelBtnClick;
            msgDialog.Commands.Add(cancelBtn);

            //Show message
            await msgDialog.ShowAsync();
        }

        private void CancelBtnClick(IUICommand command)
        {
            
        }

        private void OkBtnClick(IUICommand command)
        {

        }

        private void accentColor_on(object sender, RoutedEventArgs e)
        {
            accentColor_switch.IsOn = true;
        }
    }
}
