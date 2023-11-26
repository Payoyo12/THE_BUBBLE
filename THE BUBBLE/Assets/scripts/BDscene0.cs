using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;

public class BDscene0 : MonoBehaviour
{

    // Cadena de conexión a la base de datos SQLite en línea
    private string connectionString;
    public TextMeshProUGUI Usuario;
    public TextMeshProUGUI Contraseña;
    public TextMeshProUGUI Errores;
    public ScreenActionsScene0 Manager;
    public Datos Datos;
    public Boolean ServidorOcupado;

    private void Awake()
    {
        // Define la cadena de conexión con la URL de la base de datos en línea
        connectionString = "server=db4free.net;uid=monstercraft12;pwd=monstercraft12;database=thebubble;";
    }

    // Start is called before the first frame update
    void Start()
    {
        ServidorOcupado = false;
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    // Función para iniciar sesion del usuario
    public IEnumerator IniciarSesionUsuario()
    {
        Errores.text = "Iniciando sesion";
        ServidorOcupado = true;


        if (ComprobarUsuario())
        {
            if (ComprobarContraseña())
            {
                CargarDatos();
                Manager.DesactivarPantallaCarga();
                Manager.PantallaJugadores();
            }
            else
            {
                Manager.DesactivarPantallaCarga();
                Errores.text = "contraseña incorrecta";
                ServidorOcupado = false;
            }
        }
        else
        {
            Manager.DesactivarPantallaCarga();
            Errores.text = "usuario no existe";
            ServidorOcupado = false;
        }
        ServidorOcupado = false;
        yield return new WaitForSeconds(5.5f);
        yield return new WaitUntil(() => !ServidorOcupado);
    }



    // Función para registrar un usuario en la base de datos en línea
    public IEnumerator RegisterUsuario()
    {
        
        Errores.text = "registrando usuario";
        ServidorOcupado = true;

        //comprobamos que no exista el usuario
        if (ComprobarUsuario())
        {
            Manager.DesactivarPantallaCarga();
            Errores.text = "usuario ya existe";
            ServidorOcupado = false;
        }
        else
        {

            GenerarDatos();
            StartCoroutine(IniciarSesionUsuario());
        }
        ServidorOcupado = false;
        yield return new WaitForSeconds(100.5f);
        yield return new WaitUntil(() => !ServidorOcupado);

    }

    // Función para comprobar si existe(true) o no(false) el usuario en la base de datos en linea
    public Boolean ComprobarUsuario()
    {
        Errores.text = "comprobando usuario";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = "SELECT Nombre FROM `usuarios` WHERE Nombre = @Usuario";

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {
                
                dbCmd.Parameters.AddWithValue("@Usuario", Usuario.text);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró un resultado
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }

    // Función para comprobar si es correcta(true) o no(false)la contraseña del usuario en la base de datos en linea
    public Boolean ComprobarContraseña()
    {
        Errores.text = "comprobar contraseña";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = String.Format("SELECT Contraseña FROM `usuarios` WHERE Nombre = @Usuario AND Contraseña = @Contraseña");

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {
                
                dbCmd.Parameters.AddWithValue("@Usuario", Usuario.text);
                dbCmd.Parameters.AddWithValue("@Contraseña", Contraseña.text);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró un resultado
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }

    //funciones para cargar los datos del usuario
    public void CargarDatos()
    {

        //extrae todos los dates de la BBDD
        Errores.text = "cargando datos";
        CargarDatos1j();
        //CargarDatos2j();
        
    }

    public void CargarDatos1j()
    {
        Errores.text = "cargando datos1j";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = "SELECT * FROM `estadisticas1j` WHERE Nombre = @Usuario";

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Usuario.text);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró un resultado
                    {
                        //return true;
                        //Datos.Usuario = reader["Nombre"].ToString();
                        Datos.Usuario = Convert.ToString(reader["Nombre"]);
                        Datos.NumPartidasJugadas1J = Convert.ToInt32(reader["NumPartidasJugadas"]);
                        Datos.NumPuntosTotales1J = Convert.ToInt32(reader["NumPuntosTotales"]);
                        Datos.PuntuacionMax1J = Convert.ToInt32(reader["PuntuacionMax"]);
                        Datos.NumBurbujasTotales1J = Convert.ToInt32(reader["NumBurbujasTotales"]);
                        Datos.NumBurbujasAzules1J = Convert.ToInt32(reader["NumBurbujasAzules"]);
                        Datos.NumBurbujasDoradas1J = Convert.ToInt32(reader["NumBurbujasDoradas"]);
                    }
                    else
                    {
                        Manager.DesactivarPantallaCarga();
                        Errores.text = "Error al cargar datos1j";
                    }
                }
            }
        }
    }

    //public void CargarDatos2j()
    //{
    //    Errores.text = "cargando datos2j";
    //    using (MySqlConnection connection = new MySqlConnection(connectionString))
    //    {
    //        connection.Open();

    //        string sqlQuery = "SELECT * FROM `estadisticas2j` WHERE Nombre = @Usuario";

    //        using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
    //        {

    //            dbCmd.Parameters.AddWithValue("@Usuario", Usuario.text);

    //            using (IDataReader reader = dbCmd.ExecuteReader())
    //            {
    //                if (reader.Read()) // Si se encontró un resultado
    //                {
    //                    //return true;
    //                    Datos.NumPartidasJugadas2J = Convert.ToInt32(reader["NumPartidasJugadas"]);
    //                    Datos.NumPartidasJugadas2J = Convert.ToInt32(reader["NumPartidasJugadas"]);
    //                    Datos.NumPartidasJugadas2J = Convert.ToInt32(reader["NumPartidasJugadas"]);
    //                    Datos.NumPartidasJugadas2J = Convert.ToInt32(reader["NumPartidasJugadas"]);
    //                    Datos.NumPartidasJugadas2J = Convert.ToInt32(reader["NumPartidasJugadas"]);
    //                }
    //                else
    //                {
    //                    Manager.DesactivarPantallaCarga();
    //                    Errores.text = "Error al cargar datos2j";
    //                }
    //            }
    //        }
    //    }
    //}

    //funciones para generar los datos del usuario
    public void GenerarDatos()
    {
        Errores.text = "generando datos";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = String.Format("INSERT INTO `usuarios`(`Nombre`, `Contraseña`) " +
                                                "VALUES (@Usuario, @Contraseña)");

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Usuario.text);
                dbCmd.Parameters.AddWithValue("@Contraseña", Contraseña.text);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    GenerarDatos1j();
                    //GenerarDatos2j();
                }
                else
                {
                    Manager.DesactivarPantallaCarga();
                    Errores.text = "Error al generar datos. Intentalo mas tarde";
                }
            }
        }
    }

    private void GenerarDatos1j()
    {
        Errores.text = "generando datos1j";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();


            string sqlQuery = String.Format("INSERT INTO `estadisticas1j`(`Nombre`, `NumPartidasJugadas`, `NumPuntosTotales`, `PuntuacionMax`, `NumBurbujasTotales`, `NumBurbujasAzules`, `NumBurbujasDoradas`) " +
            "VALUES (@Usuario,0,0,0,0,0,0)");

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Usuario.text);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Errores.text = "datos1j generados correctamente";
                }
                else
                {
                    Errores.text = "Error al generar datos1J. Intentalo mas tarde";
                    Manager.DesactivarPantallaCarga();
                    BorrarUsuario();
                }
            }
        }
    }

    //INCOMPLETO PROXIMAMENTE ES SOLO UN EJEMPLO
    //private void GenerarDatos2j()
    //{

    //    Errores.text = "Generando datos2j";
    //    using (MySqlConnection connection = new MySqlConnection(connectionString))
    //    {
    //        connection.Open();


    //        string sqlQuery = String.Format("INSERT INTO `estadisticas1j`(`Nombre`, `NumPartidasJugadas`, `PuntuacionMax`, `NumBurbujasTotales`, `NumBurbujasAzules`, `NumBurbujasDoradas`) " +
    //        "VALUES (@Usuario,0,0,0,0,0)");

    //        using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
    //        {

    //            dbCmd.Parameters.AddWithValue("@Usuario", Usuario.text);

    //            int rowsAffected = dbCmd.ExecuteNonQuery();

    //            if (rowsAffected > 0)
    //            {
    //                IniciarSesionUsuario();
    //            }
    //            else
    //            {
    //                Errores.text = "Error al generar datos2J. Intentalo mas tarde";
    //                Manager.DesactivarPantallaCarga();
    //                //BorrarUsuario();
    //            }
    //        }
    //    }
    //}
    private void BorrarUsuario()
    {
        Errores.text = "Borrando usuario";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();


            string sqlQuery = String.Format("DELETE FROM `usuarios` WHERE Nombre = @Usuario");

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Usuario.text);

                int rowsAffected = dbCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Errores.text = "Usuario borrado correctamente";
                }
                else
                {
                    Errores.text = "Error al Borrar usuario";
                    Manager.DesactivarPantallaCarga();
                    //BorrarUsuario(); proximamente
                }
            }
        }
    }

}














