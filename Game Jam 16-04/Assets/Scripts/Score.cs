﻿// using, etc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//--------------------------------------------------------------------------------------
// Score object. Inheriting from MonoBehaviour. Handles the score of the game.
//--------------------------------------------------------------------------------------
public class Score : MonoBehaviour
{
    // public float for the score
    public static float m_fScore;

    // public float for what to increase the score by
    public float m_fScoreIncrease;

    // public float for what to increase the speed by
    public float m_fSpeedIncrease;

    // public text object value.
    public Text m_tTextScore;

    //--------------------------------------------------------------------------------------
    // initialization.
    //--------------------------------------------------------------------------------------
    void Awake()
    {
        // set default value
        m_fScore = 0.0f;
	}

    //--------------------------------------------------------------------------------------
    // Update: Function that calls each frame to update game objects.
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // if not game over
        if (!ConveyorBelt.m_sbGameEnd)
        {
            // increase score
            m_fScore += m_fScoreIncrease * Time.deltaTime;

            // every 50 points if not 0
            if (m_fScore!= 0 && (int)m_fScore % 50 == 0)
            {
                // increase speed
                ConveyorBelt.m_sfStaticSpeed += m_fSpeedIncrease;
            }
        }

        // convert the float score to int
        int nTmpScore = Mathf.FloorToInt(m_fScore);

        // Apply the score to the text object
        m_tTextScore.text = string.Format("{0}", nTmpScore);
    }
}