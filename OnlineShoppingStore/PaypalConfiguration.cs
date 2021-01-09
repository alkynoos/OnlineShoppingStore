using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;

        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = GetConfig();
            clientId = "AbEAR9K1AXOwjyCsjkclQs5RSpadW6j0SbxQ9vTqjnh_zo7mjWhYamyePpoNYQSSzSOUiWfRM9wRy8V9";
            clientSecret = "EGrqTSTPFTCmYAo0lDgzTOwUYfcbiRm-SiCtfdwsaM5WWt8XqjNchztjax4bEQnuRfBX6mcvm-4CERO9";
        }

        private static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}