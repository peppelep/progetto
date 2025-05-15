using Newtonsoft.Json;

namespace GestionaleFatturaPA.Utility.Common.Factory
{
	[JsonObject(MemberSerialization.OptIn)]
        public class ErrorModel
        {
            [JsonProperty]
            public int? ErrorCode { get; set; }

            [JsonProperty("shortMessage")]
            public string ErrorShortMessage { get; set; }

            [JsonProperty("errorMessage")]
            public string ErrorMessage { get; set; }
        }
}
