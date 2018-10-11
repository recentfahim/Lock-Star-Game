using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleControl : MonoBehaviour {
	[SerializeField]
	public float speed;
    public GameObject prefab;
    public GameObject colprefab;
    private bool flag;
	public float radius;
    private int rand;
    private int colrand;
    private int randdis;
    private int prevrand;
    [SerializeField]
    private AudioSource audios;

    Vector3 center;
	// Use this for initialization
	void Awake () {
        //Rotation while start
		transform.Rotate(0, 0, speed * Time.deltaTime);
        //putting value while start
        randdis = 0;
        prevrand = 0;
        audios = GetComponent<AudioSource>();

    }

    void Start()
    {
        //take random value to move any direction
        int bools = Random.Range(0, 2);
        if (bools == 1)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
        center = transform.position;
        rand = Random.Range(1, 360);
 
        Vector3 pos = RandomCircle(center, radius, rand);
        Instantiate(prefab, pos, Quaternion.identity);
        if (flag)
        {
            int colllrand = rand - 10;
            Vector3 colllpos = RandomCircle(center, radius, colllrand);
            Instantiate(colprefab, colllpos, Quaternion.identity);
        }
        else
        {
            
            int colllrand = rand + 10;
            Vector3 colllpos = RandomCircle(center, radius, colllrand);
            Instantiate(colprefab, colllpos, Quaternion.identity);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<GameManager>().gameHasEnded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                if (GameObject.FindGameObjectWithTag("star"))
                {
                    Destroy(GameObject.FindGameObjectWithTag("star"));
                }
                if (GameObject.FindGameObjectWithTag("coll"))
                {
                    Destroy(GameObject.FindGameObjectWithTag("coll"));
                }

                if (flag == true)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
                rand = Random.Range(1, 360);

                randdis = Mathf.Abs(rand - prevrand);
                if (randdis > 40)
                {
                    Debug.Log("Ok");
                }
                else
                {
                    for (int i = 0; i < 20; i++)
                    {
                        rand = Random.Range(1, 360);

                        randdis = Mathf.Abs(rand - prevrand);
                        if (randdis > 40)
                        {
                            break;
                        }
                        else
                        {
                            prevrand = rand;
                        }

                    }

                }
                Vector3 pos = RandomCircle(center, radius, rand);

                Instantiate(prefab, pos, Quaternion.identity);
                if (flag)
                {
                    colrand = rand - 10;
                    Vector3 colpos = RandomCircle(center, radius, colrand);
                    Instantiate(colprefab, colpos, Quaternion.identity);
                }
                else
                {
                    colrand = rand + 10;
                    Vector3 colpos = RandomCircle(center, radius, colrand);
                    Instantiate(colprefab, colpos, Quaternion.identity);
                }
                audios.Play();

            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("star"))
            {
                Destroy(GameObject.FindGameObjectWithTag("star"));
            }
            if (GameObject.FindGameObjectWithTag("coll"))
            {
                Destroy(GameObject.FindGameObjectWithTag("coll"));
            }
        }

        if (flag)
            {
                transform.Rotate(0, 0, speed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(0, 0, -speed * Time.deltaTime);

            }


    }

	Vector3 RandomCircle(Vector3 center, float radius,int a)
    {
        //Debug.Log(a);
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }


	
}
