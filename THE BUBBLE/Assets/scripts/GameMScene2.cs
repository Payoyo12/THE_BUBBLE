using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMScene2 : MonoBehaviour
{

    public TextMeshProUGUI Comenzando;
    private float Contador;
    private bool Temporizador;

    public ScreenActionsScene2 ScreenActionsScene2;
    public Pool Pool;

    // Start is called before the first frame update
    void Start()
    {
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

                ReestablecerValores();
                ScreenActionsScene2.PantallaResultado();

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


    }


}
