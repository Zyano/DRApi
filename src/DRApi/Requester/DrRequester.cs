using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using DRApi.Bar;
using DRApi.Channel;
using DRApi.Configuration;
using DRApi.Helper;
using DRApi.List;
using DRApi.Manifest;
using Newtonsoft.Json;

namespace DRApi.Requester {
    public class DrRequester : IDrRequester {
        /// <summary>
        /// Redirects to the desired asset. Targets includes images, subtitles and public manifests. Queries are forwarded to the destination.
        /// </summary>
        /// <param name="id">Unique asset reference. (URN)</param>
        /// <returns cref="BarResponse">Redirects to another controller. Can throw 4xx or 5xx if not found or invalid data is present.</returns>
        public async Task<BarResponse> BarAsync(string id) {
            string url = $"http://www.dr.dk/mu-online/api/1.3/bar/{id}";
            DownloadClient<BarResponse> dc = new DownloadClient<BarResponse>();
            return await dc.DownloadAndConvert(url);
        }
        /// <summary>
        /// Gets an image for a bundle. Falls back to the image from the override bundle id if specified in forcechanneloverrideid, otherwise it falls back to PrimaryChannel image, if the bundles does not have an image.
        /// </summary>
        /// <param name="id">Bundle slug or urn.</param>
        /// <param name="forcechanneloverrideid">Optional fallback bundle slug or urn. Can be used to override image from channel bundle.</param>
        /// <returns cref="BarResponse"></returns>
        public async Task<BarResponse> BarImageForBundleAsync(string id, string forcechanneloverrideid) {
            string url = $"http://www.dr.dk/mu-online/api/1.3/bar/helper/get-image-for-bundle/{id}/{forcechanneloverrideid}";
            DownloadClient<BarResponse> dc = new DownloadClient<BarResponse>();
            return await dc.DownloadAndConvert(url);
        }
        /// <summary>
        /// Gets an image for a programcard. Falls back to series image, then the image from the override bundle id if specified, otherwise to the PrimaryChannel image, if the bundles does not have an image.
        /// </summary>
        /// <param name="id">Programcard slug or urn.</param>
        /// <param name="forcechanneloverrideid">Optional fallback bundle slug or urn. Can be used to override image from channel bundle.</param>
        /// <returns cref="BarResponse"></returns>
        public async Task<BarResponse> BarImageForProgramcardAsync(string id, string forcechanneloverrideid) {
            string url=$"http://www.dr.dk/mu-online/api/1.3/bar/helper/get-image-for-programcard/{id}/{forcechanneloverrideid}";
            DownloadClient<BarResponse> dc = new DownloadClient<BarResponse>();
            return await dc.DownloadAndConvert(url);
        }
        /// <summary>
        /// Return info for a given channel
        /// </summary>
        /// <param name="id">Channel slug, urn or WhatsOnUri.</param>
        /// <returns cref="ChannelResponse"></returns>
        public async Task<ChannelResponse> ChannelAsync(string id) {
            string url=$"http://www.dr.dk/mu-online/api/1.3/channel/{id}";
            DownloadClient<ChannelResponse> dc = new DownloadClient<ChannelResponse>();
            return await dc.DownloadAndConvert(url);
        }
        /// <summary>
        /// Return all active radio channels
        /// </summary>
        /// <returns cref="ChannelResponse"></returns>
        public async Task<ChannelResponse> ChannelAllActiveDrRadioAsync() {
            string url="http://www.dr.dk/mu-online/api/1.3/channel/all-active-dr-radio-channels";
            DownloadClient<ChannelResponse> dc = new DownloadClient<ChannelResponse>();
            return await dc.DownloadAndConvert(url);
        }
        /// <summary>
        /// Gets all active tv channels. DR1, DR2, DR3, DR Ramasjang, DR Ultra and DR K
        /// </summary>
        /// <returns cref="ChannelResponse"></returns>
        public async Task<ChannelResponse> ChannelAllActiveDrTvAsync() {
            string url="http://www.dr.dk/mu-online/api/1.3/channel/all-active-dr-tv-channels";
            DownloadClient<ChannelResponse> dc = new DownloadClient<ChannelResponse>();
            return await dc.DownloadAndConvert(url);
        }

