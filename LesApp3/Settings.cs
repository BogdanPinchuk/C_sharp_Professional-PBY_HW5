using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LesApp3
{
    /// <summary>
    /// Налаштування (параметри) для збереження
    /// </summary>
    public struct Settings
    {
        /// <summary>
        /// Колір тексту
        /// </summary>
        public SettingsColor Foreground { get; set; }
        /// <summary>
        /// Колір фону
        /// </summary>
        public SettingsColor Background { get; set; }
        /// <summary>
        /// Розмір тексту
        /// </summary>
        public int SizeFont { get; set; }
        /// <summary>
        /// Назва шрифта
        /// </summary>
        public string Font { get; set; }
        /// <summary>
        /// Стиль шрифта
        /// </summary>
        public SettingsFont FontStyle { get; set; }

        /// <summary>
        /// Отримання всіх налаштувань
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetValues()
        {
            // колір тексту
            yield return Foreground.GetValues();
            // колір фону
            yield return Background.GetValues();
            // розмір тексту
            yield return SizeFont.ToString();
            // назва шрифта
            yield return Font;
            // стиль шрифта
            yield return FontStyle.GetValues();
            yield break;
        }
    }

    /// <summary>
    /// Колір параметрів
    /// </summary>
    public struct SettingsColor
    {
        public enum Cannel
        {
            /// <summary>
            /// Alpha cannel
            /// </summary>
            A,
            /// <summary>
            /// Red cannel
            /// </summary>
            R,
            /// <summary>
            /// Green cannel
            /// </summary>
            G,
            /// <summary>
            /// Blue cannel
            /// </summary>
            B
        }

        /// <summary>
        /// Alpha cannel
        /// </summary>
        public int A { get; set; }
        /// <summary>
        /// Red cannel
        /// </summary>
        public int R { get; set; }
        /// <summary>
        /// Green cannel
        /// </summary>
        public int G { get; set; }
        /// <summary>
        /// Blue cannel
        /// </summary>
        public int B { get; set; }

        /// <summary>
        /// Установка окремо по кольорам
        /// </summary>
        /// <param name="value">числове значення кольору</param>
        /// <param name="color">канал якому присвоїти колір</param>
        public void SetValue(string value, Cannel color)
        {
            // для збереження значення кольру
            int num = default(int);

            // конвертація даних в число
            if (!int.TryParse(value, out num))
                return;

            switch (color)
            {
                case Cannel.A:
                    A = num;
                    break;
                case Cannel.R:
                    R = num;
                    break;
                case Cannel.G:
                    G = num;
                    break;
                case Cannel.B:
                    B = num;
                    break;
            }
        }

        /// <summary>
        /// Установка всіх кольорів
        /// </summary>
        /// <param name="a">альфа канал</param>
        /// <param name="r">червоний канал</param>
        /// <param name="g">зелений канал</param>
        /// <param name="b">синій канал</param>
        public void SetValues(string a, string r, string g, string b)
        {
            SetValue(a, Cannel.A);
            SetValue(r, Cannel.R);
            SetValue(g, Cannel.G);
            SetValue(b, Cannel.B);
        }

        /// <summary>
        /// Отримання набору кольорів: ARGB
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetValues()
        {
            yield return A.ToString();
            yield return R.ToString();
            yield return G.ToString();
            yield return B.ToString();
            yield break;
        }

    }

    /// <summary>
    /// Стиль тексту
    /// </summary>
    public struct SettingsFont
    {
        /// <summary>
        /// Курсив
        /// </summary>
        public FontStyle FontStyle { get; set; }
        /// <summary>
        /// Потовщення
        /// </summary>
        public FontWeight FontWeight { get; set; }

        /// <summary>
        /// Отримання параиетрів стилю
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetValues()
        {
            yield return FontStyle.ToString();
            yield return FontWeight.ToString();
            yield break;
        }
    }
}
