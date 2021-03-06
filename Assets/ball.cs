﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ball : MonoBehaviour {

    int speedx, speedy;
    float speed;
    Vector2 position;
    public Material[] materials;
    new Renderer renderer;

    //puntuación
    public Text scoreblue, scorered;
    public int scoreb, scorer;

    // Use this for initialization
    void Start () {
        renderer = GetComponent<Renderer>();
        scoreb = 0;
        scorer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        scoreblue.text = scoreb.ToString();
        scorered.text = scorer.ToString(); 
	}

    // Collision detector
    void OnTriggerEnter(Collider objeto)
    {
        if(objeto.tag == "redgoal")
        {
            scoreb++;

            Invoke("ResetPositions", 2);
        }
        if(objeto.tag == "bluegoal")
        {
            scorer++;

            Invoke("ResetPositions", 3);
        }

    }

    void ResetPositions()
    {
        GetComponent<TrailRenderer>().enabled = false;

        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.localPosition = new Vector3(0, 0.65f, 0);
        GetComponent<TrailRenderer>().enabled = true;
    }
}
