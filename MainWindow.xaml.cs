using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string expresieMatematica = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdaugaLaExpresiaMatematica(object sender, RoutedEventArgs e)
        {
            Button buton = sender as Button;
            string valoareButon = buton.Content.ToString();

            Ecran.Text = Ecran.Text + valoareButon; // Ecran.Text += valoare;
        }

        private void Calculeaza(object sender, RoutedEventArgs e)
        {
            double a, b;
            string expresie = Ecran.Text;
            double rezultat = 0;

            // Cautăm operatorul în string
            if (expresie.Contains("+"))
            {
                string[] parti = expresie.Split('+');
                a = double.Parse(parti[0]);
                b = double.Parse(parti[1]);
                rezultat = a + b;
            }
            else if (expresie.Contains("-"))
            {
                string[] parti = expresie.Split('-');
                a = double.Parse(parti[0]);
                b = double.Parse(parti[1]);
                rezultat = a - b;
            }
            else if (expresie.Contains("x"))
            {
                string[] parti = expresie.Split('x');
                a = double.Parse(parti[0]);
                b = double.Parse(parti[1]);
                rezultat = a * b;
            }
            else if (expresie.Contains("/"))
            {
                string[] parti = expresie.Split('/');
                a = double.Parse(parti[0]);
                b = double.Parse(parti[1]);

                if (b == 0)
                {
                    MessageBox.Show("Nu se poate imparti la 0!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);

                    // Resetam ecranul
                    Ecran.Text = "";

                    // ne intoarcem din functie
                    return;
                }

                rezultat = a / b;
            }
            else if (expresie.Contains("%"))
            {
                string[] parti = expresie.Split('%');
                a = double.Parse(parti[0]);
                b = double.Parse(parti[1]);

                rezultat = a % b;

                if (b == 0)
                {
                    MessageBox.Show("Nu se poate imparti la 0, deci nu putem afla restul impartirii la 0!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);

                    // Resetam ecranul
                    Ecran.Text = "";

                    // ne intoarcem din functie
                    return;
                }
            }
            else
            {
                MessageBox.Show("Expresie matematica necunoscuta sau gresita!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                
                // Resetam ecranul
                Ecran.Text = "";

                // ne intoarcem din functie
                return;
            }

            // Scriem rezultatul pe ecran
            Ecran.Text = rezultat.ToString();
        }

        private void Sterge(object sender, RoutedEventArgs e)
        {
            Ecran.Text = "";
        }
    }
}