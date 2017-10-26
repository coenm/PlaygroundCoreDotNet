@echo off

IF DEFINED APPVEYOR (

    dotnet test -c Debug --no-build
    REM C:\ProgramData\chocolatey\lib\opencover.portable\tools\OpenCover.Console.exe -register:user -target:"%xunit20%\xunit.console.x86.exe" -targetargs:"src\Playground.Calculator.Test\bin\Debug\netcoreapp2.0\Playground.Calculator.Test.dll -noshadow -appveyor -xml .\xunit-results.xml" -threshold:1 -oldStyle -returntargetcode -filter:"+[Playground*]* -[Playground*.Test]*" -excludebyattribute:*.ExcludeFromCodeCoverage* -excludebyfile:*\*Designer.cs -hideskipped:All -mergebyhash -mergeoutput -output:.\coverage-dotnet.xml
) ELSE (
	echo No coverage without appveyor.
)

