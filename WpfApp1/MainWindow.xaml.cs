using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetBackground();
        }

        private void btnSzamol_Click(object sender, RoutedEventArgs e)
        {
            btnSzamol.Background = new SolidColorBrush(Colors.Black);
            btnSzamol.Foreground = new SolidColorBrush(Colors.Aqua);
            double kapacitas = Convert.ToDouble(txtKapacitas.Text);
            int atviteliSeb = Convert.ToInt32(sldAtviteliseb.Value);
            double eredmeny;
            char kapacitasMertekegyseg = Convert.ToString(((ComboBoxItem)cbKapacitas.SelectedItem).Content)[0];
            char atviteliMertekegyseg = Convert.ToString(((ComboBoxItem)cbAtviteliseb.SelectedItem).Content)[0];

            /*if ( kapacitasMertekegyseg == atviteliMertekegyseg)
            {
                eredmeny = Math.Round(kapacitas / atviteliSeb, 2);
                MessageBox.Show($"A folyamat végrehajtása: {eredmeny}sec");
            }*/
            if (kapacitasMertekegyseg == 'K')
            {

            }
            else if (kapacitasMertekegyseg == 'M')
            {
                kapacitas *= 1000;
            }
            else if (kapacitasMertekegyseg == 'G')
            {
                kapacitas *= 1000*1000;
            }
            else if (kapacitasMertekegyseg == 'T')
            {
                kapacitas *= 1000*1000*1000;
            }


            if (atviteliMertekegyseg == 'K')
            {

            }
            else if (atviteliMertekegyseg == 'M')
            {
                atviteliSeb *= 1000;
            }
            else if (atviteliMertekegyseg == 'G')
            {
                atviteliSeb *= 1000 * 1000;
            }
            else if (atviteliMertekegyseg == 'T')
            {
                atviteliSeb *= 1000 * 1000 * 1000;
            }

            
            eredmeny = Math.Round(kapacitas / atviteliSeb, 3);
            TimeSpan ido = TimeSpan.FromSeconds(eredmeny);
            string str = ido.ToString(@"hh\:mm\:ss\:fff");
            MessageBox.Show($"A folyamat végrehajtása: {str}");
            btnSzamol.Background = new SolidColorBrush(Colors.LightGray);
            btnSzamol.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void SetBackground()
        {
            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(@"images\hatter.jpg", UriKind.RelativeOrAbsolute);
            bitimg.EndInit();
            this.Background = new ImageBrush(bitimg);
        }

        private void txtKapacitas_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, @"[^\d]+");
        }
    }
}
