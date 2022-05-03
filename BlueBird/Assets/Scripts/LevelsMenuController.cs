using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenuController : MonoBehaviour
{
    public void LoadLevel(LevelButton level)
    {
        SceneManager.LoadScene(level.LvNumber);
    }
}
