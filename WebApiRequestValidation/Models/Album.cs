namespace WebApiRequestValidation.Models
{
    using System;

    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ArtistName { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}