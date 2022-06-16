namespace MinimalAPI.MongoDB.Domain.Core.Config.Query
{
    public class QueryHandler
    {
        public QueryResponse OkResponse(object result, string message)
        {
            var data = new QueryResponse(result);
            data.StatusCode = 200;
            data.Message = message;
            return data;
        }

        public QueryResponse BadRequestResponse(object errors, string message)
        {
            var data = new QueryResponse(errors);
            data.StatusCode = 400;
            data.Message = message;
            return data;
        }

        public QueryResponse InternalServerErrorResponse(object errors, string message)
        {
            var data = new QueryResponse(errors);
            data.StatusCode = 500;
            data.Message = message;
            return data;
        }
    }
}
