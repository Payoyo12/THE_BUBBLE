using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScreenActionsScene2 : MonoBehaviour
{
    public GameObject Fondo;
    public GameObject PJugar;
    public GameObject PComenzando;
    public GameObject PJugando;
    public GameObject PResultado;
    public TextMeshProUGUI Comenzando;

    private float Contador;
    private bool Temporizador;
    public GameMScene2 GameMScene2;

    // Start is called before the first frame update
    void Start()
    {
        ReestablecerValores();
        PantallaJugar();
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
                PantallaJugando();
                ReestablecerValores();
                GameMScene2.ComenzarPartida1J();



            }

        }
    }


    public void PantallaJugar()
    {
        Fondo.SetActive(true);
        PJugar.SetActive(true);
        PComenzando.SetActive(false);
        PJugando.SetActive(false);
        PResultado.SetActive(false);

    }

    public void PantallaComenzando()
    {
        Fondo.SetActive(true);
        PJugar.SetActive(false);
        PComenzando.SetActive(true);
        PJugando.SetActive(false);
        PResultado.SetActive(false);

        Temporizador = true;
    }


    public void PantallaJugando()
    {
        Fondo.SetActive(false);
        PJugar.SetActive(false);
        PComenzando.SetActive(false);
        PJugando.SetActive(true);
        PResultado.SetActive(false);

    }


    public void PantallaResultado()
    {
        Fondo.SetActive(true);
        PJugar.SetActive(false);
        PComenzando.SetActive(false);
        PJugando.SetActive(false);
        PResultado.SetActive(true);

    }

    public void Scene0()
    {
        SceneManager.LoadScene(0);
    }

    private void ReestablecerValores()
    {
        Temporizador = false;
        Contador = 3;
        Comenzando.text = Contador.ToString();


    }

}
