using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MasterIngredientList : MonoBehaviour
{
    public static MasterIngredientList Instance;

    protected void Awake()
    {
        Instance = this;
    }

    public List<Ingredient> baseIngredients = new List<Ingredient>();

    public List<Combination> combinations = new List<Combination>();

    public Ingredient failure;

    public Ingredient CombineIngredients(Ingredient ingredient, PrepMethod method)
    {
        var lIngredients = new List<Ingredient>() { ingredient };
        return CombineIngredients(lIngredients, method);
    }

    /// <summary>
    /// Combine ingredients and return the result
    /// </summary>
    /// <param name="foods"></param>
    /// <param name="method"></param>
    /// <returns></returns>
    public Ingredient CombineIngredients(List<Ingredient> foods, PrepMethod method)
    {
        Ingredient newIngredient;
        Combination former = new Combination(foods, method);
        Combination combo = combinations.FirstOrDefault(c => c.Equals(former));
        if(combo == null)
        {
            newIngredient = failure;
        }
        else
        {
            newIngredient = combo.product;
        }

        //Clear that list of ingredients
        //  but derpily keep them around for checks
        foreach(var food in foods)
        {
            food.ClearAll();
            food.transform.SetParent(transform);
        }

        newIngredient = GameObject.Instantiate(newIngredient);
        newIngredient.formingCombination = former;
        return newIngredient;
    }
}

[Serializable]
public class Combination
{
    public Combination(List<Ingredient> ingredients, PrepMethod method)
    {
        this.ingredients = ingredients;
        this.method = method;
    }

    public override bool Equals(object obj)
    {
        // If parameter is null return false.
        if (obj == null)
        {
            return false;
        }

        // If parameter cannot be cast return false.
        Combination c = obj as Combination;
        if ((System.Object)c == null)
        {
            return false;
        }

        //Do combination specific compares
        if (c.method != method)
        {
            return false;
        }

        //check both lists equals
        if (ingredients == null || c.ingredients == null || ingredients.Count != c.ingredients.Count)
        {
            return false;
        }
        for (int i = 0; i < ingredients.Count; i++)
        {
            bool foundOne = false;
            for (int j = 0; j < c.ingredients.Count; j++)
            {
                if (c.ingredients[j].Equals(ingredients[i]))
                {
                    foundOne = true;
                }
            }
            if (!foundOne)
            {
                return false;
            }
        }
        return true;
    }

    public List<Ingredient> ingredients = new List<Ingredient>();
    public PrepMethod method;

    public Ingredient product;
}

[Serializable]
public enum PrepMethod
{
    Boil, Chop , Fry
};