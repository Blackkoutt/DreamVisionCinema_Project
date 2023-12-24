namespace GUI.Interfaces
{
    public interface IMoviesListView
    {
        event EventHandler ShowMovieRoom;
        void SetMoviesListBindingSource(BindingSource moviesList);
        event EventHandler searchMovieUser;
        event EventHandler sortASCUser;
        event EventHandler sortDSCUser;
        event EventHandler clearFiltersUser;
        public ComboBox SortCriteria { get; }
        public TextBox SearchValue { get; }
        void Show();
        void Close();
        void BringToFront();
        DataGridView dataGridView { get; }
    }
}