        /// <summary>
        /// Read a given configuration.
        /// </summary>
        /// <param name="id">Configration id. eg. tv-global-message</param>
        /// <returns></returns>
        public async Task<ConfigurationResponse> ConfigurationAsync(string id) {
            string url = $"http://www.dr.dk/mu-online/api/1.3/configuration/service-message/%7Bid%7D";
            DownloadClient<ConfigurationResponse> dc = new DownloadClient<ConfigurationResponse>();
            return await dc.DownloadAndConvert(url);
        }
        /// <summary>
        /// Returns a service message for a given id. If it is enabled otherwise null.
        /// </summary>
        /// <param name="id">Configuration id</param>
        /// <returns></returns>
        public async Task<ConfigurationResponse> ConfigurationServiceMessageAsync(string id) {
            string url=$"http://www.dr.dk/mu-online/api/1.3/configuration/service-message/%7Bid%7D";
            DownloadClient<ConfigurationResponse> dc = new DownloadClient<ConfigurationResponse>();
            return await dc.DownloadAndConvert(url);
        }
        // TODO: 'limit' is limited to 60
        /// <summary>
        /// Gets a paged list by either slug or urn.
        /// </summary>
        /// <param name="id">Bundle slug or urn</param>
        /// <param name="limit">Page size, must be less than 60. (Optional)</param>
        /// <param name="offset">Page offset. (Optional)</param>
        /// <param name="excludedId">An id to exclude from the list. This can either be an urn or a slug (Optional)</param>
        /// <returns cref="ListResponse"></returns>
        public async Task<ListResponse> ListAsync(string id, int limit = 5, int offset = 0, string excludedId = "") {
            string url=$"http://www.dr.dk/mu-online/api/1.3/list/{id}&limit={limit}&offset={offset}&excludeid={excludedId}";
            DownloadClient<ListResponse> dc = new DownloadClient<ListResponse>();
            return await dc.DownloadAndConvert(url);
        }
        // TODO: channel is channelSlug (build enum with these for easier use in the future
        /// <summary>
        /// 
        /// </summary>
        /// <param name="limit">Page size, must be less than 48. (Optional)</param>
        /// <param name="offset">Page offset default is 0. (Optional)</param>
        /// <param name="channel">Channel to select last chance from. Default is all DR Channels except children channels. (Optional)</param>
        /// <returns></returns>
        public async Task<ListResponse> ListLastChanceAsync(int limit = 5, int offset = 0, string channel = "") {
            string url=$"http://www.dr.dk/mu-online/api/1.3/list/view/lastchance?limit={limit}&offset={offset}&channel={channel}";
            DownloadClient<ListResponse> dc = new DownloadClient<ListResponse>();

            return await dc.DownloadAndConvert(url);
        }

