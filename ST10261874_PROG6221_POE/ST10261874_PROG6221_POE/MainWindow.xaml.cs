using Microsoft.VisualBasic;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ST10261874_PROG6221_POE
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer dateTimeTimer; // Timer for updating date and time display
        private DispatcherTimer loadingTimer; // Timer for simulating loading screen delay
        private string userName; // User name entered by the user

        public MainWindow()
        {
            InitializeComponent();
            AskForUserName(); // Prompt user for their name
            StartDateTimeUpdater(); // Start timer for updating date and time display
        }

        private void AskForUserName()
        {
            // Use InputBox from Microsoft.VisualBasic to prompt for user name
            userName = Interaction.InputBox("Please enter your name:", "User Name", "Guest");
            if (string.IsNullOrEmpty(userName))
            {
                userName = "Guest";
            }
            welcomeTextBlock.Text = $"Welcome to my Recipe App,\n {userName}!";
        }

        private void StartDateTimeUpdater()
        {
            // Initialize and start timer for updating date and time every second
            dateTimeTimer = new DispatcherTimer();
            dateTimeTimer.Interval = TimeSpan.FromSeconds(1);
            dateTimeTimer.Tick += DateTimeTimer_Tick;
            dateTimeTimer.Start();
            UpdateDateTime(); // Initial update of date and time
        }

        private void DateTimeTimer_Tick(object sender, EventArgs e)
        {
            // Event handler for timer tick to update date and time display
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            // Update date and time display
            dateTimeTextBlock.Text = DateTime.Now.ToString("F");
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            // Event handler for Exit button click
            MessageBox.Show("App will close");
            this.Close(); // Close the application window
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            // Event handler for Developer Info button click
            string message = "Developer: Dianca Jade Naidu\n" +
                             "Student Number: ST10261874\n" +
                             "Programming 2A POE\n\n" +
                             "Instructions will be on every window on top left if the user is confused.";

            MessageBox.Show(message, "Developer Info and Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            // Event handler for Recipe button click to open Recipe window
            ShowLoadingScreen(); // Display loading screen

            // Simulate loading process with a delay using Task.Delay
            Task.Delay(2000).ContinueWith(_ =>
            {
                // Close loading screen after delay
                Dispatcher.Invoke(() => CloseLoadingScreen());

                // Open Recipe window and close the MainWindow
                Dispatcher.Invoke(() =>
                {
                    Recipe recipeWindow = new Recipe();
                    recipeWindow.Show();
                    this.Close();
                });

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ShowLoadingScreen()
        {
            // Display loading screen and hide navigation panel
            LoadingScreen.Visibility = Visibility.Visible;
            nav_pnl.Visibility = Visibility.Collapsed;
        }

        private void CloseLoadingScreen()
        {
            // Hide loading screen and restore visibility of navigation panel
            LoadingScreen.Visibility = Visibility.Collapsed;
            nav_pnl.Visibility = Visibility.Visible;

            // Stop and clean up the loading timer if necessary
            if (loadingTimer != null)
            {
                loadingTimer.Stop();
                loadingTimer = null;
            }
        }
    }
}
