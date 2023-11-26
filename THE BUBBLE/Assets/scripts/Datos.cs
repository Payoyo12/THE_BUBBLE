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
    public BDscene1 BDscene1;

    //datos
    public string Usuario;
    //1J
    public int NumPartidasJugadas1J;
    public int NumPuntosTotales1J;
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
        

    }

    // Update is called once per frame
    void Update()
    {
        BDscene1 = GameObject.FindGameObjectWithTag("BDscene1").GetComponent<BDscene1>();



    }

    //modo 1J
    public void ActualizarNumPartidasJugadas1J()
    {
        NumPartidasJugadas1J++;
        StartCoroutine(BDscene1.ActualizarNumPartidasJugadas());
    }
    public void ActualizarNumPuntosTotales1J(int NuevaPuntuacion)
    {
        NumPuntosTotales1J += NuevaPuntuacion;
        StartCoroutine(BDscene1.ActualizarNumPuntosTotales());
    }

    public void ActualizarPuntuacionMaxima1J(int NuevaPuntuacion)
    {
        PuntuacionMax1J = NuevaPuntuacion;
        StartCoroutine(BDscene1.ActualizarPuntuacionMaxima());
    }

    public void ActualizarNumBurbujasTotales1J(int NuevaPuntuacion)
    {
        NumBurbujasTotales1J += NuevaPuntuacion;
        StartCoroutine(BDscene1.ActualizarNumBurbujasTotales());
    }
    public void ActualizarNumBurbujasAzules1J(int NuevaPuntuacion)
    {
        NumBurbujasAzules1J += NuevaPuntuacion;
        StartCoroutine(BDscene1.ActualizarNumBurbujasAzules());
    }
    public void ActualizarNumBurbujasDoradas1J(int NuevaPuntuacion)
    {
        NumBurbujasDoradas1J += NuevaPuntuacion;
        StartCoroutine(BDscene1.ActualizarNumBurbujasDoradas());
    }

    //modo 2J

    //Proximamente


}
