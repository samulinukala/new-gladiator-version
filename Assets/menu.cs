using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Canvas options;
    public void moveToLevel(int _targetLevel)
    {
        SceneManager.LoadScene(_targetLevel);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void openOptions()
    {
        options.enabled = true;
    }
    public void closeOptions()
    {
        options.enabled = false;
    }
}
