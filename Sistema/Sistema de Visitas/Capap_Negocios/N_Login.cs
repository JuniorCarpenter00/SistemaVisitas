using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;
using Capa_Entidades;

namespace Capap_Negocios
{
    public class N_Login
    {
        D_Login ObjDatos = new D_Login();

        public void Guardando_N()
        {
            ObjDatos.Guardar_D();
        }

        public DataTable Buscando_N()
        {
            return ObjDatos.Buscar_D();
        }
        public DataTable Mostrando_N()
        {
            return ObjDatos.Mostrar_D();
        }

        public void Editando_N()
        {
            ObjDatos.Editar_D();
        }

        public void Borrando_N()
        {
            ObjDatos.Borrar_D();
        }
        public DataTable Login_N( )
        {
            return ObjDatos.Login_D();
        }
     
        public void DatosUser_N()
        {
            
            if (E_Login.Cargo1 == E_Cargos.Administrador)
            {
            }
            if (E_Login.Cargo1 == E_Cargos.General)
            {

            }
            
        }
    }
}
