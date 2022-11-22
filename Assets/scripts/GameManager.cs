using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //canvas

    public GameObject textPuntuacion;
    public GameObject textTemporizador;
    private TextMeshProUGUI TMPtextPuntuacion;
    private TextMeshProUGUI TMPtextTemporizador;
    public int puntuacionMaxima;
    private int temporizador = 30;

    // Variables para el temporizador

    private float incrementadorDeTiempo = 0f;

    //GameObject pool

    public GameObject pool;

    // Start is called before the first frame update
    private void Start()
    {
        //canvas

        TMPtextPuntuacion = textPuntuacion.GetComponent<TextMeshProUGUI>();
        TMPtextTemporizador = textTemporizador.GetComponent<TextMeshProUGUI>();
        puntuacionMaxima = PlayerPrefs.GetInt("score", 0); // ("nombreClave", valorPorDefectoSiNoExisteLaClave)

        //temporizador

        temporizador = 10;
        incrementadorDeTiempo = 0;
    }

    // Update is called once per frame
    private void Update()
    {
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
        TMPtextPuntuacion.text = "PUNTUACION: " + puntuacionMaxima;
        TMPtextTemporizador.text = temporizador + "s";

        if (temporizador <= 0)
        {
            incrementadorDeTiempo = 500;
            pool.GetComponent<Pool>().burbujasFinales = true;
            Debug.Log("FIN");
        }
    }
}