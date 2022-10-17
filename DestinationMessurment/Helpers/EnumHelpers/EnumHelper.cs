using System.ComponentModel;
using System.Reflection;

namespace DestinationMessurment.Service.Core.Helpers.EnumHelpers
{
    public class EnumDto
    {
        public string Name { get; set; }

        public Enum Enum { get; set; }

        public IDictionary<Type, Attribute> Attributes { get; set; }

    }

    public class EnumDto<TEnum> : EnumDto
        where TEnum : struct
    {
        public TEnum Value { get; set; }
    }

    public class Enum<TEnum>
        where TEnum : struct
    {
        public static Enum<TEnum> Current { get; } = new Enum<TEnum>();

        private IList<EnumDto<TEnum>> _items { get; }

        private Enum()
        {
            _items = new List<EnumDto<TEnum>>();

            foreach (var name in Enum.GetNames(typeof(TEnum)))
            {
                var value = Enum.Parse(typeof(TEnum), name);

                var item = new EnumDto<TEnum>
                {
                    Name = name,
                    Enum = (Enum)value,
                    Value = (TEnum)value
                };

                item.Attributes = typeof(TEnum)
                    .GetField(item.Name)
                    .GetCustomAttributes()
                    .ToDictionary(x => x.GetType(), x => x);

                _items.Add(item);
            }
        }


        private bool TryGet<TAttribute>(string value, out TAttribute attribute)
            where TAttribute : Attribute
        {
            attribute = null;

            var item = _items.FirstOrDefault(x => x.Name == value);
            if (item == null)
                return false;

            Attribute attr;
            if (!item.Attributes.TryGetValue(typeof(TAttribute), out attr))
                return false;

            attribute = (TAttribute)attr;

            return true;
        }

        #region IEnumerable

        public IEnumerator<EnumDto<TEnum>> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        #endregion

        #region Static API

        public static bool TryGetAttribute<TAttribute>(TEnum value, out TAttribute attribute)
            where TAttribute : Attribute
        {
            return Current.TryGet(value.ToString(), out attribute);
        }

        #endregion
    }

    public static class EnumHelper
    {

        public static string GetDescription<TEnum>(this TEnum value)
            where TEnum : struct
        {
            DescriptionAttribute attribute;

            return Enum<TEnum>.TryGetAttribute<DescriptionAttribute>(value, out attribute)
                ? attribute.Description
                : value.ToString();
        }
    }
}

