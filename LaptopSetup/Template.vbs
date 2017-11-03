Option Explicit
On Error Resume Next
Dim strAllUsersProgramsPath, objShell, objFSO, wshShell, objAllUsersProgramsFolder, strAppData, objFolder, objFolderItem, colVerbs, objVerb, strProfile
Dim Printer, strScript
Dim objReg, strKeyPath
Set objFSO = CreateObject("Scripting.FileSystemObject")
Const CSIDL_COMMON_PROGRAMS = &H17
Const CSIDL_PROGRAMS = &H2
Const CSIDL_STARTMENU = &Hb
Const CSIDL_ALL_USERS_DESKTOP = &H19
Const HKEY_CURRENT_USER = &H80000001 
Set objReg = GetObject("winmgmts:{impersonationLevel=impersonate}\\localhost\root\default:StdRegProv") 
strScript = Wscript.ScriptFullName
Set objShell = CreateObject("Shell.Application")
Set objAllUsersProgramsFolder = objShell.NameSpace(CSIDL_COMMON_PROGRAMS)
strAllUsersProgramsPath = objAllUsersProgramsFolder.Self.Path
Set wshShell = CreateObject( "WScript.Shell" )
strAppData = wshShell.ExpandEnvironmentStrings( "%APPDATA%" )
strProfile = wshShell.ExpandEnvironmentStrings( "%USERPROFILE%" )
' ***  This subroutine installs and sets the default printer   		--- complete	
	Sub SetPrinter(ByVal PrinterPath)
		WScript.Sleep 5000
		DIM WshNetwork
		Set WshNetwork = CreateObject("WScript.Network")
		WshNetwork.AddWindowsPrinterConnection(PrinterPath)
		WshNetwork.SetDefaultPrinter Printerpath
	end sub
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
'*** This Subroutine deletes the script and shortcuts.	
	Sub cleanup()
		objFSO.DeleteFile(strProfile & "\Desktop\RunOnce.lnk")
		objFSO.DeleteFile(strScript)
	End Sub

'*** add item to zonemap
	Sub AddZone(ByVal DomainName)
		strKeyPath = "Software\Microsoft\Windows\CurrentVersion\Internet Settings\ZoneMap\Domains\" & DomainName
		objReg.CreateKey HKEY_CURRENT_USER, strKeyPath 
		objReg.SetDWORDValue HKEY_CURRENT_USER, strKeyPath, "*", 1 
	End Sub
	
	Sub run(ByVal torun)
		wshShell.run torun
	End Sub

'*** Run Commands:

