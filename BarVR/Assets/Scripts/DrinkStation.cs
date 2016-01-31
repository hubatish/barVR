using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Try to win with those ingredients
/// </summary>
public class DrinkStation : BaseStation
{
    //Just try the first one
    public override void UseIngredients()
    {
        base.UseIngredients();
        Goal.Instance.TryCombo(curIngredients[0]);
        //Debug.Log("drinking: " + curIngredients[0].ToString());
        ClearIngredients();
    }
}
