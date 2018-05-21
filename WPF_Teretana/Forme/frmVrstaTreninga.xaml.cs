using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WPF_Teretana.Forme
{
    /// <summary>
    /// Interaction logic for frmVrstaTreninga.xaml
    /// </summary>
    public partial class frmVrstaTreninga : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmVrstaTreninga()
        {
            InitializeComponent();
            txtNazivVrstaTreninga.Focus();

            try
            {
                konekcija.Open();
                string vratiSprave = @"SELECT SpravaID, NazivSprave FROM tblSprava";
                DataTable dtSprava = new DataTable();

                SqlDataAdapter daSprava = new SqlDataAdapter(vratiSprave, konekcija);
                daSprava.Fill(dtSprava);
                cbSpravaVrstaTreninga.ItemsSource = dtSprava.DefaultView;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.azuziraj)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string upit = @"UPDATE tblVrstaTreninga
                            SET NazivVrsteTreninga='" + txtNazivVrstaTreninga.Text + "', SpravaID=" + cbSpravaVrstaTreninga.SelectedValue + " Where VrstaTreningaID=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    string insert = @"INSERT INTO tblVrstaTreninga(NazivVrsteTreninga, SpravaID)
	                            VALUES('" + txtNazivVrstaTreninga.Text + "', '" + cbSpravaVrstaTreninga.SelectedValue + "');";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih podataka nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
