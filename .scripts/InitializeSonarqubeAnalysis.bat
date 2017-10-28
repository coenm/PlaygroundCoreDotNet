IF DEFINED APPVEYOR (

	REM mkdir "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Microsoft.Common.targets\ImportBefore"
	REM copy packages\MSBuild.SonarQube.Runner.Tool.1.0.0\tools\Targets\SonarQube.Integration.ImportBefore.targets "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Microsoft.Common.targets\ImportBefore\"

	echo Sonarqube analysis for: %APPVEYOR_REPO_COMMIT%

	IF DEFINED github_oauth_token (
		echo github_oauth_token is defined.
	) ELSE (
		echo github_oauth_tokenis not defined.
	)

	IF DEFINED APPVEYOR_PULL_REQUEST_NUMBER (
		echo Analysing Pull Request %APPVEYOR_PULL_REQUEST_NUMBER%
		@echo off
		
		REM SONAR_PROJECT_KEY
		REM SONAR_PROJECT_NAME
		REM SONAR_ORGANIZATION
		REM SONAR_URL

		REM /v:"%APPVEYOR_REPO_COMMIT%"


		REM /d:sonar.cs.xunit.reportsPaths="%CD%\XUnitResults.xml"
		REM packages\xunit.runner.console.2.1.0\tools\xunit.console.exe XUnitProject1\bin\Debug\XUnitProject1.dll -xml XUnitResults.xml
		REM xunit.console.exe -appveyor -xml XUnitResults.xml

		REM extra:
		REM /n:"PlaygroundDotNetCore"  /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true"

		REM with xunit result file	
		REM SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /d:"sonar.host.url=https://sonarcloud.io" /v:"%appveyor_build_version%" /d:"sonar.cs.opencover.reportsPaths=coverage-dotnet.xml" /d:"sonar.cs.xunit.reportsPaths=xunit-results.xml" /d:"sonar.login=%sonar_login%" /d:"sonar.analysis.mode=preview" /d:"sonar.github.oauth=%github_oauth_token%" /d:"sonar.github.pullRequest=%APPVEYOR_PULL_REQUEST_NUMBER%" /d:"sonar.links.scm_dev=https://github.com/coenm/PlaygroundCoreDotNet" /d:sonar.issuesReport.console.enable=true /d:"sonar.github.repository=coenm/PlaygroundCoreDotNet" /d:sonar.verbose=true /n:"PlaygroundDotNetCore"  /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true"
		REM with trx result file
REM 		SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /d:"sonar.host.url=https://sonarcloud.io" /v:"%appveyor_build_version%" /d:"sonar.cs.opencover.reportsPaths=coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\TestResults.trx" /d:"sonar.login=%sonar_login%" /d:"sonar.analysis.mode=preview" /d:"sonar.github.oauth=%github_oauth_token%" /d:"sonar.github.pullRequest=%APPVEYOR_PULL_REQUEST_NUMBER%" /d:"sonar.links.scm_dev=https://github.com/coenm/PlaygroundCoreDotNet" /d:sonar.issuesReport.console.enable=true /d:"sonar.github.repository=coenm/PlaygroundCoreDotNet" /d:sonar.verbose=true /n:"PlaygroundDotNetCore"  /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true"

		REM SonarQube.Scanner.MSBuild.exe begin /k:"Stryker.NET"          /d:"sonar.host.url=https://sonarcloud.io" /v:"%appveyor_build_version%" /d:"sonar.cs.opencover.reportsPaths=coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\TestResults.trx" /d:"sonar.login=%sonar_login%" /d:"sonar.analysis.mode=preview" /d:"sonar.github.oauth=%github_oauth_token%" /d:"sonar.github.pullRequest=%APPVEYOR_PULL_REQUEST_NUMBER%" /d:"sonar.links.scm_dev=https://github.com/coenm/PlaygroundCoreDotNet" /d:sonar.issuesReport.console.enable=true /d:"sonar.github.repository=coenm/PlaygroundCoreDotNet" /d:sonar.verbose=true
		SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /n:"PlaygroundDotNetCore" /d:sonar.cs.opencover.reportsPaths="coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\TestResults.trx" /d:"sonar.organization=coenm-github" /d:"sonar.host.url=https://sonarcloud.io" /d:"sonar.login=%sonar_login%" /v:%appveyor_build_version% /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true" /d:"sonar.analysis.mode=preview" /d:"sonar.github.oauth=%github_oauth_token%" /d:"sonar.github.pullRequest=%APPVEYOR_PULL_REQUEST_NUMBER%" /d:"sonar.links.scm_dev=https://github.com/coenm/PlaygroundCoreDotNet" /d:sonar.issuesReport.console.enable=true /d:"sonar.github.repository=coenm/PlaygroundCoreDotNet" /d:sonar.verbose=true

	) ELSE (
		echo Analysing commit %APPVEYOR_REPO_COMMIT%
		@echo off
		REM /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\TestResults.trx"
	REM SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /n:"PlaygroundDotNetCore  /d:sonar.cs.opencover.reportsPaths="coverage-dotnet.xml" /d:"sonar.cs.xunit.reportsPaths=xunit-results.xml"                                                             /d:"sonar.host.url=https://sonarcloud.io" /d:"sonar.login=%sonar_login%" /v:%appveyor_build_version%          
		SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /n:"PlaygroundDotNetCore" /d:sonar.cs.opencover.reportsPaths="coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\TestResults.trx" /d:"sonar.organization=coenm-github" /d:"sonar.host.url=https://sonarcloud.io" /d:"sonar.login=%sonar_login%" /v:%appveyor_build_version% /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true"
    REM SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /n:"PlaygroundDotNetCore" /d:sonar.cs.opencover.reportsPaths="coverage-dotnet.xml"                                                                                                                /d:"sonar.host.url=https://sonarcloud.io" /d:"sonar.login=%sonar_login%" /v:%appveyor_build_version% 
	)
	
) ELSE (
	echo Sonarqube analysis only supported at appveyor.
)


IF DEFINED APPVEYOR_PULL_REQUEST_NUMBER (
	packages\MSBuild.SonarQube.Runner.Tool.1.0.0\tools\SonarQube.Scanner.MSBuild.exe begin /k:"Stryker.NET" /d:"sonar.host.url=https://sonarqube.com" /v:"%APPVEYOR_REPO_COMMIT%" /d:"sonar.cs.dotcover.reportsPaths=DotCoverTestCoverageReport.html" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\Stryker.NET\TestResults.trx" /d:"sonar.login=%sonarqube_auth_token%"         
			/d:"sonar.analysis.mode=preview" /d:"sonar.github.oauth=%github_oauth_token%" /d:"sonar.github.pullRequest=%APPVEYOR_PULL_REQUEST_NUMBER%" /d:"sonar.links.scm_dev=https://github.com/infosupport/stryker-net" /d:sonar.issuesReport.console.enable=true /d:"sonar.github.repository=infosupport/stryker-net" /d:sonar.verbose=true
	packages\MSBuild.SonarQube.Runner.Tool.1.0.0\tools\SonarQube.Scanner.MSBuild.exe begin /k:"Stryker.NET" /d:"sonar.host.url=https://sonarqube.com" /v:"%APPVEYOR_REPO_COMMIT%" /d:"sonar.cs.dotcover.reportsPaths=DotCoverTestCoverageReport.html" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\Stryker.NET\TestResults.trx" /d:"sonar.login=%sonarqube_auth_token%"
)