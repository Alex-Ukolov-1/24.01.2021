using System;
using System.Collections.Generic;
using System.Text;

namespace fabric_method_cinema
{
    interface IMessanger
    {
        string UserName { get; }
        string Password { get; }
        bool Connected { get; }
        IMessage CreateMessage(string text, string source, string target);
        bool Authorize();
    }
}
