using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LesApp3.Tests.Stub
{
    /// <summary>
    /// Заглушки
    /// </summary>
    public static class StubObj
    {
        #region SettingsFont
        /// <summary>
        /// Italic
        /// </summary>
        public static FontStyle FontStyle_I => FontStyles.Italic;
        /// <summary>
        /// Normal
        /// </summary>
        public static FontStyle FontStyle_N => FontStyles.Normal;

        /// <summary>
        /// Bold
        /// </summary>
        public static FontWeight FontWeight_B => FontWeights.Bold;
        /// <summary>
        /// Normal
        /// </summary>
        public static FontWeight FontWeight_N => FontWeights.Normal;

        /// <summary>
        /// Returned Italic-Bold
        /// </summary>
        public static List<string> ListValues_IB
            => new List<string>() { "Italic", "Bold" };
        /// <summary>
        /// Returned Normal-Normal
        /// </summary>
        public static List<string> ListValues_NN
            => new List<string>() { "Normal", "Normal", };
        /// <summary>
        /// Returned FontStyle-FontWeight
        /// </summary>
        public static List<string> ListValueNames_Style
            => new List<string>() { "FontStyle.FontStyle", "FontStyle.FontWeight", };
        #endregion

        #region SettingsColor
        /// <summary>
        /// Золотий колір
        /// </summary>
        public static Color ColorGold => Colors.Gold;
        /// <summary>
        /// Returned Color Gold as string
        /// </summary>
        public static List<string> ListColorValues
            => new List<string>() { ColorGold.A.ToString(),
                ColorGold.R.ToString(),
                ColorGold.G.ToString(),
                ColorGold.B.ToString()};
        /// <summary>
        /// Returned Foreground-ARGB
        /// </summary>
        public static List<string> ListValueNames_ColorForeground
            => new List<string>() { "Foreground.A",
                "Foreground.R",
                "Foreground.G",
                "Foreground.B",};
        /// <summary>
        /// Returned Background-ARGB
        /// </summary>
        public static List<string> ListValueNames_ColorBackground
            => new List<string>() { "Background.A",
                "Background.R",
                "Background.G",
                "Background.B",};
        /// <summary>
        /// Size of font
        /// </summary>
        public static int FontSize => 27;
        /// <summary>
        /// Font
        /// </summary>
        public static string Font => new FontFamily("Arial").Source;
        /// <summary>
        /// All parameters
        /// </summary>
        public static List<string> ListValues
            => new List<string>()
            {
                ListColorValues[0],
                ListColorValues[1],
                ListColorValues[2],
                ListColorValues[3],

                ListColorValues[0],
                ListColorValues[1],
                ListColorValues[2],
                ListColorValues[3],

                FontSize.ToString(),
                Font,

                ListValues_IB[0],
                ListValues_IB[1],

            };
        /// <summary>
        /// All parameter names
        /// </summary>
        public static List<string> ListValueNames
            => new List<string>()
            {
                ListValueNames_ColorForeground[0],
                ListValueNames_ColorForeground[1],
                ListValueNames_ColorForeground[2],
                ListValueNames_ColorForeground[3],

                ListValueNames_ColorBackground[0],
                ListValueNames_ColorBackground[1],
                ListValueNames_ColorBackground[2],
                ListValueNames_ColorBackground[3],

                "SizeFont",
                "Font",

                ListValueNames_Style[0],
                ListValueNames_Style[1],
            };

        /// <summary>
        /// Налаштування і назви
        /// </summary>
        public static Dictionary<string, string> ListProperties
        {
            get
            {
                Dictionary<string, string> dic =
                    new Dictionary<string, string>();
                for (int i = 0; i < ListValues.Count; i++)
                {
                    dic.Add(ListValueNames[i], ListValues[i]);
                }

                return dic;
            }
        }
        #endregion

    }
}
