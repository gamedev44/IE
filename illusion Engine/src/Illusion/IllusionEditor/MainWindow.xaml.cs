using System;
using System.Windows;
using Microsoft.Win32;
using System.Diagnostics; // Needed for Process.Start

namespace IllusionEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
        }

        private void openprojectbutton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for open project button click
            OpenProjectLaunchBrowserDialog();
        }

        private void newprojectbutton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for new project button click
            // Implement your logic for creating a new project
        }

        private void OpenProjectLaunchBrowserDialog()
        {
            OpenFileDialog projectBrowser = new OpenFileDialog();
            bool? dialogResult = projectBrowser.ShowDialog();

            if (dialogResult == true)
            {
                // Get the selected file path
                string filePath = projectBrowser.FileName;

                // Call your method to open the project
                OpenProject(filePath);
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void OpenProject(string filePath)
        {
            try
            {
                // Define the path to your game engine's or editor's executable
                string engineExecutablePath = @"C:\Path\To\Your\Game\Engine\Executable.exe";

                // Create a new process start info
                var startInfo = new ProcessStartInfo
                {
                    FileName = engineExecutablePath, // The executable to start
                    Arguments = filePath, // The project file to open
                    UseShellExecute = false
                };

                // Start the process
                using (Process process = Process.Start(startInfo))
                {
                    // You might want to do something while the game editor is running or after it's closed
                    // ...
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open the file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
