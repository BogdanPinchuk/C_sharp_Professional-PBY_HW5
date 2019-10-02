using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LesApp3
{
    /// <summary>
    /// Налаштування (параметри) для збереження
    /// </summary>
    public class Settings
    {
        private SettingsColor foreground = new SettingsColor();
        private SettingsColor background = new SettingsColor();
        private SettingsFont fontStyle = new SettingsFont();

        /// <summary>
        /// Колір тексту
        /// </summary>
        public SettingsColor Foreground
        {
            get { return foreground; }
            set { foreground = value; }
        }
        /// <summary>
        /// Колір фону
        /// </summary>
        public SettingsColor Background
        {
            get { return background; }
            set { background = value; }
        }
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
        public SettingsFont FontStyle
        {
            get { return fontStyle; }
            set { fontStyle = value; }
        }

        /// <summary>
        /// Отримання всіх налаштувань в парі назва-значення
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetProperties()
        {
            List<string> name = new List<string>(),
                value = new List<string>();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (string i in GetValueNames())
                name.Add(i);

            foreach (string i in GetValues())
                value.Add(i);

            for (int i = 0; i < name.Count; i++)
                dict.Add(name[i], value[i]);

            return dict;
        }

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

        /// <summary>
        /// Отримання всіх назв налаштувань
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetValueNames()
        {
            // колір тексту
            yield return Foreground.GetValueNames("Foreground");
            // колір фону
            yield return Background.GetValueNames("Background");
            // розмір тексту
            yield return SizeFont.ToString();
            // назва шрифта
            yield return Font;
            // стиль шрифта
            yield return FontStyle.GetValueNames("FontStyle");
            yield break;
        }
    }

    /// <summary>
    /// Колір параметрів
    /// </summary>
    public class SettingsColor
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

        private int a, r, g, b;

        /// <summary>
        /// Alpha cannel
        /// </summary>
        public int A
        {
            get { return a; }
            set { a = value; }
        }
        /// <summary>
        /// Red cannel
        /// </summary>
        public int R
        {
            get { return r; }
            set { r = value; }
        }
        /// <summary>
        /// Green cannel
        /// </summary>
        public int G
        {
            get { return g; }
            set { g = value; }
        }
        /// <summary>
        /// Blue cannel
        /// </summary>
        public int B
        {
            get { return b; }
            set { b = value; }
        }

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
        /// Установка всіх кольорів
        /// </summary>
        /// <param name="a">альфа канал</param>
        /// <param name="r">червоний канал</param>
        /// <param name="g">зелений канал</param>
        /// <param name="b">синій канал</param>
        public void SetValues(int a, int r, int g, int b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Установка всіх кольорів
        /// </summary>
        /// <param name="color">колір</param>
        public void SetValues(Color color)
        {
            this.a = color.A;
            this.r = color.R;
            this.g = color.G;
            this.b = color.B;
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

        /// <summary>
        /// Отримання назв набору кольорів: ARGB
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetValueNames(string property)
        {
            yield return property + ".A";
            yield return property + ".R";
            yield return property + ".G";
            yield return property + ".B";
            yield break;
        }

    }

    /// <summary>
    /// Стиль тексту
    /// </summary>
    public class SettingsFont
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
        /// Установка всіх параметрів
        /// </summary>
        /// <param name="fs">курсив</param>
        /// <param name="fw">товщина</param>
        public void SetValues(FontStyle fs, FontWeight fw)
        {
            FontStyle = fs;
            FontWeight = fw;
        }

        /// <summary>
        /// Установка курсиву
        /// </summary>
        /// <param name="name">назва курсиву</param>
        public void SetFontStyle(string name)
        {
            if (name.ToLower() == "Italic".ToLower())
            {
                FontStyle = FontStyles.Italic;
            }
            else
            {
                FontStyle = FontStyles.Normal;
            }
        }

        /// <summary>
        /// Установка потовщення
        /// </summary>
        /// <param name="name">назва потовщення</param>
        public void SetFontWeight(string name)
        {
            if (name.ToLower() == "Bold".ToLower())
            {
                FontWeight = FontWeights.Bold;
            }
            else
            {
                FontWeight = FontWeights.Normal;
            }
        }

        /// <summary>
        /// Отримання параметрів стилю
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetValues()
        {
            yield return FontStyle.ToString();
            yield return FontWeight.ToString();
            yield break;
        }

        /// <summary>
        /// Отримання назв параметрів стилю
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetValueNames(string property)
        {
            yield return property + "FontStyle";
            yield return property + "FontWeight";
            yield break;
        }
    }

    //todo: Реалізувати через числові дані
}
