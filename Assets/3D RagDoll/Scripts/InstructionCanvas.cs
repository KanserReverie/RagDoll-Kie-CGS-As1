using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RagDollGame
{
    public class InstructionCanvas : MonoBehaviour
    {
        public GameObject nextPanel;
        
        void Start()
        {
            Time.timeScale = 0;
            nextPanel.gameObject.SetActive(false);
        }

        void Update()
        {
            if(Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.Return))
            {
                StartGame();
            }
        }

        public void StartGame()
        {
            nextPanel.gameObject.SetActive(true);
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}