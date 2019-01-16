using System;

namespace CqsBareMetal.Apis.v1
{
    public class SaveBookCommandError : IError
    {
        public string Value { get; }

        public const string OtherError = nameof(OtherError);
        public static readonly SaveBookCommandError Set_OtherError = new SaveBookCommandError(OtherError);

        public const string InternalServerError = nameof(InternalServerError);
        public static readonly SaveBookCommandError Set_InternalServerError = new SaveBookCommandError(InternalServerError);

        private SaveBookCommandError(string value)  // We use a private constructor because this should be instantiated only through static factories
        {
            Value = value;
        }
    }
}