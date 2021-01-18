using System;
using System.Collections.Generic;

namespace Core
{
    public partial class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTimeOffset? CreateTime { get; set; }
    }
}
