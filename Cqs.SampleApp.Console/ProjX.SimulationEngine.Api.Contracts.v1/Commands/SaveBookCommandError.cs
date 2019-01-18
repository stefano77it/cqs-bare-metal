using System;

namespace ProjX.SimulationEngine.Api.Contracts.v1
{
    public class SaveBookCommandError : IError
    {
        public string ErrorType { get; }
        public string ErrorDetail { get; }

        public const string OtherError = nameof(OtherError);
        public static readonly SaveBookCommandError Set_OtherError = new SaveBookCommandError(OtherError);

        public const string InternalServerError = nameof(InternalServerError);
        // method with a standard ErrorType message and a detailed server error
        public static SaveBookCommandError Set_InternalServerError(string errorDetail) => new SaveBookCommandError(InternalServerError, errorDetail);

        private SaveBookCommandError(string errorType)  // We use a private constructor because this should be instantiated only through static factories
        {
            ErrorType = errorType ?? throw new ArgumentNullException(nameof(errorType));  // can't be null, can be empty
            ErrorDetail = "";
        }

        private SaveBookCommandError(string errorType, string errorDetail)  // We use a private constructor because this should be instantiated only through static factories
        {
            ErrorType = errorType ?? throw new ArgumentNullException(nameof(errorType));  // can't be null, can be empty

            if (errorDetail is null) { ErrorDetail = ""; }  // if is null, is set to ""
            else { ErrorDetail = errorDetail; }
        }
    }
}