using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRApi.Bar;
using DRApi.Channel;
using DRApi.Configuration;
using DRApi.List;
using DRApi.Manifest;

namespace DRApi.Requester {
    internal interface IDrRequester {
        Task<BarResponse> BarAsync(string id);
        Task<BarResponse> BarImageForBundleAsync(string id, string forcechanneloverrideid);
        Task<BarResponse> BarImageForProgramcardAsync(string id, string forcechanneloverrideid);
        Task<ChannelResponse> ChannelAsync(string id);
        Task<ChannelResponse> ChannelAllActiveDrRadioAsync();
        Task<ChannelResponse> ChannelAllActiveDrTvAsync();
        Task<ConfigurationResponse> ConfigurationAsync(string id);
        Task<ConfigurationResponse> ConfigurationServiceMessageAsync(string id);
        Task<ListResponse> ListAsync(string id, int limit, int offset, string excludedId);
        Task<ListResponse> ListLastChanceAsync(int limit, int offset, string channel);
        Task<ListResponse> ListMostViewedAsync(string channel, string channelType, int limit, int offset);
        Task<ListResponse> ListNewsAsync(int limit, int offset);
        Task<ListQuickSearchResponse> ListQuickSearchAsync(string query, string orderBy, bool orderDescending, int limitPrograms, int limitEpisodes);
        Task<ListResponse> ListSelectedListAsync(int limit, int offset);
        Task<ListResponse> ListSuggestions(string programcardId, int limit, int offset, string channel);
        Task<ListResponse> ListThemesOverviewAsync(int limit, int offset);
        Task<ManifestResponse> ManifestAysnc(string id);        
        Task<ListResponse> SearchProgramcardsWithPublicAssetAsync(string query, string onlineGenreTexts, string channels, string orderBy, bool orderDescending, bool excludeGeofiltered, int limit, int offset, string assetTarget);
        Task<ListResponse> SearchProgramcardsLatestEpisodeWithBroadcastAsync(string query, string onlineGenreTexts, string channels, string orderBy, bool orderDescending, bool excludeGeofiltered, int limit, int offset, string assetTarget);        
        Task<Programcard.Programcard> GetProgramcard(string id);
    }
}