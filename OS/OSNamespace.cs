using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCI.BasicModules.OS;
public class OSNamespace : Namespace
{
    private static Function.FuncAction[] acts =
    {
        GetInfo
    };
    private Function[] funcs =
    {
        new(acts[0], "getInfo", "Gets information about OS", null)
    };

    public OSNamespace()
    {
        Name = "OS";
        Functions = funcs;
    }

    private static void GetInfo(FunctionArgs args)
    {
        StringBuilder drives = new();
        foreach (var drive in Environment.GetLogicalDrives())
        {
            drives.AppendLine($"\t-{drive}");
        }
        OperatingSystem os = Environment.OSVersion;
        Console.WriteLine(
            $"Version: {os.Version}\n" +
            $"PID: {os.Platform}\n" +
            $"Service Pack: {os.ServicePack}\n\n" +
            $"Is 64-bit: {RCI_Core.YesNo(Environment.Is64BitOperatingSystem)}\n\n" +
            $"Logical Drives:\n{drives}\n");
    }
}
