﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Watch3D.Test.Debuggee.Geometry;
using Watch3D.Test.DebuggeeVisualizer;
using Watch3D.VisualizerServices;

[assembly: DebuggerVisualizer(
    typeof(EntryPoint),
    typeof(ObjectSource),
    Target = typeof(Mesh),
    Description = "View in Watch3D")]

[assembly: DebuggerVisualizer(
    typeof(EntryPoint),
    typeof(ObjectSource),
    Target = typeof(Point),
    Description = "View in Watch3D")]

[assembly: DebuggerVisualizer(
    typeof(EntryPoint),
    typeof(ObjectSource),
    Target = typeof(List<Point>),
    Description = "View in Watch3D")]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Watch3D.Test.DebuggeeVisualizer")]
[assembly: AssemblyDescription("Sample VS visualizer for Debuggee test project")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Watch3D")]
[assembly: AssemblyCopyright("Copyright © 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("69d9638a-f8d0-4835-b4bf-0be42597c0f6")]

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
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
