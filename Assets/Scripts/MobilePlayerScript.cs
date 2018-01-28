using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerScript : MonoBehaviour {

    public int hp = 3;
    public int speed = 5;
    public GameObject bullet;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, 0);
        transform.Translate(0, y, 0);

        if(Input.GetKeyDown("space"))
        {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
        }
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
