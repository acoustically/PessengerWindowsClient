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
      App.Current.Properties["phoneNumber"] = textBox.Text;
      this.NavigationService.Navigate(new Uri("LogInPage2.xaml", UriKind.Relative));
    }
  }
}
