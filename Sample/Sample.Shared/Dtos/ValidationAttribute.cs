namespace Sample.Shared.Dtos
{
    public class ValidationAttribute : Attribute
    {
        public string Name { get; set; }
        public ValidationAttribute(string name) { Name = name; }
    }
}
