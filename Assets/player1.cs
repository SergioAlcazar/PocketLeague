using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player1  : MonoBehaviour{

    public KeyCode acc, brake, left, right, boost;
    float speed;
    float friction = 0.1f;
    float power = 5f;
    float torque = 4f;
    float maxspeed = 5f;
    Vector3 current_speed;
    Rigidbody rb;
    string scb_prev, scr_prev;
    public Text scorered, scoreblue;

	// Use this for initialization
	void Start () {
        speed = 0f;
        rb = GetComponent<Rigidbody>();
        scb_prev.Equals(scoreblue.text);
        scr_prev.Equals(scorered.text);

    }
	
	// Update is called once per frame
	void Update () {
        current_speed = new Vector3(rb.velocity.x, rb.velocity.y, 0);
	    if(Input.GetKey(acc)&&current_speed.x<=maxspeed)
        {
            rb.AddForce(transform.right*power);
            rb.drag = 10*friction;
        }
        if (Input.GetKey(brake))
        {
            rb.AddForce(transform.right*(-power));
            rb.drag = 2*friction;
        }
        if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.forward * torque);
            rb.drag = 15*friction;
        }
        if (Input.GetKey(right))
        {
            transform.Rotate(Vector3.forward * -torque);
            rb.drag = 15*friction;
        }
        if (Input.GetKey(boost) && current_speed.x <= maxspeed * 1.7f)
        {
            rb.AddForce(transform.right * 2f*power);
            rb.drag = friction;
        }
        if (Input.GetKey(acc) || Input.GetKey(brake) || Input.GetKey(boost))
        {
            
        }else
        {
            rb.drag = 25 * friction;
        }
        if (CheckGoals())
        {
            Invoke("ResetPositions", 3);
        }
    }

    bool CheckGoals()
    {
        string scb = scoreblue.text;
        string scr = scorered.text;
        if (!scb.Equals(scb_prev) || !scr.Equals(scr_prev))
        {
            scb_prev = scb;
            scr_prev = scr;
            return true;
        }
        else {
            return false;
        }
    }

    void ResetPositions()
    {
        if (this.tag == "red")
        {
            transform.localPosition = new Vector3(5.47f, 0.65f, 0);
            transform.eulerAngles = new Vector3(0, 0, 180);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        if (this.tag == "blue")
        {
            transform.localPosition = new Vector3(-5.47f, 0.65f, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
