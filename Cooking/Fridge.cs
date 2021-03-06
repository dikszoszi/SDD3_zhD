namespace Cooking
{
    using System.Xml.Linq;

    public class Fridge
    {
        public Fridge()
        {
        }

        [ImportantProperty("MyFridgeReason")]
        public string Brand { get; set; }
        public int Capacity { get; set; }
        public System.Collections.Generic.IEnumerable<Product> Products { get; private set; }

        public static Fridge GetFridgeFromXml(string xmlPath)
        {
            XElement fridge = XDocument.Load(xmlPath).Element("fridge");
            System.Collections.Generic.IEnumerable<XElement> productElements = fridge.Descendants("product");
            System.Collections.Generic.List<Product> productList = new ();
            foreach (XElement productElement in productElements)
            {
                productList.Add(new Product
                {
                    Quantity = int.Parse(productElement.Attribute("quantity").Value, System.Globalization.NumberFormatInfo.InvariantInfo),
                    ProductName = productElement.Value
                });
            }
            return new Fridge
            {
                Brand = fridge.Attribute("brand").Value,
                Capacity = int.Parse(fridge.Attribute("capacity").Value, System.Globalization.NumberFormatInfo.InvariantInfo),
                Products = productList,
            };
        }
    }
}
