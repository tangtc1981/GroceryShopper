﻿using NUnit.Framework;
using Xamarin.UITest;

namespace GroceryShopper.XamarinUITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class UITests
    {
        private readonly Platform _platform;
        private IApp _app;

        public UITests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void TestSetup()
        {
            _app = XamarinUiTestInitializer.ConfigureAndStart(_platform, TestEnvironment.IsTestCloud);
        }

        [Test]
        public void AssertOverviewScreen()
        {
            _app.WaitForElement(v => v.Button("btnAddItem"));
            _app.WaitForElement(v => v.Id("imgBackground"));
        }

        [Test]
        public void CheckForDefaultMeatItem()
        {
            _app.WaitForElement(v => v.Text("2kg"));
            _app.WaitForElement(v => v.Text("Meat"));
            _app.WaitForElement(v => v.Text("A nice Roastbeef"));
        }

        [Test]
        public void DeleteSugar()
        {
            _app.WaitForElement(v => v.Text("Sugar"));
            _app.Tap(v => v.Id("btnDeleteItem"));
            _app.WaitForElement(v => v.Text("Do you really want to delete this item?"));            
            _app.Tap(v => v.Text("OK"));
            _app.WaitForNoElement(v => v.Text("Sugar"));
        }

        [Test]
        public void AddNewItemUnfinished()
        {
            // Act
            _app.Tap(v => v.Id("btnAddItem"));

            _app.EnterText(v => v.Id("editNotes"), "Fresh Salmon");
            _app.TapCoordinates(0, 0);

            _app.Tap(v => v.Text("Save"));

            // Assert 
            _app.WaitForElement(v => v.Text("Please check your input"));
        }

        [Test]
        public void AddNewItem()
        {
            // Act
            _app.Tap(v => v.Id("btnAddItem"));
            
            _app.EnterText(v => v.Id("editAmount"), "4");
            _app.TapCoordinates(0,0);

            _app.Tap(v => v.Class("MvxSpinner"));
            _app.WaitForElement(v => v.Text("Other"));
            _app.Tap(v => v.Text("Fish"));

            _app.EnterText(v => v.Id("editNotes"), "Fresh Salmon");

            _app.Tap(v => v.Text("Save"));

            // Assert 
            _app.WaitForElement(v => v.Text("Fresh Salmon"));
        }
    }
}