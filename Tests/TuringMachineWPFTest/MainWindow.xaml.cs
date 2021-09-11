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
using System.Collections.ObjectModel;
using System.Dynamic;
using System.ComponentModel;
using System.Data;

namespace TuringMachineWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //public class tbItem : DynamicObject
    //{
    //    public string AS { get; set; }
    //    public string Q1 { get; set; }
    //    public string Q2 { get; set; }
    //    public string Q3 { get; set; }
    //    public string Q4 { get; set; }
    //    public string Q5 { get; set; }
    //    public string Q6 { get; set; }
    //    public string Q7 { get; set; }
    //    public string Q8 { get; set; }
    //    public string Q9 { get; set; }
    //    public string Q10 { get; set; }

    //    Dictionary<string, object> dictionary
    //        = new Dictionary<string, object>();
    //    public int Count
    //    {
    //        get
    //        {
    //            return dictionary.Count;
    //        }
    //    }
    //    public override bool TryGetMember(
    //        GetMemberBinder binder, out object result)
    //    {
    //        string name = binder.Name;
    //        return dictionary.TryGetValue(name, out result);
    //    }
    //    public override bool TrySetMember(
    //        SetMemberBinder binder, object value)
    //    {
    //        dictionary[binder.Name] = value;
    //        return true;
    //    }
    //    public void AddProperty<TTValue>(string key, TTValue value = default(TTValue))
    //    {
    //        dictionary[key] = value;
    //    }
    //    public void AddProperty(string typeName, string key, object value = null)
    //    {
    //        Type type = Type.GetType(typeName);
    //        dictionary[key] = Convert.ChangeType(value, type);
    //    }
    //}
    

    public partial class MainWindow : Window
    {
        //IList<string> ColumnNames { get; set; }
        ////dict.key is column name, dict.value is value
        //Dictionary<string, string> Rows { get; set; }

        public DataTable DataTable { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            DataTable = new("States");

            DataColumn newColumn;

            newColumn = new("A\\S");
            DataTable.Columns.Add(newColumn);
            newColumn = new("Q1");
            DataTable.Columns.Add(newColumn);

            newColumn = new("Q2");
            DataTable.Columns.Add(newColumn);

            newColumn = new("Q3");
            DataTable.Columns.Add(newColumn);

            DataRow newRow = DataTable.NewRow();
            newRow.ItemArray = new object[] { "_", "a", "b" };

            DataTable.Rows.Add(newRow);

        }

        private void ButtonAddColumn_Click(object sender, RoutedEventArgs e)
        {
            ////Create a new column to add to the DataGrid
            //DataGridTextColumn textcol = new DataGridTextColumn();
            ////Create a Binding object to define the path to the DataGrid.ItemsSource property
            ////The column inherits its DataContext from the DataGrid, so you don't set the source
            //Binding b = new Binding("LastName");
            ////Set the properties on the new column
            //textcol.Binding = b;
            //textcol.Header = $"Q{DG.Columns.Count}";
            ////Add the column to the DataGrid
            //DG.Columns.Add(textcol);
            string tx = $"Q{DataTable.Columns.Count}";
            DataTable.Columns.Add(new DataColumn($"Q{DataTable.Columns.Count}"));

        }

        private void ButtonDeleteColumn_Click(object sender, RoutedEventArgs e)
        {
            DG.Columns.RemoveAt(DG.Columns.Count - 1);
        }

        private void ButtonAddRow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            DG.Items.RemoveAt(DG.Items.Count - 1);
            
        }
    }

}
