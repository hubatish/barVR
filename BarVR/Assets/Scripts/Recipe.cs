using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

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

        //actual ingredient doesn't matter
        var newIngredient = MasterIngredientList.Instance.baseIngredients[0];
        newIngredient = (Ingredient)GameObject.Instantiate(newIngredient);
        newIngredient.transform.SetParent(transform);
        newIngredient.gameObject.SetActive(false);
        newIngredient.formingCombination = combination;
        combination.product = newIngredient;

        //Populate recipe text
        PopulateRecipe(combination);
    }

    public void PopulateRecipe(Combination combination)
    {
        string instructions = combination.method.ToString() + " ";
        for (int i = 0; i < combination.ingredients.Count; i++)
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
        /*var combos = MasterIngredientList.Instance.combinations;
        var r = UnityEngine.Random.Range(0, combos.Count);
        return combos[r];*/
                int numI = UnityEngine.Random.Range(1, 3);
                var bases = MasterIngredientList.Instance.baseIngredients;
                bases = RandomArrayTool.Randomize<Ingredient>(bases.ToArray()).ToList();
                var ingredients = bases.Take(numI).ToList();
                Combination combo = new Combination(ingredients, (PrepMethod) UnityEngine.Random.Range(0, 2));
                return combo;
    }
}
