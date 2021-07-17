using System;

namespace AzurLaneAPI.Errors.V1
{
    public static class Errors
    {
        public static class X400
        {
            public const String ResourceNotFound = "The requested resource could not be found";
            public const String ResourceWithIdDoesNotExist = "A resource with the given identifier does not exist";
        }

        public static class X500 
        {
            public const String RequestFailure = "The server was unable to process the request";
        }
    }
}