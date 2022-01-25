using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Task_Manager.View.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorViewMenu.xaml
    /// </summary>
    public partial class CoordinatorViewMenu : Window
    {
        DispatcherTimer timer;

        double panelWidth;
        bool hidden;
        public CoordinatorViewMenu()
        {
            InitializeComponent();
            DataContext = new ViewModel.CoordinatorViewModel.CoordinatorViewModelMenu();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            // sidePanel.Width = 40;
            panelWidth = sidePanel.Width;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 2;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 2;
                if (sidePanel.Width <= 40)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Image_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
