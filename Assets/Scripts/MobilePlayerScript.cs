using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MobilePlayerScript : NetworkBehaviour {

    public int hp = 3;
    public int speed = 5;
    public GameObject bullet;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
		{
			return;
		}

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, 0);
        transform.Translate(0, y, 0);

        if(Input.GetKeyDown("space"))
        {
			CmdFire ();
        }
	}

	[Command]
	void CmdFire()
	{
		var b = Instantiate(bullet, this.transform.position, Quaternion.identity);

		NetworkServer.Spawn(b);
	}

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "ComputerBullet")
        {
            hp -= 1;
            Destroy(colider.gameObject);
            if (hp == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
