using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayerScript : MonoBehaviour {

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
            foreach(Transform child in firegroup1.transform)
            {
                //Quaternion childRotation =  child.transform.rotation
                Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180));
                Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180 + angle));
                Instantiate(bullet, child.transform.position, child.transform.rotation * Quaternion.Euler(0, 0, 180 + (angle * -1)));
            }
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
