cd


"..\..\Libs\SqlCeCmd\SqlCeCmd.exe" -d "Data Source=..\..\NganHangDeThi\NganHangDeThi\NganHang.sdf; Password =qbank" -e create
        
"..\..\Libs\SqlCeCmd\SqlCeCmd.exe" -d "Data Source=..\..\NganHangDeThi\NganHangDeThi\NganHang.sdf; Password =qbank" -i QuestionBank.edmx.sqlce > log.txt

"..\..\Libs\SqlCeCmd\SqlCeCmd.exe" -d "Data Source=..\..\NganHangDeThi\NganHangDeThi\NganHang.sdf; Password =qbank" -i .\FillData.sqlce > log_data.txt

rem pause

copy ..\..\NganHangDeThi\NganHangDeThi\NganHang.sdf ..\

rem pause
rem pause