@ECHO OFF

SET /P PROJ="Project: "
START "PUBLISH" /WAIT /B "dotnet" publish "%PROJ%\%PROJ%.csproj" -c Release --self-contained
MOVE /Y ".\%PROJ%\bin\Release\net6.0\publish\%PROJ%.dll" ".\publish\"
PAUSE