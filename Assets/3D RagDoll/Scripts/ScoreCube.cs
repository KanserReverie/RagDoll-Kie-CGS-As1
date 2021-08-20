using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace RagDollGame
{
    public class ScoreCube : MonoBehaviour
    {
        public RagdollScoring ragdollScoring;   // To be attached in Unity.
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                // Will give the player 2000 ponts then disapear.
                ragdollScoring.currentScore -= 1000;
                gameObject.SetActive(false);
            }
        }
    }
}