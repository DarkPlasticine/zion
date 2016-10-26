using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace Zion_base
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string catBD = @"d:\new folder\zion.llx";
        public static string conBD = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + catBD;
        public MainWindow()
        {


            InitializeComponent();

            DataSet ds = new DataSet();
            string sql = "SELECT * FROM invoice";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(conBD))
                {

                    conn.Open();

                    OleDbDataAdapter da = new OleDbDataAdapter("select * from invoice", conn);
                    OleDbCommandBuilder dcb = new OleDbCommandBuilder(da);

                    da.Fill(ds, "invoice");

                    data.ItemsSource = ds.Tables["invoice"].DefaultView;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
    }
}
