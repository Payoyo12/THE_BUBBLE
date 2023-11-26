using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScreenActionsScene0 : MonoBehaviour
{
     
    private static bool PrimeraVez = true;

    public GameObject PInicio;
    public GameObject PLogReg;
    public TextMeshProUGUI Titulo;
    public GameObject PJugadores;
    public GameObject PEstadisticas;
    public TextMeshProUGUI Estadisticas1j;
    public GameObject PLogros;
    public GameObject PInformacion;
    public GameObject PCarga;

    public Datos Datos;
    public BDscene0 BDscene0;

    

    // Start is called before the first frame update
    void Start()
    {
        DesactivarPantallaCarga();

        if (PrimeraVez)
        {
            PantallaInicio();
            PrimeraVez = false;
        }
        else
        {
            PantallaJugadores();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();

    }

    public void PantallaInicio()
    {
        PInicio.SetActive(true);
        PLogReg.SetActive(false);
        PJugadores.SetActive(false);
        PEstadisticas.SetActive(false);
        PLogros.SetActive(false);
        PInformacion.SetActive(false);
    }

    public void PantallaLog()
    {

        Titulo.text = "INICIO";
        PInicio.SetActive(false);
        PLogReg.SetActive(true);
        PJugadores.SetActive(false);
        PEstadisticas.SetActive(false);
        PLogros.SetActive(false);
        PInformacion.SetActive(false);
    }

    public void PantallaReg()
    {

        Titulo.text = "REGISTRO";
        PInicio.SetActive(false);
        PLogReg.SetActive(true);
        PJugadores.SetActive(false);
        PEstadisticas.SetActive(false);
        PLogros.SetActive(false);
        PInformacion.SetActive(false);
    }

    public void PantallaJugadores()
    {
        PInicio.SetActive(false);
        PLogReg.SetActive(false);
        PJugadores.SetActive(true);
        PEstadisticas.SetActive(false);
        PLogros.SetActive(false);
        PInformacion.SetActive(false);
    }

    public void PantallaEstadisticas()
    {

        Estadisticas1j.text = "|    " + Datos.NumPartidasJugadas1J +
                            "\n|    " + Datos.NumPuntosTotales1J +
                            "\n|    " + Datos.PuntuacionMax1J +
                            "\n|    " + Datos.NumBurbujasTotales1J +
                            "\n|    " + Datos.NumBurbujasAzules1J +
                            "\n|    " + Datos.NumBurbujasDoradas1J;

        PInicio.SetActive(false);
        PLogReg.SetActive(false);
        PJugadores.SetActive(false);
        PEstadisticas.SetActive(true);
        PLogros.SetActive(false);
        PInformacion.SetActive(false);
    }

    public void PantallaLogros()
    {
        PInicio.SetActive(false);
        PLogReg.SetActive(false);
        PJugadores.SetActive(false);
        PEstadisticas.SetActive(false);
        PLogros.SetActive(true);
        PInformacion.SetActive(false);
    }

    public void PantallaInformacion()
    {
        PInicio.SetActive(false);
        PLogReg.SetActive(false);
        PJugadores.SetActive(false);
        PEstadisticas.SetActive(false);
        PLogros.SetActive(false);
        PInformacion.SetActive(true);
    }

    public void ActivarPantallaCarga()
    {
        PCarga.SetActive(true);
    }

    public void DesactivarPantallaCarga()
    {
        PCarga.SetActive(false);
    }

    public void Scene1()
    {
        SceneManager.LoadScene(1);
    }

    public void Scene2()
    {
        SceneManager.LoadScene(2);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void EstablecerConexion (TextMeshProUGUI tipo)
    {

        ActivarPantallaCarga();

        if (tipo.text == "INICIO")
        {
            StartCoroutine(BDscene0.IniciarSesionUsuario());
            //BDscene0.IniciarSesionUsuario();
        }
        else if (tipo.text == "REGISTRO")
        {
            StartCoroutine(BDscene0.RegisterUsuario());
            //BDscene0.RegisterUsuario();
        }
        //else
        //{
        //    DesactivarPantallaCarga();
        //    Debug.Log("no coincide: "+tipo.text);

        //}
    }








}
