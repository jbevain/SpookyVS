using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;

namespace SpookyVS;

[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
[Guid(PackageGuidString)]
public sealed class SpookyVSPackage : AsyncPackage
{
    public const string PackageGuidString = "97c38372-51b8-4b8f-9602-cdf30b018576";
}
