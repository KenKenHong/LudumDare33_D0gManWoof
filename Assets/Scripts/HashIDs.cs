using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

	public int caughtBool;
	public int sneakingBool;
	//public int playerInSightBool;


	// Use this for initialization
	void Start () 
	{
		caughtBool = Animator.StringToHash("Base Layer.Caught");
		sneakingBool = Animator.StringToHash("Base Layer.Sneak");

	}

}
