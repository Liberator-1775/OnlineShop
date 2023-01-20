using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OnlineShop.Application.Common.Models;

namespace OnlineShop.WebUI.Models;

public class PatchRequestContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var prop = base.CreateProperty(member, memberSerialization);

        prop.SetIsSpecified += (o, o1) =>
        {
            if (o is PatchDto patchDtoBase) patchDtoBase.SetHasProperty(prop.PropertyName);
        };

        return prop;
    }
}