using JsonStudy.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonStudy.Models
{
    public class ResponseMovieDBOrg
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("results"), JsonConverter(typeof(JsonDataTypeConverter))]
        public IList<IDataType> Results { get; set; }
    }

    public class TV : IDataType
    {
        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("first_air_date")]
        public string FirstAirDate { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("genre_ids")]
        public IList<int> GenreIds { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("origin_country")]
        public IList<string> OriginCountry { get; set; }
    }

    public class Person : IDataType
    {
        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("profile_path")]
        public object ProfilePath { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("known_for")]
        public IList<Movie> KnownFor { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }
    }

    public class Movie : IDataType
    {
        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("genre_ids")]
        public IList<int> GenreIds { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
    }    

}
