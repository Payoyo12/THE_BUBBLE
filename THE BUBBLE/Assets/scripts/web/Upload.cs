using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upload : MonoBehaviour
{
    public Servidor servidor;
    public TMP_InputField inpUser;
    public TMP_InputField inpPass;
    public GameObject loading;
    public GameObject gameManager;


    public void ActualizarUsuario()
    {
        StartCoroutine(Iniciar());
    }

    IEnumerator Iniciar()
    {
        loading.SetActive(true);
        string[] datos = new string[3];
        datos[0] = inpUser.text;
        datos[1] = inpPass.text;
        int max = gameManager.GetComponent<GameManager>().puntuacionMaxima;
        datos[2] = max.ToString();

        StartCoroutine(servidor.ConsumirServicio("editar_usuario", datos, PostCargar));

        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        loading.SetActive(false);

    }

    void PostCargar()
    {
        switch (servidor.respuesta.codigo)
        {
            case 206:   // usuario editado con exito
                print(servidor.respuesta.mensaje);
                break;
            case 404:   // Error inesperado
                print(servidor.respuesta.mensaje);
                break;
            default:
                break;
        }
    }


}
