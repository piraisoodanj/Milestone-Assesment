using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumLoginPageAssesment
{
    internal class Program
    {
        public static void Main()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");


            IWebElement UsernameField = driver.FindElement(By.Id("username"));
            IWebElement PasswordField = driver.FindElement(By.Id("password"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var script = "document.getElementById('submit').click();";   //JQuery
            



            EnterTextBox(UsernameField, "student");  //Username fill
            EnterTextBox(PasswordField, "Password123"); //Password Fill
            js.ExecuteScript(script);  //click login button



            IWebElement LoginSuccessPopup = driver.FindElement(By.XPath("//h1[@class='post-title']"));  //using XPath
            CheckLoginSuccessPopup(LoginSuccessPopup);



        }

        public static void EnterTextBox(IWebElement webElement, string textVal)
        {
            webElement.SendKeys(textVal);
        }

        public static void CheckLoginSuccessPopup(IWebElement successPopup)
        {
            var LoginSuccessText = successPopup.Text;
            if (LoginSuccessText == "Logged In Successfully")
            {
                Console.WriteLine("Successfully Logged In");
            }
            else
            {
                Console.WriteLine("Logg In Failed");
            }
        }
    }
}
