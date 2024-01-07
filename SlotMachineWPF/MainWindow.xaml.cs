using SlotMachineWPF;
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
using static System.Net.Mime.MediaTypeNames;

namespace SlotMachineWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SlotMachine slotmachine = new();

        int count1, count2, count3 = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Spin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool c1 = Lock1.Source == closed;
                bool c2 = Lock2.Source == closed;
                bool c3 = Lock3.Source == closed;

                slotmachine.SpinSlotMachine(c1, c2, c3);
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show($"{ex.Message} \n\n Vuoi ricominciare da capo?", "Slot Machine", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Restart();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }

            Updater();
        }



        private void Lock1_Click(object sender, RoutedEventArgs e)
        {
            if (Lock1.Source == open && !(Lock2.Source == closed && Lock3.Source == closed))
                Lock1.Source = closed;
            else
                Lock1.Source = open;
        }

        private void Lock2_Click(object sender, RoutedEventArgs e)
        {
            if (Lock2.Source == open && !(Lock1.Source == closed && Lock3.Source == closed))
                Lock2.Source = closed;
            else
                Lock2.Source = open;
        }

        private void Lock3_Click(object sender, RoutedEventArgs e)
        {
            if (Lock3.Source == open && !(Lock1.Source == closed && Lock2.Source == closed))
                Lock3.Source = closed;
            else
                Lock3.Source = open;
        }

        private void HideRules_Click(object sender, RoutedEventArgs e)
        {
            Rules.Visibility = Visibility.Hidden;
        }

        private void Updater()
        {
            Rell1.Text = slotmachine.Rell1.ToString();
            Rell2.Text = slotmachine.Rell2.ToString();
            Rell3.Text = slotmachine.Rell3.ToString();

            LastWin.Text = $"Ultima Vincita: {slotmachine.LastWin}";

            Balance.Text = $"Saldo: {slotmachine.Balance}";

            if (Lock1.Source == closed)
                count1++;

            if (count1 == 2)
            {
                Lock1.Source = open;
                count1 = 0;
            }

            if (Lock2.Source == closed)
                count2++;

            if (count2 == 2)
            {
                Lock2.Source = open;
                count2 = 0;
            }

            if (Lock3.Source == closed)
                count3++;

            if (count3 == 2)
            {
                Lock3.Source = open;
                count3 = 0;
            }
        }

        private void Restart()
        {
            slotmachine = new SlotMachine();
            count1 = count2 = count3 = 0;

            Updater();
        }
    }
}