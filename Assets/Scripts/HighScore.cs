using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public static int highscore;
    [SerializeField]
    private Text txthighscore;
    private string hscore = "keyshighscore";
    // Use this for initialization
    void Start () {
        txthighscore = GetComponent<Text>();
        highscore = PlayerPrefs.GetInt(hscore, 0);

    }
	
	// Update is called once per frame
	void Update () {
        txthighscore.text = highscore.ToString();
        if (ScoreText.score > highscore)
        {
            highscore = ScoreText.score;
            txthighscore.text = highscore.ToString();
            PlayerPrefs.SetInt(hscore, highscore);
            PlayerPrefs.Save();
        }
    }
}
