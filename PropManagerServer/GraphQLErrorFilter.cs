namespace PropManagerServer
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if(error.Exception != null)
            {
                if (error.Exception is ArgumentException)
                {
                    return error.WithMessage(error.Exception.Message);
                }
                               
            }
            return error;
        }
    }
}
