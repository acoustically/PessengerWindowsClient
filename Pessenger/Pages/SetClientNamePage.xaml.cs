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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pessenger
{
  /// <summary>
  /// SetClientNamePage.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class SetClientNamePage : Page
  {
    public SetClientNamePage()
    {
      InitializeComponent();
    }
    private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
    {
      String name = textBox.Text;
      String phoneNumber = (String)App.Current.Properties["phoneNumber"];
      int clientId = (new Random()).Next(1, 9999);
      HttpRequest request = new HttpRequest();
      JObject json = new JObject();
      json.Add("name", name);
      json.Add("phone_number", phoneNumber);
      json.Add("id", clientId);
      json.Add("os", System.Environment.OSVersion.ToString());
      json = JObject.Parse(request.Post(Environment.GetUrl("/client/new"), json));
      if (json["response"].ToString() == "success")
      {
        App.Current.Properties["clientId"] = clientId;
        this.NavigationService.Navigate(new Uri("Pages/MainPage.xaml", UriKind.Relative));
      }
      else
      {
        TextBlock_MouseUp(sender, e);
      }
    }
  }
}
