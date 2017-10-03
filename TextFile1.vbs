Option Explicit
On Error Resume Next
Set objFSO = CreateObject("Scripting.FileSystemObject")


Const CSIDL_COMMON_PROGRAMS = &H17
Const CSIDL_PROGRAMS = &H2
Const CSIDL_STARTMENU = &Hb
Const CSIDL_ALL_USERS_DESKTOP = &H19

Const HKEY_CURRENT_USER = &H80000001 

Dim objReg, strKeyPath, strValueName, dwValue
'strComputer = "." 
Set objReg = GetObject("winmgmts:" _ 
    & "{impersonationLevel=impersonate}\\localhost\root\default:StdRegProv") 
 
'strKeyPath = "Software\Microsoft\Windows\CurrentVersion\Internet Settings\" _ 
'    & "ZoneMap\ESCDomains\Cymer.com" 
'objReg.CreateKey HKEY_CURRENT_USER,strKeyPath 
'strValueName = "http" 
'dwValue = 2 
'objReg.SetDWORDValue HKEY_CURRENT_USER,strKeyPath,strValueName,dwValue 
 
strKeyPath = "Software\Microsoft\Windows\CurrentVersion\Internet Settings\" _ 
    & "ZoneMap\Domains\Cymer.com" 
objReg.CreateKey HKEY_CURRENT_USER, strKeyPath 
strValueName = "*" 
dwValue = 1 
objReg.SetDWORDValue HKEY_CURRENT_USER, strKeyPath, strValueName, dwValue 

Dim strAllUsersProgramsPath, objShell, objFSO, wshShell, objAllUsersProgramsFolder, strAppData, objFolder, objFolderItem, colVerbs, objVerb, strProfile
Dim Printer, strScript
strScript = Wscript.ScriptFullName
Set objShell = CreateObject("Shell.Application")
Set objFSO = CreateObject("Scripting.FileSystemObject")

Set objAllUsersProgramsFolder = objShell.NameSpace(CSIDL_COMMON_PROGRAMS)
strAllUsersProgramsPath = objAllUsersProgramsFolder.Self.Path

Set wshShell = CreateObject( "WScript.Shell" )
strAppData = wshShell.ExpandEnvironmentStrings( "%APPDATA%" )
strProfile = wshShell.ExpandEnvironmentStrings( "%USERPROFILE%" )

'C:\Program Files (x86)\Microsoft Office\root\Office16\lync.exe
' *** open and pin outlook to taskbar
	Call pinToTaskbar("outlook.exe", "C:\Program Files (x86)\Microsoft Office\root\Office16", 1)

' *** open and pin Lync to taskbar
	Call pinToTaskbar("lync.exe", "C:\Program Files (x86)\Microsoft Office\root\Office16", 1)

' *** open and pin Cisco Expiring
	Call pinToTaskbar("Cisco AnyConnect Secure Mobility Client.lnk", strAllUsersProgramsPath & "\Cisco\Cisco AnyConnect Secure Mobility Client", 1)

' *** unpin windows media player
	Call pinToTaskbar("Windows Media Player.lnk", strAllUsersProgramsPath, 0)

    ' *** Merge registry
    'sRegFile = strProfile & "\Desktop\pinned2.reg"
    'wshShell.Run "Regedit.exe /s """ & sRegFile & "", 0, True

	' *** This Subroutine pins the program to the Taskbar  	
	Sub PinToTaskbar(ByVal FileName, FileLocation, Pin)
		
		If objFSO.FileExists(FileLocation & "\" & FileName) Then
			Set objFolder = objShell.Namespace(FileLocation)
			Set objFolderItem = objFolder.ParseName(FileName)
			Set colVerbs = objFolderItem.Verbs

			For Each objVerb in colVerbs
				If Pin = 1 Then If Replace(objVerb.name, "&", "") = "Pin to Taskbar" Then objVerb.DoIt
				If Pin = 0 Then If Replace(objVerb.name, "&", "") = "Unpin from Taskbar" Then objVerb.DoIt
			Next
		Else
			wscript.echo FileLocation & "\" & FileName
		End If
		
		
	End Sub

objFSO.DeleteFile(strProfile & "\Desktop\pinned2.reg")
objFSO.DeleteFile(strProfile & "\Desktop\RunOnce.bat")
objFSO.DeleteFile(strScript)