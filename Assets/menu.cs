using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void moveToLevel(int _targetLevel)
    {
        SceneManager.LoadScene(_targetLevel);
    }
}
