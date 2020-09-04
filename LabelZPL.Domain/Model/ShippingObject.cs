namespace LabelZPL.Domain.Model
{
  public class Sender {
    public string Name { get; set; }    
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
  }

  public class Recipient 
  {    
    public string Name { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
  }

  public class Shipping
  {
    public string TypeService { get; set; }
    public string Barcode { get; set; }
    public string Order { get; set; }
    public string Route { get; set; }
  }

  public class ShippingObject 
  {
    public ShippingObject() {
      SenderData = new Sender();
      RecipientData = new Recipient();
      ShippingData = new Shipping();
    }

    public Sender SenderData { get; set; }
    public Recipient RecipientData { get; set; }
    public Shipping ShippingData { get; set; }
  }
}