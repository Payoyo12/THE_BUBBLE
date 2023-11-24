using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    //burbujas

    public GameObject burbujas;       // Referencia prefab a instanciar
    private GameObject[] burbujasArray;   // Array de objetos a reciclar (piscina de objetos)
    private int burbujasArraySize = 30; // Tamanyo del array
    private int burbujasArrayIndice = -1;   // Indice de la posicion del array (indica la bala a activar)
    private float burbujasVelocity = 200;

    public GameObject burbujasDoradas;       // Referencia prefab a instanciar
    private GameObject[] burbujasDoradasArray;   // Array de objetos a reciclar (piscina de objetos)
    private int burbujasDoradasArraySize = 2; // Tamanyo del array
    private int burbujasDoradasArrayIndice = -1;   // Indice de la posicion del array (indica la bala a activar)
    private float burbujasDoradasVelocity = 200;
    private int randomAparicion;    //momento en el que aparecera la burbujaDorada

    //vectores aleatorios

    private int arrayVectoresSize = 4;
    private Vector3[] arrayVectores;
    private int random;

    // Variables para el temporizador

    private float incrementadorDeTiempo = 0f;

    //fin de partida
    public bool burbujasFinales = false;

    // Start is called before the first frame update
    private void Start()
    {
        //burbujas
        burbujasArray = new GameObject[burbujasArraySize]; // Creamos el array con un tamaño igual al de la variable int burbujasArraySize
        for (int i = 0; i < burbujasArraySize; i++)// Creamos todas las burbujas, las colocamos como hijas de este gameobject y las desactivamos
        {
            burbujasArray[i] = Instantiate(burbujas, transform.position, Quaternion.identity);
            burbujasArray[i].transform.parent = gameObject.transform;
            burbujasArray[i].SetActive(false);
        }

        burbujasDoradasArray = new GameObject[burbujasDoradasArraySize]; // Creamos la array con un tamaño igual al de la variable int primera
        for (int i = 0; i < burbujasDoradasArraySize; i++)// Creamos todas las balas, las colocamos como hijas de este gameobject y las desactivamos
        {
            burbujasDoradasArray[i] = Instantiate(burbujasDoradas, transform.position, Quaternion.identity);
            burbujasDoradasArray[i].transform.parent = gameObject.transform;
            burbujasDoradasArray[i].SetActive(false);
        }

        randomAparicion = Random.Range(0, 10000);

        ////vectores aleatorios
        arrayVectores = new Vector3[arrayVectoresSize]; // Creamos la array con un tamaño igual al de la variable int primera

        arrayVectores[0] = new Vector3(-11f, 6f, -1);
        arrayVectores[1] = new Vector3(10f, 6f, -1);
        arrayVectores[2] = new Vector3(-11f, -7f, -1);
        arrayVectores[3] = new Vector3(10f, -7f, -1);

        random = Random.Range(0, 4);
    }

    // Update is called once per frame
    private void Update()
    {
        if (burbujasFinales == true)
        {
            Debug.Log("Desactivando burbujas");
            desactivador();
        }
        else
        {
            random = Random.Range(0, 4);

            incrementadorDeTiempo += Time.deltaTime;
            if (incrementadorDeTiempo > 0.5f)
            {
                burbujasActive();
                incrementadorDeTiempo = 0;
            }

            //randomAparicion = Random.Range(0, 10000);
            randomAparicion = Random.Range(0, 25);

            if (randomAparicion == 20)
            {
                burbujasDoradasActive();
            }
        }
    }

    public void burbujasActive()
    {
        burbujasArrayIndice++; // Tras diparar pasamos a la siguiente burbuja

        // Si nos salimos del rango del array, volvemos a cero.
        if (burbujasArrayIndice >= burbujasArraySize)
        {
            burbujasArrayIndice = 0;
        }

        if (burbujasArray[burbujasArrayIndice].activeSelf == false)
        {
            burbujasArray[burbujasArrayIndice].transform.position = arrayVectores[random]; // Ponemos la burbuja en una de las cuatro salidas

            burbujasArray[burbujasArrayIndice].SetActive(true); // Activamos la burbuja
        }

        //movimiento

        if (burbujasArray[burbujasArrayIndice].transform.position.Equals(arrayVectores[0]))
        {
            //Debug.Log("0");

            burbujasArray[burbujasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.right * burbujasVelocity);
            burbujasArray[burbujasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.down * burbujasVelocity);
        }
        else if (burbujasArray[burbujasArrayIndice].transform.position.Equals(arrayVectores[1]))
        {
            //Debug.Log("1");

            burbujasArray[burbujasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.left * burbujasVelocity);
            burbujasArray[burbujasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.down * burbujasVelocity);
        }
        else if (burbujasArray[burbujasArrayIndice].transform.position.Equals(arrayVectores[2]))
        {
            //Debug.Log("2");

            burbujasArray[burbujasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.right * burbujasVelocity);
            burbujasArray[burbujasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.up * burbujasVelocity);
        }
        else if (burbujasArray[burbujasArrayIndice].transform.position.Equals(arrayVectores[3]))
        {
            //Debug.Log("3");

            burbujasArray[burbujasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.left * burbujasVelocity);
            burbujasArray[burbujasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.up * burbujasVelocity);
        }
    }


    public void burbujasDoradasActive()
    {
        burbujasDoradasArrayIndice++; // Tras diparar pasamos a la siguiente burbuja

        // Si nos salimos del rango del array, volvemos a cero.
        if (burbujasDoradasArrayIndice >= burbujasDoradasArraySize)
        {
            burbujasDoradasArrayIndice = 0;
        }

        if (burbujasDoradasArray[burbujasDoradasArrayIndice].activeSelf == false)
        {
            burbujasDoradasArray[burbujasDoradasArrayIndice].transform.position = arrayVectores[random]; // Ponemos la burbujaDorada en una de las cuatro salidas

            burbujasDoradasArray[burbujasDoradasArrayIndice].SetActive(true); // Activamos el enemigo
        }

        //movimiento

        if (burbujasDoradasArray[burbujasDoradasArrayIndice].transform.position.Equals(arrayVectores[0]))
        {
            //Debug.Log("0");

            burbujasDoradasArray[burbujasDoradasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.right * burbujasDoradasVelocity);
            burbujasDoradasArray[burbujasDoradasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.down * burbujasDoradasVelocity);
        }
        else if (burbujasDoradasArray[burbujasDoradasArrayIndice].transform.position.Equals(arrayVectores[1]))
        {
            //Debug.Log("1");

            burbujasDoradasArray[burbujasDoradasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.left * burbujasDoradasVelocity);
            burbujasDoradasArray[burbujasDoradasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.down * burbujasDoradasVelocity);
        }
        else if (burbujasDoradasArray[burbujasDoradasArrayIndice].transform.position.Equals(arrayVectores[2]))
        {
            //Debug.Log("2");

            burbujasDoradasArray[burbujasDoradasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.right * burbujasDoradasVelocity);
            burbujasDoradasArray[burbujasDoradasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.up * burbujasDoradasVelocity);
        }
        else if (burbujasDoradasArray[burbujasDoradasArrayIndice].transform.position.Equals(arrayVectores[3]))
        {
            //Debug.Log("3");

            burbujasDoradasArray[burbujasDoradasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.left * burbujasDoradasVelocity);
            burbujasDoradasArray[burbujasDoradasArrayIndice].GetComponent<Rigidbody2D>().AddForce(Vector3.up * burbujasDoradasVelocity);
        }
    }

    private void desactivador()
    {
        //burbujas
        for (int i = 0; i < burbujasArraySize; i++)
        {
            //if (burbujasArray[burbujasArrayIndice].activeSelf == true)
            //{
                burbujasArray[i].SetActive(false);
                Debug.Log("burbuja Desactivada");
            //}
        }

        for (int i = 0; i < burbujasDoradasArraySize; i++)
        {
           // if (burbujasDoradasArray[burbujasDoradasArrayIndice].activeSelf == true)
            //{
                burbujasDoradasArray[i].SetActive(false);
                Debug.Log("burbujaDorada Desactivada");
            //}
        }
    }
}