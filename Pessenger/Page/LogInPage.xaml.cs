using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pessenger
{
  /// <summary>
  /// LogInPage.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class LogInPage : Page
  {
    public LogInPage()
    {
      InitializeComponent();
    }

    private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
    {
      string phoneNumber = textBox.Text;
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Environment.GetUrl("/user/" + phoneNumber));
      request.Method = "GET";
      request.Headers.Add("Authorization", "Token acoustically");
      HttpResponse response = new HttpResponse(request);
      JObject json = JObject.Parse(response.Data);
      MessageBox.Show(json.ToString());
      App.Current.Properties["phoneNumber"] = textBox.Text;
      this.NavigationService.Navigate(new Uri("LogInPage2.xaml", UriKind.Relative));
    }
  }
}
