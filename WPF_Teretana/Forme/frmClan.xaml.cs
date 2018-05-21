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
    /// Interaction logic for frmClan.xaml
    /// </summary>
    public partial class frmClan : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmClan()
        {
            InitializeComponent();
            txtImeClan.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.azuziraj)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string upit = @"UPDATE tblClan 
                            SET ImeC='" + txtImeClan.Text + "', PrezimeC='" + txtPrezimeClan.Text + "',DatumRodjenjaC='" + dpDatumClan.SelectedDate + "', JMBGC='" + txtJMBGClan.Text + "', AdresaC='" + txtAdresaClan.Text + "', GradC='" + txtGradClan.Text + "', KontaktC='" + txtKontaktClan.Text + "', EmailC='" + txtEmailClan.Text + "' Where ClanID=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    string insert = @"INSERT INTO tblClan(ImeC, PrezimeC, DatumRodjenjaC, JMBGC, AdresaC, GradC, KontaktC, EmailC)
	                            VALUES('" + txtImeClan.Text + "', '" + txtPrezimeClan.Text + "', '" + dpDatumClan.SelectedDate + "', '" + txtJMBGClan.Text + "', '" + txtAdresaClan.Text + "', '" + txtGradClan.Text + "', '" + txtKontaktClan.Text + "', '" + txtEmailClan.Text + "');";
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
