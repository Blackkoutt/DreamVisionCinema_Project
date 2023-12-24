namespace GUI.Interfaces
{
    public interface IAdminMoviesView
    {
        event EventHandler addMovie;
        event EventHandler modifyMovie;
        event EventHandler deleteMovie;
        event EventHandler clearFilters;
        event EventHandler searchMovie;
        event EventHandler sortASC;
        event EventHandler sortDSC;
        public ComboBox SortCriteria { get; }
        public TextBox SearchValue { get; }
        void Show();
        void Close();
        void BringToFront();
        void SetMoviesListBindingSource(BindingSource moviesList);
    }
}
