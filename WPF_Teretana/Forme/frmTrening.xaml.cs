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
    /// Interaction logic for frmTrening.xaml
    /// </summary>
    public partial class frmTrening : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmTrening()
        {
            InitializeComponent();
            dpDatumTrening.Focus();

            try
            {
                konekcija.Open();
                string vratiClanove = @"SELECT ClanID, ImeC+' '+PrezimeC as 'Clan' FROM tblClan";
                DataTable dtClan = new DataTable();

                SqlDataAdapter daClan = new SqlDataAdapter(vratiClanove, konekcija);
                daClan.Fill(dtClan);
                cbClanTrening.ItemsSource = dtClan.DefaultView;

                string vratiTermine = @"SELECT TerminID, Trajanje FROM tblTermin";
                DataTable dtTermin = new DataTable();

                SqlDataAdapter daTermin = new SqlDataAdapter(vratiTermine, konekcija);
                daTermin.Fill(dtTermin);
                cbTerminTrening.ItemsSource = dtTermin.DefaultView;

                string vratiTrenere = @"SELECT TrenerID, ImeT+' '+PrezimeT as 'Trener' FROM tblTrener";
                DataTable dtTrener = new DataTable();

                SqlDataAdapter daTrener = new SqlDataAdapter(vratiTrenere, konekcija);
                daTrener.Fill(dtTrener);
                cbTrenerTrening.ItemsSource = dtTrener.DefaultView;
                
                string vratiVrsteTreninga = @"SELECT VrstaTreningaID, NazivVrsteTreninga FROM tblVrstaTreninga";
                DataTable dtVrstaTreninga = new DataTable();

                SqlDataAdapter daVrstaTreninga = new SqlDataAdapter(vratiVrsteTreninga, konekcija);
                daVrstaTreninga.Fill(dtVrstaTreninga);
                cbVrstaTreningaTrening.ItemsSource = dtVrstaTreninga.DefaultView;  
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

                    string upit = @"UPDATE tblTrening
                            SET DatumT='" + dpDatumTrening.SelectedDate + "', ClanID=" + cbClanTrening.SelectedValue + ", TerminID=" + cbTerminTrening.SelectedValue + ", TrenerID=" + cbTrenerTrening.SelectedValue + ", VrstaTreningaID=" + cbVrstaTreningaTrening.SelectedValue + " Where TreningID=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    string insert = @"INSERT INTO tblTrening(DatumT, ClanID, TerminID, TrenerID, VrstaTreningaID)
	                            VALUES('" + dpDatumTrening.SelectedDate + "', " + cbClanTrening.SelectedValue + ", " + cbTerminTrening.SelectedValue + ", " + cbTrenerTrening.SelectedValue + ", " + cbVrstaTreningaTrening.SelectedValue + ");";
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
