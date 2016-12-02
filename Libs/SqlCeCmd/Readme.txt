SqlCeCmd.exe is compiled against assembly version 4.0.0.0, so it will not work unless SQL Server Compact 4.0 runtime is centrally installed.
To force this application to use Private Deployment only, we have created the  SqlCeCmd.exe.config file. 
You need to copy the dlls from the folder .\Input Libs\SQLCE\v4.0 to the same folder than SqlCeCmd.exe.
You can find more info at:
http://erikej.blogspot.com/2011/06/sql-server-compact-private-deployment.html

Note:SqlCeCmd.exe has been compiled targetting platform x86 (not "AnyCPU") to work in compatibility mode on x64 machines.