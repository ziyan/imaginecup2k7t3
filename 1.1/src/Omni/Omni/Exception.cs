using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    public class InvalidUsernameException : Exception { }
    public class InvalidEmailException : Exception { }
    public class DuplicateUsernameException : Exception { }
    public class DuplicateEmailException : Exception { }
    public class InvalidCaptchaException : Exception { }
    public class InvalidSessionException : Exception { }
    public class UserAlreadyLoggedInException : Exception { }
    public class UserNotLoggedInException : Exception { }
}
