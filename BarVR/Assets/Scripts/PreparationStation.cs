using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PreparationStation : Selectable
{
    public Ingredient curIngredient;
    public Ingredient product;

    public PrepMethod method;

    public Transform ingredientSpot;

    public UITimer timer;

    protected void Start()
    {
        timer.done = FinishPrep;
    }

    public override void Select()
    {
        if (curIngredient == null)
        {
            curIngredient = PlayerHand.Instance.Release();
            if (curIngredient != null)
            {
                PlayerHand.Instance.MoveTo(curIngredient, ingredientSpot);
                timer.StartTimer();
            }
        }
    }

    public float prepTime = 2f;

    public void FinishPrep()
    {
        Debug.Log("Done prepping!");
        product = MasterIngredientList.Instance.CombineIngredients(curIngredient, method);
        product = (Ingredient)GameObject.Instantiate(product, ingredientSpot.position, Quaternion.identity);

        //Destroy ingredients
        GameObject.Destroy(curIngredient.gameObject);
        curIngredient = null;
    }
}
