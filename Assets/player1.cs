using UnityEngine;
using System.Collections;

public class player1 : MonoBehaviour {

    public KeyCode acc, brake, left, right, boost;
    float speed;
    float friction = 0.1f;
    float power = 5f;
    float torque = 4f;
    float maxspeed = 5f;
    Vector3 current_speed;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        speed = 0f;
        rb = GetComponent<Rigidbody>();
        

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
    }
}
