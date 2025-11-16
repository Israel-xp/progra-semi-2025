using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Formulario_Academica
{
    class conexión
    {
        SqlConnection objConexion = new SqlConnection(); //Conectarme a la BD.
        SqlCommand objComado = new SqlCommand(); //Ejecutar SQL en la BD. Lectura, Actualizacion, Eliminacion, Insercion.
        SqlDataAdapter objAdaptador = new SqlDataAdapter(); //un puente entre la BD y la aplicacion.
        DataSet objDs = new DataSet();

        public conexión()
        {
            String cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_academica.mdf;Integrated Security=True";
            objConexion.ConnectionString = cadenaConexion;
            objConexion.Open();
        }
        
        public DataSet obtenerdatos()
        {
            objDs.Clear();
            objComado.Connection = objConexion;

            objAdaptador.SelectCommand = objComado;

            objComado.CommandText = "SELECT * FROM estudiante";
            objAdaptador.Fill(objDs, "estudiante");

            objComado.CommandText = "SELECT * FROM materias";
            objAdaptador.Fill(objDs, "materias");

            objComado.CommandText = "SELECT * FROM Docente";
            objAdaptador.Fill(objDs, "Docente");

            return objDs;

        }
        public string administrardatos(String[] datos, String accion)
        {
            String sql = "";
            if (accion == "nuevo")
            {
                sql = "INSERT INTO estudiante(código, nombre, dirección, teléfono) VALUES ('" + datos[1] +"', '"+ datos[2] +"', '"+ datos[3] +"', '"+ datos[4] +"')";
            }
            else if (accion == "Modificar")
            {
                sql = "UPDATE estudiante SET código='" + datos[1] + "', nombre='" + datos[2] + "', dirección='" + datos[3] + "', teléfono='" + datos[4] + "' WHERE Idestudiante='" + datos[0] +"'";
            }
            else if(accion == "Eliminar")
            {
                sql = "DELETE FROM estudiante WHERE Idestudiante='"+ datos[0] +"'";
            }
            return ejecutarsql(sql);
        }
        public string administrardatosMateria(String[] datos, String accion)
        {
            String sql = "";
            if (accion == "nuevo")
            {
                sql = "INSERT INTO materias(codigo, nombre, uv ) VALUES ('"+ datos[1] + "', '"+ datos[2] + "', '"+ datos[3] +"')";
            }
            else if (accion == "Modificar")
            {
                sql = "UPDATE materias SET codigo='" + datos[1] + "', nombre='" + datos[2] + "', uv='"+ datos[3] + "' WHERE idmateria='" + datos[0] +"'";
            }
            else if (accion == "Eliminar")
            {
                sql = "DELETE FROM materias WHERE idmateria='" + datos[0] +"'";
            }
            return ejecutarsql(sql);
        }
        public string administrardatosDocentes(String[] datos, String accion)
        {
            string sql = "";

            if (accion == "nuevo")
            {
                sql = "INSERT INTO Docente(codigo, nombre, direccion, telefono) " +
                      "VALUES ('" + datos[1] + "', '" + datos[2] + "', '" + datos[3] + "', '" + datos[4] + "')";
            }
            else if (accion == "Modificar")
            {
                sql = "UPDATE Docente SET codigo='" + datos[1] + "', nombre='" + datos[2] +
                      "', direccion='" + datos[3] + "', telefono='" + datos[4] +
                      "' WHERE IdDocente='" + datos[0] + "'";
            }
            else if (accion == "Eliminar")
            {
                sql = "DELETE FROM Docente WHERE IdDocente='" + datos[0] + "'";
            }

            return ejecutarsql(sql);
        }

        private String ejecutarsql(String sql)
        {
            try
            {
                objComado.Connection = objConexion;
                objComado.CommandText = sql;
                return objComado.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
