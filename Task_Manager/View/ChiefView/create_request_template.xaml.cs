using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Task_Manager.View.ChiefView
{
    /// <summary>
    /// Логика взаимодействия для create_request_template.xaml
    /// </summary>
    public partial class create_request_template : Page
    {
        static string guid = "";

        public create_request_template()
        {
            InitializeComponent();
            string txt = File.ReadAllText(@"C:\Users\lenovo\Desktop\eccccccccccccccccccccccccccccccccccccr.json");
            List<gridelement> lis = JsonConvert.DeserializeObject<List<gridelement>>(txt); ;
            List<tecon> tecons = new List<tecon>();
            if (lis!=null)
            {


                foreach (var item in lis)
                {
                    root.Children.Add(new CustomElement(item.userelement1, item.userelement2)._Grid);
                    tecons.Add(new tecon { Content = item.userelement1.Content.ToString(), Text=item.userelement2.Content.ToString() }) ;
                }
                foreach (UIElement item in root.Children)
                {
                    if ((item as Grid) != null)
                    {

                        (item as Grid).Children[0].MouseUp += _Label_MouseDoubleClick;


                    }

                }
            }
            tStack.ItemsSource = tecons;

        }
        private void _Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            text.Text = (sender as Label).Content.ToString(); ;
            guid = (sender as Label).Uid;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            root.Children.Add(new CustomElement()._Grid);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<gridelement> b = new List<gridelement>();
            string output="";
            foreach (var item in root.Children)
            {

                if ((item as Grid)!=null)
                {
                    var v1 = (item as Grid).Children[0];

                  var v2 = (item as Grid).Children[1];
                    b.Add(new gridelement() { userelement1 = new userelement { Content = (v1 as Label).Content },
                        userelement2 =new userelement { Content = (v2 as TextBox).Text } });

                }


            }

            output = JsonConvert.SerializeObject(b);


            File.WriteAllText(@"C:\Users\lenovo\Desktop\eccccccccccccccccccccccccccccccccccccr.json", output);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (UIElement item in root.Children)
            {
               
                if((item as Grid).Children[0].Uid== guid)
                {

                    ((item as Grid).Children[0] as Label).Content = text.Text;
                }

                

            }
        }

    

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (UIElement item in root.Children)
            {

                if ((item as Grid).Children[0].Uid == guid)
                {

                    ((item as Grid).Children[0] as Label).Content = text.Text;
                }



            }
        }
    }


    public  class CustomElement:FrameworkElement
    {
        public Grid _Grid = new Grid();

        public TextBox textBox { get; set; } = new TextBox { };

        public Label _Label { get; set; } = new Label() { Content = "Lable", BorderThickness= new Thickness(1), BorderBrush=Brushes.Black};
      public  CustomElement()
        {
            _Grid.ColumnDefinitions.Add(new ColumnDefinition());
            _Grid.ColumnDefinitions.Add(new ColumnDefinition());

            Grid.SetColumn(_Label, 0);
            Grid.SetColumn(textBox,1);
            _Grid.Children.Add(_Label);
            _Grid.Children.Add(textBox);

        }
        public CustomElement(userelement userelement1, userelement userelement2)
        {
            textBox.Text = userelement2.Content.ToString();
            _Label.Content = userelement1.Content;
            _Grid.ColumnDefinitions.Add(new ColumnDefinition());
            _Grid.ColumnDefinitions.Add(new ColumnDefinition());
            _Label.Uid = userelement1.Guid.ToString() ;
            Grid.SetColumn(_Label, 0);
            Grid.SetColumn(textBox, 1);
            _Grid.Children.Add(_Label);
            _Grid.Children.Add(textBox);

        }

       
    }
    public class tecon
    {
        public string Text { get; set; }
        public string Content { get; set; }
    }
    public  class gridelement
    {
     public   userelement userelement1 { get; set; }
        public userelement userelement2 { get; set; }
    }
  public  class userelement
    {
        public Object Content { get; set; }
        
        public Guid Guid { get { return Guid.NewGuid(); } }

    }
}