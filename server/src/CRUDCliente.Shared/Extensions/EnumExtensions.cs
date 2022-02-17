using CRUDCliente.Shared.Attributes;
using System.ComponentModel;

namespace CRUDCliente.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum anyEnum)
        {
            var member = anyEnum.GetType().GetMember(anyEnum.ToString()).FirstOrDefault();
            var attr = member.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            if (attr != null) return ((DescriptionAttribute)attr).Description;
            return anyEnum.ToString();
        }

        public static string GetDetail(this Enum anyEnum)
        {
            var member = anyEnum.GetType().GetMember(anyEnum.ToString()).FirstOrDefault();
            var attr = member.GetCustomAttributes(typeof(DetailAttribute), false).FirstOrDefault();
            if (attr != null) return ((DetailAttribute)attr).Detail;
            return anyEnum.ToString();
        }

        public static T GetValueFromDescription<T>(this string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            return default;
        }
    }
}