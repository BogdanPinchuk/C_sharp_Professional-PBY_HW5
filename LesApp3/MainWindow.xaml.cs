﻿using System;
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
            // зчитування індекса вибраного елемента
            int index = cbFont.SelectedIndex;
            // знаходження назви елемента
            string font = Fonts.SystemFontFamilies.ElementAt(index).Source;
            // установка шрифта
            lbText.FontFamily = new FontFamily(font);
        }

        /// <summary>
        /// Установка стилю шотфта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbStyle_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            // зчитування індекса вибраного елемента
            int index = cbStyle.SelectedIndex;
            // згідно вибору встановлення стилю
            switch (index)
            {
                case 1: // Italic
                    lbText.FontStyle = FontStyles.Italic;
                    lbText.FontWeight = FontWeights.Normal;
                    break;
                case 2: // Bold
                    lbText.FontStyle = FontStyles.Normal;
                    lbText.FontWeight = FontWeights.Bold;
                    break;
                case 3: // Bold-Italic
                    lbText.FontStyle = FontStyles.Italic;
                    lbText.FontWeight = FontWeights.Bold;
                    break;
                default:    // normal
                    lbText.FontStyle = FontStyles.Normal;
                    lbText.FontWeight = FontWeights.Normal;
                    break;
            }

        }
    }
}
