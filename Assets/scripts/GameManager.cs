using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int puntuacionMaxima;

    // Start is called before the first frame update
    private void Start()
    {
        puntuacionMaxima = PlayerPrefs.GetInt("score", 0); // ("nombreClave", valorPorDefectoSiNoExisteLaClave)
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerPrefs.SetInt("score", puntuacionMaxima); // ("nombreClave", valorAGrabar)
        PlayerPrefs.Save(); // Esto se llama automaticamente al cerrar Unity (si no crashea)
        Debug.Log(puntuacionMaxima);
    }
}