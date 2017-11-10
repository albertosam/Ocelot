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

Run the project test Ocelot.Client.ManualTest and navigate navigate to

http://localhost:54607/api/ocelot/generator

For generate the re-routes try

http://localhost:54607/api/ocelot/generator/http/myadress.com/80?prefixAppName=myapp

