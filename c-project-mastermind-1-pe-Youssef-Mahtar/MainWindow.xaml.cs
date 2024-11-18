using System;
using System.Collections.Generic;
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

namespace c_project_mastermind_1_pe_Youssef_Mahtar
{
    public partial class MainWindow : Window
    {
        private List<string> code;
        int poging = 1;
        public MainWindow()
        {
            InitializeComponent();
            RandomKleuren();
            LabelBorder();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string checkKleur1 = ComboBox1.SelectedItem?.ToString() ?? "";
            string checkKleur2 = ComboBox2.SelectedItem?.ToString() ?? "";
            string checkKleur3 = ComboBox3.SelectedItem?.ToString() ?? "";
            string checkKleur4 = ComboBox4.SelectedItem?.ToString() ?? "";


            if (checkKleur1 == code[0])
            {
                Label1.BorderBrush = Brushes.DarkRed;

            }
            else if (checkKleur1 == code[1] || checkKleur1 == code[2] || checkKleur1 == code[3])
            {
                Label1.BorderBrush = Brushes.Wheat;
            }
            else
            {
                Label1.BorderBrush = Brushes.Transparent;
            }
            if (checkKleur2 == code[1])
            {
                Label2.BorderBrush = Brushes.DarkRed;

            }
            else if (checkKleur2 == code[0] || checkKleur2 == code[2] || checkKleur2 == code[3])
            {
                Label2.BorderBrush = Brushes.Wheat;
            }
            else
            {
                Label2.BorderBrush = Brushes.Transparent;
            }
            if (checkKleur3 == code[2])
            {
                Label3.BorderBrush = Brushes.DarkRed;

            }
            else if (checkKleur3 == code[0] || checkKleur3 == code[1] || checkKleur3 == code[3])
            {
                Label3.BorderBrush = Brushes.Wheat;
            }
            else
            {
                Label3.BorderBrush = Brushes.Transparent;
            }
            if (checkKleur4 == code[3])
            {
                Label4.BorderBrush = Brushes.DarkRed;

            }
            else if (checkKleur4 == code[0] || checkKleur4 == code[1] || checkKleur4 == code[2])
            {
                Label4.BorderBrush = Brushes.Wheat;
            }
            else
            {
                Label4.BorderBrush = Brushes.Transparent;
            }

            if (Label1.BorderBrush == Brushes.DarkRed && Label2.BorderBrush == Brushes.DarkRed &&
                Label3.BorderBrush == Brushes.DarkRed && Label4.BorderBrush == Brushes.DarkRed)
            {
                MessageBox.Show("JE HEBT ALLE KLEUREN JUIST GERADEN!", "Gewonnen!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void RandomKleuren()
        {
            Random random = new Random();
            List<string> kleuren = new List<string> { "rood", "geel", "oranje", "wit", "groen", "blauw" };

            code = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                string randomKleur = kleuren[random.Next(kleuren.Count)];
                code.Add(randomKleur);
            }

            string codeString = string.Join(", ", code);
            this.Title = $"Mastermind ({codeString})";


            foreach (string kleur in kleuren)
            {
                ComboBox1.Items.Add(kleur);
                ComboBox2.Items.Add(kleur);
                ComboBox3.Items.Add(kleur);
                ComboBox4.Items.Add(kleur);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;


            string kleurCode = GekozenKleuren(comboBox);
            SolidColorBrush colorBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(kleurCode);


            if (comboBox == ComboBox1)
            {
                Label1.Background = colorBrush;
            }
            else if (comboBox == ComboBox2)
            {
                Label2.Background = colorBrush;
            }
            else if (comboBox == ComboBox3)
            {
                Label3.Background = colorBrush;
            }
            else if (comboBox == ComboBox4)
            {
                Label4.Background = colorBrush;
            }
        }

        private string GekozenKleuren(ComboBox comboBox)
        {
            if (comboBox != null && comboBox.SelectedItem is string gekozenKleur)
            {

                switch (gekozenKleur.ToLower())
                {
                    case "rood":
                        return "#FF0000";
                    case "groen":
                        return "#008000";
                    case "blauw":
                        return "#0000FF";
                    case "geel":
                        return "#FFFF00";
                    case "oranje":
                        return "#FFA500";
                    case "wit":
                        return "#FFFFFF";
                    default:
                        return "#D3D3D3";
                }
            }

            return "#D3D3D3"; // Kleurcode "LIGHTGRAY". Is hetzelfde als achtergrond voor de kleur wit te kunnen laten zien.
        }

        private void LabelBorder()
        {
            Label1.BorderThickness = new Thickness(5);
            Label2.BorderThickness = new Thickness(5);
            Label3.BorderThickness = new Thickness(5);
            Label4.BorderThickness = new Thickness(5);
        }
    }
}