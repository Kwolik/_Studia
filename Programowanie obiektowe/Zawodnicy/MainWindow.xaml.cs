using System;
using System.Collections.Generic;
using System.IO;
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
using System.ComponentModel;

namespace Zawodnicy
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 15; i <= 55; i++)
                Age_cb.Items.Add(i);
            Age_cb.Text = "20";

            string s = String.Format("    {0,-20}   {1,-20}   {2,-10}   {3,5}", "Imię", "Nazwisko", "Wiek", "Waga");
            Lista_lb.Items.Add(s);

            ReadData();
        }
        List<Player> Lista = new List<Player>();

        private string fName = "";
        private string sName = "";

        private const string def_fName = "Podaj imię";
        private const string def_sName = "Podaj nazwisko";

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name == getFirstName_tb.Name)
                tb.Text = tb.Text == def_fName ? string.Empty : fName;
            if (tb.Name == getSecondName_tb.Name)
                tb.Text = tb.Text == def_sName ? string.Empty : sName;
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name == getFirstName_tb.Name)
                tb.Text = tb.Text == string.Empty ? def_fName : fName;
            if (tb.Name == getSecondName_tb.Name)
                tb.Text = tb.Text == string.Empty ? def_sName : sName;
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            if (fName != "" && sName != "" && fName != def_fName && sName != def_sName)
            {
                int age = Convert.ToInt32(Age_cb.Text);
                double weight = Convert.ToDouble(Weight_slider.Value);

                Player player = new Player(fName, sName, weight, age);

                Lista.Add(player);
                string s = String.Format("    {0,-20} - {1,-20} - {2,-10} - {3,5}", fName, sName, age, weight);

                Lista_lb.Items.Add(s);
            }
            else
            {
                fName = "";
                sName = "";
            }
        }

        private void getFirstName_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            fName = getFirstName_tb.Text.ToString();
        }

        private void getSecondName_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            sName = getSecondName_tb.Text.ToString();
        }

        private void Mod_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = Lista_lb.SelectedIndex - 1;
                getFirstName_tb.Text = Lista[index].GetFirstName.ToString();
                getSecondName_tb.Text = Lista[index].GetSecondName.ToString();
                Age_cb.Text = Lista[index].GetAge.ToString();
                Weight_slider.Value = Lista[index].GetWeight;
            }
            catch { }
        }

        private void Del_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lista.RemoveAt(Lista_lb.SelectedIndex - 1);
                Lista_lb.Items.Remove(Lista_lb.SelectedItem);
            }
            catch { }
        }

        private void MainWindows_Closing(object sender, CancelEventArgs e)
        {
            StreamWriter tw = new StreamWriter("Data.txt");

            foreach (var s in Lista)
            {
                //tw.WriteLine(s);
                string str = String.Format("    {0,-20} - {1,-20} - {2,-10} - {3,5}", s.GetFirstName, s.GetSecondName, s.GetAge, s.GetWeight);
                tw.WriteLine(str);
            }
            tw.Close();
            
        }

        private void ReadData()
        {
            string fileName = "Data.txt";
            try
            {
                List<string> lines = File.ReadLines(fileName).ToList();
                List<Array> lista = new List<Array>();
                string f, s;
                int a;
                double w;

                foreach (var line in lines)
                {
                    string str = line.Replace(" ", "");
                    lista.Add(str.Split('-'));
                }

                foreach (var i in lista)
                {
                    f = i.GetValue(0).ToString();
                    s = i.GetValue(1).ToString();
                    a = Convert.ToInt32(i.GetValue(2));
                    w = Convert.ToDouble(i.GetValue(3));

                    Player player = new Player(f, s, w, a);
                    Lista.Add(player);
                    string str = String.Format("    {0,-20} - {1,-20} - {2,-10} - {3,5}", f, s, a, w);

                    Lista_lb.Items.Add(str);
                }
            }
            catch { }

        }
    }
}

