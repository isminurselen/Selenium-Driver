using EPATSProject.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace EPATSLib
{

    public class EPATS
    {
        public string Url { get; set; }
        public string TcNo { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string Nationality { get; set; }

    }


    public  class ReadEPATS
    { 

        public ReadEPATS()
        {

        }

        public static Company ReadEPATSPage(EPATS epats)
        {
            Company company = new Company();
            company.TaxNumber = epats.Number;
            company.Type = epats.Type;
            company.Nationality = epats.Nationality;

            ChromeOptions argument = new ChromeOptions();
            argument.AddArguments("--headless");

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            //IWebDriver driver = new ChromeDriver(service,argument);
            IWebDriver driver = new ChromeDriver(service);
            driver.Navigate().GoToUrl(epats.Url);
            driver.Manage().Window.Maximize();

            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("/html/body/div/div/form/div/div/div[1]/div/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));

                //login sayfası
                driver.FindElement(By.Id("tridField")).SendKeys(epats.TcNo);
                driver.FindElement(By.Id("egpField")).SendKeys(epats.Password);

                driver.FindElement(By.XPath("//*[@id='loginForm']/div[2]/input[4]")).Click();

                // Yeni başvurusu sayfası - başvuru türü seçimi
                Thread.Sleep(TimeSpan.FromSeconds(20));
                driver.FindElement(By.XPath("//*[@id='selectbox86']/div/div[2]/div[1]/div/div/div[1]")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.FindElement(By.XPath("//*[@id='ui-select-choices-row-0-3']/span/span")).Click();

                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[1]/div/div/div/div/div[2]/div[3]/div/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div")).Click();
                //*[@id="button24"]/div/div[1]/div/div

                Thread.Sleep(TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("/html/body/div/div/form/div[2]/div/div[2]/div/div/div/div[3]/div/div/div[5]/div/div/div/div/div[1]/div/div")).Click();
               

                // marka bilgisi sayfası        
                Thread.Sleep(TimeSpan.FromSeconds(10));
                driver.FindElement(By.XPath("//*[@id='selectbox722']/div/div[2]/div[1]/div/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/div/div/div[2]/div[1]/div/div/ul/li/div[3]/span")).Click();

                //marka örnek yok
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[3]/div/div[1]/div[2]/div/div[1]/div[1]/div/div/span[2]/input")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div[1]/div/div/div[2]/div[1]/input")).SendKeys("selen");
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div[2]/div/div/div[1]/div/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[9]/div/div/div/div/div[1]/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));
              
                // sınıf biligleri
                driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/div/div/div[1]/div/div/div/ul/li[1]/span[2]/span/input")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
              //  driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div/div/div/div[1]/div/div")).Click();
               // Thread.Sleep(TimeSpan.FromSeconds(2));

                // rüçhan bilgisi
                driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div/div/div/div[1]/div/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));

                // yeni kişi ekle
                driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[1]/div/div[2]/div[4]/div/div[1]/div/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));

                // sahip türü seçimi
                driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div/div/div[1]")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));

                if (epats.Type == "Gerçek")
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div/div/ul")).Click();

                if (epats.Type == "Tüzel")
                {

                    // tüzel tıklama
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div/div/ul/li/div[4]")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(10));

                    // uyruk tıkla
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[3]/div/div[2]/div[1]/div")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));

                    // uyruk seç                




                    if (epats.Nationality == "Türkiye")
                    {

                        driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[1]/div[1]/div/div[2]/div[1]/input")).SendKeys(epats.Number);
                        Thread.Sleep(TimeSpan.FromSeconds(10));

                        string title = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[1]/div[2]/div/div[2]")).Text;
                        company.Title = title.Trim();
                        Thread.Sleep(TimeSpan.FromSeconds(2));

                        string taxoffice = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[1]/div[3]/div/div[2]/div[1]/span")).Text;
                        company.TaxOffice = taxoffice.Trim();
                        Thread.Sleep(TimeSpan.FromSeconds(2));


                        string eposta = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[1]/div/div[2]/div[1]/input")).Text;
                        if (string.IsNullOrEmpty(eposta))
                        {
                            eposta = "dygmuhasebe@destekgroup.com.tr";
                            driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[1]/div/div[2]/div[1]/input")).SendKeys(eposta);
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            company.Email = null;
                        }
                        else
                        {
                            company.Email = eposta.Trim();
                        }



                        string phone = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[2]/div/div[2]/div[1]/input")).Text;
                        if (string.IsNullOrEmpty(phone))
                        {
                            phone = "533 290 52 52";
                            driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[2]/div/div[2]/div[1]/input")).SendKeys(phone);
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            company.Phone = null;
                        }
                        else
                        {
                           company.Phone = phone.Trim();
                        }
                        


                        

                    }
                    else
                    {
                        // yabancılar sahip no göre tıklama işlemleri
                        driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[4]/div/div[2]/div[1]/input")).Click();
                        Thread.Sleep(TimeSpan.FromSeconds(2));

                        driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div/div/div[2]/div[1]/input")).SendKeys(epats.Number);
                        Thread.Sleep(TimeSpan.FromSeconds(2));

                        driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[2]/div/div/div[1]/div/div")).Click();
                        Thread.Sleep(TimeSpan.FromSeconds(2));

                    }
                }
                // yeni kişi ekle kaydet
                driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[4]/div/div[2]/div/div/div[1]/div/div")).Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));

                string country = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[7]/div")).Text;
                Thread.Sleep(TimeSpan.FromSeconds(2));
                company.Country = country.Trim();


                string address = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[11]/div")).Text;
                Thread.Sleep(TimeSpan.FromSeconds(2));
                company.Address = address.Trim();

                string city = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[12]/div")).Text;
                Thread.Sleep(TimeSpan.FromSeconds(2));
                company.City = city.Trim();

                string county = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[13]/div")).Text;
                Thread.Sleep(TimeSpan.FromSeconds(2));
                company.County = county.Trim();

                driver.Close();
            }
            catch(Exception ex)
            {
                driver.Close();
                throw ex;
                
            }
            
            
            return company;
           
        }



        public static void ReadEPATSPage_(EPATS epats)
        {
         

            int i = 0;
            int status = 0;
            while (i < 2)
            {
                if (status==1)
                {
                    break;
                }

                Company company = new Company();
                company.TaxNumber = epats.Number;
                company.Type = epats.Type;
                company.Nationality = epats.Nationality;

                ChromeOptions argument = new ChromeOptions();
                argument.AddArguments("--headless");

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

                //IWebDriver driver = new ChromeDriver(service,argument);
                IWebDriver driver = new ChromeDriver(service);
                driver.Navigate().GoToUrl(epats.Url);
                driver.Manage().Window.Maximize();
                
                try
                {
                                     

                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    driver.FindElement(By.XPath("/html/body/div/div/form/div/div/div[1]/div/div")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));

                    //login sayfası
                    driver.FindElement(By.Id("tridField")).SendKeys(epats.TcNo);
                    driver.FindElement(By.Id("egpField")).SendKeys(epats.Password);

                    driver.FindElement(By.XPath("//*[@id='loginForm']/div[2]/input[4]")).Click();

                    // Yeni başvurusu sayfası - başvuru türü seçimi
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    driver.FindElement(By.XPath("//*[@id='selectbox86']/div/div[2]/div[1]/div/div/div[1]")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    driver.FindElement(By.XPath("//*[@id='ui-select-choices-row-0-3']/span/span")).Click();

                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[1]/div/div/div/div/div[2]/div[3]/div/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div")).Click();
                    //*[@id="button24"]/div/div[1]/div/div

                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    driver.FindElement(By.XPath("/html/body/div/div/form/div[2]/div/div[2]/div/div/div/div[3]/div/div/div[5]/div/div/div/div/div[1]/div/div")).Click();


                    // marka bilgisi sayfası        
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    driver.FindElement(By.XPath("//*[@id='selectbox722']/div/div[2]/div[1]/div/div")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/div/div/div[2]/div[1]/div/div/ul/li/div[3]/span")).Click();

                    //marka örnek yok
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[3]/div/div[1]/div[2]/div/div[1]/div[1]/div/div/span[2]/input")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
               
                    driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div[1]/div/div/div[2]/div[1]/input")).SendKeys("selen");
                    Thread.Sleep(TimeSpan.FromSeconds(2));
               
                    // marka örneği oluştur butonu
                     driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div[2]/div/div/div[1]/div/div")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));



                    // örneneği oluştur devam et butonu
                    driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    // devam et marka örnek
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[10]/div/div/div/div/div[1]/div/div")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(10));
               
                    // sınıf biligleri tıkla            
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/div/div/div[1]/div/div/div/ul/li[1]/span[2]/span/input")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
              
                    // sınıf devam et butonu
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div/div/div/div[1]/div/div")).Click();
                   Thread.Sleep(TimeSpan.FromSeconds(5));
                  

                    // rüçhan bilgisi
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div/div/div/div[1]/div/div")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(10));

                    // yeni kişi ekle
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[1]/div/div[2]/div[4]/div/div[1]/div/div")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));

                    // sahip türü seçimi
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div/div/div[1]")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(10));

                    if (epats.Type == "Gerçek")
                        driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div/div/ul")).Click();

                    if (epats.Type == "Tüzel")
                    {

                        // tüzel tıklama
                        driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div/div/ul/li/div[4]")).Click();
                        Thread.Sleep(TimeSpan.FromSeconds(3));

                        // uyruk tıkla
                        driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[3]/div/div[2]/div[1]/div")).Click();
                        Thread.Sleep(TimeSpan.FromSeconds(2));

                        // uyruk seç                




                        if (epats.Nationality == "Türkiye")
                        {

                            driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[1]/div[1]/div/div[2]/div[1]/input")).SendKeys(epats.Number);
                            Thread.Sleep(TimeSpan.FromSeconds(5));

                            string title = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[1]/div[2]/div/div[2]")).Text;
                            company.Title = title.Trim();
                            Thread.Sleep(TimeSpan.FromSeconds(2));

                            string taxoffice = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[1]/div[3]/div/div[2]/div[1]/span")).Text;
                            company.TaxOffice = taxoffice.Trim();
                            Thread.Sleep(TimeSpan.FromSeconds(2));


                            string eposta = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[1]/div/div[2]/div[1]/input")).Text;
                            if (string.IsNullOrEmpty(eposta))
                            {
                                eposta = "dygmuhasebe@destekgroup.com.tr";
                                driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[1]/div/div[2]/div[1]/input")).SendKeys(eposta);
                                Thread.Sleep(TimeSpan.FromSeconds(1));
                                company.Email = null;
                            }
                            else
                            {
                                company.Email = eposta.Trim();
                            }



                            string phone = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[2]/div/div[2]/div[1]/input")).Text;
                            if (string.IsNullOrEmpty(phone))
                            {
                                phone = "533 290 52 52";
                                driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[2]/div/div[2]/div[1]/input")).SendKeys(phone);
                                Thread.Sleep(TimeSpan.FromSeconds(1));
                                company.Phone = null;
                            }
                            else
                            {
                                company.Phone = phone.Trim();
                            }





                        }
                        else
                        {
                            // yabancılar sahip no göre tıklama işlemleri
                            driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[4]/div/div[2]/div[1]/input")).Click();
                            Thread.Sleep(TimeSpan.FromSeconds(1));

                            driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div/div/div[2]/div[1]/input")).SendKeys(epats.Number);
                            Thread.Sleep(TimeSpan.FromSeconds(1));

                            driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[2]/div/div/div[1]/div/div")).Click();
                            Thread.Sleep(TimeSpan.FromSeconds(1));

                        }
                    }
                    // yeni kişi ekle kaydet
                    driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[4]/div/div[2]/div/div/div[1]/div/div")).Click();
                    Thread.Sleep(TimeSpan.FromSeconds(10));

                    string country = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[7]/div")).Text;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    company.Country = country.Trim();


                    string address = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[11]/div")).Text;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    company.Address = address.Trim();

                    string city = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[12]/div")).Text;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    company.City = city.Trim();

                    string county = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[13]/div")).Text;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    company.County = county.Trim();

                    driver.Close();
                    status = 1;
                }
                catch(Exception ex)
                {
                    driver.Close();
                    status = 0;
                    throw ex;
                }

                i++;
            }

        }



    }
}
