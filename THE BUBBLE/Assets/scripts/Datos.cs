using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;

public class Datos : MonoBehaviour
{
    public static Datos Instance;


    // Cadena de conexión a la base de datos SQLite en línea
    //private string connectionString;

    //datos
    public string Usuario;
    //1J
    public int NumPartidasJugadas1J;
    public int PuntuacionMax1J;
    public int NumBurbujasTotales1J;
    public int NumBurbujasAzules1J;
    public int NumBurbujasDoradas1J;
    //2J
    //Proximamente

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Define la cadena de conexión con la URL de la base de datos en línea
        //connectionString = "server=db4free.net;uid=monstercraft12;pwd=monstercraft12;database=thebubble;";

    }

    // Update is called once per frame
    void Update()
    {



    }
    public void ActualizarPuntuacionMaxima1J(int NuevaPuntuacion)
    {
        PuntuacionMax1J = NuevaPuntuacion;
        Debug.Log("Puntuacion Maxima actualizada = " + PuntuacionMax1J);
        //UPDATE PuntuacionMaxima1J
    }




}
