using System.Collections;
using UnityEngine;
using TMPro;


public class Login : MonoBehaviour
{
    public Servidor servidor;
    public TMP_InputField inpUser;
    public TMP_InputField inpPass;
    public GameObject loading;
    public GameObject login;
    public TextMeshProUGUI errores;
    public GameObject gameManager;



    public void IniciarSesion()
    {
        StartCoroutine(Iniciar());
    }

    IEnumerator Iniciar()
    {
        loading.SetActive(true);
        string[] datos = new string[2];
        datos[0] = inpUser.text;
        datos[1] = inpPass.text;

        StartCoroutine(servidor.ConsumirServicio("login", datos,PostCargar));

        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(()=>!servidor.ocupado);


        loading.SetActive(false);

        if (servidor.respuesta.codigo == 205)
        {

            StartCoroutine(servidor.ConsumirServicio("return_score", datos, PostCargar));

            //sacamos la puntuacion guardada en la respuesta del servidor 
            string resultado = servidor.respuesta.respuesta;
            string subcadena = resultado.Substring(resultado.IndexOf("score:") + 6);
            string subcadena2 = subcadena.Substring(0, subcadena.Length - 1);

            //asignamos la respuesta del server a la puntuacionMaxima
            gameManager.GetComponent<GameManager>().puntuacionMaxima = int.Parse(subcadena2);
            gameManager.GetComponent<GameManager>().TMPtextPuntuacionMaxima.text = "RECORD: " + int.Parse(subcadena2);

            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => !servidor.ocupado);
            loading.SetActive(false);
        }

    }

    void PostCargar()
    {
        switch (servidor.respuesta.codigo)
        {
            case 204:   // El usuario o la contraseña son incorrectos
                errores.text = servidor.respuesta.mensaje;
                print(servidor.respuesta.mensaje);
                break;
            case 205:   // Inicio de sesion correcto
                login.SetActive(false);
                break;
            case 207:   // sentencia realizada con exito
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
            case 404:   // Error inesperado
                errores.text = servidor.respuesta.mensaje;
                print(servidor.respuesta.mensaje);
                break;
            default:
                break;
        }
    }



}
