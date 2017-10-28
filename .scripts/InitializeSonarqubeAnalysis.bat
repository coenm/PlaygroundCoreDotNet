IF DEFINED APPVEYOR (

	REM mkdir "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Microsoft.Common.targets\ImportBefore"
	REM copy packages\MSBuild.SonarQube.Runner.Tool.1.0.0\tools\Targets\SonarQube.Integration.ImportBefore.targets "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Microsoft.Common.targets\ImportBefore\"

	echo Sonarqube analysis for: %APPVEYOR_REPO_COMMIT%

	IF DEFINED APPVEYOR_PULL_REQUEST_NUMBER (
		echo Pull Request %APPVEYOR_PULL_REQUEST_NUMBER% cannot be analysed using SonarQube.
		echo It is not possible to login using secure tokens in appveyor.
		@echo off
		REM SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /n:"PlaygroundDotNetCore" /d:sonar.cs.opencover.reportsPaths="coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\TestResults.trx" /d:"sonar.organization=coenm-github" /d:"sonar.host.url=https://sonarcloud.io" /d:"sonar.login=%sonar_login%" /v:%appveyor_build_version% /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true" /d:"sonar.analysis.mode=preview" /d:"sonar.github.oauth=%github_oauth_token%" /d:"sonar.github.pullRequest=%APPVEYOR_PULL_REQUEST_NUMBER%" /d:"sonar.links.scm_dev=https://github.com/coenm/PlaygroundCoreDotNet" /d:sonar.issuesReport.console.enable=true /d:"sonar.github.repository=coenm/PlaygroundCoreDotNet" /d:sonar.verbose=true
	) ELSE (
		echo Analysing commit %APPVEYOR_REPO_COMMIT%
		@echo off
		set SONARQUBE_ENABLED=true
		SonarQube.Scanner.MSBuild.exe begin /k:"PlaygroundDotNetCore" /n:"PlaygroundDotNetCore" /d:sonar.cs.opencover.reportsPaths="coverage-dotnet.xml" /d:"sonar.cs.vstest.reportsPaths=%APPVEYOR_BUILD_FOLDER%\TestResults.trx" /d:"sonar.organization=coenm-github" /d:"sonar.host.url=https://sonarcloud.io" /d:"sonar.login=%sonar_login%" /v:%appveyor_build_version% /d:"sonar.branch=%GitVersion_BranchName%" /d:"sonar.cpd.cross_project=true"
	)
	
) ELSE (
	echo Sonarqube analysis only supported at appveyor.
)