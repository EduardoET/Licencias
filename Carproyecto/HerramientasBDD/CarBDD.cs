
using Microsoft.EntityFrameworkCore;
using Carproyecto.HerramientasBDD;
using Carproyecto.Info;
using Carproyecto.Relaciones;
using Carproyecto.Operaciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Carproyecto.HerramientasBDD
{
    public class CarBDD
    {

        static public string connSqlServer;
        static public bool modoVirtual;
        static public string DBMemory;

        static CarBDD()
        {
            // Lectura de los parámetros del sistema
            var param = ConfigurationManager.AppSettings;

            if (param.Count == 0)
            {
                // Asignación de parámetros generales
                modoVirtual = true;
                DBMemory = "DBMemory";
                // Cadena de conección
                connSqlServer = "Data source=Server; Initial Catalog=CarProyec; Integrated Security=true;";
            }
            else
            {
                // Asignación de parámetros generales
                modoVirtual = param["modoVirtual"] == "True";
                DBMemory = param["DBMemory"];
                // Variables para preparar la conección
                string sServer = param["Server"];
                string sDB = param["DB"];
                // Cadena de conección
                connSqlServer = ConfigurationManager.ConnectionStrings["ConnSQLServer"].ConnectionString;
                connSqlServer = connSqlServer.Replace("Server", sServer).Replace("DB", sDB);
            }
        }

        static public DbContextOptions<Realacion> DBConn()
        {
            DbContextOptions<Realacion> opciones;

            if (modoVirtual)
            {
                opciones = new DbContextOptionsBuilder<Realacion>()
                    .UseInMemoryDatabase(databaseName: DBMemory)
                    .Options;
            }
            else
            {
                opciones = new DbContextOptionsBuilder<Realacion>()
                .UseSqlServer(connSqlServer)
                .Options;
            }

            return opciones;
        }

        // Creación o actualización de un parámetro en el archivod e configuración
        static public void Guardar(string key, string value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

        }
    }
}
