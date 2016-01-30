using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UITimer : MonoBehaviour {

    public Image image;

    public Action done;

    public float maxTime = 2f;
    private float curTime;

    protected void Awake()
    {
        gameObject.SetActive(false);
    }

    public void StartTimer()
    {
        StartTimer(maxTime);
    }

    public void StartTimer(float time)
    {
        maxTime = time;
        curTime = maxTime;

        gameObject.SetActive(true);
    }	

	// Update is called once per frame
	void Update () {
        curTime -= Time.deltaTime;
        image.fillAmount = curTime / maxTime;

        if (curTime <= 0)
        {
            done();
            gameObject.SetActive(false);
        }
	}
}
