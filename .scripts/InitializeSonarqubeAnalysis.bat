IF DEFINED APPVEYOR (

	mkdir "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Microsoft.Common.targets\ImportBefore"
	copy packages\MSBuild.SonarQube.Runner.Tool.1.0.0\tools\Targets\SonarQube.Integration.ImportBefore.targets "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Microsoft.Common.targets\ImportBefore\"

	echo Sonarqube analysis for: %APPVEYOR_REPO_COMMIT%

	IF DEFINED APPVEYOR_PULL_REQUEST_NUMBER (
		echo Analysing Pull Request %APPVEYOR_PULL_REQUEST_NUMBER%
		@echo off
		
		REM SONAR_PROJECT_KEY
		REM SONAR_PROJECT_NAME
		REM SONAR_ORGANIZATION
		REM SONAR_URL

		REM waarschijnlijk niet nodig
		REM /d:"sonar.organization=coenm-github"

		REM /v:"%APPVEYOR_REPO_COMMIT%"


		REM /d:sonar.cs.xunit.reportsPaths="%CD%\XUnitResults.xml"
		REM packages\xunit.runner.console.2.1.0\tools\xunit.console.exe XUnitProject1\bin\Debug\XUnitProject1.dll -xml XUnitResults.xml
		REM xunit.console.exe -appveyor -xml XUnitResults.xml

		REM extra:
		REM /n:"PlaygroundDotNetCore"  /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true"

		REM with xunit result file	
		REM SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /d:"sonar.host.url=https://sonarcloud.io" /v:"%appveyor_build_version%" /d:"sonar.cs.opencover.reportsPaths=coverage-dotnet.xml" /d:"sonar.cs.xunit.reportsPaths=xunit-results.xml" /d:"sonar.login=%sonar_login%" /d:"sonar.analysis.mode=preview" /d:"sonar.github.oauth=%github_oauth_token%" /d:"sonar.github.pullRequest=%APPVEYOR_PULL_REQUEST_NUMBER%" /d:"sonar.links.scm_dev=https://github.com/coenm/PlaygroundCoreDotNet" /d:sonar.issuesReport.console.enable=true /d:"sonar.github.repository=coenm/PlaygroundCoreDotNet" /d:sonar.verbose=true /n:"PlaygroundDotNetCore"  /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true"
		REM with trx result file
		SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /d:"sonar.host.url=https://sonarcloud.io" /v:"%appveyor_build_version%" /d:"sonar.cs.opencover.reportsPaths=coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=TestResults.trx" /d:"sonar.login=%sonar_login%" /d:"sonar.analysis.mode=preview" /d:"sonar.github.oauth=%github_oauth_token%" /d:"sonar.github.pullRequest=%APPVEYOR_PULL_REQUEST_NUMBER%" /d:"sonar.links.scm_dev=https://github.com/coenm/PlaygroundCoreDotNet" /d:sonar.issuesReport.console.enable=true /d:"sonar.github.repository=coenm/PlaygroundCoreDotNet" /d:sonar.verbose=true /n:"PlaygroundDotNetCore"  /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true"

		REM SonarQube.Scanner.MSBuild.exe begin /k:"Stryker.NET"          /d:"sonar.host.url=https://sonarcloud.io" /v:"%appveyor_build_version%" /d:"sonar.cs.opencover.reportsPaths=coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\TestResults.trx" /d:"sonar.login=%sonar_login%" /d:"sonar.analysis.mode=preview" /d:"sonar.github.oauth=%github_oauth_token%" /d:"sonar.github.pullRequest=%APPVEYOR_PULL_REQUEST_NUMBER%" /d:"sonar.links.scm_dev=https://github.com/coenm/PlaygroundCoreDotNet" /d:sonar.issuesReport.console.enable=true /d:"sonar.github.repository=coenm/PlaygroundCoreDotNet" /d:sonar.verbose=true

	) ELSE (
		echo Analysing commit %APPVEYOR_REPO_COMMIT%
		@echo off
		REM SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /d:"sonar.host.url=https://sonarcloud.io" /v:"%appveyor_build_version%" /d:"sonar.cs.opencover.reportsPaths=coverage-dotnet.xml" /d:"sonar.cs.xunit.reportsPaths=xunit-results.xml"              /d:"sonar.login=%sonar_login%" /n:"PlaygroundDotNetCore
		SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /d:"sonar.host.url=https://sonarcloud.io" /v:"%appveyor_build_version%" /d:"sonar.cs.opencover.reportsPaths=coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=TestResults.trx" /d:"sonar.login=%sonar_login%" /n:"PlaygroundDotNetCore"
		REM SonarQube.Scanner.MSBuild.exe begin /k:"Stryker.NET"          /d:"sonar.host.url=https://sonarcloud.io" /v:"%appveyor_build_version%" /d:"sonar.cs.opencover.reportsPaths=coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\Stryker.NET\TestResults.trx" /d:"sonar.login=%sonar_login%"

	)
	
) ELSE (
	echo Sonarqube analysis only supported at appveyor.
)