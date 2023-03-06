using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch
{
    public class InterfaceConverterFactory<TImpl, TInter> : JsonConverterFactory
        where TImpl : class, TInter
    {
        public Type ImplementationType { get; }
        public Type InterfaceType { get; }

        public InterfaceConverterFactory()
        {
            ImplementationType = typeof(TImpl);
            InterfaceType = typeof(TInter);
        }

        public override bool CanConvert(Type typeToConvert)
            => typeToConvert == InterfaceType;

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(InterfaceConverter<,>).MakeGenericType(ImplementationType, InterfaceType);
            return Activator.CreateInstance(converterType) as JsonConverter;
        }
    }
}
