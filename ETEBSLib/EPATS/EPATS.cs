using EPATSProject.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


    public static class ReadEPATS
    {




        public static Company ReadEPATSPage(EPATS epats)
        {
            Company company = new Company();
            company.TaxNumber = epats.Number;
            company.Type = epats.Type;
            company.Nationality = epats.Nationality;



            int i = 0;
            int status = 0;
            while (i <= 2)
            {


                if (status == 1)
                {
                  //  Console.WriteLine(company.Address);
                   // Console.ReadLine();
                    break;
                    
                }



                ChromeOptions argument = new ChromeOptions();
                argument.AddArguments("--headless");

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;

              //  IWebDriver driver = new ChromeDriver(service, argument);
                IWebDriver driver = new ChromeDriver(service);
                driver.Navigate().GoToUrl(epats.Url);
                driver.Manage().Window.Maximize();

                Thread.Sleep(TimeSpan.FromSeconds(10));



                var entry = driver.FindElementWithWait(By.XPath("/html/body/div/div/form/div/div/div[1]/div/div"));
                if (entry != null)
                {
                    entry.Click();
                }

                //login sayfası
                var no = driver.FindElementWithWait(By.Id("tridField"));
                if (no != null)
                {
                    no.SendKeys(epats.TcNo);
                }

                var psw = driver.FindElementWithWait(By.Id("egpField"));
                if (psw != null)
                {
                    psw.SendKeys(epats.Password);
                }

                var loginclick = driver.FindElementWithWait(By.XPath("//*[@id='loginForm']/div[2]/input[4]"));
                if (loginclick != null)
                {
                    loginclick.Click();
                }

                // yeni başvuru sayfası- başvuru türü seçimi
                Thread.Sleep(TimeSpan.FromSeconds(5));
                var apptypeclick = driver.FindElementWithWait(By.XPath("//*[@id='selectbox86']/div/div[2]/div[1]/div/div/div[1]/span"));
                if (apptypeclick != null)
                {
                    apptypeclick.Click();
                }
                //*[@id="selectbox86"]/div/div[2]/div[1]/div/div/input[1]
                //*[@id="selectbox86"]/div/div[2]/div[1]/div/div/div[1]/span
                //*[@id="selectbox86"]/div/div[2]/div[1]/div/div/div[1]
                

                var apptypeselect = driver.FindElementWithWait(By.XPath("//*[@id='ui-select-choices-row-0-3']/span/span"));
                if (apptypeselect != null)
                {
                    apptypeselect.Click();
                }


                var apptypegobuton = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[1]/div/div/div/div/div[2]/div[3]/div/div/div/div/div/div/div/div[2]/div/div/div[1]/div/div"));
                if (apptypegobuton != null)
                {
                    apptypegobuton.Click();
                }


                var apptypecontinue = driver.FindElementWithWait(By.XPath("/html/body/div/div/form/div[2]/div/div[2]/div/div/div/div[3]/div/div/div[5]/div/div/div/div/div[1]/div/div"));
                if (apptypecontinue != null)
                {
                    apptypecontinue.Click();
                }

                // marka bilgisi sayfası        

                var tardemarktype = driver.FindElementWithWait(By.XPath("//*[@id='selectbox722']/div/div[2]/div[1]/div/div/div[1]/span"));
                if (tardemarktype != null)
                {
                    tardemarktype.Click();
                }


                var tardemarkselect = driver.FindElementWithWait(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/div/div/div[2]/div[1]/div/div/ul/li/div[3]/span"));
                if (tardemarkselect != null)
                {
                    tardemarkselect.Click();
                }

                //marka örnek yok

                var tardemarkimageselect = driver.FindElementWithWait(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[3]/div/div[1]/div[2]/div/div[1]/div[1]/div/div/span[2]/input"));
                if (tardemarkimageselect != null)
                {
                    tardemarkimageselect.Click();
                }

                var tardemark = driver.FindElementWithWait(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div[1]/div/div/div[2]/div[1]/input"));
                if (tardemark != null)
                {
                    tardemark.SendKeys("selen");
                }


                var tardemarkimagecreatebuton = driver.FindElementWithWait(By.XPath("/html/body/div/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div[2]/div/div/div[1]/div/div"));
                if (tardemarkimagecreatebuton != null)
                {
                    tardemarkimagecreatebuton.Click();
                }

                var tardemarkimagecreatecontinue = driver.FindElementWithWait(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
                if (tardemarkimagecreatecontinue != null)
                {
                    tardemarkimagecreatecontinue.Click();
                }


                var tardemarkcontinuebuton = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[9]/div/div/div/div/div[1]/div/div"));
                if (tardemarkcontinuebuton != null)
                {
                    tardemarkcontinuebuton.Click();
                }

                // sınıf biligleri tıkla            

                var tardemarkclass = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/div/div/div[1]/div/div/div/ul/li[1]/span[2]/span/input"));
                if (tardemarkclass != null)
                {
                    tardemarkclass.Click();
                }

                var tardemarkclassbuton = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div/div/div/div[1]/div/div"));
                if (tardemarkclassbuton != null)
                {
                    tardemarkclassbuton.Click();
                }

                // rüçhan/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div/div/div/div[1]/div/div
                //var ruchan = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div/div/div/div[1]/div/div"));
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var ruchan = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[3]/div/div[2]/div/div/div/div[2]/div/div/div[4]/div/div/div/div/div[1]/div/div"));
                if (ruchan != null)
                {
                    ruchan.Click();
                }

                // yeni kişi ekle sayfası
                var person = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[1]/div/div[2]/div[4]/div/div[1]/div/div"));
                if (person != null)
                {
                    person.Click();
                }



                // sahip türü seçimi

                var persontype = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div/div/div[1]"));
                if (persontype != null)
                {
                    persontype.Click();
                }

                if (epats.Type == "Gerçek")
                {
                    var persontypeg = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div/div/ul"));
                    if (persontypeg != null)
                    {
                        persontypeg.Click();
                    }
                }


                if (epats.Type == "Tüzel")
                {

                    // tüzel tıklama
                    var persontypet = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div/div/ul/li/div[4]"));
                    if (persontypet != null)
                    {
                        persontypet.Click();
                    }


                    // uyruk tıkla
                    var nationality = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[3]/div/div[2]/div[1]/div"));
                    if (nationality != null)
                    {
                        nationality.Click();
                    }


                    // uyruk seç çöz

                    // ---------
                    if (epats.Nationality == "Türkiye")
                    {

                        var number = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[1]/div[1]/div/div[2]/div[1]/input"));
                        if (number != null)
                        {
                            number.SendKeys(epats.Number);
                        }

                        var title = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[1]/div[2]/div/div[2]")).Text;
                        if (title != null)
                        {
                            company.Title = title.Trim();
                        }


                        var taxoffice = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[1]/div[3]/div/div[2]/div[1]/span")).Text;
                        if (title != null)
                        {
                            company.TaxOffice = taxoffice.Trim();
                        }


                        var eposta = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[1]/div/div[2]/div[1]/input")).Text;
                        if (string.IsNullOrEmpty(eposta))
                        {
                            eposta = "dygmuhasebe@destekgroup.com.tr";
                            driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[1]/div/div[2]/div[1]/input")).SendKeys(eposta);
                            company.Email = null;

                        }
                        else
                        {
                            company.Email = eposta.Trim();

                        }

                        var phone = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[2]/div/div[2]/div[1]/input")).Text;
                        if (string.IsNullOrEmpty(phone))
                        {
                            phone = "533 290 52 52";
                            driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div[2]/div/div[2]/div[1]/input")).SendKeys(phone);
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

                        var fnumber = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[1]/div/div[1]/div[4]/div/div[2]/div[1]/input"));
                        if (fnumber != null)
                        {
                            fnumber.Click();
                        }


                        var fnumber1 = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[3]/div/div[1]/div/div/div[2]/div[1]/input"));
                        if (fnumber1 != null)
                        {
                            fnumber1.SendKeys(epats.Number);
                        }

                        var fnumber2 = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div/div[2]/div/div/div[1]/div/div"));
                        if (fnumber2 != null)
                        {
                            fnumber2.Click();
                        }

                    }



                }

                // yeni kişi ekle kaydet

                var personsavebuton = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div/div/div/div/div/div/div[4]/div/div[2]/div/div/div[1]/div/div"));
                if (personsavebuton != null)
                {
                    personsavebuton.Click();
                }

                Thread.Sleep(TimeSpan.FromSeconds(2));
                var country = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[10]/div")).Text;               
                if (country != null)
                {
                    company.Country = country.Trim();
                }
                else
                {
                    country = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[8]/div")).Text;
                    company.Country = country.Trim();
                }



                /*
                string tur = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[3]/div")).Text;

                string v4 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[4]/div")).Text;

                string v5 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[5]/div")).Text;

                string v6 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[6]/div")).Text;

                string v7 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[7]/div")).Text;
                
                string v8 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[8]/div")).Text;

                string v9 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[9]/div")).Text;

                string v10 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[10]/div")).Text;

                string v11 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[11]/div")).Text;

                string v12 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[12]/div")).Text;

                string v13 = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[13]/div")).Text;
                */
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var address = driver.FindElement(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[11]"));
                if (address != null)
                {  
                    company.Address = address.Text.Trim();
                }
                else
                {
                    address = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[7]"));
                    company.Address = address.Text.Trim();
                }
                
               
                var city= driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[12]")).Text;
                if (city != null)
                {
                    company.City = city.Trim();
                }
                else
                {
                    city = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[8]")).Text;
                    company.City = city.Trim();
                }


               
                var county = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[13]")).Text;
                if (county != null)
                {
                    company.County = county.Trim();
                }
                else
                {
                    county = driver.FindElementWithWait(By.XPath("/html/body/div[1]/div/form/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div/div[3]/div/div[1]/div/div/div/div[3]/div[2]/div/div/div/div[13]")).Text;
                    company.County = county.Trim();
                }

                

                status = 1;
                driver.Close();
                i++;
            }

          
            return company;

        }
        //Explicit Wait(Açık bekleme)
        public static IWebElement FindElementWithWait_(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(c => c.FindElement(by));
            if (wait != null)
            {
                return wait;
            }
            {
                return null;
            }
        }

        // FluentWait
        public static IWebElement FindElementWithWait(this IWebDriver driver, By by)
        {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                {
                    PollingInterval = TimeSpan.FromSeconds(5),

                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                var waitelement = wait.Until(c => c.FindElement(by));

                if (waitelement != null)
                {
                    return waitelement;
                }
                {
                    return null;
                }
          

        }

    }
}
