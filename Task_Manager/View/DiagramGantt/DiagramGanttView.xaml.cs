using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_Manager.View.DiagramGantt
{
    /// <summary>
    /// Логика взаимодействия для DiagramGanttView.xaml
    /// </summary>
    public partial class DiagramGanttView : Page
    {
        public DiagramGanttView()
        {
            InitializeComponent();

            for (int i = 0; i < 12; i++)
            {
                Grid1time.RowDefinitions.Add(new RowDefinition() {});
                Grid1.RowDefinitions.Add(new RowDefinition());
               

            }
            for (int i = 0; i < 11; i++)
            {
                Button button = new Button() { Background=Brushes.Transparent,Content = string.Format("{0}:00", i + 8) };

                Grid.SetColumn(button, 0);
                Grid.SetRow(button, i + 1);
                Grid1time.Children.Add(button);


            }
            for (int i = 0; i < 34; i++)
            {
                var b = new ColumnDefinition();
                b.Width = new GridLength(40);
                    Grid1.ColumnDefinitions.Add( b);
               
            } 
            for (int i = 0; i < 31; i++)
            {
            
                    Button button = new Button() { Background = Brushes.Transparent, Content = i+1};

                Grid.SetColumn(button, i );
                Grid.SetRow(button, 0);

                    Grid1.Children.Add(button);

                
            }
            Model.task_book task_ = new Model.task_book();
            task_.start_date = DateTime.Parse("16/12/2021 08:00:00");
            task_.end_date = DateTime.Parse("16/12/2021 09:00:00");
            var t = new TaskSchedules()
            {
                Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №1",
                end = task_.end_date,
                start = task_.start_date
                                ,
                Status = "В работе",
                id = 0

            };
            var g = new TaskSchedules()
            {
                Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №1123",
                end = DateTime.Parse("3/12/2021 16:00:00"),
                start = DateTime.Parse("1/12/2021 13:00:00")
                                ,
                Status = "Принят",
                id = 1

            };
            var r = new TaskSchedules()
            {
                Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №12",
                end = DateTime.Parse("6/12/2021 11:00:00"),
                start = DateTime.Parse("4/12/2021 10:00:00")
                ,
                Status = "Завершен",
                id = 2
            };
          var  tasks = new List<TaskSchedules>();
            tasks.Add(g);
            tasks.Add(t);
           tasks.Add(r);
            foreach (var item in tasks)
            {
                but button = new but() { Content = item.task, Background = Brushes.LightGreen };
                Grid.SetColumn(button, item.start.Day-1);
                Grid.SetColumnSpan(button, (item.end.Day - item.start.Day)+1);

                Grid.SetRow(button, item.start.Hour-7);
                Grid.SetRowSpan(button, (item.end.Hour- item.start.Hour)+1/*item.end.Hour-12*/);
                Grid1.Children.Add(button);
            }
           
        }
        int j = 1;

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            //  MessageBox.Show((sender as ScrollViewer).HorizontalOffset.ToString());

        }
    }


    public class TaskSchedules
    {
        public object id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string task { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public List<string> statuslist { get; set; } = new List<string> { "Принят", "Завершен", "В работе" };

    }
    /// <summary>
    /// Все состаяния "Принят", "Завершен", "В работе"
    /// </summary>
    enum State
    {

    }
    class but : Button
    {
        public string Description { get; set; }
    }
}
