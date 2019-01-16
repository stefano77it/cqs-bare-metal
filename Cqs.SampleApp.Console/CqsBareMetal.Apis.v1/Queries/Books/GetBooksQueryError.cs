using System;

namespace CqsBareMetal.Apis.v1
{
    public class GetBooksQueryError : IError
    {
        public string Value { get; }

        public const string OtherError = nameof(OtherError);
        public static readonly GetBooksQueryError Set_OtherError = new GetBooksQueryError(OtherError);

        public const string InternalServerError = nameof(InternalServerError);
        public static readonly GetBooksQueryError Set_InternalServerError = new GetBooksQueryError(InternalServerError);

        private GetBooksQueryError(string value)  // We use a private constructor because this should be instantiated only through static factories
        {
            Value = value;
        }
    }
}
