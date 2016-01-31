using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    [SerializeField]
    public Recipe recipe;

    public static Goal Instance;

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
            Health.Instance.LoseHealth(healAmount/2f);
        }
    }

}
