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

    public List<Ingredient> ingredients = new List<Ingredient>();

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
        Combination combo = combinations.FirstOrDefault(c => c.Equals(new Combination(foods, method)));
        if(combo == null)
        {
            return failure;
        }
        return combo.product;
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

        //both lists have same values
        var onlyMine = ingredients.Except(c.ingredients);
        var onlyTheirs = c.ingredients.Except(ingredients);
        return (onlyMine.Count()==onlyTheirs.Count() && onlyMine.Count()==0);
    }

    public List<Ingredient> ingredients = new List<Ingredient>();
    public PrepMethod method;

    public Ingredient product;
}

[Serializable]
public enum PrepMethod
{
    Boil, Chop, Fry
};