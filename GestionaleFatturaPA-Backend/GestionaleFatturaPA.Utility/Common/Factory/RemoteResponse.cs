using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace GestionaleFatturaPA.Utility.Common.Factory
{
	[JsonObject(MemberSerialization.OptIn)]
    [DataContract(Namespace = "")]
    public class RemoteResponse
    {
        public RemoteResponse()
        {
            this.HasError = false;
        }

        [JsonProperty]
        [DataMember]
        public bool HasError { get; set; }

        [JsonProperty]
        [DataMember]
        public ErrorModel Error { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    [DataContract(Namespace = "")]
    [KnownType("GetTypes")]
    public class RemoteResponse<T> : RemoteResponse
    {
        [JsonProperty(TypeNameHandling = TypeNameHandling.Auto)]
        [DataMember]
        public T Data { get; set; }

        private static Type[] GetTypes()
        {
            return new Type[1] { typeof(RemoteResponse<T>) };
        }
    }
}
