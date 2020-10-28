using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
        {
            public void Initialize()
            {
                InitializeButtons();
            }
        
            private void InitializeButtons()
            {
                GameObject.Find("Start").GetComponent<Button>().onClick.AddListener(startButton);
                GameObject.Find("Quit").GetComponent<Button>().onClick.AddListener(quitButton);
            }

            private void startButton()
            {
                SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

            private void quitButton()
            {
                QuitGame();
        }
        public void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

    }