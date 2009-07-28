[Setup]
AppId={{FD6788BD-91F1-4081-89D6-B31859C98379}
AppName=Ushahidi
AppVerName=Ushahidi PPC
AppPublisher=Ushahidi
AppPublisherURL=http://www.ushahidi.com
AppSupportURL=http://www.ushahidi.com
AppUpdatesURL=http://www.ushahidi.com
DefaultDirName={pf}\Ushahidi PPC 2003
DefaultGroupName=Ushahidi
DisableProgramGroupPage=yes
OutputDir=.
OutputBaseFilename=Ushahidi.PPC2003
SetupIconFile=Ushahidi.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Files]
Source: "Microsoft.NETCFv35.ini"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wm.armv4i.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.ppc.armv4.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.armv4.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.mipsii.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.mipsiv.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.sh4.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.x86.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "Ushahidi.PPC2003.ini"; DestDir: "{app}"; Flags: ignoreversion
Source: "Ushahidi.PPC2003.CAB"; DestDir: "{app}"; Flags: ignoreversion

[Run]
FileName: {code:GetCEappManager}; Parameters: {code:GetIniFile|\Microsoft.NETCFv35.ini}
FileName: {code:GetCEappManager}; Parameters: {code:GetIniFile|\Ushahidi.PPC2003.ini}

[Code]
function GetCEappManager(Param : string) : string;
var Path: String;
begin
  Path:= '';
  RegQueryStringValue(HKEY_LOCAL_MACHINE, 'SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\CEAPPMGR.EXE','', Path)
  result:= Path
end;

function GetIniFile(Param : string) : string;
begin
  result:= ExpandConstant('"{app}') + Param + '"';
end;

