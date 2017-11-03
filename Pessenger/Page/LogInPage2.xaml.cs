using System;
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
    }
  }
}
