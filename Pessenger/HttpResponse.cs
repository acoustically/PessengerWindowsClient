using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pessenger
{
  class HttpResponse
  {
    string data;
    public HttpResponse(HttpWebRequest request) {
      HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
      HttpStatusCode status = resp.StatusCode;
      Console.WriteLine(status);  // 정상이면 "OK"

      Stream respStream = resp.GetResponseStream();
      StreamReader sr = new StreamReader(respStream);
      data = sr.ReadToEnd();
    }
    public string Data
    {
      get
      {
        return data;
      }
    }
  }
}
