using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "MobileBullet" || colider.gameObject.tag == "ComputerBullet")
        {
            Destroy(colider.gameObject);
        }
    }
}
