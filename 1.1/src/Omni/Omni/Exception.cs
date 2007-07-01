using System;
using System.Collections.Generic;
using System.Text;

namespace Omni
{
    public class InvalidUsernameException : Exception { }
    public class InvalidEmailException : Exception { }
    public class DuplicateUsernameException : Exception { }
    public class InvalidCaptchaException : Exception { }
    public class InvalidSessionException : Exception { }
}
