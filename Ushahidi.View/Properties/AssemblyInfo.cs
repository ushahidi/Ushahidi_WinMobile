﻿using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Ushahidi")]
[assembly: AssemblyDescription("Ushahidi is a platform that crowdsources crisis information, allowing anyone to submit crisis information through text messaging using a mobile phone, email or web form. Windows Mobile PocketPC 2003 - Windows Mobile 6 PocketPC - Windows Mobile 6 SmartPhone")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Ushahidi")]
[assembly: AssemblyProduct("Ushahidi WindowsMobile")]
[assembly: AssemblyCopyright("Copyright ©  2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("771cb331-533b-44ba-987e-13b7f72acf14")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.2.*")]

// Below attribute is to suppress FxCop warning "CA2232 : Microsoft.Usage : Add STAThreadAttribute to assembly"
// as Device app does not support STA thread.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")]
