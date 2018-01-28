using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

    public int speed = 20;

    // Use this for initialization
    void Start () {
        //Rigidbody2D rb2d = (Rigidbody2D) GetComponent("Rigidbody2D");

        //rb2d.AddForce(transform.up * speed);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += (transform.up * speed * Time.deltaTime )/ 25;
	}
}
