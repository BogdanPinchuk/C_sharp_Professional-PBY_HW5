using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LesApp3.Lib
{
    /// <summary>
    /// Налаштування (параметри) для збереження
    /// </summary>
    public struct Settings
    {
        //private SettingsColor foreground;// = new SettingsColor();
        //private SettingsColor background;// = new SettingsColor();
        //private SettingsFont fontStyle;// = new SettingsFont();

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
            foreach (var i in Foreground.GetValues())
                yield return i;
            // колір фону
            foreach (var i in Background.GetValues())
                yield return i;
            // розмір тексту
            yield return SizeFont.ToString();
            // назва шрифта
            yield return Font;
            // стиль шрифта
            foreach (var i in FontStyle.GetValues())
                yield return i;
        }

        /// <summary>
        /// Отримання всіх назв налаштувань
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetValueNames()
        {
            // колір тексту
            foreach (var i in Foreground.GetValueNames("Foreground"))
                yield return i;
            // колір фону
            foreach (var i in Background.GetValueNames("Background"))
                yield return i;
            // розмір тексту
            yield return "SizeFont";
            // назва шрифта
            yield return "Font";
            // стиль шрифта
            foreach (var i in FontStyle.GetValueNames("FontStyle"))
                yield return i;
        }

        /// <summary>
        /// Розпізнавання зчитаних даних і занесення в параметри
        /// </summary>
        /// <param name="data">вхідні дані</param>
        public void Recognition(Dictionary<string, string> data)
        {
            List<string> property = new List<string>();
            // колір тексту
            foreach (string i in Foreground.GetValueNames("Foreground"))
            {
                property.Add(data[i]);
            }
            Foreground = new SettingsColor().SetValues(property[0], property[1], property[2], property[3]);
            property.Clear();

            // колір фону
            foreach (string i in Foreground.GetValueNames("Background"))
            {
                property.Add(data[i]);
            }
            Background = new SettingsColor().SetValues(property[0], property[1], property[2], property[3]);
            property.Clear();

            // розмір шрифта
            {
                int temp = 0;
                if (int.TryParse(data["SizeFont"], out temp))
                {
                    SizeFont = temp;
                }
            }

            // шрифт
            Font = data["Font"];

            // стиль шрифта
            foreach (string i in FontStyle.GetValueNames("FontStyle"))
            {
                property.Add(data[i]);
            }
            FontStyle = new SettingsFont().SetValues(property[0], property[1]);
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
        public SettingsColor SetValues(string value, Cannel color)
        {
            // для збереження значення кольру
            int num = default(int);

            // конвертація даних в число
            if (!int.TryParse(value, out num))
                throw new Exception("Невірні вхідні дані.");

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

            return this;
        }

        /// <summary>
        /// Установка всіх кольорів
        /// </summary>
        /// <param name="a">альфа канал</param>
        /// <param name="r">червоний канал</param>
        /// <param name="g">зелений канал</param>
        /// <param name="b">синій канал</param>
        public SettingsColor SetValues(string a, string r, string g, string b)
        {
            SetValues(a, Cannel.A);
            SetValues(r, Cannel.R);
            SetValues(g, Cannel.G);
            SetValues(b, Cannel.B);

            return this;
        }

        /// <summary>
        /// Установка всіх кольорів
        /// </summary>
        /// <param name="a">альфа канал</param>
        /// <param name="r">червоний канал</param>
        /// <param name="g">зелений канал</param>
        /// <param name="b">синій канал</param>
        public SettingsColor SetValues(int a, int r, int g, int b)
        {
            A = a;
            R = r;
            G = g;
            B = b;

            return this;
        }

        /// <summary>
        /// Установка всіх кольорів
        /// </summary>
        /// <param name="color">колір</param>
        public SettingsColor SetValues(Color color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;

            return this;
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
        }

        /// <summary>
        /// Отримання кольору
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
            => new Color()
            {
                A = (byte)this.A,
                R = (byte)this.R,
                G = (byte)this.G,
                B = (byte)this.B,
            };

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
        /// Установка всіх параметрів стилю шрифта
        /// </summary>
        /// <param name="fs">курсив</param>
        /// <param name="fw">товщина</param>
        public SettingsFont SetValues(FontStyle fs, FontWeight fw)
        {
            FontStyle = fs;
            FontWeight = fw;

            return this;
        }

        /// <summary>
        /// Установка всіх параметрів стилю шрифта
        /// </summary>
        /// <param name="fs">FontStyle</param>
        /// <param name="fw">FontWeight</param>
        public SettingsFont SetValues(string fs, string fw)
        {
            FontStyle = SetFontStyle(fs);
            FontWeight = SetFontWeight(fw);

            return this;
        }

        /// <summary>
        /// Установка курсиву
        /// </summary>
        /// <param name="name">назва курсиву</param>
        public FontStyle SetFontStyle(string name)
        {
            if (name.ToLower() == "Italic".ToLower())
            {
                FontStyle = FontStyles.Italic;
            }
            else
            {
                FontStyle = FontStyles.Normal;
            }

            return FontStyle;
        }

        /// <summary>
        /// Установка потовщення
        /// </summary>
        /// <param name="name">назва потовщення</param>
        public FontWeight SetFontWeight(string name)
        {
            if (name.ToLower() == "Bold".ToLower())
            {
                FontWeight = FontWeights.Bold;
            }
            else
            {
                FontWeight = FontWeights.Normal;
            }

            return FontWeight;
        }

        /// <summary>
        /// Отримання параметрів стилю
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetValues()
        {
            yield return FontStyle.ToString();
            yield return FontWeight.ToString();
        }

        /// <summary>
        /// Отримання назв параметрів стилю
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetValueNames(string property)
        {
            yield return property + ".FontStyle";
            yield return property + ".FontWeight";
        }
    }

}
