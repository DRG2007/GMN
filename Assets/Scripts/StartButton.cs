using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GMN.Global;
using static GMN.Global.GameState;
public class StartButton : MonoBehaviour
{

    public void PlayGame()
    {
        if(PlayerPrefs.GetInt(HasCompletedTutorialString, 0) == 0)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }

}
