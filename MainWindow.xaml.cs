using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
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

        void AdaugaLaExpresiaMatematica(object sender, RoutedEventArgs e)
        {
            Button buton = sender as Button;
            string valoareButon = buton.Content.ToString();
            Ecran.Text = Ecran.Text + valoareButon; // Ecran.Text += valoare;
        }

        void Sterge(object sender, RoutedEventArgs e)
        {
            Ecran.Text = "";
        }
        void afisareEroare(string mesaj)
        {
            MessageBox.Show(mesaj, "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            Ecran.Text = "";
        }


        void Calculeaza(object sender, RoutedEventArgs e)
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
            else if (expresie.Contains("*"))
            {
                string[] parti = expresie.Split('*');
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
                    afisareEroare("Nu se poate imparti la 0!"); 
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
                   afisareEroare("Nu se poate calcula restul impartirii la 0!");
                    return;
                }
            }
            else
            {
               afisareEroare("Expresie matematica invalida!");
                return;
            }

            // Scriem rezultatul pe ecran
            Ecran.Text = rezultat.ToString();
        }


        private void CalculeazaExpresie(object sender, RoutedEventArgs e)
        {
            string expresie = Ecran.Text;
            try
            {
                var rezultat = new DataTable().Compute(expresie, "");
                Ecran.Text = rezultat.ToString();
            }
            catch (SyntaxErrorException)
            {
                afisareEroare("Expresie matematica invalida!");
                return;
            }
            catch (EvaluateException ex)
            {
                afisareEroare(ex.Message);
                return;
            }
        }
    }
}