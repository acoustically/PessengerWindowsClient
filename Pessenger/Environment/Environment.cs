using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessenger
{
  class Environment
  {
    private const string serverUrl = "http://52.79.104.209:5000";
    public static string GetUrl(string url) {
      return serverUrl + url;
    }
  }
}
