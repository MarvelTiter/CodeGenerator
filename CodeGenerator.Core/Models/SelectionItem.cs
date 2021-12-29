namespace CodeGenerator.Core.Models
{
    public class SelectionItem<T>
    {
        public string Display { get; set; }
        public T Value { get; set; }
    }
}
