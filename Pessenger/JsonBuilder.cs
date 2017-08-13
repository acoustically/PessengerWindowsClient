using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using static Pessenger.LogInPage2;

namespace Pessenger
{
  class JsonBuilder
  {
    public static String BuildJson(Account account)
    {
      MemoryStream mStream = new MemoryStream();
      DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Account));
      ser.WriteObject(mStream, account);
      mStream.Position = 0;
      StreamReader reader = new StreamReader(mStream);
      return reader.ReadToEnd();
    }
  }
}
