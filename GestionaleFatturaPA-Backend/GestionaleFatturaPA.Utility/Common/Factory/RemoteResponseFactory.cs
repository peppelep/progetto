
namespace GestionaleFatturaPA.Utility.Common.Factory
{
    public static class RemoteResponseFactory
    {
        public static RemoteResponse<T> CreateResponse<T>(T data)
        {
            RemoteResponse<T> remoteResponse = new RemoteResponse<T>();
            remoteResponse.Data = data;
            remoteResponse.HasError = false;
            return remoteResponse;
        }

        public static RemoteResponse<T> CreateErrorResponse<T>(string message, int? code = null)
        {
            RemoteResponse<T> remoteResponse = new RemoteResponse<T>();
            remoteResponse.HasError = true;
            remoteResponse.Error = new ErrorModel()
            {
                ErrorCode = code,
                ErrorMessage = message
            };
            return remoteResponse;
        }

        public static RemoteResponse<T> CreateErrorResponse<T>(T data, String message, int? code = 500)
        {
            RemoteResponse<T> remoteResponse = new RemoteResponse<T>();
            remoteResponse.HasError = true;
            remoteResponse.Error = new ErrorModel()
            {
                ErrorCode = code,
                ErrorMessage = message
            };
            remoteResponse.Data = data;
            return remoteResponse;
        }

    }
}
