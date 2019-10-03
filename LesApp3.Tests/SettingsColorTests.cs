using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LesApp3.Tests.Stub;
using System.Windows.Media;
using System.Diagnostics;

namespace LesApp3.Tests
{
    [TestClass]
    public class SettingsColorTests
    {
        /// <summary>
        /// Кольори
        /// </summary>
        SettingsColor sc;

        [TestInitialize]
        public void Initialize_SettingsColor()
        {
            sc = new SettingsColor();
        }

        [TestMethod]
        public void StyleGround_ARGB_Equal()
        {
            // arrange
            Color color = StubObj.ColorGold;
            sc.A = color.A;
            sc.R = color.R;
            sc.G = color.G;
            sc.B = color.B;

            // assert
            color = Color.FromArgb((byte)sc.A, (byte)sc.R, (byte)sc.G, (byte)sc.B);
            Assert.AreEqual(StubObj.ColorGold, color);
        }

        [TestMethod]
        public void SetValues_StringCannel_Equal()
        {
            // arrange
            Color color = StubObj.ColorGold;

            // act
            sc.SetValues(color.A.ToString(), SettingsColor.Cannel.A);
            sc.SetValues(color.R.ToString(), SettingsColor.Cannel.R);
            sc.SetValues(color.G.ToString(), SettingsColor.Cannel.G);
            sc.SetValues(color.B.ToString(), SettingsColor.Cannel.B);

            // assert
            color = Color.FromArgb((byte)sc.A, (byte)sc.R, (byte)sc.G, (byte)sc.B);
            Assert.AreEqual(StubObj.ColorGold, color);
        }

        [TestMethod]
        public void SetValues_Strings_Equal()
        {
            // arrange
            Color color = StubObj.ColorGold;

            // act
            sc.SetValues(color.A.ToString(), 
                color.R.ToString(),
                color.G.ToString(),
                color.B.ToString());

            // assert
            color = Color.FromArgb((byte)sc.A, (byte)sc.R, (byte)sc.G, (byte)sc.B);
            Assert.AreEqual(StubObj.ColorGold, color);
        }

        [TestMethod]
        public void SetValues_Ints_Equal()
        {
            // arrange
            Color color = StubObj.ColorGold;

            // act
            sc.SetValues(color.A, color.R, color.G, color.B);

            // assert
            color = Color.FromArgb((byte)sc.A, (byte)sc.R, (byte)sc.G, (byte)sc.B);
            Assert.AreEqual(StubObj.ColorGold, color);
        }

        [TestMethod]
        public void SetValues_Color_Equal()
        {
            // arrange
            Color color = StubObj.ColorGold;

            // act
            sc.SetValues(color);

            // assert
            color = Color.FromArgb((byte)sc.A, (byte)sc.R, (byte)sc.G, (byte)sc.B);
            Assert.AreEqual(StubObj.ColorGold, color);
        }

        [TestMethod]
        public void GetValues_ARGB()
        {
            // arrange
            Color color = StubObj.ColorGold;

            // act
            sc.SetValues(color);

            // assert
            int j = 0;
            foreach (var i in sc.GetValues())
            {
                Assert.AreEqual(StubObj.ListColorValues[j++], i);
            }

            foreach (var i in sc.GetValues())
            {
                Debug.WriteLine(i);
            }
        }

        [TestMethod]
        public void GetValueNames_Names()
        {
            // arange
            string stub = "Foreground";

            // assert
            int j = 0;
            foreach (var i in sc.GetValueNames(stub))
            {
                Assert.AreEqual(StubObj.ListValueNames_ColorForeground[j++], i);
            }

            foreach (var i in sc.GetValueNames(stub))
            {
                Debug.WriteLine(i);
            }

            // arrange
            stub = "Background";

            // assert
            j = 0;
            foreach (var i in sc.GetValueNames(stub))
            {
                Assert.AreEqual(StubObj.ListValueNames_ColorBackground[j++], i);
            }

            foreach (var i in sc.GetValueNames(stub))
            {
                Debug.WriteLine(i);
            }
        }
    }
}
