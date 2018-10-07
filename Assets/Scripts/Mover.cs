using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private bool check;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (check)
            {
                Debug.Log("Right");
                check = false;
            }
            else
            {
                //Debug.Log("Wrong");
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "star")
        {
            //Debug.Log("trigger");
            ScoreText.score += 1;
            check = true;
        }
        if(col.gameObject.tag == "coll")
        {
            FindObjectOfType<GameManager>().EndGame();
            //Debug.Log("Game Over");
            Destroy(this.gameObject);

        }
    }

}
