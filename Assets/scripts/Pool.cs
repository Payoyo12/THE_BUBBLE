using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    //burbujas

    public GameObject burbujas;       // Referencia prefab a instanciar
    private GameObject[] burbujasArray;   // Array de objetos a reciclar (piscina de objetos)
    private int burbujasArraySize = 100; // Tamanyo del array
    private int burbujasArrayIndice = -1;   // Indice de la posicion del array (indica la bala a activar)
    private float burbujasVelocity = 60;

    //vectores aleatorios

    private int arrayVectoresSize = 4;
    private Vector3[] arrayVectores;
    private int random;

    // Variables para el temporizador

    private float incrementadorDeTiempo = 0f;

    //private float duracionDeRonda = 30f;

    // Start is called before the first frame update
    private void Start()
    {
        //burbujas
        burbujasArray = new GameObject[burbujasArraySize]; // Creamos la array con un tamaño igual al de la variable int primera
        for (int i = 0; i < burbujasArraySize; i++)// Creamos todas las balas, las colocamos como hijas de este gameobject y las desactivamos
        {
            burbujasArray[i] = Instantiate(burbujas, transform.position, Quaternion.identity);
            burbujasArray[i].transform.parent = gameObject.transform;
            burbujasArray[i].SetActive(false);
        }

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
        random = Random.Range(0, 4);

        incrementadorDeTiempo += Time.deltaTime;
        if (incrementadorDeTiempo > 1)
        {
            burbujasActive();
            incrementadorDeTiempo = 0;
        }
    }

    public void burbujasActive()
    {
        burbujasArrayIndice++; // Tras diparar pasamos a la siguiente bala

        // Si nos salimos del rango del array, volvemos a cero.
        if (burbujasArrayIndice >= burbujasArraySize)
        {
            burbujasArrayIndice = 0;
        }

        if (burbujasArray[burbujasArrayIndice].activeSelf == false)
        {
            burbujasArray[burbujasArrayIndice].transform.position = arrayVectores[random]; // Ponemos el enemigoAmor en una de las cuatro salidas

            burbujasArray[burbujasArrayIndice].SetActive(true); // Activamos el enemigo
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
}