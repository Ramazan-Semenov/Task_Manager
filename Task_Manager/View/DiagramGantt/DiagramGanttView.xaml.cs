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
    public partial class DiagramGanttView : UserControl
    {
        public DiagramGanttView()
        {
            InitializeComponent();
          
            for (int i = 0; i < 25; i++)
            {
                timestack.Children.Add(new Button { Height = 31, Content = i });
                Grid1.RowDefinitions.Add(new RowDefinition() {MinHeight=31 });


            }
            for (int i = 1; i < 32; i++)
            {
                stackweek.Children.Add(new Button { Width = 90, Content = i });
                Grid1.ColumnDefinitions.Add(new ColumnDefinition() {MinWidth=90 });
            }
            Model.task_book task_ = new Model.task_book();
            task_.start_date = DateTime.Parse("16/12/2021 14:00:00");
            task_.end_date = DateTime.Parse("16/12/2021 19:00:00");
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
                end = DateTime.Parse("16/12/2021 10:00:00"),
                start = DateTime.Parse("16/12/2021 08:00:00")
                                ,
                Status = "Принят",
                id = 1

            };
            var r = new TaskSchedules()
            {
                Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №12",
                end = DateTime.Parse("6/12/2021 03:00:00"),
                start = DateTime.Parse("4/12/2021 01:00:00")
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
                but button = new but() { Content = item.Description, Background = Brushes.LightGreen };
                Grid.SetColumn(button, item.start.Day-1);
                Grid.SetRow(button, item.start.Hour);
                Grid.SetRowSpan(button, item.end.Hour+1);
                Grid.SetColumnSpan(button, item.start.Day-1);
                Grid1.Children.Add(button);
            }
           
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
