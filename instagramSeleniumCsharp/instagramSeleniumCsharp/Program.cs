using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace instagramSeleniumCsharp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Siteye girmek
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.instagram.com");
            Thread.Sleep(2000);
            Console.WriteLine("Siteye giriş yapıldı");


            // kullanıcı adı ve şifre alanlarını bulmak
            IWebElement userName = driver.FindElement(By.Name("username"));
            IWebElement password = driver.FindElement(By.Name("password"));


            // kullanıcı adı ve şifre alanlarına gerekli bilgileri girmek
            Console.Write("Kullanıcı adınızı girin:");
            string entyrUserName = System.Console.ReadLine();
            userName.SendKeys(entyrUserName);
            Console.WriteLine();

            Console.Write("Şifrenizi girin:");
            string entyrPassword = System.Console.ReadLine();
            password.SendKeys(entyrPassword);
            Console.WriteLine();


            Console.WriteLine("Bilgilendirme: Hesap bilgileri sisteme girildi.");


            // butonu bulma
            IWebElement loginButton = driver.FindElement(By.CssSelector("._acan._acap._acas._aj1-"));

            // Login butonuna basıp giriş yapma
            loginButton.Click();
            Thread.Sleep(5000);
            Console.WriteLine("Bilgilendirme: Login butonuna basıldı");

            Console.Write("Sayfasına girilecek kişinin kullanıcı adını giriniz:");
            string openUser = System.Console.ReadLine();
            driver.Navigate().GoToUrl($"https://www.instagram.com/{openUser}");
            Thread.Sleep(3000);
            Console.WriteLine("Bilgilendirme: Profil sayfası açıldı.");

            // TAKİP EDENLER _______________________________________________________________________________________

            IWebElement followersLink = driver.FindElement(By.CssSelector($"a[href='/{openUser}/followers/']"));


            // Takipçiler butonuna basma
            followersLink.Click();
            Thread.Sleep(2500);
            Console.WriteLine("Bilgilendirme: Takipçiler alanı açıldı.");

            Console.WriteLine("Bilgilendirme: Scroll yapılıyor");
            scrollDown();
            Thread.Sleep(2500);
            Console.WriteLine("Bilgilendirme: Scroll bitti");
            Thread.Sleep(2500);

            IReadOnlyCollection<IWebElement> followers = driver.FindElements(By.CssSelector(".x9f619.xjbqb8w.x1rg5ohu.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x1n2onr6.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.x1q0g3np.xqjyukv.x6s0dn4.x1oa3qoh.x1nhvcw1"));
            Thread.Sleep(2500);

            Console.WriteLine("Bilgilendirme: Ulaşılan takipçi sayısı:");
            Console.WriteLine(followers.Count);
            Thread.Sleep(2500);
            Console.WriteLine("Bilgilendirme: Takipçiler listeden okunuyor.");
            Console.WriteLine("Bilgilendirme: Takipçiler:");

            List<string> followersList = new List<string>();
            int sayacFollower = 1;
            foreach (IWebElement follower in followers)
            {
                followersList.Add(follower.Text);
                Console.WriteLine(sayacFollower + ".) " + follower.Text);
                sayacFollower++;
            }
            Thread.Sleep(3000);


            // followers kapat butonu bulma
            IWebElement followersCloseButton = driver.FindElement(By.CssSelector(".x9f619.xjbqb8w.x78zum5.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x1sxyh0.xurb0ha.x1n2onr6.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.xdt5ytf.xqjyukv.x1qjc9v5.x1oa3qoh.x1nhvcw1"));

            // followers kapat
            followersCloseButton.Click();
            Thread.Sleep(2000);
            Console.WriteLine("Bilgilendirme: Takipçilerin listelenmesi tamamlandı.");
            Console.WriteLine("________________________________________________________________________");

            // TAKİP EDİLENLER _______________________________________________________________________________________
            IWebElement followingLink = driver.FindElement(By.CssSelector($"a[href='/{openUser}/following/']"));
            Thread.Sleep(3000);
            Console.WriteLine("Bilgilendirme: Takip edilenler alanı açıldı.");

            followingLink.Click();
            Thread.Sleep(5000);

            Console.WriteLine("Bilgilendirme: Scroll yapılıyor");
            scrollDown();
            Console.WriteLine("Bilgilendirme: Scroll bitti");
            Thread.Sleep(3000);


            IReadOnlyCollection<IWebElement> following = driver.FindElements(By.CssSelector(".x9f619.xjbqb8w.x1rg5ohu.x168nmei.x13lgxp2.x5pf9jr.xo71vjh.x1n2onr6.x1plvlek.xryxfnj.x1c4vz4f.x2lah0s.x1q0g3np.xqjyukv.x6s0dn4.x1oa3qoh.x1nhvcw1"));

            Console.WriteLine("Bilgilendirme: Takip edilenler listeden okunuyor.");
            Console.WriteLine("Bilgilendirme: Ulaşılan takip edilen sayısı:");
            Console.WriteLine(following.Count);
            Thread.Sleep(2500);
            Console.WriteLine("Bilgilendirme: Takip edilenler:");

            int sayacFollowing = 1;

            List<string> followingList = new List<string>();

            foreach (IWebElement follower in following)
            {
                followingList.Add(follower.Text);
                Console.WriteLine(sayacFollowing + ".) " + follower.Text);
                sayacFollowing++;

            }
            Thread.Sleep(3000);
            Console.WriteLine("Bilgilendirme: Takip edilenlerin listelenmesi tamamlandı.");
            Console.WriteLine("_______________________________________________________________________________");

            List<string> biziTakipEtmeyenler = followingList.Except(followersList).ToList();
            Console.WriteLine("------------------------ Kullanıcıyı takip etmeyenler -------------------------");

            foreach (string s in biziTakipEtmeyenler)
            {
                Console.WriteLine("*");
                Console.WriteLine(s);
            }



            // ________________________________________________________________________________________________________________
            // takipçiler ve takip ettiklerimiz sayfalarında scroll barı aşağı indirme metodu. bu metod yukarıda kullanılmıştır.
            void scrollDown()
            { // scroll için js yazma
                string jsCommand = "" +
                    "sayfa = document.querySelector('._aano');" +
                    "sayfa.scrollTo(0,sayfa.scrollHeight);" +
                    "var sayfaSonu = sayfa.scrollHeight;" +
                    "return sayfaSonu;";

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                var sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));

                // scrollu en alta gelene kadar aşağı kaydırma
                while (true)
                {
                    var son = sayfaSonu;
                    Thread.Sleep(2000);
                    sayfaSonu = Convert.ToInt32(js.ExecuteScript(jsCommand));
                    if (son == sayfaSonu) break;
                }
            }
        }

    }
}