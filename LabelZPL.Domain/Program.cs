using System;
using System.IO;
using LabelZPL.Domain.Model;
using LabelZPL.Domain.Util;

namespace LabelZPL.Domain
{
  public class Program
  {
    public static void Main()
    {
      ShippingObject _dadosRemessa = new ShippingObject();

      _dadosRemessa.RecipientData.Name = "Eliana Xavier";
      _dadosRemessa.RecipientData.Street = "Praça Conego Ulisses";
      _dadosRemessa.RecipientData.Number = "308";
      _dadosRemessa.RecipientData.Neighborhood = "Centro";
      _dadosRemessa.RecipientData.Complement = "Apartamento 101";
      _dadosRemessa.RecipientData.ZipCode = "37270-000";
      _dadosRemessa.RecipientData.City = "Campo Belo";
      _dadosRemessa.RecipientData.State = "MG";
      
      _dadosRemessa.SenderData.Name = "Sophie e Andreia Contábil Ltda";
      _dadosRemessa.SenderData.Street = "Rua Jairo de Aquino Martins";
      _dadosRemessa.SenderData.Number = "890";
      _dadosRemessa.SenderData.Neighborhood = "Parque das Rodovias";      
      _dadosRemessa.SenderData.ZipCode = "12605-615";
      _dadosRemessa.SenderData.City = "Lorena";
      _dadosRemessa.SenderData.State = "SP";

      _dadosRemessa.ShippingData.TypeService = "STD";
      _dadosRemessa.ShippingData.Route = "DIQ-MG-INT [001]";
      _dadosRemessa.ShippingData.Barcode = "diqi00090000000001";
      _dadosRemessa.ShippingData.Order = "SDfhsHCD94_001_v";

      string path = Directory.GetCurrentDirectory();
      var typePrint = TypePrint.DPI300;
      var typeFile = TypeFile.PDF;

      Console.WriteLine(String.Format("-----------------------Label {0}-----------------------", typeFile.ToString()));      

      string fileZpl = Zpl.CreateZPL(_dadosRemessa, typePrint);      

      Util.SaveZPLToFile.ZplToFile(fileZpl, typePrint, typeFile);

      Console.WriteLine(String.Format("------------------Generated {0} File-------------------", typeFile.ToString()));

      Console.WriteLine("-------------------------Label-------------------------");
      Console.WriteLine(fileZpl);
    }
  }
}
