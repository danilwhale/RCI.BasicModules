using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RCI.Modules.FS;
public class FSNamespace : Namespace
{
    private static Function.FuncAction[] actions =
    {
        WriteFS,
        ReadFS,
        CreateFS,
        RemoveFS,
        IsExistsFS,
        InfoFS
    };
    private Function[] funcs =
    {
        new(actions[0], "write", "Writes <content> to <filepath>", "<filepath>; <content>"),
        new(actions[1], "read", "Reads text from <filepath>, and prints it to console", "<filepath>"),
        new(actions[2], "new", "Creates new empty file at <filepath>", "<filepath>"),
        new(actions[3], "remove", "Now is obsolete. Use \"rm\" instead", "<filepath>"),
        new(actions[4], "exists", "Checks, if file at <filepath> exists", "<filepath>"),
        new(actions[5], "about", "Prints information about <filepath>", "<filepath>")
    };
    public FSNamespace()
    {
        Name = "FS";
        Functions = funcs;
    }


    private static void WriteFS(FunctionArgs args)
    {
        File.WriteAllText(args.String(0)!, args.String(1));
        RCI_Core.WriteSuccess("Writed provided text to provided path");
    }

    private static void ReadFS(FunctionArgs args)
    {
        string[] lns = File.ReadAllLines(args.String(0)!);
        for (int ln = 1; ln < lns.Length + 1; ln++)
        {
            Console.WriteLine($"│ {ln}    │ {lns[ln - 1]}");
        }
    }

    private static void CreateFS(FunctionArgs args)
    {
        File.Create(args.String(0)!);
        RCI_Core.WriteSuccess("Created new file on provided path");
    }
    private static void RemoveFS(FunctionArgs args)
    {
        RCI_Core.WriteTip("This command no lorger supports\nUse \"rm\" instead.");
    }

    private static void IsExistsFS(FunctionArgs args)
    {
        Console.WriteLine(RCI_Core.YesNo(File.Exists(args.String(0))));
    }

    private static void InfoFS(FunctionArgs args)
    {
        FileInfo info = new(args.String(0)!);
        Console.WriteLine(
            $"Information about \"{info.FullName}\"\n" +
            $"\tParent: {info.DirectoryName}\n" +
            $"\tSize: {RCI_Core.GetSizeString(info.Length)}\n\n" +
            $"\tCreated: {info.CreationTime}\n" +
            $"\tEdited: {info.LastWriteTime}\n" +
            $"\tAccessed: {info.LastAccessTime}\n\n" +
            $"\tAttributes: {info.Attributes}\n" +
            $"\tRead-only?: {RCI_Core.YesNo(info.IsReadOnly)}");
    }
}
