using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfOracleTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        OracleConnection conn;

        private void DB_Connect(object sender, RoutedEventArgs e)
        {
            try
            {
                string strCon = "data source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User ID=scott;Password=tiger";
                conn = new OracleConnection(strCon);
                conn.Open();

                MessageBox.Show("DB Connection OK!");
            }

            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void Select_Emp(object sender, RoutedEventArgs e)
        {
            string sql = "select empno, ename, job from emp ";

            OracleCommand comm = new OracleCommand();
            if (conn == null) DB_Connect(this, null);
            comm.Connection = conn;
            comm.CommandText = sql;
            
            OracleDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            List<EmpViewModel> emps = new List<EmpViewModel>();

            while (reader.Read())
            {
                emps.Add(new EmpViewModel()
                {
                    Empno = reader.GetInt32(reader.GetOrdinal("empno")),
                    Ename = reader.GetString(reader.GetOrdinal("ename")),
                    Job = reader.GetString(reader.GetOrdinal("job"))
                });
            }
            lstView.ItemsSource = emps;
            reader.Close();
        }
    }
}
