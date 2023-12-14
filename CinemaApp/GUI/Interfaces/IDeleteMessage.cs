using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface IDeleteMessage
    {
        void Show();
        void Close();
        void BringToFront();

        event EventHandler submitDelete;
        event EventHandler cancelDelete;
    }
}
