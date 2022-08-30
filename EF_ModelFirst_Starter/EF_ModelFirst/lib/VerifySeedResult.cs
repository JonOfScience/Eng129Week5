using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst.lib;

public class VerifySeedResult
{
    public VerifySeedResult()
    {
        Added = 0;
        Checked = 0;
        Restored = 0;
    }

    public int Added { get; set; }
    public int Checked { get; set; }
    public int Restored { get; set; }
}
