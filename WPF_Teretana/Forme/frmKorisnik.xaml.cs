using System;
using System.Collections.Generic;
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
    /// Interaction logic for frmKorisnik.xaml
    /// </summary>
    public partial class frmKorisnik : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmKorisnik()
        {
            InitializeComponent();
            txtImeKorisnik.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                string insert = @"INSERT INTO tblKorisnik(ImeK, PrezimeK, DatumRodjenjaK, JMBGK, AdresaK, GradK, KontaktK, EmailK, KorisnickoIme, Lozinka)
	                            VALUES('" + txtImeKorisnik.Text + "', '" + txtPrezimeKorisnik.Text + "', '" + dpDatumKorisnik.SelectedDate + "', '" + txtJMBGKorisnik.Text + "', '" + txtAdresaKorisnik.Text + "', '" + txtGradKorisnik.Text + "', '" + txtKontaktKorisnik.Text + "', '" + txtEmailKorisnik.Text + "', '" + txtKorisnickoImeKorisnik.Text + "', '" + txtLozinkaKorisnik.Text + "');";
                SqlCommand cmd = new SqlCommand(insert, konekcija);
                cmd.ExecuteNonQuery();
                this.Close();
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
