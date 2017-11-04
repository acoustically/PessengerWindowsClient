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
      HttpRequest request = new HttpRequest();
      JObject json = JObject.Parse(request.Get(Environment.GetUrl("/user/" + phoneNumber)));
      if (json["response"].ToString() == "success")
      {
        App.Current.Properties["phoneNumber"] = textBox.Text;
        this.NavigationService.Navigate(new Uri("Pages/LogInPage2.xaml", UriKind.Relative));
      }
    }
  }
}
