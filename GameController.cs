using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public static GameController Instance
	{
		get
		{
			if(instance == null) instance = new GameObject("GameController").
				AddComponent<GameController>(); //create game controller object if required
			return instance;
		}
	}

	//Internal reference to single active instance of object - for singleton behavior
	private static GameController instance = null;
	public static int playCount;

	void Awake()
	{
		//Check if there is an existing instance of this object 
		if((instance) && (instance.GetInstanceID() != GetInstanceID()))
			DestroyImmediate(gameObject); //Delete duplicate
		else
		{
			instance = this; //Make this object the only instance
			DontDestroyOnLoad(gameObject);//Set as do not destroy
		}
		playCount = 0;
	}
}
