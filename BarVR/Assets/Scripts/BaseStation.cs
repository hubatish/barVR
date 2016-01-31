using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BaseStation : Selectable
{
    public AudioSource sound;

    public List<Ingredient> curIngredients;
    public List<Transform> ingredientSpots = new List<Transform>();

    public void AddIngredient(Ingredient ingredient)
    {
        if (curIngredients.Count >= ingredientSpots.Count)
        {
            PlayerHand.Instance.DropIngredient();
            return;
        }
        int numI = curIngredients.Count;
        ingredient.GetComponent<Collider>().enabled = false;

        PlayerHand.Instance.MoveTo(ingredient, ingredientSpots[numI],delegate()
        {
            //ingredient.transform.SetParent(ingredientSpots[numI]);
            ingredient.transform.position = ingredientSpots[numI].position;
            ingredient.GetComponent<Collider>().enabled = true;
            ingredient.GetComponent<Rigidbody>().isKinematic = true;
        });
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
            ingredient.GetComponent<Rigidbody>().isKinematic = false;
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
        if (sound != null)
        {
            sound.Play();
        }
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
