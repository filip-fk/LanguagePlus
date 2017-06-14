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
    public sealed partial class DestinationPage : Page
    {
        public DestinationPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation imageAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("image");
            if (imageAnimation != null)
            {
                imageAnimation.TryStart(DestinationImage);
            }

            ConnectedAnimation textAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("text");
            if (textAnimation != null)
            {
                textAnimation.TryStart(DestinationT);
            }
            ConnectedAnimation imageAnimation1 =
               ConnectedAnimationService.GetForCurrentView().GetAnimation("image1");
            if (imageAnimation1 != null)
            {
                imageAnimation1.TryStart(DestinationImage1);
            }

            ConnectedAnimation textAnimation1 =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("text1");
            if (textAnimation1 != null)
            {
                textAnimation1.TryStart(DestinationT1);
            }
            ConnectedAnimation imageAnimation2 =
               ConnectedAnimationService.GetForCurrentView().GetAnimation("image2");
            if (imageAnimation2 != null)
            {
                imageAnimation2.TryStart(DestinationImage2);
            }

            ConnectedAnimation textAnimation2 =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("text2");
            if (textAnimation2 != null)
            {
                textAnimation2.TryStart(DestinationT2);
            }
            ConnectedAnimation imageAnimation3 =
               ConnectedAnimationService.GetForCurrentView().GetAnimation("image3");
            if (imageAnimation3 != null)
            {
                imageAnimation3.TryStart(DestinationImage3);
            }

            ConnectedAnimation textAnimation3 =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("text3");
            if (textAnimation3 != null)
            {
                textAnimation3.TryStart(DestinationT3);
            }
        }
    }
}
