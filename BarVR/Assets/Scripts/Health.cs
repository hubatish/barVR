﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Health drains over time
///     Lose at 0
/// </summary>
public class Health : MonoBehaviour {

    public static Health Instance;

	void Awake () {
        Instance = this;
        curHealth = maxHealth;
	}

    public Image healthBar;
    //TODO: make health blood effect around vision
    //public 

    public float maxHealth = 100;

    protected float curHealth;

    protected float deathSpeed = 3f;

    protected void FixedUpdate()
    {
        LoseHealth(deathSpeed*Time.deltaTime);
    }

    public void LoseHealth(float health)
    {
        curHealth -= health;

        if (curHealth <= 0)
        {
            Lose();
        } else if (curHealth >= maxHealth)
        {
            curHealth = maxHealth;
        }

        healthBar.fillAmount = curHealth / maxHealth;
    }

    public void Lose()
    {
        //TODO: Do cool stuff here
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
