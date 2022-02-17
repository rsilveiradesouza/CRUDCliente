namespace CRUDCliente.Shared.Attributes
{
    public class DetailAttribute : Attribute
    {
        public static readonly DetailAttribute Default = new DetailAttribute();
        public virtual string Detail => DetailValue;
        protected string DetailValue { get; set; }
        public DetailAttribute() : this(string.Empty) { }
        public DetailAttribute(string detail) => DetailValue = detail;
    }
}