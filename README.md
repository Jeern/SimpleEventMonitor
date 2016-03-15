# SimpleEventMonitor

A simple event monitor for .NET that monitors events from any .NET system using SignalR

## Usage

1. You create your monitor app. 
    1. Open Visual Studio and Create a New Empty ASP.NET Web Site
    1. Install-Package SimpleEventMonitor.Web in the project
    1. Open the Web.config and change the value of the appSetting SEM:HubBaseUrl to your new projects baseUrl e.g. http://localhost:52317 (remember to change it if deploying to a server)


