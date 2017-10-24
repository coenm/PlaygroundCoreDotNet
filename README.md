# PlaygroundCoreDotNet
This is a playground for .net core application development combined with free continuous integration services like [appveyor](http://appveyor.com), [travis-ci](https://travis-ci.org/), and [sonarqube](https://about.sonarcloud.io/).


## Continuous integration status

| Service | Status |
| :--- | :--- |
| Appveyor Windows build of develop branch: | [![Build status](https://ci.appveyor.com/api/projects/status/d6clbt722i1fxcy9/branch/develop?svg=true)](https://ci.appveyor.com/project/coenm/playgroundcoredotnet/branch/develop) |
| Coverage of develop branch: | [![codecov](https://codecov.io/gh/coenm/PlaygroundCoreDotNet/branch/develop/graph/badge.svg)](https://codecov.io/gh/coenm/PlaygroundCoreDotNet)
| SonarQube (last success build)  | [![Quality Gate](https://sonarcloud.io/api/badges/gate?key=PlaygroundDotNetCore&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore) [![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore&metric=coverage&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore) [![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore&metric=vulnerabilities&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore) [![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore&metric=ncloc&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore) | 
 <!-- see https://github.com/QualInsight/qualinsight-plugins-sonarqube-badges/wiki/Measure-badges  -->


 <!-- gate -->
[![Quality Gate](https://sonarcloud.io/api/badges/gate?key=PlaygroundDotNetCore%3Adevelop&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

 <!-- ncloc : lines of code -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&metric=ncloc&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- function_complexity -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&metric=function_complexity&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- test_success_density	%age of tests that have succeeded -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&metric=test_success_density&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- test_errors -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&metric=test_errors&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- test_failures -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&metric=failures&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- coverage -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&metric=coverage&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- new_coverage -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&metric=new_coverage&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- duplicated_lines_density -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&metric=duplicated_lines_density&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- new_duplicated_lines_density -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&metric=new_duplicated_lines_density&blinking=true)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- vulnerabilities -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&blinking=true&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- new_vulnerabilities -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&blinking=true&metric=new_vulnerabilities)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- bugs -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&blinking=true&metric=bugs)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- new_bugs -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&blinking=true&metric=new_bugs)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- code_smells -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&blinking=true&metric=code_smells)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)

<!-- new_code_smells -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&blinking=true&metric=new_code_smells)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)



<!-- sqale_debt_ratio -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&blinking=true&metric=sqale_debt_ratio)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)


<!-- new_sqale_debt_ratio -->
[![Quality Gate](https://sonarcloud.io/api/badges/measure?key=PlaygroundDotNetCore%3Adevelop&blinking=true&metric=new_sqale_debt_ratio)](https://sonarcloud.io/dashboard?id=PlaygroundDotNetCore:develop)


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