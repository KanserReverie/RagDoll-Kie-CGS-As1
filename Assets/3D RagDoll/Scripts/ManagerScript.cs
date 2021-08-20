using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RagDollGame
{
    // This will just handle the other input key functions.
    public class ManagerScript : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Retry();
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                MainMenu();
            }

        }
        public void Retry()
        {
            Time.timeScale = 1; 
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
        
        public void MainMenu()
        {
            Time.timeScale = 1; 
            SceneManager.LoadScene(0);
        }
    }
}