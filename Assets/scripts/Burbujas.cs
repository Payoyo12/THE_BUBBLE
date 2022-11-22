using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burbujas : MonoBehaviour
{
    //vidas

    private int burbujaVida = 1;
    private int burbujaDoradaVida = 3;

    //gameManager
    private GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager");
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnEnable()
    {
        if (gameObject.tag.Equals("burbuja"))
        {
            burbujaVida = 1;
        }

        if (gameObject.tag.Equals("burbujaDorada"))
        {
            burbujaDoradaVida = 3;
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.tag.Equals("burbuja"))
        {
            burbujaVida--;
        }

        if (gameObject.tag.Equals("burbujaDorada"))
        {
            burbujaDoradaVida--;
        }

        if (burbujaVida == 0)
        {
            gameManager.GetComponent<GameManager>().puntuacion++;
            gameObject.SetActive(false);
            //Debug.Log("gg");
        }

        if (burbujaDoradaVida == 0)
        {
            gameManager.GetComponent<GameManager>().puntuacion += 3;
            gameObject.SetActive(false);
            //Debug.Log("gg");
        }
    }
}