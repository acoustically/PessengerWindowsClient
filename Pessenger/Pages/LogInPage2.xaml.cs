using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pessenger
{
    /// <summary>
    /// LogInPage2.xaml에 대한 상호 작용 논리
    /// </summary>
  public partial class LogInPage2 : Page
  {
    public LogInPage2()
    {
      InitializeComponent();
    }

    private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
    {
      String password = passwordBox.Password;
      String phoneNumber = (String)App.Current.Properties["phoneNumber"];
      HttpRequest request = new HttpRequest();
      JObject json = new JObject();
      json.Add("password", password);
      json = JObject.Parse(request.Post(Environment.GetUrl("/user/" + phoneNumber), json));
      if (json["response"].ToString() == "success")
      {
        this.NavigationService.Navigate(new Uri("Pages/SetClientNamePage.xaml", UriKind.Relative));
      }
    }
  }
}
