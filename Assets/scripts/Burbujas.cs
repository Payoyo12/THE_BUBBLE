using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burbujas : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        //Debug.Log("gg");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pared")
        {
            gameObject.SetActive(false);
        }
    }
}