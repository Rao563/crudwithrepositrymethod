namespace crudwithrepositrymethod.Entity
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        //Foreign Key
        public int ProductId { get; set; }

        //Navigation Property

        public Product Product { get; set; }



    }
}
