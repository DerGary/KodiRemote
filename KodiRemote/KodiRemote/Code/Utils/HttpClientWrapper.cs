using KodiRemote.Code.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace KodiRemote.Code.Utils {
    public abstract class AbstractHttpClient : HttpClient {
        protected abstract string MediaTypeString { get; }
        protected MediaTypeHeaderValue _mediaType;
        protected MediaTypeHeaderValue MediaType {
            get {
                if (_mediaType == null) {
                    _mediaType = new MediaTypeHeaderValue(MediaTypeString);
                }
                return _mediaType;
            }
        }
        protected MediaTypeWithQualityHeaderValue _mediaTypeQuality;
        protected MediaTypeWithQualityHeaderValue MediaTypeQuality {
            get {
                if (_mediaTypeQuality == null) {
                    _mediaTypeQuality = new MediaTypeWithQualityHeaderValue(MediaTypeString);
                }
                return _mediaTypeQuality;
            }
        }

        public AbstractHttpClient(string username, string password) : base() {
            this.DefaultRequestHeaders.Accept.Add(MediaTypeQuality);
            if (username != null || password != null) {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
                string s = System.Convert.ToBase64String(plainTextBytes);
                this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", s);
            }
        }

        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            if (request?.Content?.Headers?.ContentLength > 0) {
                request.Content.Headers.ContentType = MediaType;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
    public class JsonHttpClient : AbstractHttpClient {
        protected override string MediaTypeString {
            get {
                return "application/json";
            }
        }
        public JsonHttpClient(string username, string password) : base(username, password) { }
    }
    public class HttpClientWrapper : IDisposable {
        private JsonHttpClient client;

        public HttpClientWrapper() :this(null,null) {}
        public HttpClientWrapper(string username, string password) {
            client = new JsonHttpClient(username, password);
        }

        public async Task<RPCResponse<T>> GetAsync<T>(string url) {
            using (var response = await client.GetAsync(url)) {
                return JsonSerializer.FromJson<RPCResponse<T>>(await response.Content.ReadAsStringAsync());
            }
        }
        public async Task<InMemoryRandomAccessStream> GetAsync(string url) {
            InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
            using (var response = await client.GetAsync(url)) {
                if (!response.IsSuccessStatusCode) {
                    throw new Exception(response.StatusCode.ToString());
                }
                await (await response.Content.ReadAsStreamAsync()).CopyToAsync(stream.AsStreamForWrite());
                //await stream.FlushAsync();
                //stream.Seek(0);
                return stream;
            }
        }

        public async Task<RPCResponse<T>> PostAsync<T>(string url, RPC request) {
            var content = new StringContent(JsonSerializer.ToJson(request));
            using (var response = await client.PostAsync(url, content)) {
                return JsonSerializer.FromJson<RPCResponse<T>>(await response.Content.ReadAsStringAsync());
            }
        }

        public void Dispose() {
            client.Dispose();
        }
    }
}
