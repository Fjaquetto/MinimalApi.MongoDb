namespace MinimalAPI.MongoDB.Domain.Core.Config.Command
{
    public abstract class CommandHandler
    {
        public CommandResponse CreateResponse(object result, string message)
        {
            var data = new CommandResponse(result);
            data.StatusCode = 201;
            data.Message = message;
            return data;
        }

        public CommandResponse OkResponse(object result, string message)
        {
            var data = new CommandResponse(result);
            data.StatusCode = 200;
            data.Message = message;
            return data;
        }

        public CommandResponse BadRequestResponse(object errors, string message)
        {
            var data = new CommandResponse(errors);
            data.StatusCode = 400;
            data.Message = message;
            return data;
        }

        public CommandResponse InternalServerErrorResponse(object errors, string message)
        {
            var data = new CommandResponse(errors);
            data.StatusCode = 500;
            data.Message = message;
            return data;
        }
    }
}
