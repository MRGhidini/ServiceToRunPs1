# ServiceToRunPs1
Service in C# to run PS1 file from time to time

# Conf.xml
This in the debug folder and in the release folder, contains the path to the ps1 file

# ScriptPowerShell.ps1
Contains a sample code by reading the XML tag in a folder and moving it to another folder based on the XML source

# ExecuteAppServico.exe
Executable, searching and running ps1 file pointed to in XML every 3 seconds

# InstallServico.bat
contains the command to install the executable "ExecuteAppServico.exe" as a service.

# UnistalServico.bat
contains the command to uninstall the executable "ExecuteAppServico.exe" from the services

