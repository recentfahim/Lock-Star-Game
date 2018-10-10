using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private bool check;
    [SerializeField]
    private GameObject deatheffect;

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
            destroyHoldEffect(deatheffect);
            FindObjectOfType<GameManager>().EndGame();
            //Debug.Log("Game Over");
            Destroy(this.gameObject);

        }
    }

    IEnumerator destroyHoldEffect(GameObject particles)
    {
        while (particles.GetComponent<ParticleSystem>().time > 0.5f)
        {
            yield return null;
        }

        particles.GetComponent<ParticleSystem>().loop = false;

        yield return new WaitForSeconds(2f);
        if (particles)
        {
            Destroy(particles);
        }
    }

}
