using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GreenGrey.Analytics.Helpers
{
    public class IgnorePropertiesResolver : DefaultContractResolver
    {
        private readonly HashSet<string> m_ignoreProps;
        public IgnorePropertiesResolver(IEnumerable<string> _propNamesToIgnore)
        {
            this.m_ignoreProps = new HashSet<string>(_propNamesToIgnore);
        }

        protected override JsonProperty CreateProperty(MemberInfo _member, MemberSerialization _memberSerialization)
        {
            JsonProperty property = base.CreateProperty(_member, _memberSerialization);
            if (this.m_ignoreProps.Contains(property.PropertyName))
            {
                property.ShouldSerialize = _ => false;
            }
            return property;
        }
    }
}