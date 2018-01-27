using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    private int vie;

    // Use this for initialization
    void Start()
    {
        vie = 3;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "vide")
        {
            transform.position = new Vector3(-2.5f, 1, 0);
            vie--;
        }
    }
}
