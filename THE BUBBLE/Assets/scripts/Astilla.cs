using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astilla : MonoBehaviour
{
    private Vector3 mousePos;

    // Start is called before the first frame update
    private void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        mousePos.x += 0.8f;
        mousePos.y += 0.5f;
        transform.position = mousePos;
    }

    // Update is called once per frame
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        mousePos.x += 0.8f;
        mousePos.y += 0.5f;
        transform.position = mousePos;
    }
}