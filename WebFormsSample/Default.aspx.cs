using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Web;

namespace WebFormsSample
{
    public partial class Default : System.Web.UI.Page
    {
        private string domain = ConfigurationManager.AppSettings["auth0:Domain"];
        private string clientId = ConfigurationManager.AppSettings["auth0:ClientId"];
        private string audience = ConfigurationManager.AppSettings["auth0:Audience"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.IsAuthenticated)
            {
                this.Button1.Visible = false;
                var identity = (ClaimsIdentity)User.Identity;
                IEnumerable<Claim> claims = identity.Claims;
                this.ClaimsGridView.DataSource = claims;
                this.ClaimsGridView.DataBind();
            }
            else this.Button1.Visible = true;

         
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            var returnUrl = this.Request.Url;

            FederatedAuthentication.SessionAuthenticationModule.SignOut();
            
            Response.Redirect(
                string.Format("https://{0}/v2/logout?client_id={1}&returnTo={2}",
                    ConfigurationManager.AppSettings["auth0:Domain"], ConfigurationManager.AppSettings["auth0:ClientId"],
                    returnUrl));
        }

        protected void Login_Click(object sender, EventArgs e)
        {

            string callbackUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/LoginCallback.ashx";
            string userInfoUrl = string.Format("https://{0}/userinfo", ConfigurationManager.AppSettings["auth0:Domain"]);
            string audience = this.audience == null ? userInfoUrl : this.audience;

            Random r = new Random();
            int rInt = r.Next(0, 100); //for ints
            int range = 100;
            double nonce = r.NextDouble() * range; //for doubles
            
            var state = "ru=" + System.Web.HttpUtility.UrlEncode(Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/'));

            Response.Redirect(
    string.Format("https://{0}/authorize?client_id={1}&scope=openid profile&redirect_uri={2}&response_type=code&audience={3}&state={4}&nonce={5}",
        ConfigurationManager.AppSettings["auth0:Domain"], ConfigurationManager.AppSettings["auth0:ClientId"], callbackUrl, audience, state, nonce.ToString()));
        }
    }
}