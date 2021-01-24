using System;
using System.Collections.Generic;
using System.Text;

namespace fabric_method_cinema
{
    public interface IMessage
    {
        string Text { get; }
        string Target { get; }
        string Source { get; }
        void Send();
    }
}
