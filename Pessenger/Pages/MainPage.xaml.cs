using Newtonsoft.Json.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Pessenger
{
  /// <summary>
  /// MainPage.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainPage : Page
  {
    public MainPage()
    {
      InitializeComponent();
      Thread getSmsMessageThread = new Thread(new ThreadStart(GetSmsMessage));
      getSmsMessageThread.SetApartmentState(ApartmentState.STA);
      getSmsMessageThread.IsBackground = true;
      getSmsMessageThread.Start();
    }
    private void GetSmsMessage()
    {
      while (true)
      {
        HttpRequest request = new HttpRequest();
        string phoneNumber = (string)App.Current.Properties["phoneNumber"];
        int id = (int)App.Current.Properties["clientId"];
        JObject json = JObject.Parse(request.Get(Environment.GetUrl("/sms-message/" + phoneNumber + "/" + id)));
        if (json["response"].ToString() == "success")
        {
          json = JObject.Parse(json["sms_message"].ToString());
          string from_ = json["from_"].ToString();
          string body = json["body"].ToString();
          (new SmsMessageBox(from_, body)).Show();
        }
        Thread.Sleep(800);
      }
    }
  }
}
