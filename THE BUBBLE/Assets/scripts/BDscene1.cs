using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using UnityEngine;

public class BDscene1 : MonoBehaviour
{

    // Cadena de conexión a la base de datos SQLite en línea
    private string connectionString;
    public Boolean ServidorOcupado;
    public Datos Datos;

    private void Awake()
    {
        // Define la cadena de conexión con la URL de la base de datos en línea
        connectionString = "server=db4free.net;uid=monstercraft12;pwd=monstercraft12;database=thebubble;";
        Datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ActualizarNumPartidasJugadas()
    {
        ServidorOcupado = true;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = "UPDATE `estadisticas1j` SET `NumPartidasJugadas`= @NumPartidasJugadas WHERE `Nombre` = @Usuario";

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Datos.Usuario);
                dbCmd.Parameters.AddWithValue("@NumPartidasJugadas", Datos.NumPartidasJugadas1J);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró un resultado
                    {
                        Debug.Log("Campo actualizado con exito");
                    }
                    else
                    {
                        Debug.Log("Fallo al actualizar Campo");
                    }
                }
            }
        }

        ServidorOcupado = false;
        yield return new WaitUntil(() => !ServidorOcupado);
    }
    public IEnumerator ActualizarNumPuntosTotales()
    {
        ServidorOcupado = true;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = "UPDATE `estadisticas1j` SET `NumPuntosTotales`= @NumPuntosTotales WHERE `Nombre` = @Usuario";

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Datos.Usuario);
                dbCmd.Parameters.AddWithValue("@NumPuntosTotales", Datos.NumPuntosTotales1J);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró un resultado
                    {
                        Debug.Log("Campo actualizado con exito");
                    }
                    else
                    {
                        Debug.Log("Fallo al actualizar Campo");
                    }
                }
            }
        }

        ServidorOcupado = false;
        yield return new WaitUntil(() => !ServidorOcupado);
    }

    public IEnumerator ActualizarPuntuacionMaxima()
    {
        ServidorOcupado = true;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = "UPDATE `estadisticas1j` SET `PuntuacionMax`= @PuntuacionMax WHERE `Nombre` = @Usuario";

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Datos.Usuario);
                dbCmd.Parameters.AddWithValue("@PuntuacionMax", Datos.PuntuacionMax1J);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró un resultado
                    {
                        Debug.Log("Campo actualizado con exito");
                    }
                    else
                    {
                        Debug.Log("Fallo al actualizar Campo");
                    }
                }
            }
        }

        ServidorOcupado = false;
        yield return new WaitUntil(() => !ServidorOcupado);
    }

    public IEnumerator ActualizarNumBurbujasTotales()
    {
        ServidorOcupado = true;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = "UPDATE `estadisticas1j` SET `NumBurbujasTotales`= @NumBurbujasTotales WHERE `Nombre` = @Usuario";

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Datos.Usuario);
                dbCmd.Parameters.AddWithValue("@NumBurbujasTotales", Datos.NumBurbujasTotales1J);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró un resultado
                    {
                        Debug.Log("Campo actualizado con exito");
                    }
                    else
                    {
                        Debug.Log("Fallo al actualizar Campo");
                    }
                }
            }
        }

        ServidorOcupado = false;
        yield return new WaitUntil(() => !ServidorOcupado);
    }

    public IEnumerator ActualizarNumBurbujasAzules()
    {
        ServidorOcupado = true;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = "UPDATE `estadisticas1j` SET `NumBurbujasAzules`= @NumBurbujasAzules WHERE `Nombre` = @Usuario";

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Datos.Usuario);
                dbCmd.Parameters.AddWithValue("@NumBurbujasAzules", Datos.NumBurbujasAzules1J);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró un resultado
                    {
                        Debug.Log("Campo actualizado con exito");
                    }
                    else
                    {
                        Debug.Log("Fallo al actualizar Campo");
                    }
                }
            }
        }

        ServidorOcupado = false;
        yield return new WaitUntil(() => !ServidorOcupado);
    }

    public IEnumerator ActualizarNumBurbujasDoradas()
    {
        ServidorOcupado = true;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string sqlQuery = "UPDATE `estadisticas1j` SET `NumBurbujasDoradas`= @NumBurbujasDoradas WHERE `Nombre` = @Usuario";

            using (MySqlCommand dbCmd = new MySqlCommand(sqlQuery, connection))
            {

                dbCmd.Parameters.AddWithValue("@Usuario", Datos.Usuario);
                dbCmd.Parameters.AddWithValue("@NumBurbujasDoradas", Datos.NumBurbujasDoradas1J);

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read()) // Si se encontró un resultado
                    {
                        Debug.Log("Campo actualizado con exito");
                    }
                    else
                    {
                        Debug.Log("Fallo al actualizar Campo");
                    }
                }
            }
        }

        ServidorOcupado = false;
        yield return new WaitUntil(() => !ServidorOcupado);
    }





}
