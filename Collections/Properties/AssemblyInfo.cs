/* See License.md in the solution root for license information.
 * File: AssemblyInfo.cs
*/

using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
#if !DNX
using System.Security.Permissions;
#endif

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Collections.Generic")]
[assembly: AssemblyDescription("This are C# class libraries that implements generic collections that are \r\nnot covered by the .NET base class library. At the moment this is just\r\na BinaryHeap implementation with various variations, and based on that\r\nan implementation of a PriorityQueue.")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug Version")]
#else
[assembly: AssemblyConfiguration("Release Version")]
#endif
[assembly: AssemblyCompany("Pfeifers-Software")]
[assembly: AssemblyProduct("Pfeifers Collections")]
[assembly: AssemblyCopyright("Copyright © 2004-2018 by Jürgen Pfeifer. All rights reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("3.0.1.0")]
[assembly: AssemblyFileVersion("3.0.1.0")]

[assembly: ComVisible(false)]
[assembly: System.CLSCompliant(false)]
