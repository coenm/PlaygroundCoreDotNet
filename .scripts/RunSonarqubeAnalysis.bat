@echo off

IF DEFINED APPVEYOR (
	IF DEFINED SONARQUBE_ENABLED (
	    SonarQube.Scanner.MSBuild.exe end /d:sonar.login="%sonar_login%"
	)
) ELSE (
	echo Sonarqube analysis only supported at appveyor.
)