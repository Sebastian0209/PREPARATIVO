using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite.Net.Interop;
using System.Threading.Tasks;

namespace XFproductos
{
    public interface IConfig

    {
        string DirectorioDB { get;  }
        ISQLitePlatform Plataforma { get;  }
    }

}
