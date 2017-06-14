using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LanguagePlus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Progress : Page
    {

        //public string pbr_value10 { get; set; }

        //public string reading10 { get { return $"{pbr_value10}"; } }

        public Progress()
        {
            this.InitializeComponent();
            s_pbr.Value = 90;
            write_file();
            read_file();

            try
            {
                if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
                {
                    Windows.UI.Xaml.Media.AcrylicBrush myBrush = new Windows.UI.Xaml.Media.AcrylicBrush();
                    myBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;
                    myBrush.TintColor = Color.FromArgb(255, 225, 225, 225);
                    myBrush.FallbackColor = Color.FromArgb(255, 225, 225, 225);
                    myBrush.TintOpacity = 0.6;

                    prog_master.Background = myBrush;
                }
                else
                {
                    SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 225, 225, 225));

                    prog_master.Background = myBrush;
                }
            }
            catch { }
        }

        public async void write_file()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync("value.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, s_pbr.Value.ToString());
        }

        public async void read_file()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync("value.txt");
            string text = await FileIO.ReadTextAsync(sampleFile);
            p_words.Text = text + "%";
            d_perc.Text = text + "%";
            //d_pbr.Value = Convert.ToDouble(text);
            //s_pbr.Value = Convert.ToDouble(text);
        }

        private void NavigateToDestinationPage()
        {
            /*
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("grid", s_grid);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("text", s_text);
            Frame.Navigate(typeof(Progress));
            */
        }

        private void t_nav(object sender, TappedRoutedEventArgs e)
        {
            NavigateToDestinationPage();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation imageAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("grid");
            if (imageAnimation != null)
            {
                imageAnimation.TryStart(d_grid);
            }

            ConnectedAnimation textAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("text");
            if (textAnimation != null)
            {
                textAnimation.TryStart(d_text);
            }

            ConnectedAnimation percAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("perc");
            if (percAnimation != null)
            {
                percAnimation.TryStart(d_perc);
            }

            ConnectedAnimation pbrAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("pbr");
            if (pbrAnimation != null)
            {
                pbrAnimation.TryStart(d_pbr);
            }
        }

        private void svp_sc(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);

            if (home.IsSelected == true)
            {
                Frame.Navigate(typeof(MainPage));
            }

            if (motion_l.IsSelected == true)
            {
                //nav to add.. and open
            }
        }
    }
}
