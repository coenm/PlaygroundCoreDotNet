# PlaygroundCoreDotNet
This is a playground for .net core application development combined with free continuous integration services like [appveyor](http://appveyor.com), [travis-ci](https://travis-ci.org/), and [sonarqube](https://about.sonarcloud.io/).


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



## TODO's
- [x] Setup [GitFlow](http://nvie.com/posts/a-successful-git-branching-model/). Add develop branch and make this the default branch in GitHub.
- [ ] simple .net core / standard project with unittests (ie. MsTest, xUnit, NUnit)
- [ ] Use Appveyor
- [ ] Use Travis
- [ ] Use SonarQube
- [ ] Extend project with Typescript, npm etc.
- [ ] [GitVersion](https://gitversion.readthedocs.io/en/latest/) for automatic versioning.


