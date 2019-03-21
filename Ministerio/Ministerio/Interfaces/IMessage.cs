using System;
using System.Collections.Generic;
using System.Text;

namespace Ministerio.Interfaces
{
    public interface IMessage
    {
        void LongToast(string mensaje);
        void ShortToast(string mensaje);
    }
}
