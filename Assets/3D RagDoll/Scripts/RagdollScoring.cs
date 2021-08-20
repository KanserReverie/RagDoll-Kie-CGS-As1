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
        currentScore = 10000f;
        gameRunning = false;
        currentScoreText.text = ("Score: " + currentScore.ToString("N0"));
        gameTimerText.text = ("Timer: " + gameTimer.ToString("N2"));
    }

    private void Update()
    {
        if(gameRunning)
        {
            gameTimer += Time.deltaTime;
            quaternionTime += Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 100, 0), quaternionTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 100, 0), Time.deltaTime);
            currentScoreText.text = ("Score: " + currentScore.ToString("N0"));
            gameTimerText.text = ("Timer: " + gameTimer.ToString("N2"));
        }
    }

    private void FixedUpdate()
    {
        if(gameRunning)
        {
            currentScore -= ScoreRagdoll()*0.001f;
        }

        if(currentScore <= 0)
        {
            currentScoreText.text = ("Score: " + currentScore.ToString("N0"));
            Time.timeScale = 0.8f;
            gameRunning = false;
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
