using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCI.NSAPI;

namespace RCI.BasicModules.Time;
public class Plugin : IPlugin
{
    public string Name => "Time Module for RCI 1.4+";

    public Version Version => new(1,0);

    public string Author => "danilwhale";

    public Namespace[] Namespaces => new Namespace[] { new TimeNamespace() };
}
