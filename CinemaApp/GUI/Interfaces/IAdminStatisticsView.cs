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
