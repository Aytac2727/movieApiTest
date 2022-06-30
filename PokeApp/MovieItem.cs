namespace MovieApp
{
    public class MovieItem
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }  
        public MovieItem(string title, string year, string genre, string plot, string actors)
        {
            Title = title;
            Year = year;
            Genre = genre;
            Plot = plot;
            Actors = actors;
        }
    }

}
