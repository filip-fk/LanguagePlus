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

            public viewLanguage viewModel { get; set; }

        public Progress()
        {
            this.viewModel = new viewLanguage();
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

        /*
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
             */

        private void word_view(object sender, TappedRoutedEventArgs e)
        {
            //rewrite
        }

        private void open_splt(object sender, RoutedEventArgs e)
        {
            spv.IsPaneOpen = !spv.IsPaneOpen;
        }

        private void add_back(object sender, TappedRoutedEventArgs e)
        {
            //rewrite
        }
    }
}
