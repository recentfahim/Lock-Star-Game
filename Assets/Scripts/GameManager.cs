using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameHasEnded = false;
    public float restartdelay = 5f;
    public GameObject gameoverui;


    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            StartCoroutine(Waitforsec());
            
            
        }
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator Waitforsec()
    {
        gameHasEnded = true;
        Debug.Log("End Game");
        FindObjectOfType<CircleControl>().speed = 0;
        yield return new WaitForSeconds(1);

        gameoverui.SetActive(true);
        UnityAdManager.instance.ShowAd();
    }

}
