using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Owin;

[assembly: AssemblyTitle("SampleMonitor")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: Guid("ab485421-0b79-4115-9579-c819633a5b48")]
[assembly: OwinStartup(typeof(SampleMonitor.Startup))]
