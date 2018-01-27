using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public float vitesse;
    bool modifvitesse;
    public int vie;
    public float pourcentage;

    float slowTime;

    public AudioClip Degats;
    private AudioSource source;
    private float volumecourtedistance= .5f;
    private float volumelonguedistance= 1.0f;
    // Use this for initialization
    void Start()
    {
        vitesse = 20.0f;
        modifvitesse = false;
        vie = 3;
        pourcentage = 0.0f;

        source = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * vitesse;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * vitesse;

        transform.Translate(x, 0, 0);
        transform.Translate(0, y, 0);

        float curentTime = (Time.time);
        if (modifvitesse== true && ((curentTime - slowTime) > 3))
        {
            vitesse = 30;
            modifvitesse = false;
        }
    }

    void OnTriggerEnter2D (Collider2D other)
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
            AudioSource.PlayClipAtPoint(Degats, transform.position);
            vitesse = vitesse / 2;
            modifvitesse = true;
            slowTime = (Time.time);
        }

        if (other.gameObject.tag == "Tir normaux")
        {
            Debug.Log("Dommage pris");
            Debug.Log("recul");
        }

        if (other.gameObject.tag == "Bonus")
         {
            Debug.Log("BOOST!!!!");
        }
    }
}
