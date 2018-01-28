using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ComputerPlayerScript : NetworkBehaviour {

	[SyncVar(hook="OnChangeHealth")]
    public int hp = 500;
    public GameObject bullet;
    public int angle = 30;
    public int angle2 = 23;
    public GameObject firegroup1;
    public GameObject firegroup2;
    public GameObject laser1;
    public GameObject laser2;
    public Dictionary<int, float> cooldowns;
	public Slider healthBar;

	// Use this for initialization
	void Start ()
    {
        cooldowns = new Dictionary<int, float>();
        cooldowns.Add(1, 0);
        cooldowns.Add(2, 0);
        cooldowns.Add(3, 0);
        cooldowns.Add(4, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        float currentTime = Time.time;
		if(Input.GetKeyDown("y"))
        {
            if(cooldowns[1] < currentTime)
            {
                CmdFire1();
                cooldowns[1] = currentTime + 0.1F;
            }
            
        }
        if(Input.GetKeyDown("i"))
        {
            if (cooldowns[2] < currentTime)
            {
                CmdFire2();
                cooldowns[2] = currentTime + 6F;
            }
        }
        if (Input.GetKeyDown("t"))
        {
            if (cooldowns[3] < currentTime)
            {
                CmdFire3();
                cooldowns[3] = currentTime + 6F;
            }
        }
        if (Input.GetKeyDown("u"))
        {
            if (cooldowns[4] < currentTime)
            {
                CmdFire4();
                cooldowns[4] = currentTime + 0.1F;
            }
        }

    }

    [Command]
    void CmdFire1()
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

    [Command]
    void CmdFire2()
    {
        var d = Instantiate(laser1, laser1.transform.position, laser1.transform.rotation * Quaternion.Euler(0, 0, 0));

        NetworkServer.Spawn(d);
    }

    [Command]
    void CmdFire3()
    {
        var e = Instantiate(laser2, laser2.transform.position, laser2.transform.rotation * Quaternion.Euler(0, 0, 0));

        NetworkServer.Spawn(e);
    }

    [Command]
    void CmdFire4()
    {
        foreach (Transform child in firegroup2.transform)
        {
            //Quaternion childRotation =  child.transform.rotation
            var a = Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180 + (angle2 * 2)));
            var b = Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180 + angle2));
            var c = Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180 + (angle2 * -1)));
            var d = Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180 + (angle2 * -2)));

            NetworkServer.Spawn(a);
            NetworkServer.Spawn(b);
            NetworkServer.Spawn(c);
            NetworkServer.Spawn(d);
        }
    }

    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "MobileBullet")
        {
			TakeDamage (colider);
        }
    }

	void TakeDamage(Collider2D colider)
	{
		if (!isServer)
		{
			return;
		}

		hp -= 1;
		Destroy(colider.gameObject);
		if (hp == 0)
		{
			Destroy(this.gameObject);
		}
	}

	void OnChangeHealth(int currentHealth)
	{
		healthBar.value = currentHealth;
	}
}
