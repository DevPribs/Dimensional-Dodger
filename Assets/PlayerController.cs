using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	public int speed;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Translate(x, 0, 0);
		transform.Translate(0, y, 0);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<SpriteRenderer>().material.color = Color.blue;
	}

	void Fire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}
}
