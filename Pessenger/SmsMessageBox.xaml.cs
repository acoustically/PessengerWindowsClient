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
    private string from_;
    private string body;
    public SmsMessageBox(string from_, string body)
    {
      Left = System.Windows.SystemParameters.WorkArea.Width - 240;
      Top = System.Windows.SystemParameters.WorkArea.Height - 160;
      this.from_ = from_;
      this.body = body;
      InitializeComponent();
    }
   
    private void OnCreate(object sender, RoutedEventArgs e)
    {
      phoneNumberTextBlock.Text = from_;
      smsBodyTextBlock.Text = body;

    }
    public new void Show()
    {
      base.Show();
      Thread.Sleep(3000);
      Close();
    }
  }
}
