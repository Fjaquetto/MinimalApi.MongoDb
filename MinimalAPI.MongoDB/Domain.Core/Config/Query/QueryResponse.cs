namespace MinimalAPI.MongoDB.Domain.Core.Config.Query
{
    public class QueryResponse
    {
        public QueryResponse(object data)
        {
            Date = DateTime.Now;
            Data = data;
        }

        public QueryResponse(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Date = DateTime.Now;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; private set; }
        public object Data { get; set; }
    }
}

