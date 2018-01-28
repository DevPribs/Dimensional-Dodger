using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayerScript : MonoBehaviour {

    public int hp = 500;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "MobileBullet")
        {
            hp -= 1;
            Destroy(colider.gameObject);
            if( hp == 0)
            {
                Destroy(this);
            }
        }
    }
}
