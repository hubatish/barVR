using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    [SerializeField]
    public Recipe recipe;

    public static Goal Instance;

    protected void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        recipe.SetCombination();
	}
}
