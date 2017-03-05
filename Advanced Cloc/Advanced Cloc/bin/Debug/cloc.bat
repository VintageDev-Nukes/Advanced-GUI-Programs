@Echo OFF
 
SET WorkingDir=%1
SET Directory=%2
SET OutputFile=%3

Echo Comenzando a leer. > "%OutputFile%"
Echo. >> "%OutputFile%"
Echo ========================== >> "%OutputFile%"
Echo. >> "%OutputFile%"

Echo Carpeta: %Directory% >> "%OutputFile%"
Echo. >> "%OutputFile%"
%1\cloc-1.60.exe %2 >> "%OutputFile%"
Echo. >> "%OutputFile%"
Echo ========================== >> "%OutputFile%"
Echo. >> "%OutputFile%"
 
PUSHD %2
(
	FOR /D /R %%@ in ("*") DO (
 
		Echo Carpeta: "%%~@" >> "%OutputFile%"
		Echo. >> "%OutputFile%"
 		%1\cloc-1.60.exe "%%~@" >> "%OutputFile%"
 		Echo. >> "%OutputFile%"
 		Echo ========================== >> "%OutputFile%"
 		Echo. >> "%OutputFile%"

	)
 
)
POPD

Echo Proceso terminado, gracias por usar CLOC. >> "%OutputFile%"

Exit