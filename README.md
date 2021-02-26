![Banner](Images/Banner.png)

# SeamlessChex

[![GitHub Actions Status](https://github.com/jfern01/SeamlessChex/workflows/Build/badge.svg?branch=main)](https://github.com/jfern01/SeamlessChex/actions)

[![GitHub Actions Build History](https://buildstats.info/github/chart/jfern01/SeamlessChex?branch=main&includeBuildsFromPullRequest=false)](https://github.com/jfern01/SeamlessChex/actions)


SeamlessChex API client for .NET


## Usage

### Dependency Injection
```cs
public virtual void ConfigureServices(IServiceCollection services) =>
	services.AddSeamlessChex("api-key");
```

### DIY
```cs
var seamless = new SeamlessChexClient("api-key");
```
