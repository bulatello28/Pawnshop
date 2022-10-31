using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pawnshop.AdoApp;

namespace Pawnshop.ClassApp
{
    public class DbConnection
    {
        public static LombardEntities Connection = new LombardEntities();
    }
}
