using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PreparationStation : BaseStation
{
    //Animator anim;
    // int boilhash = Animator.StringToHash("shake");
    public GameObject boiling;
    public Ingredient product;

    public PrepMethod method;
    public UITimer timer;

    protected void Start()
    {
        // anim = GetComponent<Animator>();
        boiling = GameObject.Find("HolyFireStrike");
        boiling.SetActive(false);
        timer.done = FinishPrep;
    }

    public override void UseIngredients()
    {
        //They clicked while have ingredients in Station
        boiling.SetActive(true);
        timer.StartTimer();
    }

    public float prepTime = 2f;

    public void FinishPrep()
    {
        Debug.Log("Done prepping!");
        // anim.SetTrigger(boilhash);

        product = MasterIngredientList.Instance.CombineIngredients(curIngredients, method);
        product.transform.position = ingredientSpots[0].position;

        ClearIngredients();
        boiling.SetActive(false);
    }
}
