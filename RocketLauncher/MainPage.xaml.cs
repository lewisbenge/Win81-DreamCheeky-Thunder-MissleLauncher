using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RocketLauncher
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MissleLauncher _launcher;

        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;
        }

        private void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            MissleLauncher.MissleLauncherFound += async (o, args) =>
            {
                _launcher = args.MissleLauncher;
                await _launcher.TurnLedOn();
            };
            MissleLauncher.SearchForMissleLauncher(Dispatcher);
        }


        private async void TapLeft(object sender, TappedRoutedEventArgs e)
        {
            await _launcher.MoveLeft();
        }

        private async void TapRight(object sender, TappedRoutedEventArgs e)
        {
            await _launcher.MoveRight();
        }

        private async void TapUp(object sender, TappedRoutedEventArgs e)
        {
            await _launcher.MoveUp();
        }

        private async void TapDown(object sender, TappedRoutedEventArgs e)
        {
            await _launcher.MoveDown();
        }

        private async void FireDown(object sender, TappedRoutedEventArgs e)
        {
            await _launcher.Fire();
        }
    }
}
