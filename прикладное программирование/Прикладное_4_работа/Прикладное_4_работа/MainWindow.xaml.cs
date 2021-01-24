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
using System.Windows.Media.Animation;

namespace Прикладное_4_работа
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int c = Convert.ToInt32(rer.Text);
            
            void alex1(int f)
            {
                if (c == 1)
                {
                    TranslateTransform transform = new TranslateTransform();
                    gr3.RenderTransform = transform;
                    DoubleAnimation miny = new DoubleAnimation(0, -50, TimeSpan.FromSeconds(1));
                    transform.BeginAnimation(TranslateTransform.YProperty, miny);
                    Thickness thickness = new Thickness { Bottom = 50, Left = 320, Right = 220, Top = 0 };
                    gr3.Margin = thickness;

                }

                if (c == 2)
                {
                    TranslateTransform transform = new TranslateTransform();
                    gr3.RenderTransform = transform;
                    DoubleAnimation miny = new DoubleAnimation(0, -100, TimeSpan.FromSeconds(1));
                    transform.BeginAnimation(TranslateTransform.YProperty, miny);
                    Thickness thickness = new Thickness { Bottom = 100, Left = 320, Right = 220, Top = 0 };
                    gr3.Margin = thickness;
                }

                if (c == 3)
                {
                    TranslateTransform transform = new TranslateTransform();
                    gr3.RenderTransform = transform;
                    DoubleAnimation miny = new DoubleAnimation(0, -150, TimeSpan.FromSeconds(1));
                    transform.BeginAnimation(TranslateTransform.YProperty, miny);
                    Thickness thickness = new Thickness { Bottom = 150, Left = 320, Right = 220, Top = 0 };
                    gr3.Margin = thickness;
                }
            }
            alex1(c);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AAA se = new AAA();
            se.result();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AAA se = new AAA();
            se.RED(Convert.ToInt32(rer.Text));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AAA se = new AAA();
            se.algo();
            //MessageBox.Show("вы загрузили груз");
            terra3.Visibility = Visibility.Hidden;
            terra4.Visibility = Visibility.Visible;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AAA se = new AAA();
            se.algo1();
            //MessageBox.Show("вы разгрузили груз");
            terra4.Visibility = Visibility.Hidden;
            terra3.Visibility = Visibility.Visible;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("энергия данна!");
            terra.Visibility = Visibility.Visible;
            terra1.Visibility = Visibility.Visible;
            terra2.Visibility = Visibility.Visible;
            terra3.Visibility = Visibility.Visible;
            terra4.Visibility = Visibility.Visible;
            terra6.Visibility = Visibility.Visible;
            rer.Visibility = Visibility.Visible;
        }
        public class AAA
        {
            public void algo()
            {
                MessageBox.Show("вы загрузили");
            }

            public void algo1()
            {
                MessageBox.Show("вы выгрузили");
            }

            public void algo2()
            {
                MessageBox.Show("вначале выгрузите старый груз!!!");
            }

            public void result()
            {
                MessageBox.Show("грузоподъемность данного лифта около 1 тонны");
            }

            public void RED(int B)
            {
                MessageBox.Show("данный этаж:" + B);
            }
        }

        public void rer_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
