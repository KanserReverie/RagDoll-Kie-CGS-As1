using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RagDollGame
{
    public class StartTimer : MonoBehaviour
    {
        public RagdollScoring ragdollScorer;
        public RotateBox rotatingBox;
        
        // Start is called before the first frame update
        void Start()
        {
            ragdollScorer.gameRunning = false;
            rotatingBox.boxRotatable = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            rotatingBox.boxRotatable = true;
            ragdollScorer.gameRunning = true;
            gameObject.SetActive(false);
        }
    }
}