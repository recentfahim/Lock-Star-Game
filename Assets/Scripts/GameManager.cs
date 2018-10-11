using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool gameHasEnded = false;
    public float restartdelay = 5f;
    public GameObject gameoverui;
    private IEnumerator coroutine;


    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            StartCoroutine(Reset());
            
        }
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);

        gameHasEnded = true;
        Debug.Log(Time.time);
        Debug.Log("End Game");
        FindObjectOfType<CircleControl>().speed = 0;
        gameoverui.SetActive(true);
    }
}
