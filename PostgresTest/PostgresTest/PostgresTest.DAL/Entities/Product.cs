namespace PostgresTest.DAL.Entities
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public ICollection<Purchase>? Purchases { get; set; }
    }
}
