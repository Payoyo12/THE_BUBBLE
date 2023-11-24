using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMScene1 : MonoBehaviour
{

    //temporizador de la partida
    public TextMeshProUGUI Comenzando;
    private float Contador;
    private bool Temporizador;

    public ScreenActionsScene1 ScreenActionsScene1;
    public Pool Pool;


    //datos de la partida
    public Datos Datos;
    public int PuntuacionActual;

    private void Awake()
    {
        Datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
        ReestablecerValores();


    }

    // Update is called once per frame
    void Update()
    {
        if (Temporizador)
        {
            if (Contador > 0)
            {
                Contador -= Time.deltaTime;
                int tiempoRedondeado = Mathf.CeilToInt(Contador);
                Comenzando.text = tiempoRedondeado.ToString();
            }
            else
            {
                if (PuntuacionActual>Datos.PuntuacionMax1J)
                {
                    Datos.ActualizarPuntuacionMaxima1J(PuntuacionActual);
                }

                ScreenActionsScene1.PantallaResultado();
                ReestablecerValores();
                

            }

        }
    }


    public void ComenzarPartida1J()
    {

        Temporizador = true;
        Pool.burbujasFinales = false;

    }

    private void ReestablecerValores()
    {
        Temporizador = false;
        Contador = 10;
        Comenzando.text = Contador.ToString();
        PuntuacionActual = 0;
        Pool.burbujasFinales = true;
    }


}
