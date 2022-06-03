namespace WebApi.Dtos
{
    public class CreateCustomerDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
    public class CustomerDto : CreateCustomerDto
    {
        public long Id { get; set; }
    }
}
