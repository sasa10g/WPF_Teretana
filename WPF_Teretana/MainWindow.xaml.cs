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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Teretana.Forme;

namespace WPF_Teretana
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool azuziraj;
        public static object pomocni;

        public static SqlConnection konekcija = Konekcija.KreirajKonekciju();

        private static void PocetniDataGrid(DataGrid grid)
        {
            try
            {
                konekcija.Open();

                string upit = @"SELECT ClanID as ID, ImeC as Ime, PrezimeC as Prezime, DatumRodjenjaC as 'Datum Rodjenja', JMBGC as JMBG, AdresaC as Adresa, GradC as Grad, KontaktC as Kontakt, EmailC as Email FROM tblClan";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                grid.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

            public MainWindow()
        {
            InitializeComponent();
            PocetniDataGrid(dataGridCentralni);
        }

        private void btnClanovi_Click(object sender, RoutedEventArgs e)
        {
            btnDodajClana.Visibility = Visibility.Visible;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajTrenera.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajTrening.Visibility = Visibility.Collapsed;
            btnDodajVrstuTreninga.Visibility = Visibility.Collapsed;
            btnDodajSpravu.Visibility = Visibility.Collapsed;
            btnDodajRegistraciju.Visibility = Visibility.Collapsed;

            btnIzmeniClana.Visibility = Visibility.Visible;

            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniTrenera.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniTrening.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuTreninga.Visibility = Visibility.Collapsed;
            btnIzmeniSpravu.Visibility = Visibility.Collapsed;
            btnIzmeniRegistraciju.Visibility = Visibility.Collapsed;

            btnObrisiClana.Visibility = Visibility.Visible;

            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiTrenera.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiTrening.Visibility = Visibility.Collapsed;
            btnObrisiVrstuTreninga.Visibility = Visibility.Collapsed;
            btnObrisiSpravu.Visibility = Visibility.Collapsed;
            btnObrisiRegistraciju.Visibility = Visibility.Collapsed;

            PocetniDataGrid(dataGridCentralni);

        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            btnDodajKorisnika.Visibility = Visibility.Visible;

            btnDodajClana.Visibility = Visibility.Collapsed;
            btnDodajTrenera.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajTrening.Visibility = Visibility.Collapsed;
            btnDodajVrstuTreninga.Visibility = Visibility.Collapsed;
            btnDodajSpravu.Visibility = Visibility.Collapsed;
            btnDodajRegistraciju.Visibility = Visibility.Collapsed;

            btnIzmeniKorisnika.Visibility = Visibility.Visible;

            btnIzmeniClana.Visibility = Visibility.Collapsed;
            btnIzmeniTrenera.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniTrening.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuTreninga.Visibility = Visibility.Collapsed;
            btnIzmeniSpravu.Visibility = Visibility.Collapsed;
            btnIzmeniRegistraciju.Visibility = Visibility.Collapsed;

            btnObrisiKorisnika.Visibility = Visibility.Visible;

            btnObrisiClana.Visibility = Visibility.Collapsed;
            btnObrisiTrenera.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiTrening.Visibility = Visibility.Collapsed;
            btnObrisiVrstuTreninga.Visibility = Visibility.Collapsed;
            btnObrisiSpravu.Visibility = Visibility.Collapsed;
            btnObrisiRegistraciju.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"SELECT KorisnikID as ID, ImeK as Ime, PrezimeK as Prezime, DatumRodjenjaK as 'Datum Rodjenja', JMBGK as JMBG, AdresaK as Adresa, GradK as Grad, KontaktK as Kontakt, EmailK as Email, KorisnickoIme as 'Korisnicko ime', Lozinka FROM tblKorisnik";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnTreneri_Click(object sender, RoutedEventArgs e)
        {
            btnDodajTrenera.Visibility = Visibility.Visible;

            btnDodajClana.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajTrening.Visibility = Visibility.Collapsed;
            btnDodajVrstuTreninga.Visibility = Visibility.Collapsed;
            btnDodajSpravu.Visibility = Visibility.Collapsed;
            btnDodajRegistraciju.Visibility = Visibility.Collapsed;

            btnIzmeniTrenera.Visibility = Visibility.Visible;

            btnIzmeniClana.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniTrening.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuTreninga.Visibility = Visibility.Collapsed;
            btnIzmeniSpravu.Visibility = Visibility.Collapsed;
            btnIzmeniRegistraciju.Visibility = Visibility.Collapsed;

            btnObrisiTrenera.Visibility = Visibility.Visible;

            btnObrisiClana.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiTrening.Visibility = Visibility.Collapsed;
            btnObrisiVrstuTreninga.Visibility = Visibility.Collapsed;
            btnObrisiSpravu.Visibility = Visibility.Collapsed;
            btnObrisiRegistraciju.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"SELECT TrenerID as ID, ImeT as Ime, PrezimeT as Prezime, DatumRodjenjaT as 'Datum Rodjenja', JMBGT as JMBG, AdresaT as Adresa, GradT as Grad, KontaktT as Kontakt, EmailT as Email, NazivVrsteTreninga as 'Vrsta treninga' FROM tblTrener
                                INNER JOIN tblVrstaTreninga on tblTrener.VrstaTreningaID = tblVrstaTreninga.VrstaTreningaID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnTermini_Click(object sender, RoutedEventArgs e)
        {
            btnDodajTermin.Visibility = Visibility.Visible;

            btnDodajClana.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajTrenera.Visibility = Visibility.Collapsed;
            btnDodajTrening.Visibility = Visibility.Collapsed;
            btnDodajVrstuTreninga.Visibility = Visibility.Collapsed;
            btnDodajSpravu.Visibility = Visibility.Collapsed;
            btnDodajRegistraciju.Visibility = Visibility.Collapsed;

            btnIzmeniTermin.Visibility = Visibility.Visible;

            btnIzmeniClana.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniTrenera.Visibility = Visibility.Collapsed;
            btnIzmeniTrening.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuTreninga.Visibility = Visibility.Collapsed;
            btnIzmeniSpravu.Visibility = Visibility.Collapsed;
            btnIzmeniRegistraciju.Visibility = Visibility.Collapsed;

            btnObrisiTermin.Visibility = Visibility.Visible;

            btnObrisiClana.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiTrenera.Visibility = Visibility.Collapsed;
            btnObrisiTrening.Visibility = Visibility.Collapsed;
            btnObrisiVrstuTreninga.Visibility = Visibility.Collapsed;
            btnObrisiSpravu.Visibility = Visibility.Collapsed;
            btnObrisiRegistraciju.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"SELECT TerminID as ID, PocetakTermina as Pocetak, KrajTermina as Kraj, Trajanje FROM tblTermin";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnTreninzi_Click(object sender, RoutedEventArgs e)
        {
            btnDodajTrening.Visibility = Visibility.Visible;

            btnDodajClana.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajTrenera.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajVrstuTreninga.Visibility = Visibility.Collapsed;
            btnDodajSpravu.Visibility = Visibility.Collapsed;
            btnDodajRegistraciju.Visibility = Visibility.Collapsed;

            btnIzmeniTrening.Visibility = Visibility.Visible;

            btnIzmeniClana.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniTrenera.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuTreninga.Visibility = Visibility.Collapsed;
            btnIzmeniSpravu.Visibility = Visibility.Collapsed;
            btnIzmeniRegistraciju.Visibility = Visibility.Collapsed;

            btnObrisiTrening.Visibility = Visibility.Visible;

            btnObrisiClana.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiTrenera.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiVrstuTreninga.Visibility = Visibility.Collapsed;
            btnObrisiSpravu.Visibility = Visibility.Collapsed;
            btnObrisiRegistraciju.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"SELECT TreningID as ID, DatumT as Datum, ImeC+' '+PrezimeC as Clan, Trajanje, ImeT+' '+PrezimeT as Trener, NazivVrsteTreninga as 'Vrsta treninga' FROM tblTrening
                                INNER JOIN tblClan on tblTrening.ClanID = tblClan.ClanID
                                INNER JOIN tblTermin on tblTrening.TerminID = tblTermin.TerminID
                                INNER JOIN tblTrener on tblTrening.TrenerID = tblTrener.TrenerID
                                INNER JOIN tblVrstaTreninga on tblTrening.VrstaTreningaID = tblVrstaTreninga.VrstaTreningaID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnVrsteTreninga_Click(object sender, RoutedEventArgs e)
        {
            btnDodajVrstuTreninga.Visibility = Visibility.Visible;

            btnDodajClana.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajTrenera.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajTrening.Visibility = Visibility.Collapsed;
            btnDodajSpravu.Visibility = Visibility.Collapsed;
            btnDodajRegistraciju.Visibility = Visibility.Collapsed;

            btnIzmeniVrstuTreninga.Visibility = Visibility.Visible;

            btnIzmeniClana.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniTrenera.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniTrening.Visibility = Visibility.Collapsed;
            btnIzmeniSpravu.Visibility = Visibility.Collapsed;
            btnIzmeniRegistraciju.Visibility = Visibility.Collapsed;

            btnObrisiVrstuTreninga.Visibility = Visibility.Visible;

            btnObrisiClana.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiTrenera.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiTrening.Visibility = Visibility.Collapsed;
            btnObrisiSpravu.Visibility = Visibility.Collapsed;
            btnObrisiRegistraciju.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"SELECT VrstaTreningaID as ID, NazivVrsteTreninga as 'Vrsta treninga', NazivSprave as Sprava FROM tblVrstaTreninga
                                INNER JOIN tblSprava on tblVrstaTreninga.SpravaID = tblSprava.SpravaID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnSprave_Click(object sender, RoutedEventArgs e)
        {
            btnDodajSpravu.Visibility = Visibility.Visible;

            btnDodajClana.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajTrenera.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajTrening.Visibility = Visibility.Collapsed;
            btnDodajVrstuTreninga.Visibility = Visibility.Collapsed;
            btnDodajRegistraciju.Visibility = Visibility.Collapsed;

            btnIzmeniSpravu.Visibility = Visibility.Visible;

            btnIzmeniClana.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniTrenera.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniTrening.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuTreninga.Visibility = Visibility.Collapsed;
            btnIzmeniRegistraciju.Visibility = Visibility.Collapsed;

            btnObrisiSpravu.Visibility = Visibility.Visible;

            btnObrisiClana.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiTrenera.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiTrening.Visibility = Visibility.Collapsed;
            btnObrisiVrstuTreninga.Visibility = Visibility.Collapsed;
            btnObrisiRegistraciju.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"SELECT SpravaID as ID, NazivSprave as Naziv, Kolicina FROM tblSprava";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnRegistracije_Click(object sender, RoutedEventArgs e)
        {
            btnDodajRegistraciju.Visibility = Visibility.Visible;

            btnDodajClana.Visibility = Visibility.Collapsed;
            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnDodajTrenera.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajTrening.Visibility = Visibility.Collapsed;
            btnDodajVrstuTreninga.Visibility = Visibility.Collapsed;
            btnDodajSpravu.Visibility = Visibility.Collapsed;

            btnIzmeniRegistraciju.Visibility = Visibility.Visible;

            btnIzmeniClana.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniTrenera.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniTrening.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuTreninga.Visibility = Visibility.Collapsed;
            btnIzmeniSpravu.Visibility = Visibility.Collapsed;

            btnObrisiRegistraciju.Visibility = Visibility.Visible;

            btnObrisiClana.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiTrenera.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiTrening.Visibility = Visibility.Collapsed;
            btnObrisiVrstuTreninga.Visibility = Visibility.Collapsed;
            btnObrisiSpravu.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"SELECT RegistracijaID as ID, DatumR as Datum, ImeK+' '+PrezimeK as Korisnik, ImeC+' '+PrezimeC as Clan FROM tblRegistracija
                                INNER JOIN tblKorisnik on tblRegistracija.KorisnikID = tblKorisnik.KorisnikID
                                INNER JOIN tblClan on tblRegistracija.ClanID = tblClan.ClanID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        //DODAVANJE

        private void btnDodajClana_Click(object sender, RoutedEventArgs e)
        {
            frmClan prozor = new frmClan();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni);
        }

        private void btnDodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            frmKorisnik prozor = new frmKorisnik();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni);
        }

        private void btnDodajTrenera_Click(object sender, RoutedEventArgs e)
        {
            frmTrener prozor = new frmTrener();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni);
        }

        private void btnDodajTermin_Click(object sender, RoutedEventArgs e)
        {
            frmTermin prozor = new frmTermin();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni);
        }

        private void btnDodajTrening_Click(object sender, RoutedEventArgs e)
        {
            frmTrening prozor = new frmTrening();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni);
        }

        private void btnDodajVrstuTreninga_Click(object sender, RoutedEventArgs e)
        {
            frmVrstaTreninga prozor = new frmVrstaTreninga();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni);
        }

        private void btnDodajSpravu_Click(object sender, RoutedEventArgs e)
        {
            frmSprava prozor = new frmSprava();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni);
        }

        private void btnDodajRegistraciju_Click(object sender, RoutedEventArgs e)
        {
            frmRegistracija prozor = new frmRegistracija();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni);
        }

        //IZMENA

        private void btnIzmeniClana_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmClan prozor = new frmClan();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "SELECT * FROM tblClan WHERE ClanID =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    //ImeC, PrezimeC, DatumRodjenjaC, JMBGC, AdresaC, GradC, KontaktC, EmailC
                    prozor.txtImeClan.Text = citac["ImeC"].ToString();
                    prozor.txtPrezimeClan.Text = citac["PrezimeC"].ToString();
                    prozor.dpDatumClan.Text = citac["DatumRodjenjaC"].ToString();
                    prozor.txtJMBGClan.Text = citac["JMBGC"].ToString();
                    prozor.txtAdresaClan.Text = citac["AdresaC"].ToString();
                    prozor.txtGradClan.Text = citac["GradC"].ToString();
                    prozor.txtKontaktClan.Text = citac["KontaktC"].ToString();
                    prozor.txtEmailClan.Text = citac["EmailC"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                PocetniDataGrid(dataGridCentralni);
                azuziraj = false;
            }
        }

        private void btnIzmeniKorisnika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmKorisnik prozor = new frmKorisnik();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "SELECT * FROM tblKorisnik WHERE KorisnikID =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    //ImeK, PrezimeK, DatumRodjenjaK, JMBGK, AdresaK, GradK, KontaktK, EmailK, KorisnickoIme, Lozinka
                    prozor.txtImeKorisnik.Text = citac["ImeK"].ToString();
                    prozor.txtPrezimeKorisnik.Text = citac["PrezimeK"].ToString();
                    prozor.dpDatumKorisnik.Text = citac["DatumRodjenjaK"].ToString();
                    prozor.txtJMBGKorisnik.Text = citac["JMBGK"].ToString();
                    prozor.txtAdresaKorisnik.Text = citac["AdresaK"].ToString();
                    prozor.txtGradKorisnik.Text = citac["GradK"].ToString();
                    prozor.txtKontaktKorisnik.Text = citac["KontaktK"].ToString();
                    prozor.txtEmailKorisnik.Text = citac["EmailK"].ToString();
                    prozor.txtKorisnickoImeKorisnik.Text = citac["KorisnickoIme"].ToString();
                    prozor.txtLozinkaKorisnik.Text = citac["Lozinka"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                PocetniDataGrid(dataGridCentralni);
                azuziraj = false;
            }
        }

        private void btnIzmeniTrenera_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmTrener prozor = new frmTrener();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "SELECT * FROM tblTrener WHERE TrenerID =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    //ImeT, PrezimeT, DatumRodjenjaT, JMBGT, AdresaT, GradT, KontaktT, EmailT, VrstaTreningaID
                    prozor.txtImeTrener.Text = citac["ImeT"].ToString();
                    prozor.txtPrezimeTrener.Text = citac["PrezimeT"].ToString();
                    prozor.dpDatumTrener.Text = citac["DatumRodjenjaT"].ToString();
                    prozor.txtJMBGTrener.Text = citac["JMBGT"].ToString();
                    prozor.txtAdresaTrener.Text = citac["AdresaT"].ToString();
                    prozor.txtGradTrener.Text = citac["GradT"].ToString();
                    prozor.txtKontaktTrener.Text = citac["KontaktT"].ToString();
                    prozor.txtEmailTrener.Text = citac["EmailT"].ToString();
                    prozor.cbVrstaTreningaTrener.SelectedValue = citac["VrstaTreningaID"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                PocetniDataGrid(dataGridCentralni);
                azuziraj = false;
            }
        }

        private void btnIzmeniTermin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmTermin prozor = new frmTermin();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "SELECT * FROM tblTermin WHERE TerminID =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    //PocetakTermina, KrajTermina, Trajanje
                    prozor.txtPocetakTermin.Text = citac["PocetakTermina"].ToString();
                    prozor.txtKrajTermin.Text = citac["KrajTermina"].ToString();
                    prozor.txtTrajanjeTermin.Text = citac["Trajanje"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                PocetniDataGrid(dataGridCentralni);
                azuziraj = false;
            }
        }

        private void btnIzmeniTrening_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniVrstuTreninga_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmVrstaTreninga prozor = new frmVrstaTreninga();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "SELECT * FROM tblVrstaTreninga WHERE VrstaTreningaID =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    //NazivVrsteTreninga, SpravaID
                    prozor.txtNazivVrstaTreninga.Text = citac["NazivVrsteTreninga"].ToString();
                    prozor.cbSpravaVrstaTreninga.SelectedValue = citac["SpravaID"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                PocetniDataGrid(dataGridCentralni);
                azuziraj = false;
            }
        }

        private void btnIzmeniSpravu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmSprava prozor = new frmSprava();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "SELECT * FROM tblSprava WHERE SpravaID =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    //NazivSprave, Kolicina
                    prozor.txtNazivSprava.Text = citac["NazivSprave"].ToString();
                    prozor.txtKolicinaSprava.Text = citac["Kolicina"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                PocetniDataGrid(dataGridCentralni);
                azuziraj = false;
            }
        }

        private void btnIzmeniRegistraciju_Click(object sender, RoutedEventArgs e)
        {

        }

        //BRISANJE

        private void btnObrisiClana_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiTrenera_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiTermin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiTrening_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiVrstuTreninga_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiSpravu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiRegistraciju_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
