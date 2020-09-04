using System;
using System.IO;
using System.Text.RegularExpressions;
using LabelZPL.Domain.Model;

namespace LabelZPL.Domain.Util
{
  public class Zpl
  {
    public static string PathLabel(string file) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Util", "Labels", file);
    public static string CreateZPL(ShippingObject externalDocument, TypePrint typePrint)
    {
      string fileZpl = typePrint switch
      {
        TypePrint.DPI200 => File.ReadAllText(PathLabel("SmartLabel_200.prn")),
        TypePrint.DPI300 => File.ReadAllText(PathLabel("SmartLabel_300.prn")),
        TypePrint.DPI600 => File.ReadAllText(PathLabel("SmartLabel_600.prn")),
        _ => throw new Exception("Printer type not found."),
      };
      fileZpl = Regex
      .Replace(fileZpl, @"\s+", "");

      // Remetente
      fileZpl = fileZpl.Replace("[REMNOME]", externalDocument.SenderData.Name?.ToUpper());
      fileZpl = fileZpl.Replace("[REMENDERECO]", externalDocument.SenderData.Street?.ToUpper());
      fileZpl = fileZpl.Replace("[REMNUMERO]", externalDocument.SenderData.Number?.ToUpper());
      fileZpl = fileZpl.Replace("[REMBAIRRO]", externalDocument.SenderData.Neighborhood?.ToUpper());
      fileZpl = fileZpl.Replace("[REMCEP]", externalDocument.SenderData.ZipCode);
      fileZpl = fileZpl.Replace("[REMCIDADE]", externalDocument.SenderData.City?.ToUpper());
      fileZpl = fileZpl.Replace("[REMUF]", externalDocument.SenderData.State?.ToUpper());

      // Destinatário
      fileZpl = fileZpl.Replace("[DESTNOME]", externalDocument.RecipientData.Name);
      fileZpl = fileZpl.Replace("[DESTENDERECO]", externalDocument.RecipientData.Street);
      fileZpl = fileZpl.Replace("[DESTENDERECONUMERO]", externalDocument.RecipientData.Number);
      fileZpl = fileZpl.Replace("[DESTBAIRRO]", externalDocument.RecipientData.Neighborhood);
      fileZpl = fileZpl.Replace("[DESTCOMPLEMENTO]", externalDocument.RecipientData.Complement);
      fileZpl = fileZpl.Replace("[DESTCEP]", externalDocument.RecipientData.ZipCode);
      fileZpl = fileZpl.Replace("[DESTCIDADE]", externalDocument.RecipientData.City);
      fileZpl = fileZpl.Replace("[DESTUF]", externalDocument.RecipientData.Street);

      //Transportadora
      fileZpl = fileZpl.Replace("[ENCTIPO]", externalDocument.ShippingData.TypeService.ToUpper());
      fileZpl = fileZpl.Replace("[VOLCODBARRA]", externalDocument.ShippingData.Barcode.ToUpper());      
      fileZpl = fileZpl.Replace("[ENCPEDIDO]", externalDocument.ShippingData.Order.ToUpper());      
      fileZpl = fileZpl.Replace("[VOLROTA]", externalDocument.ShippingData.Route.ToUpper());      

      //Outros
      fileZpl = fileZpl.Replace("[DATA]", DateTime.Now.ToString("dd/MM"));
      fileZpl = fileZpl.Replace("[HORAINI]", DateTime.Now.ToString("HH:mm"));      
      fileZpl = fileZpl.Replace("[HORAFIM]", DateTime.Now.ToString("HH:mm"));

      return fileZpl;
    }
  }
}





