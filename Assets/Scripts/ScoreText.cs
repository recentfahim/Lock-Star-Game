using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    [SerializeField]
	public Text txtScore;
    public static int score;
	// Use this for initialization
	void Awake () {
		txtScore = GetComponent<Text>();

		score  = 0;
	}
	
	// Update is called once per frame
	void Update () {
		txtScore.text = score.ToString();
	}

}
