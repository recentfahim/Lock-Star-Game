using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private bool check;
    [SerializeField]
    private GameObject deatheffect;
    [SerializeField]
    private AudioSource audios;

    private void Start()
    {
        audios = GetComponent<AudioSource>();
    }

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
                audios.Play();
                Instantiate(deatheffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
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

            audios.Play();
            Instantiate(deatheffect,transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().EndGame();
            //Debug.Log("Game Over");
            Destroy(this.gameObject);

        }
    }

    

}
