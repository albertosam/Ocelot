# Ocelot Client

Library for re-routes generator in Ocelot format

## How to use
- Add a Ocelot.Client in dependencies from your webapi project
- In Statup.cs, add the code:

```

public void ConfigureServices(IServiceCollection services)
  ....

  // allow Ocelot Client Generator Routes
  services.AddOcelotConfigurationGen();
 }
```

## How to Test

Run the project test Ocelot.Client.ManualTest and navigate to

http://localhost:54607/api/ocelot/generator

For generate the re-routes try

http://localhost:54607/api/ocelot/generator/http/myadress.com/80?prefixAppName=myapp

The result response is
```
{
  "ReRoutes": [
    {
      "DownstreamPathTemplate": "/myapp/api/Test",
      "UpstreamPathTemplate": "/myapp/api/Test",
      "UpstreamHttpMethod": [
        "GET",
        "POST"
      ],
      "ReRouteIsCaseSensitive": false,
      "DownstreamScheme": "http",
      "DownstreamHost": "myadress.com",
      "DownstreamPort": 80
    },
    {
      "DownstreamPathTemplate": "/myapp/api/Test/{id}",
      "UpstreamPathTemplate": "/myapp/api/Test/{id}",
      "UpstreamHttpMethod": [
        "GET",
        "PUT",
        "DELETE"
      ],
      "ReRouteIsCaseSensitive": false,
      "DownstreamScheme": "http",
      "DownstreamHost": "myadress.com",
      "DownstreamPort": 80
    },
    {
      "DownstreamPathTemplate": "/myapp/api/Values",
      "UpstreamPathTemplate": "/myapp/api/Values",
      "UpstreamHttpMethod": [
        "GET",
        "POST"
      ],
      "ReRouteIsCaseSensitive": false,
      "DownstreamScheme": "http",
      "DownstreamHost": "myadress.com",
      "DownstreamPort": 80
    },
    {
      "DownstreamPathTemplate": "/myapp/api/Values/{id}",
      "UpstreamPathTemplate": "/myapp/api/Values/{id}",
      "UpstreamHttpMethod": [
        "GET",
        "PUT",
        "DELETE"
      ],
      "ReRouteIsCaseSensitive": false,
      "DownstreamScheme": "http",
      "DownstreamHost": "myadress.com",
      "DownstreamPort": 80
    }
  ]
}
```
