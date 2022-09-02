using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCI.BasicModules.Time;
public class TimeNamespace : Namespace
{
    private static Function.FuncAction[] acts =
    {
        GetDate,
        GetTime
    };
    private Function[] funcs =
    {
        new(acts[0], "today", "Prints full today date on PC", null),
        new(acts[1], "now", "Prints local time on PC", null)
    };

    public TimeNamespace()
    {
        Name = "Time";
        Functions = funcs;
    }

    private static void GetDate(FunctionArgs args) =>
        Console.WriteLine(DateTime.Today.ToLongDateString());
    private static void GetTime(FunctionArgs args) =>
        Console.WriteLine(DateTime.Now.ToLongTimeString());
}
