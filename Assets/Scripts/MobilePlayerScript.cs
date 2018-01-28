﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MobilePlayerScript : NetworkBehaviour {

	[SyncVar(hook="OnChangeHealth")]
    public int hp = 3;
    public int speed = 5;
    public GameObject bullet;
    public float firerate = 0.75f;
    private float time;
	public Slider healthBar;

	// Use this for initialization
	void Start ()
    {
        time = Time.time + firerate;
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

        int numberTouches = Input.touchCount;

        if (numberTouches > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 updatedPosition = Camera.main.ScreenToWorldPoint(touch.position);
            updatedPosition.z = 0;
            this.transform.position = updatedPosition;
        }

        if (time <= Time.time)
        {
            time = Time.time + firerate;
            CmdFire();
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
