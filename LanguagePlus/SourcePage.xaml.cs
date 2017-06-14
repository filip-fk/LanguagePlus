using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class SourcePage : Page
    {
        public SourcePage()
        {
            this.InitializeComponent();
        }

        private void NavigateToDestinationPage()
        {
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("image", SourceImage);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("text", SourceT);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("image1", SourceImage1);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("text1", SourceT1);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("image2", SourceImage2);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("text2", SourceT2);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("image3", SourceImage3);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("text3", SourceT3);
            Frame.Navigate(typeof(DestinationPage));
        }

        private void t_nav(object sender, TappedRoutedEventArgs e)
        {

            NavigateToDestinationPage();
        }
    }
}
