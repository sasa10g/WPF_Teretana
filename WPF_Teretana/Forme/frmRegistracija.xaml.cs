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
    /// Interaction logic for frmRegistracija.xaml
    /// </summary>
    public partial class frmRegistracija : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmRegistracija()
        {
            InitializeComponent();
            dpDatumRegistracija.Focus();

            try
            {
                konekcija.Open();
                string vratiKorisnike = @"SELECT KorisnikID, ImeK+' '+PrezimeK as 'Korisnik' FROM tblKorisnik";
                DataTable dtKorisnik = new DataTable();

                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnike, konekcija);
                daKorisnik.Fill(dtKorisnik);
                cbKorisnikRegistracija.ItemsSource = dtKorisnik.DefaultView;

                string vratiClanove = @"SELECT ClanID, ImeC+' '+PrezimeC as 'Clan' FROM tblClan";
                DataTable dtClan = new DataTable();

                SqlDataAdapter daClan = new SqlDataAdapter(vratiClanove, konekcija);
                daClan.Fill(dtClan);
                cbClanRegistracija.ItemsSource = dtClan.DefaultView;
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

                    string upit = @"UPDATE tblRegistracija
                            SET DatumR='" + dpDatumRegistracija.SelectedDate + "', KorisnikID=" + cbKorisnikRegistracija.SelectedValue + ", ClanID=" + cbClanRegistracija.SelectedValue + " Where RegistracijaID=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    string insert = @"INSERT INTO tblRegistracija(DatumR, KorisnikID, ClanID)
	                            VALUES('" + dpDatumRegistracija.SelectedDate + "', " + cbKorisnikRegistracija.SelectedValue + ", " + cbClanRegistracija.SelectedValue + ");";
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
