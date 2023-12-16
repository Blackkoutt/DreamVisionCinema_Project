using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Interfaces
{
    public interface IAdminStatisticsView
    {
        void Show();
        void Close();
        void BringToFront();
        public Label Earings { get; }
        public Label Guideline { get; }
        public CircularProgressBar.CircularProgressBar Progress { get; }

        event EventHandler mostPopularClickEvent;
        event EventHandler mostProfitableClickEvent;

    }
}
