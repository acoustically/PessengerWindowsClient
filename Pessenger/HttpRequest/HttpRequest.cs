using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace Pessenger
{
  class HttpRequest
  {

    public string Get(string url)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      AddToken(request);
      request.Method = "GET";
      HttpResponse response = new HttpResponse(request);
      return response.Data;
    }
    public string Post(string url, JObject json)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.ContentType = "application/json";

      AddToken(request);
      request.Method = "POST";
      StreamWriter writer = new StreamWriter(request.GetRequestStream());
      writer.Write(json);
      writer.Flush();
      writer.Close();

      HttpResponse response = new HttpResponse(request);
      return response.Data;
    }
    private void AddToken(HttpWebRequest request)
    {
      request.Headers.Add("Authorization", "Token acoustically");     
    }
  }
}
