using Newtonsoft.Json;
using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace WSP.APPLICATION.CONNECTION.SERVICES.RestConnectionServices
{
    public enum Authentication
    {
        None,
        Header,
        Basic,
        Complete
    }
    public class WspAdministrationConnectionRest
    {
        public static async Task<T> Post<T>(string _urlBase, string _method, object _request, Authentication _authentication, string _usuario = "", string _password = "", string _channel = "", string _publicToken = "", string _appUserid = "")
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            httpClientHandler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
            var _clientRest = new RestClient(httpClientHandler);
            var _requestRest = new RestRequest(_urlBase + _method, Method.Post).AddJsonBody(_request);

            if (_authentication != Authentication.None)
            {
                switch (_authentication)
                {
                    case Authentication.Header:
                        _requestRest.AddHeader("USUARIO", _usuario);
                        _requestRest.AddHeader("PASSWORD", _password);
                        break;
                    case Authentication.Basic:
                        _clientRest.Authenticator = new HttpBasicAuthenticator(_usuario, _password);
                        break;
                    case Authentication.Complete:
                        _requestRest.AddHeader("channel", _channel);
                        _requestRest.AddHeader("publicToken", _publicToken);
                        _requestRest.AddHeader("appUserId", _appUserid);
                        _clientRest.Authenticator = new HttpBasicAuthenticator(_usuario, _password);
                        break;
                }
            }
            var _responseRest = await _clientRest.ExecutePostAsync(_requestRest);
            HttpStatusCode _statusCode = _responseRest.StatusCode;
            if (_statusCode == HttpStatusCode.OK)
            {
                var _responseService = _responseRest.Content == null ? "" : _responseRest.Content;
                return JsonConvert.DeserializeObject<T>(_responseService);
            }
            else
            {
                throw new Exception($"ERROR => URL METHOD: {_urlBase + _method}; STATUS: {_statusCode}");
            }
        }
    }
}
