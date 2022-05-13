using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZartisRocketLander
{
    public interface IRocketLander
    {
        string QueryPosition(int x, int y);
    }
}
