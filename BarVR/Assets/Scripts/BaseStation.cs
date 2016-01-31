using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BaseStation : Selectable
{
    public List<Ingredient> curIngredients;
    public List<Transform> ingredientSpots = new List<Transform>();

    public void AddIngredient(Ingredient ingredient)
    {
        if (curIngredients.Count >= ingredientSpots.Count)
        {
            PlayerHand.Instance.DropIngredient();
            return;
        }
        PlayerHand.Instance.MoveTo(ingredient, ingredientSpots[curIngredients.Count]);
        curIngredients.Add(ingredient);
        ingredient.onSelect += delegate ()
        {
            RemoveIngredient(ingredient);
        };
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        if (curIngredients.Contains(ingredient))
        {
            curIngredients.Remove(ingredient);
            ingredient.onSelect = delegate () { };
        }
    }

    public override void Select()
    {
        var ingredient = PlayerHand.Instance.Release();
        if (ingredient != null)
        {
            AddIngredient(ingredient);
        }
        else if(curIngredients.Count>0)
        {
            UseIngredients();
        }
    }

    public virtual void UseIngredients()
    {
        //They clicked while have ingredients in Station
    }

    protected void ClearIngredients()
    {
        //Destroy ingredients
        for (int i = curIngredients.Count - 1; i >= 0; i--)
        {
            curIngredients[i].ClearAll();
            //GameObject.Destroy(curIngredients[i].gameObject);
        }
        curIngredients = new List<Ingredient>();
    }
}
