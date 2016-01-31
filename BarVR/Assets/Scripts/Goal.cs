using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Handle winnig & losing
/// </summary>
public class Goal : MonoBehaviour {

    [SerializeField]
    public Recipe recipe;

    public static Goal Instance;

    public Action onDrinkFail = delegate () { };

    protected void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        recipe.SetCombination();
	}

    public float healAmount = 20f;

    public void TryCombo(Ingredient final)
    {
        if (recipe.combination.product.Equals(final))
        {
            Debug.Log("winnig");
            recipe.SetCombination();
            Health.Instance.LoseHealth(-healAmount);
        }
        else
        {
            onDrinkFail();
            Health.Instance.LoseHealth(healAmount/2f);
        }
    }

}
