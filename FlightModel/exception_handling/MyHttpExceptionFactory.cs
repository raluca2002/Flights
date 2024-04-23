
using MPP_Csharp_Server_Client.FlightModel.domain.exception_handling;
using MPP_Csharp_Server_Client.FlightModel.domain.exceptions;

namespace MPP_Csharp_Server_Client.FlightModel.domain
{
    public class MyHttpExceptionFactory : IMyHttpExceptionFactory
    {
        public static MyBadReqHttpException CreateBadReqException(
            string message = "Bad request")
        {
            return new MyBadReqHttpException(message);
        }

        public static MyUnauthorizedHttpException CreateUnauthorizedException(
            string message = "Unauthorized request")
        {
            return new MyUnauthorizedHttpException(message);
        }

        public static MyForbiddenHttpException CreateForbiddenException(
            string message = "Forbidden request")
        {
            return new MyForbiddenHttpException(message);
        }
        
        /// <summary>
        ///  most used exception
        /// </summary>
        /// <param name="message"> the message in the new exceptoion </param>
        /// <returns> a new MyCoffeeHttpException </returns>
        public static MyFlightHttpException CreateFlightException(
            string message = "exceptieeeeeeeee")
        {
            return new MyFlightHttpException(message);
        }

        public static MyInternalServerErrorHttpException CreateInternalServerErrorException(
            string message = "Internal server error")
        {
            return new MyInternalServerErrorHttpException(message);
        }
    }
}