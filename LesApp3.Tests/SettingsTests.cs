using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LesApp3.Lib.Tests.Stub;
using System.Windows.Media;
using System.Diagnostics;

namespace LesApp3.Lib.Tests
{
    [TestClass]
    public class SettingsTests
    {
        /// <summary>
        /// Налаштування
        /// </summary>
        Settings settings;

        [TestInitialize]
        public void Initialize_Settings()
        {
            settings = new Settings();
        }

        [TestMethod]
        public void Settings_FontStyle_Equal()
        {
            // assert
            Assert.AreEqual(StubObj.FontStyle_N, settings.FontStyle.FontStyle);
            Assert.AreEqual(StubObj.FontWeight_N, settings.FontStyle.FontWeight);

            // arrange
            settings.FontStyle = new SettingsFont().SetValues(StubObj.FontStyle_I, StubObj.FontWeight_B);

            // assert
            Assert.AreEqual(StubObj.FontStyle_I, settings.FontStyle.FontStyle);
            Assert.AreEqual(StubObj.FontWeight_B, settings.FontStyle.FontWeight);
        }

        [TestMethod]
        public void Settings_StyleGround_Equal()
        {
            // arrange
            SettingsColor stub = new SettingsColor().SetValues(StubObj.ColorGold);
            settings.Background = stub;
            settings.Foreground = stub;

            // assert
            Assert.AreEqual(stub, settings.Background);
            Assert.AreEqual(stub, settings.Foreground);
        }

        [TestMethod]
        public void Settings_SizeFont_Equal()
        {
            // arrange
            settings.SizeFont = StubObj.FontSize;

            // assert
            Assert.AreEqual(StubObj.FontSize, settings.SizeFont);
        }

        [TestMethod]
        public void Settings_Font_Equal()
        {
            // arrange
            settings.Font = StubObj.Font;

            // assert
            Assert.AreEqual(StubObj.Font, settings.Font);
        }

        [TestMethod]
        public void GetValues_AllValues()
        {
            // arrange
            SettingsColor stub = new SettingsColor().SetValues(StubObj.ColorGold);
            settings.Background = stub;
            settings.Foreground = stub;
            settings.SizeFont = StubObj.FontSize;
            settings.Font = StubObj.Font;
            settings.FontStyle = new SettingsFont().SetValues(StubObj.FontStyle_I, StubObj.FontWeight_B);

            // assert
            int j = 0;
            foreach (var i in settings.GetValues())
            {
                Assert.AreEqual(StubObj.ListValues[j++], i);
            }

            foreach (var i in settings.GetValues())
            {
                Debug.WriteLine(i);
            }
        }

        [TestMethod]
        public void GetValues_AllValueNames()
        {
            // assert
            int j = 0;
            foreach (var i in settings.GetValueNames())
            {
                Assert.AreEqual(StubObj.ListValueNames[j++], i);
            }

            foreach (var i in settings.GetValueNames())
            {
                Debug.WriteLine(i);
            }
        }

        [TestMethod]
        public void GetProperties_All()
        {
            // arrange
            SettingsColor stub = new SettingsColor().SetValues(StubObj.ColorGold);
            settings.Background = stub;
            settings.Foreground = stub;
            settings.SizeFont = StubObj.FontSize;
            settings.Font = StubObj.Font;
            settings.FontStyle = new SettingsFont().SetValues(StubObj.FontStyle_I, StubObj.FontWeight_B);

            // assert
            int j = 0;
            foreach (var i in settings.GetProperties())
            {
                Assert.AreEqual(StubObj.ListProperties.Keys.ElementAt(j), i.Key);
                Assert.AreEqual(StubObj.ListProperties.Values.ElementAt(j++), i.Value);
            }

            // present
            foreach (var i in settings.GetProperties())
            {
                Debug.WriteLine($"{i.Key} : {i.Value}");
            }
        }
    }
}
