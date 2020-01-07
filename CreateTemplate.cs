using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class CreateTemplate : MonoBehaviour 
{
	public GameObject templatePrefab;
	public Transform templateSpawn;
	public GameObject endTemplatePrefab;
	public Transform endTemplateSpawn;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(Ball.moveTimer < 300)
		{
			if(other.gameObject.tag == "Ball")
			{
				GameObject templateInstance = Instantiate(templatePrefab, templateSpawn.position, Quaternion.identity/*templatePrefab.rotation*/) as GameObject;
				Debug.Log("Spawned One", templateInstance);
			}
		}
		if(Ball.moveTimer > 300)
		{
			if(other.gameObject.tag == "Ball")
			{
				GameObject endTemplateInstance = Instantiate(endTemplatePrefab, endTemplateSpawn.position, Quaternion.identity/*templatePrefab.rotation*/) as GameObject;
				Debug.Log("Spawned One", endTemplateInstance);
			}
		}
	}
}
