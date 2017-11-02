# PlaygroundCoreDotNet
This is a playground for .net core application development combined with free continuous integration services like [appveyor](http://appveyor.com), [travis-ci](https://travis-ci.org/), and [sonarqube](https://about.sonarcloud.io/).


## Continuous integration status

| Service | Develop | Master |
| :--- | :--- | :--- |
| Appveyor CI (Windows) | [![Build status](https://ci.appveyor.com/api/projects/status/d6clbt722i1fxcy9/branch/develop?svg=true)](https://ci.appveyor.com/project/coenm/playgroundcoredotnet/branch/develop)| [![Build status](https://ci.appveyor.com/api/projects/status/d6clbt722i1fxcy9/branch/master?svg=true)](https://ci.appveyor.com/project/coenm/playgroundcoredotnet/branch/master) | 
| Travis CI (Linux) | [![Release build Status](https://travis-ci.org/coenm/PlaygroundCoreDotNet.svg?branch=develop)](https://travis-ci.org/coenm/PlaygroundCoreDotNet) | [![Release build Status](https://travis-ci.org/coenm/PlaygroundCoreDotNet.svg?branch=master)](https://travis-ci.org/coenm/PlaygroundCoreDotNet) | 
| Code coverage | [![codecov](https://codecov.io/gh/coenm/PlaygroundCoreDotNet/branch/develop/graph/badge.svg)](https://codecov.io/gh/coenm/PlaygroundCoreDotNet) | [![codecov](https://codecov.io/gh/coenm/PlaygroundCoreDotNet/branch/master/graph/badge.svg)](https://codecov.io/gh/coenm/PlaygroundCoreDotNet) |
| SonarQube  | [![Quality Gate](https://sonarcloud.io/api/badges/gate?key=PlaygroundDotNetCore%3Adevelop&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)  | [![Quality Gate](https://sonarcloud.io/api/badges/gate?key=PlaygroundDotNetCore%3Amaster&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:master)  | 

 <!-- see https://github.com/QualInsight/qualinsight-plugins-sonarqube-badges/wiki/Measure-badges  -->


### Coverage
Coverage trend of the develop branch.
 ![Coverage trend of develop](https://codecov.io/gh/coenm/PlaygroundCoreDotNet/branch/develop/graphs/commits.svg)

## Build and Test
First step. Compile.
```bash
dotnet build
```

## Unittests
For unittesting in c#, I have selected xUnit and FakeItEasy.
To run the tests, execute the following:
```bash
dotnet test src/Playground.Calculator.Test/Playground.Calculator.Test.csproj
dotnet test src/Playground.Web.Test/Playground.Web.Test.csproj
```


## TODO's
- [x] Setup [GitFlow](http://nvie.com/posts/a-successful-git-branching-model/). Add develop branch and make this the default branch in GitHub.
- [x] simple .net core / standard project with unittests (ie. ~~MsTest~~, xUnit, ~~NUnit~~)
- [x] Use Appveyor. This is in progress. Need to show tests. Use the gitversion output. Also need to export the config to appvayor.yml
- [x] Use Travis. In progress.
- [x] Tweak SonarQube (improve/set analysis). This is work in progress. Currently we run sonar analysis on the project and something gets displayed.
- [ ] Typescript, npm, webpack, etc. etc.
- [x] [GitVersion](https://gitversion.readthedocs.io/en/latest/) for automatic versioning. This is work in progress.
- [x] ASP.NET core WebApi 
- [ ] ASP.NET core SignalR
- [ ] [ZeroMQ](https://www.nuget.org/packages/NetMQ/4.0.0.4-beta)
- [ ] NLog (or Serilog or .. use the internal [ILogger interface](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging?tabs=aspnetcore2x) ).
- [ ] NuGet packaging.


## Notes
- After adding a new testproject, it is necessary to fix the travis configuration and test script configuration (used in appveyor). Check if this can be improved somehow.
- New projects need a fixed ProjectGuid (for sonarqube, see below), and DebugType and DebugSymbols set (for opencover, dotnetcore project)
- Because multiple c# testprojects are used, the number of test is not correct in SonarQube.


- see https://github.com/OpenCover/opencover/issues/636
```xml
<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    <DebugType>full</DebugType>
    <DebugSymbols>True</DebugSymbols>
</PropertyGroup>
```

- SonarQube in .netcore.

Click [here](https://jira.sonarsource.com/browse/SONARMSBRU-167) for the source. SonarQube requires a project guid. Therefore i've added the following snippet to the csproj file.

```xml
<PropertyGroup>
  <!-- Fake project guid to satisfy SonarQube -->
  <!-- Copied from sln -->
  <!-- See https://jira.sonarsource.com/browse/SONARMSBRU-167 -->
  <ProjectGuid>D7E737EA-D72D-4BB6-9454-B8ECABD64975</ProjectGuid> 
</PropertyGroup>
```  
