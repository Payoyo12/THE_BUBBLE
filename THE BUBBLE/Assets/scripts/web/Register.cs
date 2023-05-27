using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Register : MonoBehaviour
{
    public Servidor servidor;
    public TMP_InputField inpUser;
    public TMP_InputField inpPass;
    public GameObject loading;
    public TextMeshProUGUI errores;


    public void RegistrarUsuario()
    {
        StartCoroutine(Iniciar());
    }

    IEnumerator Iniciar()
    {
        loading.SetActive(true);
        string[] datos = new string[3];
        datos[0] = inpUser.text;
        datos[1] = inpPass.text;
        datos[2] = "0";

        StartCoroutine(servidor.ConsumirServicio("reg_user", datos, PostCargar));

        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        loading.SetActive(false);

    }

    void PostCargar()
    {
        switch (servidor.respuesta.codigo)
        {
            case 201:   // Usuario creado correctamente
                errores.text = servidor.respuesta.mensaje;
                print(servidor.respuesta.mensaje);
                break;
            case 400:   // Error al conectar con el servidor
                errores.text = servidor.respuesta.mensaje;
                print(servidor.respuesta.mensaje);
                break;
            case 402:   // Faltan datos para ejecutar la accion solicitada
                errores.text = servidor.respuesta.mensaje;
                print(servidor.respuesta.mensaje);
                break;
            case 403:   // Ya existe un usuario registrado con ese nombre
                errores.text = servidor.respuesta.mensaje;
                print(servidor.respuesta.mensaje);
                break;
            case 404:   // Error inesperado
                errores.text = servidor.respuesta.mensaje;
                print(servidor.respuesta.mensaje);
                break;
            default:
                break;
        }
    }



}
