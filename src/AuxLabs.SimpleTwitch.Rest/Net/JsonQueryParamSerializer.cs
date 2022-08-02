using RestEase;
using System.Text.Json;

namespace AuxLabs.SimpleTwitch.Rest.Net
{
    internal class JsonQueryParamSerializer : RequestQueryParamSerializer
    {
        public override IEnumerable<KeyValuePair<string, string>> SerializeQueryParam<T>(string name, T value, RequestQueryParamSerializerInfo info)
        {
            if (value == null)
                yield break;

            yield return new KeyValuePair<string, string>(name, JsonSerializer.Serialize<T>(value));
        }

        public override IEnumerable<KeyValuePair<string, string>> SerializeQueryCollectionParam<T>(string name, IEnumerable<T> values, RequestQueryParamSerializerInfo info)
        {
            if (values == null)
                yield break;

            foreach (var value in values)
            {
                if (value != null)
                    yield return new KeyValuePair<string, string>(name, JsonSerializer.Serialize<T>(value));
            }
        }
    }
}
