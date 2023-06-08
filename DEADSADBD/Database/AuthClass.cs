using DEADSADBD.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEADSADBD.Database
{
    internal class AuthClass
    {
        public static Vospit vospit;
        public static Polzov polzov;
        public static bool Auth(string login, string pass)
        {
            vospit = EfModel.Init().Vospits.FirstOrDefault(v => v.Login == login && v.Passvord == pass);
            return vospit != null;
        }
        public static bool Auth1(string login, string pass)
        {
            polzov = EfModel.Init().Polzovs.FirstOrDefault(p => p.Login == login && p.Password == pass);
            return polzov != null;

        }
    }
}
