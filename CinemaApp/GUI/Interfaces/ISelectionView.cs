using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface ISelectionView
    {
        void Show();
        void Close();
        void Hide();
        void BringToFront();
        event EventHandler ShowAuthenticationView;
        event EventHandler ShowMainUserView;
        void StartFailure(string msg);
    }
}
