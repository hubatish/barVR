using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using System.Linq;

public class CameraEffects : ZBehaviour {

    public Shader sepiaTone;

    public float effectTime = 20f;

	// Use this for initialization
	void Start () {
        Cached<Effects>().effects.Add(delegate()
        {
            var effect = Camera.main.gameObject.AddComponent<SepiaTone>();
            effect.shader = sepiaTone;
        });
        Cached<Effects>().effects.Add(delegate ()
        {
            var effect = Camera.main.gameObject.GetComponent<NoiseAndScratches>();
            effect.enabled = true;
        });
        //Cached<Effects>().effects.Last()();
	}
}
