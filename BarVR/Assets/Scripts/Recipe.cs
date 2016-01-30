using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Display how to make an ingredient
/// </summary>
public class Recipe : MonoBehaviour {

    public Text text;

    public Combination combination;

	// Use this for initialization
	void Start () {
        //SetCombination();
	}

    public void SetCombination()
    {
        combination = GetRandomCombination();
        string instructions = combination.method.ToString() + " ";
        for(int i=0;i<combination.ingredients.Count;i++)
        {
            instructions += combination.ingredients[i].ToString();
            if (i != combination.ingredients.Count - 1)
            {
                instructions += ", ";
            }
        }
        text.text = instructions;
    }

    protected Combination GetRandomCombination()
    {
        var combos = MasterIngredientList.Instance.combinations;
        var r = UnityEngine.Random.Range(0, combos.Count);
        return combos[r];
    }
}
