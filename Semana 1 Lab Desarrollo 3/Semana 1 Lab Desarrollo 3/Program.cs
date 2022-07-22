using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_1_Lab_Desarrollo_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olive\source\Desarrollo 3\Semana 1 Lab Desarrollo 3\Semana 1 Lab Desarrollo 3\Deportados.mdf;Integrated Security=True";
            conection.Open();

            string select = "SI";

            while (select.ToUpper() == "SI")
            {

                string Nombre, Apellido, Documento, Nacionalidad, Sexo, FechaViaje, LugarViaje, NumeroVuelo, idpersona = "0" , idviaje ="0" ;

                Console.WriteLine("Nombre: ");
                Nombre = Console.ReadLine();

                Console.WriteLine("Apellido: ");
                Apellido = Console.ReadLine();

                Console.WriteLine("Documento: ");
                Documento = Console.ReadLine();

                Console.WriteLine("Nacionalidad: ");
                Nacionalidad = Console.ReadLine();

                Console.WriteLine("Sexo (M/F): ");
                Sexo = Console.ReadLine();

                Console.WriteLine("Inserterte datos del viaje");
                Console.WriteLine();

                Console.WriteLine("Fecha del viaje : DD/MM/YYYY ");
                FechaViaje = Console.ReadLine();

                Console.WriteLine("Lugar de viaje: ");
                LugarViaje = Console.ReadLine();

                Console.WriteLine("Numero de Vuelo: ");
                NumeroVuelo = Console.ReadLine();

                Console.WriteLine("Enlaza viales con personas deportadas");

                Console.WriteLine("id persona: ");
                idpersona = Console.ReadLine();

                Console.WriteLine("id viaje: ");
                idviaje = Console.ReadLine();


                SqlCommand command = new SqlCommand();
                command.Connection = conection;
                // tabla persona
                command.CommandText = "ppUpsertPersona";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Apellido", Apellido);
                command.Parameters.AddWithValue("@Documento", Documento);
                command.Parameters.AddWithValue("@Nacionalidad", Nacionalidad);
                command.Parameters.AddWithValue("@Sexo", Sexo);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                //Viaje
                command.CommandText = "ppInsertViaje";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FechaViaje", DateTime.Parse(FechaViaje));
                command.Parameters.AddWithValue("@LugarViaje", LugarViaje);
                command.Parameters.AddWithValue("@NumeroVuelo", NumeroVuelo);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                //personaviaje

                command.CommandText = "ppInsertID";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPersona",idpersona);
                command.Parameters.AddWithValue("@IdViaje", idviaje);
                command.ExecuteNonQuery();

                Console.WriteLine("Desea ingresar deportados?");
                select = Console.ReadLine();
                Console.Clear();
            }
        }   
    }
}
