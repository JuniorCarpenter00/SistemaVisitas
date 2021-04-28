using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidades;
using System.Configuration;

namespace Capa_Datos
{
    public class D_Visitas : D_Conexion
    {

        public void Guardar_D()
        {
            SqlCommand cmd = new SqlCommand("sp_guardar_visitantes", cxn);
            cmd.CommandType = CommandType.StoredProcedure;

            cxn.Open();
            cmd.Parameters.AddWithValue("@nombre", E_Visitas.Nombre1);
            cmd.Parameters.AddWithValue("@apellido", E_Visitas.Apellido1);
            cmd.Parameters.AddWithValue("@edificio", E_Visitas.Edificio1);
            cmd.Parameters.AddWithValue("@aula", E_Visitas.Aula1);
            cmd.Parameters.AddWithValue("@telefono", E_Visitas.Telefono1);
            cmd.Parameters.AddWithValue("@hora_entrada", E_Visitas.FechaEntrada1);
            cmd.Parameters.AddWithValue("@hora_salida", E_Visitas.FechaSalida1);
            cmd.Parameters.AddWithValue("@carrera", E_Visitas.Carrera1);
            cmd.Parameters.AddWithValue("@correo", E_Visitas.Correo1);
            cmd.Parameters.AddWithValue("@matricula", E_Visitas.Matricula1);
            cmd.Parameters.AddWithValue("@motivo_visita", E_Visitas.MotivoVisita1);
            cmd.Parameters.AddWithValue("@foto", E_Visitas.Foto1);


            cmd.ExecuteNonQuery();

            cxn.Close();
        }
        public void Editar_D()
        {
            SqlCommand cmd = new SqlCommand("sp_editar_visitantes", cxn);
            cmd.CommandType = CommandType.StoredProcedure;

            cxn.Open();
            cmd.Parameters.AddWithValue("@id", E_Visitas.Id1);
            cmd.Parameters.AddWithValue("@nombre", E_Visitas.Nombre1);
            cmd.Parameters.AddWithValue("@apellido", E_Visitas.Apellido1);
            cmd.Parameters.AddWithValue("@edificio", E_Visitas.Edificio1);
            cmd.Parameters.AddWithValue("@aula", E_Visitas.Aula1);
            cmd.Parameters.AddWithValue("@telefono", E_Visitas.Telefono1);
            cmd.Parameters.AddWithValue("@hora_entrada", E_Visitas.FechaEntrada1);
            cmd.Parameters.AddWithValue("@hora_salida", E_Visitas.FechaSalida1);
            cmd.Parameters.AddWithValue("@carrera", E_Visitas.Carrera1);
            cmd.Parameters.AddWithValue("@correo", E_Visitas.Correo1);
            cmd.Parameters.AddWithValue("@matricula", E_Visitas.Matricula1);
            cmd.Parameters.AddWithValue("@motivo_visita", E_Visitas.MotivoVisita1);
            cmd.Parameters.AddWithValue("@foto", E_Visitas.Foto1);

            cmd.ExecuteNonQuery();

            cxn.Close();
        }
        public void Borrar_D()
        {
            SqlCommand cmd = new SqlCommand("sp_borrar_visitantes", cxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cxn.Open();

            cmd.Parameters.AddWithValue("@id", E_Visitas.Id1);

            cmd.ExecuteNonQuery();
            cxn.Close();
        }
        public DataTable Buscar_D()
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_visitantes", cxn);
            cmd.CommandType = CommandType.StoredProcedure;

            cxn.Open();
            cmd.Parameters.AddWithValue("@id", E_Visitas.Id1);
            cmd.Parameters.AddWithValue("@nombre", E_Visitas.Nombre1); 
            cmd.ExecuteNonQuery();

            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            cxn.Close();
            return tabla;

        }
        public DataTable Mostrar_D()
        {
            cxn.Open();
            SqlCommand cmd = new SqlCommand("select * from vw_visitante", cxn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            cxn.Close();
            return dataTable;
        }

    }
}
