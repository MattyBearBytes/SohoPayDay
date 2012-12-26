using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using BearBytes.SohoPayDay.Mvc.Models;

namespace BearBytes.SohoPayDay.Mvc
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: " 	Ekopfkntfw3s1W5rwS1iA",
                consumerSecret: "CG7QVO6KE17og4IpD8NiuxnEpi6QKHi6LUo8q58YY");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "307799202663317",
                appSecret: "565ce63b41759c5ff7e7c29b680de39d");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