        /// <summary>
        /// Gets a paged list of most viewed programcards within the latest 7 days filtered by channel and channeltype. Lists are paged by 12 per default.
        /// </summary>
        /// <param name="channel">Channel slug e.g. dr1, dr2 or whatsOnUri</param>
        /// <param name="channelType">TV or RADIO</param>
        /// <param name="limit">Page size, must be less than 48. (Optional)</param>
        /// <param name="offset">Page offset. (Optional)</param>
        /// <returns cref="ListResponse"></returns>
        public async Task<ListResponse> ListMostViewedAsync(string channel, string channelType = "TV", int limit = 5, int offset = 0) {
            string url= $"http://www.dr.dk/mu-online/api/1.3/list/view/mostviewed?channel={channel}&channeltype={channelType}&limit={limit}&offset={offset}";
            DownloadClient<ListResponse> dc = new DownloadClient<ListResponse>();
            return await dc.DownloadAndConvert(url);
        }
        /// <summary>
        /// List of news for the news zone.
        /// Obtains the news information used on dr.dk
        /// </summary>
        /// <param name="limit">Page size. Default value 5. (Optinal)</param>
        /// <param name="offset">Page offset. Default value 0. (Optinal)</param>
        /// <returns cref="ListResponse"></returns>
        public async Task<ListResponse> ListNewsAsync(int limit = 5, int offset = 0) {
            string url = $"http://www.dr.dk/mu-online/api/1.3/list/view/news?limit{limit}&offset={offset}";
            DownloadClient<ListResponse> dc = new DownloadClient<ListResponse>();
            return await dc.DownloadAndConvert(url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderDescending"></param>
        /// <param name="limitPrograms"></param>
        /// <param name="limitEpisodes"></param>
        /// <returns cref="ListQuickSearchResponse"></returns>
        public async Task<ListQuickSearchResponse> ListQuickSearchAsync(string query, string orderBy = "", bool orderDescending = false, int limitPrograms = 5, int limitEpisodes = 5) {
            // Ugly if else structure
            string url =
                $"http://www.dr.dk/mu-online/api/1.3/search/tv/programcards-latest-episode-with-broadcast/series-title-starts-with/{query}?limit={limitPrograms}&limitepisodes{limitEpisodes}";
            if(!string.IsNullOrEmpty(orderBy)) {
                url += $"&orderby={orderBy}&orderdescending={orderDescending}";
            }
            DownloadClient<ListQuickSearchResponse> dc = new DownloadClient<ListQuickSearchResponse>();
            return await dc.DownloadAndConvert(url);
        }

        /// <summary>
        /// Gets a list of current selected spots. First item with larger image than the following items.
        /// </summary>
        /// <param name="limit">Page size, must be less than 60. (Optional)</param>
        /// <param name="offset">Page offset. (Optional)</param>
        /// <returns></returns>
        public async Task<ListResponse> ListSelectedListAsync(int limit = 5, int offset = 0) {
            string url = $"http://www.dr.dk/mu-online/api/1.3/list/view/selectedlist?limit={limit}&offset={offset}";
            DownloadClient<ListResponse> dc = new DownloadClient<ListResponse>();
            return await dc.DownloadAndConvert(url);
        }

        /// <summary>
        /// Gets suggested programs which relates to the supplied programcard id. Standard for not logged in users
        /// </summary>
        /// <param name="programcardId">Urn or Slug for programcard</param>
        /// <param name="limit">Page size. Default value 10. (Optional)</param>
        /// <param name="offset">Page offset. Default value 0. (Optional)</param>
        /// <param name="channel">Required for Ramasjang (dr-ramasjang) and Ultra (dr-ultra). But not for other channels</param>
        /// <returns cref="ListResponse">A list cotaining the obtained suggestions based on the progg</returns>
        public async Task<ListResponse> ListSuggestions(string programcardId, int limit = 5, int offset = 0, string channel = "") {
            string url = $"http://www.dr.dk/mu-online/api/1.3/list/view/suggestions?programcardid={programcardId}&limit={limit}&offset={offset}&channel={channel}";
            DownloadClient<ListResponse> dc = new DownloadClient<ListResponse>();
            return await dc.DownloadAndConvert(url);
        }

        /// <summary>
        /// Overview list of themes. Combines first programcard from each theme into one list. 
        /// Series information on each MuListItem is info from theme and not from the belonging series. 
        /// Changed the overview collection only to include repremiere themes according to aggrement with Sille
        /// </summary>
        /// <param name="limit">Default value is 5</param>
        /// <param name="offset">Default value is 0</param>
        /// <returns></returns>
        public async Task<ListResponse> ListThemesOverviewAsync(int limit = 5, int offset = 0) {
            string url = $"http://www.dr.dk/mu-online/api/1.3/list/view/themesoverview?limit={limit}&offset={offset}";
            DownloadClient<ListResponse> dc = new DownloadClient<ListResponse>();
            return await dc.DownloadAndConvert(url);
        }

        public async Task<ManifestResponse> ManifestAysnc(string id) {
            string url=$"http://www.dr.dk/mu-online/api/1.3/manifest/{id}";
            DownloadClient<ManifestResponse> dc = new DownloadClient<ManifestResponse>();
            return await dc.DownloadAndConvert(url);
        }

        /// <summary>
        /// Free text search method. Searches free text in Series Titles.
        /// The series must have one or more programcards with a public asset. 
        /// The result is ordered alphabetically by series title, unless otherwise is specified in paramters.
        /// </summary>
        /// <param name="query">Search query SeriesTitle</param>
        /// <param name="onlineGenreTexts">
        /// Comma seperated genre list to filter search on. List of online genres :
        /// "Drama" ,"Dokumentar", "Livsstil", "Kultur", "Natur & viden", 
        /// "Nyheder & aktualitet", "Sport" and "Underholdning". (Optional)</param>
        /// <param name="channels">Comma seperated channel slug or whatsOnUri list. (Optional)</param>
        /// <param name="orderBy">Supported values are "Title" and "PrimaryBroadcastDay". Default sort order is ascending by title. (Optional)</param>
        /// <param name="orderDescending">True will sort descending, and false will sort ascending. This value is only use, if orderBy has a value. Default is false. (Optional)</param>
        /// <param name="excludeGeofiltered">Filter to exclude geofiltered programcards. Default is false. (Optional)</param>
        /// <param name="limit">Page size, must be less than 75. (Optional)</param>
        /// <param name="offset">Page offset. (Optional)</param>
        /// <param name="assetTarget">Asset target to filter search on. Possible values : "Default", "SpokenSubtitles", "VisuallyInterpreted", "SignLanguage"</param>
        /// <returns></returns>
        public async Task<ListResponse> SearchProgramcardsWithPublicAssetAsync(string query, string onlineGenreTexts = "", string channels = "", string orderBy = "", bool orderDescending = false,
         bool excludeGeofiltered = false, int limit = 5, int offset = 0, string assetTarget = "") {
            // Ugly if else structure
            string url = $"http://www.dr.dk/mu-online/api/1.3/search/tv/programcards-latest-episode-with-asset/series-title/{query}?limit={limit}&excludegeofiltered={excludeGeofiltered}&offset={offset}";
            if(!string.IsNullOrEmpty(onlineGenreTexts)) {
                url += $"&onlinegenretexts={onlineGenreTexts}";
            }
            if(!string.IsNullOrEmpty(channels)) {
                url += $"&channels={channels}";
            }
            if(!string.IsNullOrEmpty(orderBy)) {
                url += $"&orderby={orderBy}&orderdescending={orderDescending}";
            }
            if(!string.IsNullOrEmpty(assetTarget)) {
                url += $"&assettarget={assetTarget}";
            }
            DownloadClient<ListResponse> dc = new DownloadClient<ListResponse>();
            return await dc.DownloadAndConvert(url);
        }

        /// <summary>
        /// Free text search method. Searches Series Titles starting with the supplied query. The result is ordered alphabetically by series title, unless otherwise is specified in paramters.
        /// </summary>
        /// <param name="query">Search query SeriesTitle</param>
        /// <param name="onlineGenreTexts"> Comma seperated genre list to filter search on.List of online genres : 
        /// "Drama" ,"Dokumentar", "Livsstil", "Kultur", "Natur & viden", "Nyheder & aktualitet", "Sport" and "Underholdning". 
        /// (Optional)</param>
        /// <param name="channels">Comma seperated channel slug or whatsOnUri list. (Optional)</param>
        /// <param name="orderBy">Supported values are "Title" and "PrimaryBroadcastDay". Default sort order is ascending by title. (Optional)</param>
        /// <param name="orderDescending">True will sort descending, and false will sort ascending. This value is only use, if orderBy has a value. Default is false. (Optional)</param>
        /// <param name="excludeGeofiltered">Filter to exclude geofiltered programcards.Default is false. (Optional)</param>
        /// <param name="limit">Page size, must be less than 75. (Optional)</param>
        /// <param name="offset">Page offset. (optional)</param>
        /// <param name="assetTarget"></param>
        /// <returns></returns>
        public async Task<ListResponse> SearchProgramcardsLatestEpisodeWithBroadcastAsync(string query, string onlineGenreTexts = "", string channels = "", string orderBy = "", bool orderDescending = false,
         bool excludeGeofiltered = false, int limit = 5, int offset = 0, string assetTarget = "") {
            string url =
                $"http://www.dr.dk/mu-online/api/1.3/search/tv/programcards-latest-episode-with-broadcast/series-title-starts-with/{query}?limit={limit}&orderdescending={orderDescending}&excludegeofiltered={excludeGeofiltered}";
            if(!string.IsNullOrEmpty(onlineGenreTexts)) {
                url += $"&onlinegenretexts={onlineGenreTexts}";
            }
            if(!string.IsNullOrEmpty(channels)) {
                url += $"&channels={channels}";
            }
            if(!string.IsNullOrEmpty(orderBy)) {
                url += $"&orderby={orderBy}";
            }
            if(offset > 0) {
                url += $"&offset={offset}";
            }
            if(!string.IsNullOrEmpty(assetTarget)) {
                url += $"&assettarget={assetTarget}";
            }
            DownloadClient<ListResponse> dc = new DownloadClient<ListResponse>();
            return await dc.DownloadAndConvert(url);
        }

        /// <summary>
        /// Gets a ProgramCard by id
        /// </summary>
        /// <param name="id">Urn or Slug</param>
        /// <returns>Programcard</returns>
        public async Task<Programcard.Programcard> GetProgramcard(string id) {
            string url = $"http://www.dr.dk/mu-online/api/1.3/programcard/{id}";
            DownloadClient<Programcard.Programcard> dc = new DownloadClient<Programcard.Programcard>();
            return await dc.DownloadAndConvert(url);
        }
    }
}
