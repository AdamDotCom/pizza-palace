@echo off
cls
..\Dependencies\nant\bin\NAnt.exe -buildfile:PizzaPalace.build %*
pause