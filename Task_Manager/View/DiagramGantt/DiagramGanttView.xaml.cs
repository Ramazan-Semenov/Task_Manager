using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Task_Manager.Model;

namespace Task_Manager.View.DiagramGantt
{
    /// <summary>
    /// Логика взаимодействия для DiagramGanttView.xaml
    /// </summary>
    public partial class DiagramGanttView : UserControl
    {


        public IList<task_book> Task_Book
        {
            get
            {
                return (IList<task_book>)GetValue(Task_BookProperty);
            }
            set
            {
                SetValue(Task_BookProperty, value);
            }
        }

        public static readonly DependencyProperty Task_BookProperty =
            DependencyProperty.Register(
                "Task_Book",
                typeof(IList<task_book>),
                typeof(DiagramGanttView),
                new PropertyMetadata(default(IList<task_book>), OnTask_BookPropertyChanged));

        private static void OnTask_BookPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DiagramGanttView source = d as DiagramGanttView;

            source.OnCustomerChanged();
        }
        protected virtual void OnCustomerChanged()
        {
            Grid1time.Children.Clear();
            //  button.Click -= Button_Click;
            foreach (var item in Task_Book)
            {

                if ((item.start_date.Hour - 8) >= 0 & (item.end_date.Day - item.start_date.Day) >= 0 && (item.end_date.Hour - item.start_date.Hour) >= 0)
                {
                    Button button = new Button() { Tag = item, Content = item.name_of_the_task, Background = Brushes.LightGreen };
                    button.Click += Button_Click;
                    Grid.SetColumn(button, item.start_date.Day - 1);
                    Grid.SetColumnSpan(button, (item.end_date.Day - item.start_date.Day) + 1);

                    Grid.SetRow(button, item.start_date.Hour - 8);
                    Grid.SetRowSpan(button, (item.end_date.Hour - item.start_date.Hour) + 1);
                    Grid1time.Children.Add(button);

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.Viewing_a_task.Viewing_a_task_View viewing_A_Task_ = new Viewing_a_task.Viewing_a_task_View(((sender as Button).Tag as Model.task_book));
            viewing_A_Task_.Show();
        }

        public static readonly DependencyProperty SliderVerticalProperty = DependencyProperty.Register(
       nameof(SliderVertical), typeof(Visibility), typeof(DiagramGanttView), new FrameworkPropertyMetadata(Visibility.Collapsed,
          FrameworkPropertyMetadataOptions.None));

        public Visibility SliderVertical
        {
            get { return (Visibility)GetValue(SliderVerticalProperty); }
            set { SetValue(SliderVerticalProperty, value); }
        }
        public static readonly DependencyProperty HorizontalVerticalProperty = DependencyProperty.Register(
       nameof(HorizontalVertical), typeof(Visibility), typeof(DiagramGanttView), new FrameworkPropertyMetadata(Visibility.Collapsed,
          FrameworkPropertyMetadataOptions.None));

        public Visibility HorizontalVertical
        {
            get { return (Visibility)GetValue(HorizontalVerticalProperty); }
            set { SetValue(HorizontalVerticalProperty, value); }
        }
        public DiagramGanttView()
        {
            InitializeComponent();
            Loaded += DiagramGanttView_Loaded;



        }

        private void DiagramGanttView_Loaded(object sender, RoutedEventArgs e)
        {
            NowDate.Text = string.Format("{0}\n{1}", DateTime.Now.ToString("d/M/yy"), CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek));
            for (int i = 0; i < 11; i++)
            {
                TimeLine.Children.Add(new Button { Width = 30, Height = 30, Content = string.Format("{0}:00", i + 8) });
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(30);
                Grid1time.RowDefinitions.Add(row);

            }


            for (int i = 1; i < 32; i++)
            {
                Button button = new Button() { Width = 30, Height = 40 };
                button.Content = (i).ToString() + "." + DateTime.Now.Month + "\n " + CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetAbbreviatedDayName(DateTime.Parse(string.Format("{0}.{1}.{2}", i, DateTime.Now.Month, DateTime.Now.Year)).DayOfWeek); /*+ DateTime.Parse(string.Format("{0}.{1}.{2}", i, DateTime.Now.Month, DateTime.Now.Year)).DayOfWeek.ToString().Replace("Friday","Чт")*/  /*string.Format("{0:00}:{1:00}", span.Hours, span.Minutes);*/

                DateLine.Children.Add(button/*new Button { Width = 30, Height = 30, Content = string.Format("{0}", i) }*/);
                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength(30);
                Grid1time.ColumnDefinitions.Add(column);

            }
            //foreach (var item in Task_Book)
            //{

            //    if ((item.start_date.Hour - 8) >= 0 & (item.end_date.Day - item.start_date.Day) >= 0 && (item.end_date.Hour - item.start_date.Hour) >= 0)
            //    {
            //        Button button = new Button() { Content = item.name_of_the_task, Background = Brushes.LightGreen };
            //        Grid.SetColumn(button, item.start_date.Day - 1);
            //        Grid.SetColumnSpan(button, (item.end_date.Day - item.start_date.Day) + 1);

            //        Grid.SetRow(button, item.start_date.Hour - 8);
            //        Grid.SetRowSpan(button, (item.end_date.Hour - item.start_date.Hour) + 1 /*item.end.Hour-12*/);
            //        Grid1time.Children.Add(button);

            //    }
            //}
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            DateLineScroll.ScrollToHorizontalOffset(Grid1timeScroll.HorizontalOffset);
            TimeLineScroll.ScrollToVerticalOffset(Grid1timeScroll.VerticalOffset);
            //  MessageBox.Show((sender as ScrollViewer).HorizontalOffset.ToString());

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DateLineScroll.ScrollToHorizontalOffset(cv.Value);
            Grid1timeScroll.ScrollToHorizontalOffset(cv.Value);
        }

        private void c_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeLineScroll.ScrollToVerticalOffset(c.Value);
            Grid1timeScroll.ScrollToVerticalOffset(c.Value);

        }
    }

}
