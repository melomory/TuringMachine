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

namespace TuringMachineWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Text { get; set; }

        public string Move { get; set; } = "><.";
     
        public struct Test
        {
            public string Q0 { get; set; }
            public string Q1 { get; set; }
            public string Q2 { get; set; }
        }

        public Test test;

        public MainWindow()
        {
            InitializeComponent();




            //List<List<string>> rows = new();
            //string alph = "_ab";

            //List<string> row = new() { alph[0].ToString() };
            //row.Add("");
            //row.Add("_<5");
            //row.Add("_<5");
            //row.Add("_<5");
            //row.Add("_>7");
            //row.Add("_.0");
            //row.Add("");

            //rows.Add(row);

            //row = new() { alph[1].ToString() };
            //row.Add("a>2");
            //row.Add("a>3");
            //row.Add("a>4");
            //row.Add("a>6");
            //row.Add("_<5");
            //row.Add("a>6");
            //row.Add("");
            //rows.Add(row);

            //row = new() { alph[2].ToString() };
            //row.Add("b>2");
            //row.Add("b>3");
            //row.Add("b>4");
            //row.Add("b>6");
            //row.Add("_<5");
            //row.Add("b>6");
            //row.Add("a>6");
            //rows.Add(row);


        }

        private void ButtonAddColumn_Click(object sender, RoutedEventArgs e)
        {
            //Create a new column to add to the DataGrid
            DataGridTextColumn textcol = new DataGridTextColumn();
            //Create a Binding object to define the path to the DataGrid.ItemsSource property
            //The column inherits its DataContext from the DataGrid, so you don't set the source
            Binding b = new Binding("LastName");
            //Set the properties on the new column
            textcol.Binding = b;
            textcol.Header = $"Q{DG.Columns.Count}";
            //Add the column to the DataGrid
            DG.Columns.Add(textcol);
        }

        private void ButtonDeleteColumn_Click(object sender, RoutedEventArgs e)
        {
            DG.Columns.RemoveAt(DG.Columns.Count - 1);
        }

        private void ButtonAddRow_Click(object sender, RoutedEventArgs e)
        {
            test = new();
            test.Q0 = "_";
            test.Q1 = "_<5";
            test.Q2 = "_<5";

            //test.Q0 = "_";
            //test.Q1 = "a";
            //test.Q2 = "b";

            //Q1.Add("");
            //Q1.Add("a>2");
            //Q1.Add("b>2");

            //Q2.Add("");
            //Q2.Add("a>3");
            //Q2.Add("b>3");

            DG.Items.Add(test);
        }

        private void ButtonDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            DG.Items.RemoveAt(DG.Items.Count - 1);
        }
    }
}
