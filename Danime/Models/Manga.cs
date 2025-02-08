using System;
using System.Collections.Generic;

namespace Danime.Models
{
    public class MangaData
    {
        public class Author
        {
            public int mal_id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Datum
        {
            public int mal_id { get; set; }
            public string url { get; set; }
            public Images images { get; set; }
            public bool approved { get; set; }
            public List<Title> titles { get; set; }
            public string title { get; set; }
            public string title_english { get; set; }
            public string title_japanese { get; set; }
            public List<string> title_synonyms { get; set; }
            public string type { get; set; }
            public int? chapters { get; set; }
            public int? volumes { get; set; }
            public string status { get; set; }
            public bool publishing { get; set; }
            public Published published { get; set; }
            public double? score { get; set; }
            public double? scored { get; set; }
            // Make scored_by nullable to handle null values from the API.
            public int? scored_by { get; set; }
            // Changed rank to nullable int.
            public int? rank { get; set; }
            public int popularity { get; set; }
            public int members { get; set; }
            public int favorites { get; set; }
            public string synopsis { get; set; }
            public string background { get; set; }
            public List<Author> authors { get; set; }
            public List<Serialization> serializations { get; set; }
            public List<Genre> genres { get; set; }
            public List<object> explicit_genres { get; set; }
            public List<Theme> themes { get; set; }
            public List<Demographic> demographics { get; set; }
        }

        public class Demographic
        {
            public int mal_id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        // Updated properties to be nullable to handle potential null values from the API.
        public class From
        {
            public int? day { get; set; }
            public int? month { get; set; }
            public int? year { get; set; }
        }

        public class Genre
        {
            public int mal_id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Images
        {
            public Jpg jpg { get; set; }
            public Webp webp { get; set; }
        }

        public class Items
        {
            public int count { get; set; }
            public int total { get; set; }
            public int per_page { get; set; }
        }

        public class Jpg
        {
            public string image_url { get; set; }
            public string small_image_url { get; set; }
            public string large_image_url { get; set; }
        }

        public class Pagination
        {
            public int last_visible_page { get; set; }
            public bool has_next_page { get; set; }
            public int current_page { get; set; }
            public Items items { get; set; }
        }

        public class Prop
        {
            public From from { get; set; }
            public To to { get; set; }
        }

        public class Published
        {
            // Changed to nullable DateTime to safely handle null values from the API.
            public DateTime? from { get; set; }
            public DateTime? to { get; set; }
            public Prop prop { get; set; }
            public string @string { get; set; }
        }

        // This class is used when the API returns multiple manga items (e.g., search results)
        public class Root
        {
            public Pagination pagination { get; set; }
            public List<Datum> data { get; set; }
        }

        // New class for wrapping a single manga detail response
        public class RootSingle
        {
            public Datum data { get; set; }
        }

        public class Serialization
        {
            public int mal_id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Theme
        {
            public int mal_id { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Title
        {
            public string type { get; set; }
            public string title { get; set; }
        }

        public class To
        {
            public int? day { get; set; }
            public int? month { get; set; }
            public int? year { get; set; }
        }

        public class Webp
        {
            public string image_url { get; set; }
            public string small_image_url { get; set; }
            public string large_image_url { get; set; }
        }
    }
}
