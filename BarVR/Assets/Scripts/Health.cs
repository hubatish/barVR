using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public float deathSpeed = 1f;

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
        }

        healthBar.fillAmount = curHealth / maxHealth;
    }

    public void Lose()
    {
        //TODO: Do cool stuff here
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
