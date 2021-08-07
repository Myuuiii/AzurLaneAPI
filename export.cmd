@echo off
cd AzurLaneAPI
dotnet clean
del /q /s /f bin
del /q /s /f obj
cd ../AzurLaneClasses
dotnet clean
del /q /s /f bin
del /q /s /f obj
cd ..
7z a export.7z .\AzurLaneAPI\ .\AzurLaneClasses\
cd AzurLaneAPI
dotnet build
cd ../AzurLaneClasses
dotnet build