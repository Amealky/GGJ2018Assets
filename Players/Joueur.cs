using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    float vitesse;
    bool modifvitesse;
    private int vie;

    // Use this for initialization
    void Start()
    {
        vitesse = 10.0f;
        modifvitesse = false;
        vie = 3;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * vitesse;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * vitesse;

        transform.Translate(x, 0, 0);
        transform.Translate(0, y, 0);

        /*if (modifvitesse== true)*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("colision enter 2d");
        if (other.gameObject.tag == "Vide")
        {
            transform.position = new Vector3(-5.5f, 0, -11);
            vie--;
            Debug.Log("J1 a:" + vie);
        }

        if (other.gameObject.tag == "VirusSlow")
        {
            vitesse = vitesse / 2;
            float curentTime = (Time.time);
            if ((Time.time) - curentTime > curentTime+5)
            {
                vitesse = vitesse * 2;
            }
        }

       /* if (other.gameObject.tag == "Bonus")
        {

        }*/
    }
}
