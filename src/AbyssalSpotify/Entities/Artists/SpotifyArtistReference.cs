﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbyssalSpotify
{
    /// <summary>
    ///     A light data class containing some artist data, sometimes returned by the Spotify API
    ///     in lieu of a full <see cref="SpotifyArtist"/> object.
    /// </summary>
    public class SpotifyArtistReference : SpotifyReference<SpotifyArtist>
    {
        /// <summary>
        ///     A list of all known external URLs for this artist, like Twitter, Facebook, etc.
        ///     This dictionary allows custom indexing for unknown properties.
        /// </summary>
        public SpotifyExternalUrlsCollection ExternalUrls { get; }

        /// <summary>
        ///     The Spotify ID data for this artist.
        /// </summary>
        public SpotifyUri Id { get; }

        /// <summary>
        ///     The name of the artist.
        /// </summary>
        public string Name { get; }

        /// <inheritdoc />
        public override Task<SpotifyArtist> GetFullEntityAsync() => Client.GetArtistAsync(Id.Id);

        internal SpotifyArtistReference(SpotifyClient client, JObject data) : base(client)
        {
            ExternalUrls = new SpotifyExternalUrlsCollection(data["external_urls"].ToObject<IDictionary<string, string>>());
            Id = new SpotifyUri(data["uri"].ToObject<string>());
            Name = data["name"].ToObject<string>();
        }
    }
}