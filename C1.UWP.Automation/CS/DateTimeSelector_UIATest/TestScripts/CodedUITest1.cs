using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Windows.Automation;
using System.Linq;

namespace TestScripts
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }


        [TestMethod]
        public void Test_ValuePattern()
        {
            //Launch app 
            XamlWindow samplewindow = XamlWindow.Launch(
                "10da12ee-a022-4719-88bb-93272747b2c1_3gp2x379966ha!App");

            System.Threading.Thread.Sleep(3000);

            XamlWindow MS_XAML_DateTimeSelector_UIATest = new XamlWindow();
            MS_XAML_DateTimeSelector_UIATest.SearchProperties[XamlWindow.PropertyNames.Name] = "DateTimeSelector_UIATest2015";

            var DateTimeSelector_UIATest = AutomationElement.RootElement.FindFirst
            (TreeScope.Children, new System.Windows.Automation.PropertyCondition(AutomationElement.NameProperty,
            "DateTimeSelector_UIATest2015"));
            DateTimeSelector_UIATest = DateTimeSelector_UIATest.FindFirst(TreeScope.Children, Condition.TrueCondition);

            var datetimeselector = DateTimeSelector_UIATest.FindFirst(TreeScope.Children, 
                new System.Windows.Automation.PropertyCondition(AutomationElement.AutomationIdProperty, "datetimeselector"));

            //Tap the button (in which "3/19/2010" date is set to SelectedDate)
            var btn_Set = new XamlButton(MS_XAML_DateTimeSelector_UIATest);
            btn_Set.SearchProperties[XamlButton.PropertyNames.AutomationId] = "btn_Set";
            Gesture.Tap(btn_Set);

            //CodedUI does not recognize DateSelector control , so we can't use valuepattern
            //var DateEditor = new XamlControl(MS_XAML_DateTimeSelector_UIATest);
            //DateEditor.SearchProperties[XamlControl.PropertyNames.AutomationId] = "DateEditor";

            //var msg = "Before:" + DateEditor.FriendlyName;

            //object _valuepattern = null;
            //if (datetimeselector.TryGetCurrentPattern(ValuePattern.Pattern, out _valuepattern))
            //{
            //    ((ValuePattern)_valuepattern).SetValue("10/23/2010");
            //}

            //msg += ".After:" + DateEditor.FriendlyName;

            //Assert.AreEqual("Before:3/19/2010.After:10/23/2010", msg);
            System.Threading.Thread.Sleep(2000);

            var msg = "Before:" + GetDateTime(MS_XAML_DateTimeSelector_UIATest);

            XamlComboBox CboDays = new XamlComboBox(MS_XAML_DateTimeSelector_UIATest);
            CboDays.SearchProperties[XamlComboBox.PropertyNames.AutomationId] = "DaysList";
            XamlComboBox CboMonths = new XamlComboBox(MS_XAML_DateTimeSelector_UIATest);
            CboMonths.SearchProperties[XamlComboBox.PropertyNames.AutomationId] = "MonthsList";
            XamlComboBox CboYears = new XamlComboBox(MS_XAML_DateTimeSelector_UIATest);
            CboYears.SearchProperties[XamlComboBox.PropertyNames.AutomationId] = "YearsList";

            CboYears.SelectedItem = "2010";
            CboMonths.SelectedItem = "October";
            CboDays.SelectedIndex = 22;

            msg += ".After:" + GetDateTime(MS_XAML_DateTimeSelector_UIATest);
            Assert.AreEqual("Before:19/March/2010/12/00/AM/.After:23/October/2010/12/00/AM/", msg);
        }

        public string GetDateTime(XamlWindow Window)
        {
            string selectedDateTime = "";
            Window.GetChildren().ToList()
                .Where(ctrl => ctrl.ControlType.Name == "ComboBox").ToList()
                .ForEach(ctrl => selectedDateTime += (ctrl as XamlComboBox).SelectedItem.ToString() + "/");

            return selectedDateTime;
        }


        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
