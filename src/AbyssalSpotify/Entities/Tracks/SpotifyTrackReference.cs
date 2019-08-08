﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AbyssalSpotify
{
    /// <summary>
    ///     A light data class containing some album data, sometimes returned by the Spotify API
    ///     in lieu of a full <see cref="SpotifyTrack"/> object.
    /// </summary>
    public class SpotifyTrackReference : SpotifyReference<SpotifyTrack>
    {
        /// <summary>
        ///     A list of references to the artists who performed the track.
        /// </summary>
        [JsonPropertyName("artists")]
        public ImmutableArray<SpotifyArtistReference> Artists { get; }

        /// <summary>
        ///     A list of ISO 3166-1 alpha-2 country codes, representing markets in which this track can be played.
        /// </summary>
        [JsonPropertyName("available_markets")]
        public ImmutableArray<string> AvailableMarkets { get; }

        /// <summary>
        ///     The disc number, usually <c>1</c> unless the album consists of more than one disc.
        /// </summary>
        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; }

        /// <summary>
        ///     The duration of the track.
        /// </summary>
        [JsonPropertyName("duration_ms")]
        public TimeSpan Duration { get; }

        /// <summary>
        ///     Whether or not this track has explicit lyrics. Note that <c>false</c> means the track doesn't have explicit lyrics OR it is unknown.
        /// </summary>
        [JsonPropertyName("explicit")]
        public bool HasExplicitLyrics { get; }

        /// <summary>
        ///     A collection of known external URLs for this track.
        /// </summary>
        [JsonPropertyName("external_urls")]
        public SpotifyExternalUrlsCollection ExternalUrls { get; }

        /// <summary>
        ///     The Spotify ID data for this track.
        /// </summary>
        [JsonPropertyName("uri")]
        public SpotifyUri Id { get; }

        // TODO: Track Relinking (is_playable, linked_from, restrictions)

        /// <summary>
        ///     The name of this track.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; }

        /// <summary>
        ///     A URL to a 30-second preview (in MP3 format) of the track.
        /// </summary>
        [JsonPropertyName("preview_url")]
        public string PreviewUrl { get; }

        /// <summary>
        ///     The number of the track on this disc. If the album has several discs,
        ///     the track number is the number on the specified disc.
        /// </summary>
        [JsonPropertyName("track_number")]
        public int TrackNumber { get; }

        /// <summary>
        ///     Whether or not the track is from a Spotify local file.
        /// </summary>
        [JsonPropertyName("is_local")]
        public bool IsLocalTrack { get; }

        /// <inheritdoc />
        public override Task<SpotifyTrack> GetFullEntityAsync(SpotifyClient client) => client.GetTrackAsync(Id.Id);
    }
}