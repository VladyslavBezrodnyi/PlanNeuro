namespace PlanNeuro.Domain.Responses
{
    public class OkResponse : BaseResponse
    {
        public object Data { get; set; }

        public OkResponse(int statusCode, object data)
            : base(statusCode)
        {
            Data = data;
        }
    }
}
