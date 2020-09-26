using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
//using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShoutWatch
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const int INTERNET_COOKIE_HTTPONLY = 0x00002000;

        [DllImport("wininet.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);

        private string InternetGetCookieEx(string url)
        {
            uint sizeInBytes = 0;
            InternetGetCookieEx(url, null, null, ref sizeInBytes, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero);
            uint bufferCapacityInChars = (uint)Encoding.Unicode.GetMaxCharCount((int)sizeInBytes);
            var cookieData = new StringBuilder((int)bufferCapacityInChars);
            InternetGetCookieEx(url, null, cookieData, ref bufferCapacityInChars, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero);
            return cookieData.ToString();
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async Task<CookieContainer> DownloadCookiesAsync(string url, string username, string password)
        {


            CookieContainer container = null;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.UseDefaultCredentials = false;
            request.Method = "POST";
            
            request.ContentType = "application/x-www-form-urlencoded";
            try
            {
                var buffer = Encoding.ASCII.GetBytes("username=user&password=password");//string.Format("url =&username={0}&password={1}", username, password));
                                                                                              //request.ContentLength = buffer.Length;
                var requestStream = await request.GetRequestStreamAsync();
                requestStream.Write(buffer, 0, buffer.Length);
                // requestStream.Close();

                container = request.CookieContainer = new CookieContainer();

                await request.GetResponseAsync();
            }
            catch(WebException e)
            {
                MessageDialog m = new MessageDialog(e.Message);
                await m.ShowAsync();
            }
            //response.Close();
            return container;
        }



        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //ShoutWatcher watcher = new ShoutWatcher();
            //Shout[] shouts = await watcher.GetShoutsAsync("http://www.ffxiah.com/shouts", Server.Odin);

            //foreach (Shout s in shouts)
            //{
            //    ListBoxItem lbi = new ListBoxItem();
            //    lbi.Content = string.Format("{0} {1} {2} {3} {4}", s.Zone, s.Timestamp, s.Character, s.Mode, s.Message);
            //    ShoutListView.Items.Add(lbi);
            //}

            CookieContainer cookies = await DownloadCookiesAsync("https://www.ffxiah.com/login", "Kunihiro", "$pitfire12");
            CookieCollection cc = cookies.GetCookies(new Uri("https://www.ffxiah.com/login"));
            foreach (Cookie c in cc)
            {
                ListBoxItem lbi = new ListBoxItem();

                lbi.Content = string.Format("{0} {1}", c.Name, c.Value);
                ShoutListView.Items.Add(lbi);
            }
            //HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, new Uri("https://ffxiah.com/login"));

            //msg.Content = new HttpStringContent("url=&username=kunihiro&password=$pitfire12");
            //webView.NavigationCompleted += WebView_NavigationCompleted;

            //webView.NavigateWithHttpRequestMessage(msg);





            //HttpClient client = new HttpClient();

            //var response = await client.PostAsync(new Uri("https://ffxiah.com/login"), new HttpStringContent("url=&username=kunihiro&password=$pitfire12", Windows.Storage.Streams.UnicodeEncoding.Utf8));
            //string value;
            //value = response.Headers.ToString();
            //var msg = new MessageDialog(value);
            //await msg.ShowAsync();
        }

        private async void WebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            string s = InternetGetCookieEx("https://ffxiah.com");

            MessageDialog msg = new MessageDialog(s);
            await msg.ShowAsync();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string s = InternetGetCookieEx("https://ffxiah.com");

            MessageDialog msg = new MessageDialog(s);
            await msg.ShowAsync();
        }
    }
}
