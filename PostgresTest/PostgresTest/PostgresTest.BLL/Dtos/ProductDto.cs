namespace PostgresTest.BLL.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
    }
    public class ProductDto : CreateProductDto
    {
        public int ProductID { get; set; }
    }
}
