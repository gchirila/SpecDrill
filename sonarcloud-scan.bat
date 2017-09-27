d:\_apps\sonarqube\bin\SonarQube.Scanner.MSBuild.exe begin /k:"CosminSontu:SpecDrill" /o:"cosminsontu-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="7912897f13c182e8daa0a6f958761bb021cfca68"

MsBuild.exe /t:Rebuild

d:\_apps\sonarqube\bin\SonarQube.Scanner.MSBuild.exe end /d:sonar.login="7912897f13c182e8daa0a6f958761bb021cfca68"
