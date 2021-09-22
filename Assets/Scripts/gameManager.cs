using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public int kills;
    public int highScore;
    public int numberOfPlayers=1;
    bool isPaused=false;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");    
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&isPaused==false)
        {
            pauseGame();
            GameObject.FindGameObjectWithTag("pauseMenu").GetComponent<Canvas>().enabled=true;
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.SetActive(true);
            isPaused = true;
        }else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            resumeGame();
            isPaused = false;
        }
    }


    public void saveScore(int _scoreToBeCompared)
    {
        if(_scoreToBeCompared>highScore)
        {
            highScore = _scoreToBeCompared;
            PlayerPrefs.SetInt("highScore", highScore);

        }

    }
    public void exitTheGame()
    {
      
        Application.Quit();
    }
    public void exitToMenu()
    {
        
        SceneManager.LoadScene(1);
    }
    public void pauseGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<specialShootAbility>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<attack>().enabled = false;
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("enemy"))
        {
            e.GetComponent<EnemyAI>().enabled=false;
        }
        foreach(GameObject s in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            s.GetComponent<Spawner>().enabled=false;
        }
        foreach (GameObject shot in GameObject.FindGameObjectsWithTag("Shot"))
        {
            shot.GetComponent<shot>().enabled = false;
        }
    }
    public void resumeGame()
    {
        GameObject.FindGameObjectWithTag("pauseMenu").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<specialShootAbility>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<attack>().enabled = true;
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("enemy"))
        {
            e.GetComponent<EnemyAI>().enabled = true;
        }
        foreach (GameObject s in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            s.GetComponent<Spawner>().enabled = true;
        }
        foreach (GameObject shot in GameObject.FindGameObjectsWithTag("Shot"))
        {
            shot.GetComponent<shot>().enabled = true;
        }
    }
    public void resetTheGame()
    {
  
        SceneManager.LoadScene(0);
    }
}
