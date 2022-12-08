using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Threading;

namespace project12
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

        DispatcherTimer timer;

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.IsEnabled = true;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm:ss");
            date.Text = d.ToString("dddd dd.MM.yyyy");
        }

        public void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uint firstValue = UInt32.Parse(inpFirstValue.Text);
                uint secondValue = UInt32.Parse(inpSecondValue.Text);
                double geometricMean = Math.Sqrt(firstValue * secondValue);

                result.Text = geometricMean.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Calculate2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int sourceValue = Int32.Parse(inpValue.Text); 
                int hundred = sourceValue / 100; 
                int dozen = (sourceValue /10) % 10; 
                int currentValue = (dozen * 100) + (hundred * 10) + (sourceValue % 10);
                result2.Text = currentValue.ToString();   
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            inpFirstValue.Clear();
            inpSecondValue.Clear();
            inpValue.Clear();
            result.Clear();
            result2.Clear();
        }

        public void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Гранин ИСП-31 Реализовать расчет задачи: Даны два " +
                "неотрицательных числа a и b. Найти их среднее геометрическое, " +
                "то есть квадратный корень из их произведения. Дано трехзначное число. " +
                "Вывести число, полученное при перестановке цифр сотен и " +
                "десятков исходного числа (например, 123 перейдет в 213).", "О программе",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
