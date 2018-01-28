using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerScript : MonoBehaviour {

    public int hp = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "ComputerBullet")
        {
            hp -= 1;
            Destroy(colider.gameObject);
            if (hp == 0)
            {
                Destroy(this);
            }
        }
    }
}
