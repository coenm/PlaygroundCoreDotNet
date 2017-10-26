# PlaygroundCoreDotNet
This is a playground for .net core application development combined with free continuous integration services like [appveyor](http://appveyor.com), [travis-ci](https://travis-ci.org/), and [sonarqube](https://about.sonarcloud.io/).


## Continuous integration status

| Service | Develop | Master |
| :--- | :--- | :--- |
| Appveyor CI (Windows) | [![Build status](https://ci.appveyor.com/api/projects/status/d6clbt722i1fxcy9/branch/develop?svg=true)](https://ci.appveyor.com/project/coenm/playgroundcoredotnet/branch/develop)| [![Build status](https://ci.appveyor.com/api/projects/status/d6clbt722i1fxcy9/branch/master?svg=true)](https://ci.appveyor.com/project/coenm/playgroundcoredotnet/branch/master) | 
| Travis CI (Linux) | todo | todo | 
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

Unittest the library with a MsTest project.
There are two test projects with the MS Test and xUnit frameworks.
```bash
dotnet test src/Playground.Calculator.Test/Playground.Calculator.Test.csproj
```

## Libraries used
- [x] xUnit
- [x] ~~MS Test~~
- [ ] ~~NUnit~~
- [x] FakeItEasy
- [x] ~~Moq~~

## TODO's
- [x] Setup [GitFlow](http://nvie.com/posts/a-successful-git-branching-model/). Add develop branch and make this the default branch in GitHub.
- [x] simple .net core / standard project with unittests (ie. ~~MsTest~~, xUnit, ~~NUnit~~)
- [x] Use Appveyor. This is in progress. Need to show tests. Use the gitversion output. Also need to export the config to appvayor.yml
- [ ] Use Travis
- [ ] Tweak SonarQube (improve/set analysis). This is work in progress. Currently we run sonar analysis on the project and something gets displayed.
- [ ] Extend project with Typescript, npm etc.
- [x] [GitVersion](https://gitversion.readthedocs.io/en/latest/) for automatic versioning. This is work in progress.



## Notes

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
