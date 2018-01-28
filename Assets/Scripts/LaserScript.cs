using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    private int frameCount;

	// Use this for initialization
	void Start ()
    {
        frameCount = 0;
        transform.localScale = new Vector3(0.3F, 1F, 1F);
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch(frameCount)
        {
            case 30:
                transform.localScale = new Vector3(0.15F, 1F, 1F);
                break;
            case 60:
                transform.localScale = new Vector3(0.3F, 1F, 1F);
                break;
            case 90:
                transform.localScale = new Vector3(0.15F, 1F, 1F);
                break;
            case 120:
                transform.localScale = new Vector3(1F, 1F, 1F);
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                break;
            case 240:
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
        frameCount += 1;
	}
}
