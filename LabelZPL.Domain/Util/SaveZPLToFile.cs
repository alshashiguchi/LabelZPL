using System;
using System.IO;
using System.Net;
using System.Text;

namespace LabelZPL.Domain.Util
{
  public static class SaveZPLToFile
  {
    public static void ZplToFile(string fileZpl, TypePrint typePrint, TypeFile typeFile) 
    {
      byte[] zpl = Encoding.UTF8.GetBytes(fileZpl);

      string url = typePrint switch
      {
        TypePrint.DPI200 => "http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/",
        TypePrint.DPI300 => "http://api.labelary.com/v1/printers/12dpmm/labels/4x6/0/",
        TypePrint.DPI600 => "http://api.labelary.com/v1/printers/24dpmm/labels/4x6/0/",
        _ => throw new Exception("Tipo de impressora não localizada."),
      };
      
      var request = (HttpWebRequest) WebRequest.Create(url);      
      
      request.Method = "POST";
      request.Accept = typeFile == TypeFile.PDF ? "application/pdf" : "image/png"; 
      request.ContentType = "application/x-www-form-urlencoded";
      request.ContentLength = zpl.Length;

      var requestStream = request.GetRequestStream();
      requestStream.Write(zpl, 0, zpl.Length);
      requestStream.Close();

      try 
      {
        var response = (HttpWebResponse) request.GetResponse();
        var responseStream = response.GetResponseStream();
        var fileStream = typeFile == TypeFile.PDF ? File.Create("label.pdf") : File.Create("label.png");;
    
        responseStream.CopyTo(fileStream);
        responseStream.Close();
        fileStream.Close();
      } catch (WebException e) {
        Console.WriteLine("Error: {0}", e.Status);
      }
    }
  }
}