namespace crudwithrepositrymethod.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        //Navigation Property

        public List<Order> Orders { get; set; }
    }
}
