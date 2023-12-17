using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface IAuthenticationView
    {
        void Show();
        void Close();
        void BringToFront();
        void Hide();
        public RichTextBox Login { get; }
        public RichTextBox Password { get; }
        event EventHandler SignIn;
    }
}
