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

    //audio

    public GameObject audioBurbuja16;
    public GameObject audioBurbujaDorada;

    //collider

    private BoxCollider2D[] burbujaBoxCollider2D;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager");
        audioBurbuja16 = GameObject.FindGameObjectWithTag("burbujaexplot16");
        audioBurbujaDorada = GameObject.FindGameObjectWithTag("burbujaexplotdorada");
    }

    // Start is called before the first frame update
    private void Start()
    {
        burbujaBoxCollider2D = gameObject.GetComponents<BoxCollider2D>();
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
            burbujaBoxCollider2D[0].enabled = true;
            burbujaBoxCollider2D[1].enabled = true;
        }

        if (gameObject.tag.Equals("burbujaDorada"))
        {
            burbujaDoradaVida = 3;
            burbujaBoxCollider2D[0].enabled = true;
            burbujaBoxCollider2D[1].enabled = true;
        }

        audioBurbuja16.GetComponent<AudioSource>().Stop();
        audioBurbujaDorada.GetComponent<AudioSource>().Stop();
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
            audioBurbuja16.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("burbujaexplot16");
            burbujaBoxCollider2D[0].enabled = false;
            burbujaBoxCollider2D[1].enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            //gameManager.GetComponent<GameManager>().puntuacion++;
            gameManager.GetComponent<GameMScene1>().PuntuacionActual++;
            gameManager.GetComponent<GameMScene1>().BurbujasAzules++;

        }

        if (burbujaDoradaVida == 0)
        {
            audioBurbujaDorada.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("burbujaexplot16");
            burbujaBoxCollider2D[0].enabled = false;
            burbujaBoxCollider2D[1].enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            //gameManager.GetComponent<GameManager>().puntuacion += 3;
            gameManager.GetComponent<GameMScene1>().PuntuacionActual +=3;
            gameManager.GetComponent<GameMScene1>().BurbujasDoradas++;

        }
    }
    
    public void DestroyBubble()
    {
        gameObject.SetActive(false);
    }
}