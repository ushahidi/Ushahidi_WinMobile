[Setup]
AppId={{E55F619A-97CB-46FE-AFC7-C52C74876CAA}
AppName=Ushahidi
AppVerName=Ushahidi Windows Mobile
AppPublisher=Ushahidi
AppPublisherURL=http://www.ushahidi.com
AppSupportURL=http://www.ushahidi.com
AppUpdatesURL=http://www.ushahidi.com
DefaultDirName={pf}\Ushahidi Windows Mobile
DefaultGroupName=Ushahidi
DisableProgramGroupPage=yes
OutputDir=.\..
OutputBaseFilename=Ushahidi
SetupIconFile=Ushahidi.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "dutch"; MessagesFile: "compiler:Dutch.isl"
Name: "french"; MessagesFile: "compiler:French.isl"
Name: "german"; MessagesFile: "compiler:German.isl"
Name: "italian"; MessagesFile: "compiler:Italian.isl"
Name: "polish"; MessagesFile: "compiler:Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Portuguese.isl"
Name: "spanish"; MessagesFile: "compiler:Spanish.isl"

[Files]
Source: "Microsoft.NETCFv35.ini"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wm.armv4i.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.ppc.armv4.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.armv4.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.mipsii.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.mipsiv.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.sh4.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "NETCFv35.wce.x86.cab"; DestDir: "{app}"; Flags: ignoreversion
Source: "Ushahidi.ini"; DestDir: "{app}"; Flags: ignoreversion
Source: "Ushahidi.CAB"; DestDir: "{app}"; Flags: ignoreversion

[Run]
FileName: {code:GetCEappManager}; Parameters: {code:GetIniFile|\Microsoft.NETCFv35.ini}
FileName: {code:GetCEappManager}; Parameters: {code:GetIniFile|\Ushahidi.ini}

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
