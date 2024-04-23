using System.Net;
using System.Text;

using System.Text.Json;
using MPP_Csharp_Server_Client.FlightModel.domain.exceptions;

namespace MPP_Csharp_Server_Client.Api.view_models
{
    public class MyHttpResponseMessage : HttpResponseMessage
    {
        private MyHttpResponseMessage(MyHttpResponseMessageBuilder builder)
        {
            if (!Enum.IsDefined(typeof(HttpStatusCode), builder.StatusCode))
            {
                builder.StatusCode = 417;
            }
            
            base.StatusCode = (HttpStatusCode)Enum.ToObject(typeof(HttpStatusCode), builder.StatusCode);
            
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };
            base.Content = new StringContent(JsonSerializer.Serialize(builder.Content, options), Encoding.UTF8, "application/json");
        }
        
        
        
        public class MyHttpResponseMessageBuilder
        {
            public int StatusCode { get; set; }
            public object? Content { get; set; }
            
            public MyHttpResponseMessageBuilder(int statusCode = 418, object? content = null)
            {
                StatusCode = statusCode;
                Content = content;
            }
            
            public MyHttpResponseMessageBuilder SetAll(Func<object?> getContent)
            {
                try
                {
                    Content = getContent.Invoke();
                    StatusCode = 200;
                }
                catch (AbstractMyHttpException myHttpException)
                {
                    Content = myHttpException.Message;
                    StatusCode = myHttpException.Code;
                }
                catch (Exception)
                {
                    Content = "Severe internal server error";
                    StatusCode = 500;
                }
                return this;
            }
            
            public MyHttpResponseMessage Build()
            {
                return new MyHttpResponseMessage(this);
            }
            
            // public MyHttpResponseMessageBuilder SetStatusCode(int statusCode)
            // {
            //     StatusCode = statusCode;
            //     return this;
            // }
            //
            // public MyHttpResponseMessageBuilder SetContent(object? content)
            // {
            //     Content = content;
            //     return this;
            // }
        }
    }
}