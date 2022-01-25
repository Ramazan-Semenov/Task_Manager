using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Task_Manager.View.StaffView
{
    /// <summary>
    /// Логика взаимодействия для StaffViewMenu.xaml
    /// </summary>
    public partial class StaffViewMenu : Window
    {
        DispatcherTimer timer;

        double panelWidth;
        bool hidden;
        public StaffViewMenu()
        {
            InitializeComponent();
            DataContext = new ViewModel.StaffViewModel.StaffViewModelMenu();

           
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;

            panelWidth = sidePanel.Width;
         


        }
        private void Timer_Tick(object sender, EventArgs e)
        {
         
                if (hidden)
                {
                sidePanel.Width += 4;

                  if (sidePanel.Width >= panelWidth)
                    {
                        timer.Stop();
                        hidden = false;
                    }
                }
                else if((panelWidth >= 40)&(hidden==false))
                {

                sidePanel.Width -= 4;

                if ((sidePanel.Width <= 40))
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
            hidden = false;
            timer.Start();
        }

        private void Image_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
            hidden = false;
            timer.Start();
        }

        private void Frame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //hidden = false;
            //timer.Start();
        }
    }
}
