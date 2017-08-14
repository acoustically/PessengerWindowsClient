using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

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
      phoneNumberTextBlock.Text = json["sms-sender-phone-number"].ToString();
      smsBodyTextBlock.Text = json["sms-body"].ToString();
    }
    private void updateWindow()
    {
    }
  }
}
