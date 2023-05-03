using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonNETHideObjectTest
{
    public class Resolver : IReferenceResolver
    {
        public Resolver()
        {
        }

        public void AddReference(object context, string reference, object value)
        {

        }

        public string GetReference(object context, object value)
        {
            throw new NotImplementedException();
        }

        public bool IsReferenced(object context, object value)
        {
            return true;
        }

        public object ResolveReference(object context, string reference)
        {
            throw new NotImplementedException();
        }

        public class DynamicContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);

                if (property.PropertyType == typeof(MShape))
                {
                    property.ShouldSerialize = instance =>
                    {
                        var shape = (MShape)instance.GetType().GetProperty(property.PropertyName)?.GetValue(instance);

                        if (shape is MCircle)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    };
                }

                return property;
            }
        }
    }
}
