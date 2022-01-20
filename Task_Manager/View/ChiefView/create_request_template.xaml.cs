using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Task_Manager.View.ChiefView
{
    /// <summary>
    /// Логика взаимодействия для create_request_template.xaml
    /// </summary>
    public partial class create_request_template : Page
    {
        static string guid = "";
        static UIElement guidgrid = new UIElement();
        static string output = "";
        static Model.CrudOperations.list_implicit_request list_Implicit_Request = new Model.CrudOperations.list_implicit_request();
        static string Dep = "";
        public create_request_template()
        {
            InitializeComponent();
            // Initform();
            //tStack.ItemsSource = tecons;
            ListDepartment.ItemsSource = Model.ListElement.ListElement.ListDepartment;
        }

        private void Initform(string Json = "")
        {
            //string txt = File.ReadAllText(@"C:\Users\lenovo\Desktop\eccccccccccccccccccccccccccccccccccccr.json");
            if (Json != null)
            {
                List<gridelement> lis = JsonConvert.DeserializeObject<List<gridelement>>(Json); ;
                //List<tecon> tecons = new List<tecon>();
                if (lis != null)
                {


                    foreach (var item in lis)
                    {
                        root.Children.Add(new CustomElement(item.userelement1, item.userelement2)._Grid);
                        //tecons.Add(new tecon { Content = item.userelement1.Content.ToString(), Text=item.userelement2.Content.ToString() }) ;
                    }
                    foreach (UIElement item in root.Children)
                    {
                        if ((item as Grid) != null)
                        {
                            (item as Grid).MouseUp += Create_request_template_MouseUp;
                            (item as Grid).Children[0].MouseUp += _Label_MouseDoubleClick;


                        }

                    }
                }
            }

        }

        private void Create_request_template_LostFocus(object sender, RoutedEventArgs e)
        {
            (sender as Grid).Background = Brushes.White;
        }

        private void Create_request_template_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Grid).Background = Brushes.White;
        }

        private void Create_request_template_MouseUp(object sender, MouseButtonEventArgs e)
        {
            foreach (UIElement item in root.Children)
            {
                (item as Grid).Background = Brushes.White;
            }
                    (sender as Grid).Background = Brushes.LightSkyBlue;
            guidgrid = (sender as Grid);
        }

        private void _Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            text.Text = (sender as Label).Content.ToString(); ;
            guid = (sender as Label).Uid;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            root.Children.Add(new CustomElement()._Grid);
            foreach (UIElement item in root.Children)
            {
                if ((item as Grid) != null)
                {

                    (item as Grid).Children[0].MouseUp += _Label_MouseDoubleClick;


                }

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<gridelement> b = new List<gridelement>();

            foreach (var item in root.Children)
            {

                if ((item as Grid) != null)
                {
                    var v1 = (item as Grid).Children[0];

                    var v2 = (item as Grid).Children[1];
                    b.Add(new gridelement()
                    {
                        userelement1 = new userelement { Content = (v1 as Label).Content },
                        userelement2 = new userelement { Content = (v2 as TextBox).Text }
                    });

                }


            }
            output = JsonConvert.SerializeObject(b);

            list_Implicit_Request.name = Nametemplate.Text;
            list_Implicit_Request.implicit_request_json = output;
            list_Implicit_Request.department = ListDepartment.Text;
            if ((list_Implicit_Request.name.Length > 0) && (list_Implicit_Request.implicit_request_json.Length > 0) && (list_Implicit_Request.department.Length > 0))
            {
                new Model.CrudOperations.Crud_Operations_Implicit_Request().Create(list_Implicit_Request);
                ListNameTemplate.ItemsSource = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => x.department == Dep).Select(x => x.name);

            }
            else
            {
                MessageBox.Show("Error");
            }


            //File.WriteAllText(@"C:\Users\lenovo\Desktop\eccccccccccccccccccccccccccccccccccccr.json", output);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (UIElement item in root.Children)
            {

                if ((item as Grid).Children[0].Uid == guid)
                {

                    ((item as Grid).Children[0] as Label).Content = text.Text;
                }



            }

            //else
            //{
            //    MessageBox.Show("Сохранение зафиксированы");
            //}

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



        private void ListDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var F = (sender as ComboBox).SelectedValue.ToString();
            ListNameTemplate.ItemsSource = null;
            Add.IsEnabled = true;
            Dep = F;
            Nametemplate.Text = "";
            list_Implicit_Request = new Model.CrudOperations.list_implicit_request();
            text.Text = "";
            list_Implicit_Request = new Model.CrudOperations.list_implicit_request();
            //MessageBox.Show(); ;
            string f = "";
            if (new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => x.department == F).Count() > 0)

            {
                f = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => x.department == F).FirstOrDefault().implicit_request_json.ToString(); ;

            }
            //if (f.Length>0)
            //{
            //    Initform(f);

            //}

            ListNameTemplate.ItemsSource = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => x.department == F).Select(x => x.name);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            root.Children.Remove(guidgrid);

        }

        private void ListNameTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            root.Children.Clear();
            // MessageBox.Show( );
            string F = "";
            if (e.AddedItems.Count > 0)
            {
                F = e.AddedItems[0].ToString();
                Model.CrudOperations.list_implicit_request implicit_Request = new Model.CrudOperations.Crud_Operations_Implicit_Request().GetEntityList().Where(x => (x.name == F) & (x.department == Dep)).FirstOrDefault();
                Nametemplate.Text = implicit_Request.name;
                list_Implicit_Request.id = implicit_Request.id;
                if (implicit_Request.implicit_request_json.Length > 0)
                {
                    Initform(implicit_Request.implicit_request_json);

                }
            }


        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            root.Children.Clear();
            Nametemplate.Text = "";
            list_Implicit_Request = new Model.CrudOperations.list_implicit_request();
            text.Text = "";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            List<gridelement> b = new List<gridelement>();

            foreach (var item in root.Children)
            {

                if ((item as Grid) != null)
                {
                    var v1 = (item as Grid).Children[0];

                    var v2 = (item as Grid).Children[1];
                    b.Add(new gridelement()
                    {
                        userelement1 = new userelement { Content = (v1 as Label).Content },
                        userelement2 = new userelement { Content = (v2 as TextBox).Text }
                    });

                }


            }
            output = JsonConvert.SerializeObject(b);
            list_Implicit_Request.name = Nametemplate.Text;
            list_Implicit_Request.implicit_request_json = output;
            list_Implicit_Request.department = ListDepartment.Text;
            if ((list_Implicit_Request.id > 0) && (list_Implicit_Request.name.Length > 0) && (list_Implicit_Request.implicit_request_json.Length > 0) && (list_Implicit_Request.department.Length > 0))
            {
                MessageBox.Show(string.Format("NAME:{0}, ID:{1}, DEP:{2}", list_Implicit_Request.name, list_Implicit_Request.id, list_Implicit_Request.department));

                new Model.CrudOperations.Crud_Operations_Implicit_Request().Update(list_Implicit_Request);

            }
        }
    }


    public class CustomElement : FrameworkElement
    {
        public Grid _Grid = new Grid() { Uid = Guid.NewGuid().ToString() };

        public TextBox textBox { get; set; } = new TextBox { };

        public Label _Label { get; set; } = new Label() { Uid = Guid.NewGuid().ToString(), Content = "Lable", BorderThickness = new Thickness(1), BorderBrush = Brushes.Black };
        public CustomElement()
        {
            _Grid.ColumnDefinitions.Add(new ColumnDefinition());
            _Grid.ColumnDefinitions.Add(new ColumnDefinition());

            Grid.SetColumn(_Label, 0);
            Grid.SetColumn(textBox, 1);
            _Grid.Children.Add(_Label);
            _Grid.Children.Add(textBox);

        }
        public CustomElement(userelement userelement1, userelement userelement2)
        {
            textBox.Text = userelement2.Content.ToString();
            _Label.Content = userelement1.Content;
            _Grid.ColumnDefinitions.Add(new ColumnDefinition());
            _Grid.ColumnDefinitions.Add(new ColumnDefinition());
            _Label.Uid = userelement1.Guid.ToString();
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
    public class gridelement
    {
        public userelement userelement1 { get; set; }
        public userelement userelement2 { get; set; }
    }
    public class userelement
    {
        public Object Content { get; set; }

        public Guid Guid { get { return Guid.NewGuid(); } }

    }
}