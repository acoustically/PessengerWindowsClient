using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
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
    /// LogInPage2.xaml에 대한 상호 작용 논리
    /// </summary>
  public partial class LogInPage2 : Page
  {
    Socket socket;

    [DataContract]
    internal class Account
    {
      [DataMember]
      String client;
      [DataMember]
      String phoneNumber;
      [DataMember]
      String password;
      public Account(String phoneNumber, String password)
      {
        this.client = "windows";
        this.phoneNumber = phoneNumber;
        this.password = password;
      }
    }

    public LogInPage2()
    {
      InitializeComponent();
    }

    private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
    {
      String password = passwordBox.Password;
      String phoneNumber = (String)App.Current.Properties["phoneNumber"];
      socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("52.79.104.209"), 8100);
      socket.Connect(endPoint);
      String data = JsonBuilder.BuildJson(new Account(phoneNumber, password));
      SocketCommunicator.WriteSocket(socket, data);
      //Thread writeThread = new Thread(WriteSocket);
      //writeThread.Start(makeJson(new Account(phoneNumber, password)));
    }
  }
}
