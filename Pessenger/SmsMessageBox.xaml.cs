using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Windows;

namespace Pessenger
{
  /// <summary>
  /// SmsMessageBox.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class SmsMessageBox : Window
  {
    String jsonData;
    public SmsMessageBox(String jsonData)
    {
      Left = System.Windows.SystemParameters.WorkArea.Width - 240;
      Top = System.Windows.SystemParameters.WorkArea.Height - 160;
      this.jsonData = jsonData;
      InitializeComponent();
    }

    public string JsonData { get => jsonData; set => jsonData = value; }

    private void OnCreate(object sender, RoutedEventArgs e)
    {
      JObject json = JObject.Parse(jsonData);
      phoneNumberTextBlock.Text = json["smsSenderPhoneNumber"].ToString();
      smsBodyTextBlock.Text = json["smsBody"].ToString();

    }
    public new void Show()
    {
      base.Show();
      Timer timer = new Timer((Object param)=>
      {
        this.Dispatcher.Invoke(Close);
      }, null, 4000, 1000);
    }
  }
}
