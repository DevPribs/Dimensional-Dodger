using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ComputerPlayerScript : NetworkBehaviour {

    public int hp = 500;
    public GameObject bullet;
    public int angle = 30;
    public GameObject firegroup1;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown("n"))
        {
            CmdFire();
        }

	}

    [Command]
    void CmdFire()
    {
        foreach (Transform child in firegroup1.transform)
        {
            //Quaternion childRotation =  child.transform.rotation
            var a = Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180));
            var b = Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180 + angle));
            var c = Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180 + (angle * -1)));

            NetworkServer.Spawn(a);
            NetworkServer.Spawn(b);
            NetworkServer.Spawn(c);
        }
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "MobileBullet")
        {
            hp -= 1;
            Destroy(colider.gameObject);
            if( hp == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
