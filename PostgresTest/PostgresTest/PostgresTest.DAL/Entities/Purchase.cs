namespace PostgresTest.DAL.Entities
{
    /// <summary>
    /// Продажа
    /// </summary>
    public class Purchase
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
