using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public static class E_Login
    {
        private static string code;
        private static int ID;
        private static string _user;
        private static string _pass;
        private static string Nombre;
        private static string Apellido;
        private static string Cargo;
        private static DateTime Fecha;
        private static byte[] Foto;

        public static string Code { get => code; set => code = value; }
        public static int ID1 { get => ID; set => ID = value; }
        public static string User { get => _user; set => _user = value; }
        public static string Pass { get => _pass; set => _pass = value; }
        public static string Nombre1 { get => Nombre; set => Nombre = value; }
        public static string Apellido1 { get => Apellido; set => Apellido = value; }
        public static string Cargo1 { get => Cargo; set => Cargo = value; }
        public static DateTime Fecha1 { get => Fecha; set => Fecha = value; }
        public static byte[] Foto1 { get => Foto; set => Foto = value; }
    }
}
