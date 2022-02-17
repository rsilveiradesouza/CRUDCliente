using CRUDCliente.Shared.Attributes;
using System.ComponentModel;

namespace CRUDCliente.Shared.Enums
{
    [SerializeEnumAsInt]
    public enum OrderDirection
    {
        [Description("asc")]
        ASC = 1,
        [Description("desc")]
        DESC = 2
    }
}