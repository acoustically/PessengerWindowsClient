using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Pessenger.LogInPage2;

namespace Pessenger
{
  class SocketCommunicator
  {
    internal class Containner
    {
      Socket socket;
      Object data;
      public Containner(Socket socket, Object data)
      {
        this.socket = socket;
        this.data = data;
      }

      public Socket Socket { get => socket; set => socket = value; }
      public Object Data { get => data; set => data = value; }
    }

    public static void ReadSocket(Socket socket, Page page)
    {
      Thread thread = new Thread(ReadSocketCallback);
      thread.SetApartmentState(ApartmentState.STA);
      thread.IsBackground = true;
      thread.Start(new Containner(socket, page));
    }

    private static void ReadSocketCallback(Object containner)
    {
      Socket socket = (Socket)((Containner)containner).Socket;
      List<byte> data = new List<byte>();
      byte[] dataPiece = new byte[1024];
      while (true)
      {
        int dataLength;
        if ((dataLength = socket.Receive(dataPiece)) < 1024 && dataLength != 0)
        {
          String dataString = Encoding.UTF8.GetString(dataPiece);
          if (int.Parse(dataString) == 0)
          {
            Page page = (Page)((Containner)containner).Data;
            App.Current.Dispatcher.Invoke(() =>
            {
              App.Current.Properties["LogInState"] = "Visible";
              page.NavigationService.Navigate(new Uri("LogInPage.xaml", UriKind.Relative));
            });
          }
          else if (int.Parse(dataString) == 1)
          {
            Page page = (Page)((Containner)containner).Data;
            
            App.Current.Dispatcher.Invoke(()=>
            {
              page.NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
            });
          }
          else
          {
            SmsMessageBox smsMessageBox = new SmsMessageBox(dataString);
            smsMessageBox.Show();
            System.Windows.Threading.Dispatcher.Run();
            return;
          }
        }
        else
        {

        }
      }

    }

    public static void WriteSocket(Socket socket, Object data)
    {
      Thread thread = new Thread(WriteSocketCallBack);
      thread.IsBackground = true;
      thread.Start(new Containner(socket, data));
    }

    private static void WriteSocketCallBack(Object containner)
    {
      Socket socket = ((Containner)containner).Socket;
      Object data = ((Containner)containner).Data;
      socket.Send(Encoding.UTF8.GetBytes((String)data));
    }

  }
}
