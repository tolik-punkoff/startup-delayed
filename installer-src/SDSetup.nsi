; Script generated with the Venis Install Wizard

; Define your application name
!define APPNAME "StartupDelayed"
!define APPNAMEANDVERSION "StartupDelayed v. 0.0.2"

; Main Install settings
Unicode true
Name "${APPNAMEANDVERSION}"
InstallDir "$PROGRAMFILES\StartupDelayed"
InstallDirRegKey HKLM "Software\${APPNAME}" ""
OutFile "SDSetup.exe"

LicenseData "bin\LICENSE.txt"
LicenseText "If you accept the terms of the agreement, click I Agree to continue. You must accept the agreement to install ${APPNAMEANDVERSION}."

DirText "Выбор каталога для установки программы ${APPNAMEANDVERSION}."

ShowInstDetails show

Section "StartupDelayed"

	; Set Section properties
	SetOverwrite on

	; Set Section Files and Shortcuts
	SetOutPath "$INSTDIR\"
	File "bin\cl_help.txt"
	File "bin\LICENSE.txt"
	File "bin\readme-en.txt"
	File "bin\readme-ru.txt"
	File "bin\StartupDelayed.exe"
	
	CreateDirectory "$SMPROGRAMS\StartupDelayed"
	CreateShortCut "$SMPROGRAMS\StartupDelayed\StartupDelayed (settings).lnk" "$INSTDIR\StartupDelayed.exe" "/d"
	CreateShortCut "$SMPROGRAMS\StartupDelayed\Readme (ru).lnk" "$INSTDIR\readme-ru.txt"
	CreateShortCut "$SMPROGRAMS\StartupDelayed\Readme (en).lnk" "$INSTDIR\readme-en.txt"
	CreateShortCut "$SMPROGRAMS\StartupDelayed\Command line help.lnk" "$INSTDIR\cl_help.txt"
	CreateShortCut "$SMPROGRAMS\StartupDelayed\Uninstall.lnk" "$INSTDIR\uninstall.exe"
	
	

SectionEnd

Section -FinishSection

	WriteRegStr HKLM "Software\${APPNAME}" "" "$INSTDIR"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" "$INSTDIR\uninstall.exe"
	WriteUninstaller "$INSTDIR\uninstall.exe"
	
	MessageBox MB_YESNO "Добавить ярлык программы в автозагрузку?" IDNO NoAdd
		CreateShortCut "$SMSTARTUP\StartupDelayed.lnk" "$INSTDIR\StartupDelayed.exe" "/run /d"
	NoAdd:

	MessageBox MB_YESNO "Запустить настройку программы?" IDNO NoRun
		Exec "$INSTDIR\StartupDelayed.exe /d"
	NoRun:

SectionEnd

;Uninstall section
Section Uninstall
	
	SetDetailsView show

	;Remove from registry...
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"
	DeleteRegKey HKLM "SOFTWARE\${APPNAME}"

	; Delete self
	Delete "$INSTDIR\uninstall.exe"

	; Delete Shortcuts
	Delete "$SMSTARTUP\StartupDelayed.lnk"
	Delete "$SMPROGRAMS\StartupDelayed\StartupDelayed (settings).lnk"
	Delete "$SMPROGRAMS\StartupDelayed\Uninstall.lnk"
	Delete "$SMPROGRAMS\StartupDelayed\Readme (ru).lnk"
	Delete "$SMPROGRAMS\StartupDelayed\Readme (en).lnk"
	Delete "$SMPROGRAMS\StartupDelayed\Command line help.lnk"

	; Clean up StartupDelayed
	Delete "$INSTDIR\cl_help.txt"
	Delete "$INSTDIR\LICENSE.txt"
	Delete "$INSTDIR\readme-en.txt"
	Delete "$INSTDIR\readme-ru.txt"
	Delete "$INSTDIR\StartupDelayed.exe"

	; Remove remaining directories
	RMDir "$SMPROGRAMS\StartupDelayed"
	RMDir "$INSTDIR\"

SectionEnd

Function un.onInit

	MessageBox MB_YESNO|MB_DEFBUTTON2|MB_ICONQUESTION "Remove ${APPNAMEANDVERSION} and all of its components?" IDYES DoUninstall
		Abort
	DoUninstall:

FunctionEnd

; eof