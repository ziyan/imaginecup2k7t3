using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    public class InvalidUsernameException : System.Exception { }
    public class InvalidEmailException : System.Exception { }
    public class DuplicateUsernameException : System.Exception { }
    public class DuplicateEmailException : System.Exception { }
    public class InvalidCaptchaException : System.Exception { }
    public class InvalidSessionException : System.Exception { }
    public class UserAlreadyLoggedInException : System.Exception { }
    public class UserNotLoggedInException : System.Exception { }
    public class TryLoginTooManyTimesException : System.Exception { }
    public static class Exception
    {
        public static void Rethrow(System.Exception e)
        {
            if (e.InnerException != null)
                throw e.InnerException;
            if (e.ToString().IndexOf("InvalidUsernameException") > -1)
                throw new InvalidUsernameException();
            if (e.ToString().IndexOf("InvalidSessionException") > -1)
                throw new InvalidSessionException();
            if (e.ToString().IndexOf("InvalidEmailException") > -1)
                throw new InvalidEmailException();
            if (e.ToString().IndexOf("DuplicateUsernameException") > -1)
                throw new DuplicateUsernameException();
            if (e.ToString().IndexOf("DuplicateEmailException") > -1)
                throw new DuplicateEmailException();
            if (e.ToString().IndexOf("InvalidCaptchaException") > -1)
                throw new InvalidCaptchaException();
            if (e.ToString().IndexOf("UserAlreadyLoggedInException") > -1)
                throw new UserAlreadyLoggedInException();
            if (e.ToString().IndexOf("UserNotLoggedInException") > -1)
                throw new UserNotLoggedInException();
            if (e.ToString().IndexOf("TryLoginTooManyTimesException") > -1)
                throw new TryLoginTooManyTimesException();
            if (e.ToString().IndexOf("ArgumentNullException") > -1)
                throw new ArgumentNullException();
            if (e.ToString().IndexOf("ArgumentException") > -1)
                throw new ArgumentException();
            if (e.ToString().IndexOf("ArgumentOutOfRangeException") > -1)
                throw new ArgumentOutOfRangeException();

            throw e;
        }
    }
}
