/* See License.md in the solution root for license information.
 * File: AssemblyInfo.cs
*/

using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
#if !PCL
#if !DNX
using System.Security.Permissions;
#endif
#endif

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if !PCL
#if DNX
[assembly: AssemblyTitle("Collections.Generic.Core")]
#else
[assembly: AssemblyTitle("Collections.Generic")]
#endif
#else
[assembly: AssemblyTitle("Collections.Generic.PCL")]
#endif
[assembly: AssemblyDescription("Generic Collections not provided by the Framework")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug Version")]
#else
[assembly: AssemblyConfiguration("Release Version")]
#endif
[assembly: AssemblyCompany("Pfeifers Software")]
[assembly: AssemblyProduct("Pfeifers Collections")]
[assembly: AssemblyCopyright("Copyright © 2004-2016 by Jürgen Pfeifer. All rights reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("2.1.0.0")]
[assembly: AssemblyFileVersion("2.1.0.0")]

[assembly: ComVisible(false)]
[assembly: System.CLSCompliant(false)]
