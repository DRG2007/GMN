using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GMN.Local
{
    public class LocalGameManager : MonoBehaviour
    {
        private bool isGamePaused;

        public GameObject pauseMenu;

        public void PauseGame()
        {
            isGamePaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        public void UnpauseGame()
        {
            isGamePaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }

        public void GoBackToMenu()
        {
            SceneManager.LoadScene("Start");
        }

        public void QuitGame()
        {
            #if UNITY_EDITOR
            
            UnityEditor.EditorApplication.isPlaying = false;

            #elif UNITY_STANDALONE
            
            Application.Quit()

            #endif
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(!isGamePaused)
                {
                    PauseGame();
                } else {
                    UnpauseGame();
                }
            }
        }

        void Start()
        {
            Time.timeScale = 1;
        }
    }   
}

