using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //canvas

    public GameObject textPuntuacion;
    public GameObject textPuntuacionMaxima;
    public GameObject textTemporizador;
    public GameObject textTitulo;
    public GameObject butoonPlay;
    public GameObject butoonExit;
    private TextMeshProUGUI TMPtextPuntuacion;
    public TextMeshProUGUI TMPtextPuntuacionMaxima;
    private TextMeshProUGUI TMPtextTemporizador;
    public int puntuacion;
    public int puntuacionMaxima;

    private int temporizador = 60;

    // Variables para el temporizador

    private float incrementadorDeTiempo = 0f;

    //GameObject pool

    public GameObject pool;

    // Start is called before the first frame update
    private void Start()
    {
        MostrarMenuPrincipal();

        puntuacionMaxima = PlayerPrefs.GetInt("score", 0); // ("nombreClave", valorPorDefectoSiNoExisteLaClave)

        //canvas

        TMPtextTemporizador = textTemporizador.GetComponent<TextMeshProUGUI>();
        TMPtextPuntuacion = textPuntuacion.GetComponent<TextMeshProUGUI>();
        TMPtextPuntuacionMaxima = textPuntuacionMaxima.GetComponent<TextMeshProUGUI>();
        TMPtextPuntuacionMaxima.text = "RECORD: " + puntuacionMaxima;

        //puntuacion
        puntuacion = 0;
        //temporizador
        temporizador = 60;
        //incrementador de tiempo
        incrementadorDeTiempo = 500;

        pool.GetComponent<Pool>().burbujasFinales = true;
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(puntuacionMaxima);
        incrementadorDeTiempo += Time.deltaTime;
        if (incrementadorDeTiempo > 1 && incrementadorDeTiempo < 500)
        {
            temporizador--;
            incrementadorDeTiempo = 0;
        }

        //canvas

        PlayerPrefs.SetInt("score", puntuacionMaxima); // ("nombreClave", valorAGrabar)
        PlayerPrefs.Save(); // Esto se llama automaticamente al cerrar Unity (si no crashea)
        //Debug.Log(puntuacionMaxima);
        TMPtextPuntuacion.text = "PUNTUACION: " + puntuacion;
        TMPtextTemporizador.text = temporizador + "s";

        if (temporizador <= 0)
        {
            MostrarMenuPrincipal();
            incrementadorDeTiempo = 500;
            pool.GetComponent<Pool>().burbujasFinales = true;
            Debug.Log("FIN");
        }

        if (puntuacion > puntuacionMaxima)
        {
            Debug.Log(puntuacionMaxima);
            puntuacionMaxima = puntuacion;
            TMPtextPuntuacionMaxima.text = "RECORD: " + puntuacionMaxima;
        }
    }

    //pantalla de menus y botones
    public void StartButoonPlay()
    {
        incrementadorDeTiempo = 0;
        temporizador = 60;
        puntuacion = 0;

        pool.GetComponent<Pool>().burbujasFinales = false;

        OcultarMenuPrincipal();
    }

    public void StarButtonExit()
    {
        Debug.Log("saliiii");
        Application.Quit();
    }

    private void OcultarMenuPrincipal()
    {
        textPuntuacion.SetActive(true);
        textPuntuacionMaxima.SetActive(false);
        textTemporizador.SetActive(true);
        textTitulo.SetActive(false);
        butoonPlay.SetActive(false);
        butoonExit.SetActive(false);
    }

    private void MostrarMenuPrincipal()
    {
        textPuntuacion.SetActive(false);
        textPuntuacionMaxima.SetActive(true);
        textTemporizador.SetActive(false);
        textTitulo.SetActive(true);
        butoonPlay.SetActive(true);
        butoonExit.SetActive(true);
    }
}