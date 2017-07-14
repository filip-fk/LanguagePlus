using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Windows.Input;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LanguagePlus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public RecordingViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new RecordingViewModel();
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

                    main_master.Background = myBrush;
                }
                else
                {
                    SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 225, 225, 225));

                    main_master.Background = myBrush;
                }
            }
            catch { }

            var color = new UISettings().GetColorValue(UIColorType.Accent);

            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = color;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            titleBar.ButtonForegroundColor = Colors.White;
        }
       
        public async void read_file()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync("value.txt");
            string text = await FileIO.ReadTextAsync(sampleFile);
            //s_percentage.Text = text + "%";;
            //s_pbr.Value = Convert.ToDouble(text);
        }

        private void Nav_to_p()
        {
            Frame.Navigate(typeof(Progress));
        }

        private void Nav_to_d()
        {
            Frame.Navigate(typeof(dictionary));
        }

        private void Nav_to_t()
        {
            Frame.Navigate(typeof(task));
        }

        private void Nav_to_s()
        {
            Frame.Navigate(typeof(settings));
        }

        private void Nav_to_i()
        {
            Frame.Navigate(typeof(information));
        }

        private void t_nav(object sender, TappedRoutedEventArgs e)
        {
            //NavigateToDestinationPage();
        }

        private void phone_sc(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tap_nav10(object sender, TappedRoutedEventArgs e)
        {
            VariableSizedWrapGrid grid10 = sender as VariableSizedWrapGrid;
            string path = grid10.Tag.ToString();

            if (path == "p") { Nav_to_p(); }
            if (path == "d") { Nav_to_d(); }
            if (path == "t") { Nav_to_t(); }
            if (path == "s") { Nav_to_s(); }
            if (path == "i") { Nav_to_i(); }

            /*TextBlock a_name = sender as TextBlock;
           string new10 = a_name.Text;*/
        }

        public void redirect(string path)
        {
            
        }

        private void t_nav_f(object sender, TappedRoutedEventArgs e)
        {

            VariableSizedWrapGrid grid10 = sender as VariableSizedWrapGrid;
            string path = grid10.Tag.ToString();

            if (path == "p") { Nav_to_p(); }
            if (path == "d") { Nav_to_d(); }
            if (path == "t") { Nav_to_t(); }
            if (path == "s") { Nav_to_s(); }
            if (path == "i") { Nav_to_i(); }
        }

        private void t_nav_g(object sender, TappedRoutedEventArgs e)
        {

            StackPanel grid11 = sender as StackPanel;
            string path = grid11.Tag.ToString();

            if (path == "p") { Nav_to_p(); }
            if (path == "d") { Nav_to_d(); }
            if (path == "t") { Nav_to_t(); }
            if (path == "s") { Nav_to_s(); }
            if (path == "i") { Nav_to_i(); }
        }
    }

    public class Recording
    {
        public string ArtistName { get; set; }
        public string CompositionName { get; set; }
        public string Symbol { get; set; }
        public string name17 { get; set; }

        public Recording()
        {

        }
    }

    public class RecordingViewModel
    {
        private Recording defaultRecording = new Recording();
        public Recording DefaultRecording { get { return this.defaultRecording; } }

        private ObservableCollection<Recording> recordings = new ObservableCollection<Recording>();
        public ObservableCollection<Recording> Recordings { get { return this.recordings; } }
        public RecordingViewModel()
        {
            this.recordings.Add(new Recording()
            {
                ArtistName = "Progress",
                CompositionName = "Words, Quizes,\nFluency",
                Symbol = "\xE081",
                name17 = "p"
            });
            this.recordings.Add(new Recording()
            {
                ArtistName = "Dictionary",
                CompositionName = "New words, Add words,\nEdit words",
                Symbol = "\xE82d",
                name17 = "d"
            });
            this.recordings.Add(new Recording()
            {
                ArtistName = "Tasks",
                CompositionName = "To do, HW, Goals",
                Symbol = "\xEadf",
                name17 = "t"
            });
            this.recordings.Add(new Recording()
            {
                ArtistName = "Settings",
                CompositionName = "Add/change language,\nApp settings",
                Symbol = "\xE115",
                name17 = "s"
            });
            this.recordings.Add(new Recording()
            {
                ArtistName = "Info",
                CompositionName = "About, Terms of use",
                Symbol = "\xE946",
                name17 = "i"
            });
        }
    }

    public class language
    {
        public string l1 { get; set; }
        public string l2 { get; set; }

        public language()
        {

        }
    }

    public class viewLanguage
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        
        private language defaultLanguage = new language();
        public language DefaultLanguage { get { return this.defaultLanguage; } }

        private ObservableCollection<language> languages = new ObservableCollection<language>();
        public ObservableCollection<language> Languages { get { return this.languages; } }
        public viewLanguage()
        {
            string value_l_s = localSettings.Values["lang_s"].ToString();
            string[] split1 = value_l_s.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach(string l_ in split1)
            {
                this.languages.Add(new language()
                {
                    l2 = l_
                });
            }
        }
    }
}
