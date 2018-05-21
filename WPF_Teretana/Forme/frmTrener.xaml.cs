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
    /// Interaction logic for frmTrener.xaml
    /// </summary>
    public partial class frmTrener : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmTrener()
        {
            InitializeComponent();
            txtImeTrener.Focus();

            try
            {
                konekcija.Open();
                string vratiVrsteTreninga = @"SELECT VrstaTreningaID, NazivVrsteTreninga FROM tblVrstaTreninga";
                DataTable dtVrstaTreninga = new DataTable();

                SqlDataAdapter daVrstaTreninga = new SqlDataAdapter(vratiVrsteTreninga, konekcija);
                daVrstaTreninga.Fill(dtVrstaTreninga);
                cbVrstaTreningaTrener.ItemsSource = dtVrstaTreninga.DefaultView;
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

                string insert = @"INSERT INTO tblTrener(ImeT, PrezimeT, DatumRodjenjaT, JMBGT, AdresaT, GradT, KontaktT, EmailT, VrstaTreningaID)
	                            VALUES('" + txtImeTrener.Text + "', '" + txtPrezimeTrener.Text + "', '" + dpDatumTrener.SelectedDate + "', '" + txtJMBGTrener.Text + "', '" + txtAdresaTrener.Text + "', '" + txtGradTrener.Text + "', '" + txtKontaktTrener.Text + "', '" + txtEmailTrener.Text + "', '" + cbVrstaTreningaTrener.SelectedValue + "');";
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
