namespace AzureWebApp.Models
{
    public class IndexModel
    {
        public IEnumerable<Product> Products { get; set; }
        public bool IsBeta { get; set; }
    }
}
