using System;

namespace Utilities.Exceptions {
    internal class UnexpectedValueException : Exception {
        internal UnexpectedValueException(object value) : base(GetMessage(value)) { }
        internal UnexpectedValueException(object value, string objectName) : base(GetMessage(value, objectName)) { }

        private static string GetMessage(object value) {
            return $"Unexpected value \'{value}\' of type \'{value.GetType().FullName}\'";
        }
        private static string GetMessage(object value, string objectName) {
            return $"Object \'{objectName}\' has unexpected value \'{value}\' of type \'{value.GetType().FullName}\'";
        }
    }
}