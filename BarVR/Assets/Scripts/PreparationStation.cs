﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PreparationStation : BaseStation
{
    public Ingredient product;

    public PrepMethod method;
    public UITimer timer;

    protected void Start()
    {
        timer.done = FinishPrep;
    }

    public override void UseIngredients()
    {
        //They clicked while have ingredients in Station
        timer.StartTimer();
    }

    public float prepTime = 2f;

    public void FinishPrep()
    {
        Debug.Log("Done prepping!");
        product = MasterIngredientList.Instance.CombineIngredients(curIngredients, method);
        product.transform.position = ingredientSpots[0].position;

        ClearIngredients();
    }
}
