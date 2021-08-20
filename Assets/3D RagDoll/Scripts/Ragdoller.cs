using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RagDollGame
{
    public class Ragdoller : MonoBehaviour
    {
        // When the scene Starts it will disable the ragdoll.
        private void OnEnable()
        {
            DisableRagdoll();
        }

        // 
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnableRagdoll();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DisableRagdoll();
            }
        }

        void DisableRagdoll()
        {
            // 'var' takes the left hand side and makes the variable = that.
            // You need to ensure it = a variable.
            // This is the same as:
            // Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
            var bodies = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody body in bodies)
            {
                body.isKinematic = true;
            }
            Animator anim = GetComponent<Animator>();
            anim.enabled = true;
        }

        void EnableRagdoll()
        {
            var bodies = GetComponentsInChildren<Rigidbody>();
            foreach (var body in bodies)
            {
                body.isKinematic = false;
            }
            var anim = GetComponent<Animator>();
            anim.enabled = false;
        }
    }
}