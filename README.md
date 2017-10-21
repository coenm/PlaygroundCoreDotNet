# PlaygroundCoreDotNet
This is a playground for .net core application development combined with free continuous integration services like [appveyor](http://appveyor.com), [travis-ci](https://travis-ci.org/), and [sonarqube](https://about.sonarcloud.io/).


## Continuous integration status


| Service | Status |
| :--- | :--- |
| Appveyor Windows build of develop branch: | [![Build status](https://ci.appveyor.com/api/projects/status/d6clbt722i1fxcy9/branch/develop?svg=true)](https://ci.appveyor.com/project/coenm/playgroundcoredotnet/branch/develop) |
| Coverage of develop branch: | [![codecov](https://codecov.io/gh/coenm/PlaygroundCoreDotNet/branch/develop/graph/badge.svg)](https://codecov.io/gh/coenm/PlaygroundCoreDotNet)
| SonarQube (last success build)  | [![Quality Gate](https://sonarcloud.io/api/badges/gate?key=PlaygroundDotNetCoreDevelop&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCoreDevelop) [![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCoreDevelop&metric=coverage&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCoreDevelop) [![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCoreDevelop&metric=vulnerabilities&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCoreDevelop) [![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCoreDevelop&metric=ncloc&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCoreDevelop) | 


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
dotnet test src/Playground.Calculator.MsTest.Test/Playground.Calculator.MsTest.Test.csproj
dotnet test src/Playground.Calculator.xUnit.Test/Playground.Calculator.xUnit.Test.csproj
```

## Libraries used
- [x] xUnit
- [x] MS Test
- [ ] NUnit
- [x] FakeItEasy
- [x] Moq

## TODO's
- [x] Setup [GitFlow](http://nvie.com/posts/a-successful-git-branching-model/). Add develop branch and make this the default branch in GitHub.
- [x] simple .net core / standard project with unittests (ie. MsTest, xUnit, NUnit)
- [x] Use Appveyor. This is in progress. Need to show tests. Use the gitversion output. Also need to export the config to appvayor.yml
- [ ] Use Travis
- [ ] Use SonarQube
- [ ] Extend project with Typescript, npm etc.
- [x] [GitVersion](https://gitversion.readthedocs.io/en/latest/) for automatic versioning. This is work in progress.



## Notes

- see https://github.com/OpenCover/opencover/issues/636
```
<PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    <DebugType>full</DebugType>
    <DebugSymbols>True</DebugSymbols>
</PropertyGroup>
```