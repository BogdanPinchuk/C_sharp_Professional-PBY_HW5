using Microsoft.VisualStudio.TestTools.UnitTesting;
using LesApp3.Tests.Stub;
using System.Diagnostics;

namespace LesApp3.Tests
{
    [TestClass]
    public class SettingsFontTests
    {
        /// <summary>
        /// Стиль тексту
        /// </summary>
        SettingsFont sf;

        [TestInitialize]
        public void Initialize_SettingsFont()
        {
            sf = new SettingsFont();
        }

        [TestMethod]
        public void FontStyle_Italic_Equal()
        {
            // assert
            Assert.AreEqual(StubObj.FontStyle_N, sf.FontStyle);

            // arrange
            sf.FontStyle = StubObj.FontStyle_I;

            // assert
            Assert.AreEqual(StubObj.FontStyle_I, sf.FontStyle);
        }

        [TestMethod]
        public void FontWeight_Bold_Equal()
        {
            // assert
            Assert.AreEqual(StubObj.FontWeight_N, sf.FontWeight);

            // arrange
            sf.FontWeight = StubObj.FontWeight_B;

            // assert
            Assert.AreEqual(StubObj.FontWeight_B, sf.FontWeight);
        }

        [TestMethod]
        public void SetValues_BoldItalic_Equal()
        {
            // assert
            Assert.AreEqual(StubObj.FontStyle_N, sf.FontStyle);
            Assert.AreEqual(StubObj.FontWeight_N, sf.FontWeight);

            // act
            sf.SetValues(StubObj.FontStyle_I, StubObj.FontWeight_B);

            // assert
            Assert.AreEqual(StubObj.FontStyle_I, sf.FontStyle);
            Assert.AreEqual(StubObj.FontWeight_B, sf.FontWeight);
        }

        [TestMethod]
        public void SetFontStyle_Italic_Equal()
        {
            // arrange
            string stub = StubObj.FontStyle_I.ToString();
            Debug.WriteLine(stub);

            // act
            sf.SetFontStyle(stub);

            // assert
            Assert.AreEqual(StubObj.FontStyle_I, sf.FontStyle);
        }

        [TestMethod]
        public void SetFontWeight_Bold_Equal()
        {
            // arrange
            string stub = StubObj.FontWeight_B.ToString();
            Debug.WriteLine(stub);

            // act
            sf.SetFontWeight(stub);

            // assert
            Assert.AreEqual(StubObj.FontWeight_B, sf.FontWeight);
        }

        [TestMethod]
        public void GetValues_NormalNormal()
        {
            // assert
            int j = 0;
            foreach (var i in sf.GetValues())
            {
                Assert.AreEqual(StubObj.ListValues_NN[j++], i);
            }

            foreach (var i in sf.GetValues())
            {
                Debug.WriteLine(i);
            }
        }

        [TestMethod]
        public void GetValues_ItalicBold()
        {
            // act
            sf.SetValues(StubObj.FontStyle_I, StubObj.FontWeight_B);

            // assert
            int j = 0;
            foreach (var i in sf.GetValues())
            {
                Assert.AreEqual(StubObj.ListValues_IB[j++], i);
            }

            foreach (var i in sf.GetValues())
            {
                Debug.WriteLine(i);
            }
        }

        [TestMethod]
        public void GetValueNames_Names()
        {
            // arange
            string stub = "FontStyle";

            // assert
            int j = 0;
            foreach (var i in sf.GetValueNames(stub))
            {
                Assert.AreEqual(StubObj.ListValueNames_Style[j++], i);
            }

            foreach (var i in sf.GetValueNames(stub))
            {
                Debug.WriteLine(i);
            }
        }

    }
}
