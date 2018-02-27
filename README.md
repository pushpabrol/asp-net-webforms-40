# asp-net-webforms-40

Before you run,

Change settings within Web.config

```
    <add key="auth0:Domain" value="auth0:domain"/>
    <add key="auth0:ClientId" value="auth0:client_id"/>
    <add key="auth0:ClientSecret" value="auth0:client_secret"/>

```



Other settings required at the client within Auth0 are:

- Make sure you have the correct callback url setup : http://localhost:49219/LoginCallback.ashx
- Make sure you have the correct allowed logout url setup for the client: http://localhost:49219/default.aspx
