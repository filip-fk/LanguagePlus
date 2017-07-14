using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Popups;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace LanguagePlus
{
    public sealed partial class MyUserControl1 : UserControl
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        string new_old_local { get; set; }

        public MyUserControl1(string l_, string lang, string del, string selected, string new_old)
        {
            this.InitializeComponent();

            #region setup pickers

            new_old_local = new_old;

            if (del == "n") //hide
            {
                del_btn.Visibility = Visibility.Collapsed;
            }
                        
            #region add selected items
            if (selected == "bg")
            {
                lan_opt.SelectedItem = bg;
            }
            if (selected == "nl")
            {
                lan_opt.SelectedItem = nl;
            }
            if (selected == "en")
            {
                lan_opt.SelectedItem = en;
            }
            if (selected == "fr")
            {
                lan_opt.SelectedItem = fr;
            }
            if (selected == "de")
            {
                lan_opt.SelectedItem = de;
            }
            if (selected == "ru")
            {
                lan_opt.SelectedItem = ru;
            }
            if (selected == "es")
            {
                lan_opt.SelectedItem = es;
            }
            #endregion
            

            else if (del == "d") //disable
            {
                del_btn.IsEnabled = false;
            }

            else if (del == "y") //enable
            {
                del_btn.Visibility = Visibility.Visible;
                del_btn.IsEnabled = true;
            }

            l.Text = "(L" + l_ + ")";

            #region set languages
            if ((l_ == "0") || ((l_ == "1")))
            {
                if (lang.Contains("bg"))
                {
                    bg.IsEnabled = true;
                }
                if (lang.Contains("nl"))
                {
                    nl.IsEnabled = true;
                }
                if (lang.Contains("en"))
                {
                    en.IsEnabled = true;
                }
                if (lang.Contains("fr"))
                {
                    fr.IsEnabled = true;
                }
                if (lang.Contains("de"))
                {
                    de.IsEnabled = true;
                }
                if (lang.Contains("ru"))
                {
                    ru.IsEnabled = true;
                }
                if (lang.Contains("es"))
                {
                    es.IsEnabled = true;
                }
            }

            else if ((l_ != "0") && (l_ != "1"))
            {
                if ((lang.Contains("bg")) && (!localSettings.Values["lang_s"].ToString().Contains("bg")))
                {
                    bg.IsEnabled = true;
                }
                if ((lang.Contains("nl")) && (!localSettings.Values["lang_s"].ToString().Contains("nl")))
                {
                    nl.IsEnabled = true;
                }
                if ((lang.Contains("en")) && (!localSettings.Values["lang_s"].ToString().Contains("en")))
                {
                    en.IsEnabled = true;
                }
                if ((lang.Contains("fr")) && (!localSettings.Values["lang_s"].ToString().Contains("fr")))
                {
                    fr.IsEnabled = true;
                }
                if ((lang.Contains("de")) && (!localSettings.Values["lang_s"].ToString().Contains("de")))
                {
                    de.IsEnabled = true;
                }
                if ((lang.Contains("ru")) && (!localSettings.Values["lang_s"].ToString().Contains("ru")))
                {
                    ru.IsEnabled = true;
                }
                if ((lang.Contains("es")) && (!localSettings.Values["lang_s"].ToString().Contains("es")))
                {
                    es.IsEnabled = true;
                }
            }
            #endregion
            #endregion
        }

        private void language_selected(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem language_pick = (sender as ComboBox).SelectedItem as ComboBoxItem;

            string selection_tag = string.Empty;

            selection_tag = (lan_opt.SelectedItem as ComboBoxItem).Tag.ToString();

            if (l.Text.Contains("0"))
            {
                localSettings.Values["lang_app"] = selection_tag + ",";
            }

            else if (l.Text.Contains("1"))
            {
                localSettings.Values["lang_l"] = selection_tag + ",";
            }

            else if (((!l.Text.Contains("0")) || ((!l.Text.Contains("1")))) /* add if needed (((...) || (...)) && (...))*/ )
            {
                /*
                 string value_l_s = localSettings.Values["lang_s"].ToString();
                string[] split1 = value_l_s.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (value_l_s != "")
                {
                    foreach (string check in split1)
                    {
                        if (check == selection_tag)
                        {
                            //language exists
                            //show_message("Language exists", "These languages already exist!");
                        }

                        else localSettings.Values["lang_s"] += selection_tag + ",";
                    }
                }

                else 
                 */

                if (new_old_local == "n")
                {
                    localSettings.Values["lang_s"] += selection_tag + ",";
                }

                else if (new_old_local == "o")
                {

                }
            }
        }

        private void del_l(object sender, RoutedEventArgs e)
        {
            // check if last (dell)
            if ((this.Parent as Panel).Children.Count() == 1)
            {
                (this.Parent as Panel).Children.Add(new MyUserControl1(((this.Parent as Panel).Children.Count() + 1).ToString(), "bg,nl,fr,de,ru,es", "y", "e", "n"));
                (this.Parent as Panel).Children.Remove(this);
            }

            //dell from list
            else (this.Parent as Panel).Children.Remove(this);

            // dell from str
            string value_l_s = localSettings.Values["lang_s"].ToString();
            string[] split1 = value_l_s.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string new_str = string.Empty;

            foreach (var new_word in split1)
            {
                try
                {
                    if (new_word == (lan_opt.SelectedItem as ComboBoxItem).Tag.ToString())
                    {
                        //ignore
                    }

                    // re-add to str
                    else new_str += new_word + ",";
                }
                catch { }
            }

            // re-write str
            localSettings.Values["lang_s"] = new_str;
        }

        private void show_instr(object sender, TappedRoutedEventArgs e)
        {
            if (lan_opt.IsEnabled == false)
            {
                show_message("Option deactivated", "To change the language, please delete this one first. Then, please add a new one!");
            }
        }
        private async void show_message(string title, string message)
        {
            MessageDialog msgDialog = new MessageDialog(message, title);

            //OK Button
            UICommand okBtn = new UICommand("Ok");
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
    }
}

