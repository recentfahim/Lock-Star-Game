using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour {

    public static UnityAdManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowAd()
    {
        if (PlayerPrefs.HasKey("Addcount"))
        {
            if (PlayerPrefs.GetInt("Addcount") == 3)
            {
                if (Advertisement.IsReady("video"))
                {
                    Advertisement.Show("video");
                }
                PlayerPrefs.SetInt("Addcount", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Addcount", PlayerPrefs.GetInt("Addcount") +1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Addcount", 0);
        }
    }
}
