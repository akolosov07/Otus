namespace PostgresTest.BLL.Dtos
{
    public class CreatePurchaseDto
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
    }
    public class PurchaseDto : CreatePurchaseDto
    {
        public CustomerDto Customer { get; set; }
        public ProductDto Product { get; set; }
    }    
}
