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
    public GameObject butoonPlay;
    public GameObject butoonExit;
    private TextMeshProUGUI TMPtextPuntuacion;
    private TextMeshProUGUI TMPtextPuntuacionMaxima;
    private TextMeshProUGUI TMPtextTemporizador;
    public int puntuacion;
    private int puntuacionMaxima;

    private int temporizador = 30;

    // Variables para el temporizador

    private float incrementadorDeTiempo = 0f;

    //GameObject pool

    public GameObject pool;

    // Start is called before the first frame update
    private void Start()
    {
        MostrarMenuPrincipal();

        //canvas

        TMPtextTemporizador = textTemporizador.GetComponent<TextMeshProUGUI>();
        TMPtextPuntuacion = textPuntuacion.GetComponent<TextMeshProUGUI>();
        TMPtextPuntuacionMaxima = textPuntuacionMaxima.GetComponent<TextMeshProUGUI>();
        TMPtextPuntuacionMaxima.text = "RECORD: " + puntuacionMaxima;
        puntuacionMaxima = PlayerPrefs.GetInt("score", 0); // ("nombreClave", valorPorDefectoSiNoExisteLaClave)

        //puntuacion
        puntuacion = 0;
        //temporizador
        temporizador = 30;
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
        TMPtextPuntuacion.text = "PUNTUACION: : " + puntuacion;
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
        temporizador = 30;
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
        butoonPlay.SetActive(false);
        butoonExit.SetActive(false);
    }

    private void MostrarMenuPrincipal()
    {
        textPuntuacion.SetActive(false);
        textPuntuacionMaxima.SetActive(true);
        textTemporizador.SetActive(false);
        butoonPlay.SetActive(true);
        butoonExit.SetActive(true);
    }
}