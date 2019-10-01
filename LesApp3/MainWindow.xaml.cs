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

namespace LesApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // стартовы налаштування

        }

        private void SetFonts()
        {
            //lbText.FontFamily
            
        }

        /// <summary>
        /// При виборі кольору фону
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СpGround_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            // установка кольору фону label
            lbText.Background = new SolidColorBrush(cpGround.SelectedColor.Value);
        }

        /// <summary>
        /// При виборі кольору тексту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CpText_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            // установка кольору тексту label
            lbText.Foreground = new SolidColorBrush(cpText.SelectedColor.Value);
        }

        /// <summary>
        /// При зміні повзунка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // установка розміру тексту
            lbText.FontSize = sSize.Value;
            // вивдення розміру
            if (tbSize != null)
            {
                tbSize.Text = lbText.FontSize.ToString("F0");
            }
        }

        /// <summary>
        /// При виборі стилю шрифта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // установка шрифта
            //lbText.FontStyle
        }
    }
}
