@echo off
mkdir %WinDir%\System32\CatYoutuber\
xcopy /y * %WinDir%\System32\CatYoutuber\
cd %WinDir%\System32\CatYoutuber\
%WinDir%\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe /nologo /codebase SubscriberCounterDeskBand.dll
pause