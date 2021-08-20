using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RagdollScoring : MonoBehaviour
{
    private Joint[] joints;
        float quaternionTime;
    [SerializeField] private float minForceToAddScore = 1f;
    public bool gameRunning;

    public float currentScore;
    public Text currentScoreText;
    private float gameTimer;
    public Text gameTimerText;

    private void OnEnable()
    {
        joints = GetComponentsInChildren<Joint>();
    }

    private void Start()
    {
        quaternionTime = 0;
        gameTimer = 0;
        gameRunning = false;
    }

    private void Update()
    {
        if(gameRunning)
        {
            gameTimer += Time.deltaTime;
            quaternionTime += Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 100, 0), quaternionTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 100, 0), Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if(gameRunning)
        {
            currentScore -= ScoreRagdoll();
        }
    }

    float ScoreRagdoll()
    {
        float totalForce = 0;
        foreach (Joint joint in joints)
        {
            // If the force is too small dont add force.
            if (joint.currentForce.magnitude > minForceToAddScore)
            {
                totalForce += joint.currentForce.magnitude * 0.1f;
            }
        }

        
        return totalForce;
    }
}
