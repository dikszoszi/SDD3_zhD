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
        public System.Collections.Generic.List<Product> Products { get; set; }

        public static Fridge GetFridgeFromXml(string xmlPath)
        {
            XElement fridge = XDocument.Load(xmlPath).Element("fridge");
            System.Collections.Generic.IEnumerable<XElement> productElements = fridge.Descendants("product");
            System.Collections.Generic.List<Product> productList = new System.Collections.Generic.List<Product>();
            foreach (XElement productElement in productElements)
            {
                productList.Add(new Product
                {
                    Quantity = int.Parse(productElement.Attribute("quantity").Value),
                    ProductName = productElement.Value
                });
            }
            return new Fridge
            {
                Brand = fridge.Attribute("brand").Value,
                Capacity = int.Parse(fridge.Attribute("capacity").Value),
                Products = productList,
            };
        }
    }
}
