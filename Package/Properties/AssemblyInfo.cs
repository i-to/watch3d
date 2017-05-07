using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

[assembly: ProvideCodeBase(AssemblyName = "HelixToolkit", CodeBase = "$PackageFolder$\\HelixToolkit.dll")]
[assembly: ProvideCodeBase(AssemblyName = "HelixToolkit.Wpf", CodeBase = "$PackageFolder$\\HelixToolkit.Wpf.dll")]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Watch3D")]
[assembly: AssemblyDescription("3D object visualizer for Visual Studio debugger.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Watch3D")]
[assembly: AssemblyCopyright("Copyright © Igor Tolmachov 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.0.0.0")]
[assembly: AssemblyFileVersion("0.0.0.0")]
