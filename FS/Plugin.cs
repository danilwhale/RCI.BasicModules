using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCI.Modules.FS;
public class Plugin : NSAPI.IPlugin
{
    public string Name => "File System Module for RCI 1.4+";

    public Version Version => new(1, 0);

    public string Author => "danilwhale";

    public Namespace[] Namespaces => new Namespace[] { new FSNamespace() };

}
