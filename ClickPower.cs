using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickPower : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public static bool mouseDown;
	public static float power = 0;
	public float powermax = 45.0f;
	public float powermin = 1.0f;
	public float timeToMove = 1.5f;
	public Slider slider;
	private float lerpAmt = 0.0f;

	public Transform club;
	public GameObject swing;
	//Original positions to rotate back to 
	public float originalX;
	public float originalZ;
	public float originalY;
	public float currentX;
	public float currentY;
	public float currentZ;

	void Start()
	{
		originalX = club.localEulerAngles.x;
		originalZ = club.localEulerAngles.z;
		originalY = club.localEulerAngles.y;
	}

	void Update()
	{
		if(mouseDown && Ball.isMoving == false)
		{
			lerpAmt += Time.deltaTime / timeToMove;
			slider.value = lerpAmt;
			/*club.RotateAround(swing.transform.position, swing.transform.up, 100*Time.deltaTime);
			Vector3 currentRotation = club.localRotation.eulerAngles;
			club.localRotation = Quaternion.Euler(currentRotation);*/
		}
	}

	public void OnPointerDown(PointerEventData pointerEventData)
	{
		mouseDown = true;
	}

	public void OnPointerUp(PointerEventData pointerEventData)
	{
		mouseDown = false;
		//club.eulerAngles = new Vector3(0, currentY, originalZ * Time.deltaTime);
		power = Mathf.Lerp(powermin, powermax, lerpAmt)*50;
		lerpAmt = 0;
		slider.value = 0;
	}
}
