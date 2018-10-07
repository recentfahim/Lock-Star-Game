using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "star")
        {
            Debug.Log("fahim-trigger");
            ScoreText.score += 1;
        }
        if(col.gameObject.tag == "coll")
        {
            Debug.Log("Game Should Over........");
            Destroy(this.gameObject);

        }
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "star")
		{
			Debug.Log("fahim - collision2d");
		}
	}
}
