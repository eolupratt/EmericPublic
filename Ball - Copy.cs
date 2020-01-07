using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour 
{
	public GameObject putter;
	public Rigidbody rb;
	public static bool isMoving;
	public static bool puttMade;
	public static int puttCount;
	public bool stop;
	public bool inRough;
	public bool inSand;
	public float roughSpeed = 12.5f;
	public float sandSpeed = 1.5f;
	public float resetBallTime;
	public Transform target;
	public GameObject startpoint;
	public Vector3 newPos;
	public float ResetDelay = 1.0f;
	public static int points;
	public static bool pointsEnabled = true;
	public static int score;
	public Text pointsText;
	public Text scoreText;
	public int txtScore;
	public int txtPoints;
	public int c;

	public static int holePar;
	public static int puttCount1;
	public static int puttCount2;
	public static int puttCount3;
	public static int puttCount4;
	public static int puttCount5;
	public static int puttCount6;
	public static int puttCount7;
	public static int puttCount8;
	public static int puttCount9;
	public static int puttCount10;
	public static int puttCount11;
	public static int puttCount12;
	public static int puttCount13;
	public static int puttCount14;
	public static int puttCount15;
	public static int puttCount16;
	public static int puttCount17;
	public static int puttCount18;
	
	public static int puttCount20;
	public static int puttCount21;
	public static int puttCount22;
	public static int puttCount23;
	public static int puttCount24;
	public static int puttCount25;
	public static int puttCount26;
	public static int puttCount27;
	public static int puttCount28;
	public static int puttCount29;
	public static int puttCount30;
	public static int puttCount31;

	//private bool hasStarted = false;
	public static bool hasStarted = false;
	private bool resetBallEnabled = false;
	private Vector3 putterToBallVector;
	private Vector3 lastPosition;
	private Transform myTransform;
	private IEnumerator resetBall;

	public Camera MainCamera;
	public Camera ShotCamera;
	public Camera OverheadCamera;
	Renderer m_renderer;

	public AudioClip putt;
	public AudioClip made;
	public AudioClip clap;
	public AudioClip ahh;
	public AudioClip coin;
	public AudioClip leaves;
	public AudioSource mySource;
	public float myVolume = 1.0f;

	private Quaternion targetRotation;

	private float originalX;
	private float originalY;
	private float originalZ;

	// Use this for initialization
	void Start () 
	{
		rb.velocity = transform.forward * 0;
		/*Putt();
		RotateLeft();
		RotateRight();
		SetPointsText();
		PuttCount();*/
		myTransform = transform;
		lastPosition = myTransform.position;
		isMoving = false;
		stop = false;
		resetBallEnabled = false;
		resetBallTime = 0.0f;
		puttMade = false;
		inSand = false;
		inRough = false;
		puttCount = 0;
		points = 0;
		txtPoints = 0;
		pointsText.text = "POINTS: 0";
		newPos = startpoint.transform.position;
		rb.velocity = transform.forward * 0;
		c = SceneManager.GetActiveScene().buildIndex;
		hasStarted = true;
		MainCamera.enabled = true;
		ShotCamera.enabled = false;
		putter.GetComponent<Renderer>().enabled = true;
		//rotation
		targetRotation = transform.rotation;
		originalX = transform.localEulerAngles.x;
		originalY = transform.localEulerAngles.y;
		originalZ = transform.localEulerAngles.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(puttMade == true)
		{
			putter.GetComponent<Renderer>().enabled = false;
		}

		if(myTransform.position != lastPosition && rb.velocity.magnitude > .035f)//(myTransform.position != lastPosition)
		{
			isMoving = true;	//the ball is moving
			rb.constraints = RigidbodyConstraints.None;
			resetBallTime = 0.25f;	//set the amount of time the ball has to rotate to face the hole
			resetBallEnabled = false;	//the ball is not allowed to reset
			putter.GetComponent<Renderer>().enabled = false;  //Putter and canvas renderers enabled is false
			if(rb.velocity.magnitude <= .035f)
			{
				rb.velocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;
				isMoving = false;	//stop the ball
			}
		}
		else//if(myTransform.position == lastPosition)
		{
			isMoving = false;	//the ball is stoped
			rb.constraints = RigidbodyConstraints.FreezeRotation;
			resetBallEnabled = true;	//the ball is able to be rest
			resetBallTime -= Time.deltaTime;	//count down for the amount of time the ball can reset
			//Putter and canvas renderers enabled is true
			if(puttMade == false)
			{
				putter.GetComponent<Renderer>().enabled = true;
			}
			if(puttCount > 0 && resetBallTime > 0 && resetBallEnabled == true)
			{
				transform.LookAt(target);	//rotate the ball to look at the hole
			}
			resetBallEnabled = false;	//the ball is not allowed to reset
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			
			if(puttCount >= 7)
			{
				if (c < SceneManager.sceneCountInBuildSettings)
				{
					CameraFade.StartAlphaFade( Color.black, false, 2f, 2f, () => { SceneManager.LoadScene(c+1); } );
				}
			}
		}
		if(inRough == true)
		{
			rb.drag = 1.5f;
		}
		else if(inSand == true)
		{
			rb.drag = 4.5f;
		}
		else
		{
			rb.drag = 0.1f;
		}
		/*if(isMoving == true && hasStarted == true)
		{
			if(rb.velocity.magnitude <= minSpeed)
			{
				rb.velocity = transform.forward * 0;
				isMoving = false;
			}
		}*/
		lastPosition = myTransform.position;
		//print(rb.velocity.magnitude.ToString());

	}

	void PuttCount()
	{
		Scene sceneCheck = SceneManager.GetActiveScene();
		if(sceneCheck.name == "Scene6")
		{
			puttCount1 = puttCount;
			holePar = 3;
		}
		if(sceneCheck.name == "Scene9")
		{
			puttCount2 = puttCount;
			holePar = 3;
		}
		if(sceneCheck.name == "Scene12")
		{
			puttCount3 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene15")
		{
			puttCount4 = puttCount;
			holePar = 3;
		}
		if(sceneCheck.name == "Scene18")
		{
			puttCount5 = puttCount;
			holePar = 5;
		}
		if(sceneCheck.name == "Scene21")
		{
			puttCount6 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene24")
		{
			puttCount7 = puttCount;
			holePar = 3;
		}
		if(sceneCheck.name == "Scene27")
		{
			puttCount8 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene30")
		{
			puttCount9 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene34")
		{
			puttCount10 = puttCount;
			holePar = 3;
		}
		if(sceneCheck.name == "Scene37")
		{
			puttCount11 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene40")
		{
			puttCount12 = puttCount;
			holePar = 3;
		}
		if(sceneCheck.name == "Scene43")
		{
			puttCount13 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene46")
		{
			puttCount14 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene49")
		{
			puttCount15 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene52")
		{
			puttCount16 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene55")
		{
			puttCount17 = puttCount;
			holePar = 5;
		}
		if(sceneCheck.name == "Scene58")
		{
			puttCount18 = puttCount;
			holePar = 5;
		}
		if(sceneCheck.name == "Scene62")
		{
			puttCount20 = puttCount;
			holePar = 3;
		}
		if(sceneCheck.name == "Scene65")
		{
			puttCount21 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene68")
		{
			puttCount22 = puttCount;
			holePar = 5;
		}
		if(sceneCheck.name == "Scene71")
		{
			puttCount23 = puttCount;
			holePar = 3;
		}
		if(sceneCheck.name == "Scene74")
		{
			puttCount24 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene77")
		{
			puttCount25 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene80")
		{
			puttCount26 = puttCount;
			holePar = 5;
		}
		if(sceneCheck.name == "Scene83")
		{
			puttCount27 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene86")
		{
			puttCount28 = puttCount;
			holePar = 3;
		}
		if(sceneCheck.name == "Scene89")
		{
			puttCount29 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene92")
		{
			puttCount30 = puttCount;
			holePar = 4;
		}
		if(sceneCheck.name == "Scene95")
		{
			puttCount31 = puttCount;
			holePar = 3;
		}
    }

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "HoleTrigger" & puttCount == 1)
		{
			//Hole in 1
			puttMade = true;
			if(holePar == 3)
			{
				points += 1000;
				SetPointsText();
			}
			if(holePar == 4)
			{
				points += 2500;
				SetPointsText();
			}
			if(holePar == 5)
			{
				points += 5000;
				SetPointsText();
			}
			GameController.totalPoints += points;
			score += 1;
			mySource.PlayOneShot( made, myVolume );
			mySource.PlayOneShot( clap, 2.0f );
			putter.GetComponent<Renderer>().enabled = false;
			SwitchCam();
		}
		else if(other.gameObject.tag == "HoleTrigger" & puttCount == 2)
		{
			puttMade = true;
			if(holePar == 3)//Birdie
			{
				points += 500;
				SetPointsText();
			}
			if(holePar == 4)//Eagle
			{
				points += 1000;
				SetPointsText();
			}
			if(holePar == 5)//2 X Eagle
			{
				points += 2500;
				SetPointsText();
			}
			GameController.totalPoints += points;
			score += 2;
			mySource.PlayOneShot( made, myVolume );
			mySource.PlayOneShot( clap, 2.0f );
			putter.GetComponent<Renderer>().enabled = false;
			SwitchCam();
		}
		else if(other.gameObject.tag == "HoleTrigger" & puttCount == 3)
		{
			puttMade = true;
			if(holePar == 3)//Par
			{
				points += 250;
				SetPointsText();
			}
			if(holePar == 4)//Birdie
			{
				points += 500;
				SetPointsText();
			}
			if(holePar == 5)//Eagle
			{
				points += 1000;
				SetPointsText();
			}
			GameController.totalPoints += points;
			score += 3;
			mySource.PlayOneShot( made, myVolume );
			mySource.PlayOneShot( clap, 2.0f );
			putter.GetComponent<Renderer>().enabled = false;
			SwitchCam();
		}
		else if(other.gameObject.tag == "HoleTrigger" & puttCount == 4)
		{
			puttMade = true;
			if(holePar == 3)//Bogey
			{
				points -= 1000;
				SetPointsText();
				mySource.PlayOneShot( made, myVolume );
				mySource.PlayOneShot( ahh, myVolume );
			}
			if(holePar == 4)//Par
			{
				points += 250;
				SetPointsText();
				mySource.PlayOneShot( made, myVolume );
				mySource.PlayOneShot( clap, 2.0f );
			}
			if(holePar == 5)//Birdie
			{
				points += 500;
				SetPointsText();
				mySource.PlayOneShot( made, myVolume );
				mySource.PlayOneShot( clap, 2.0f );
			}
			score += 4;
			putter.GetComponent<Renderer>().enabled = false;
			SwitchCam();
		}
		else if(other.gameObject.tag == "HoleTrigger" & puttCount == 5)
		{
			puttMade = true;
			if(holePar == 3)//2 X Bogey
			{
				points -= 2500;
				SetPointsText();
				mySource.PlayOneShot( made, myVolume );
				mySource.PlayOneShot( ahh, myVolume );
			}
			if(holePar == 4)//Bogey
			{
				points -= 1000;
				SetPointsText();
				mySource.PlayOneShot( made, myVolume );
				mySource.PlayOneShot( ahh, myVolume );
			}
			if(holePar == 5)//Par
			{
				points += 250;
				SetPointsText();
				mySource.PlayOneShot( made, myVolume );
				mySource.PlayOneShot( clap, 2.0f );
			}
			GameController.totalPoints += points;
			score += 5;
			putter.GetComponent<Renderer>().enabled = false;
			SwitchCam();
		}
		else if(other.gameObject.tag == "HoleTrigger" & puttCount >= 6)
		{
			puttMade = true;
			if(holePar == 3)//3 X Bogey
			{
				points -= 5000;
				SetPointsText();
				mySource.PlayOneShot( made, myVolume );
				mySource.PlayOneShot( ahh, myVolume );
			}
			if(holePar == 4)//2 X Bogey
			{
				points -= 2500;
				SetPointsText();
				mySource.PlayOneShot( made, myVolume );
				mySource.PlayOneShot( ahh, myVolume );
			}
			if(holePar == 5)//Bogey
			{
				points -= 1000;
				SetPointsText();
				mySource.PlayOneShot( made, myVolume );
				mySource.PlayOneShot( ahh, myVolume );
			}
			GameController.totalPoints += points;
			score += 6;
			putter.GetComponent<Renderer>().enabled = false;
			SwitchCam();
		}
		else if(other.gameObject.tag == "Bush")
		{
			mySource.PlayOneShot( leaves, myVolume );
			rb.velocity -= transform.forward * .01f;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "50" || collision.gameObject.tag == "100" || 
		 collision.gameObject.tag == "250" || collision.gameObject.tag == "500" ||
		 collision.gameObject.tag == "1000")
		{
			//mySource.PlayOneShot( coin, myVolume );
			//points += 50;
			SetPointsText();
			//GameController.totalPoints += 50;
			rb.velocity += transform.forward * 5.0f;
		}
		/*if(collision.gameObject.tag == "100")
		{
			mySource.PlayOneShot( coin, myVolume );
			//points += 100;
			SetPointsText();
			//GameController.totalPoints += 100;
			rb.velocity += transform.forward * 5.0f;
		}
		if(collision.gameObject.tag == "250")
		{
			mySource.PlayOneShot( coin, myVolume );
			//points += 250;
			SetPointsText();
			//GameController.totalPoints += 250;
			rb.velocity += transform.forward * 5.0f;
		}
		if(collision.gameObject.tag == "500")
		{
			mySource.PlayOneShot( coin, myVolume );
			//points += 500;
			SetPointsText();
			//GameController.totalPoints += 500;
			rb.velocity += transform.forward * 5.0f;
		}
		if(collision.gameObject.tag == "1000")
		{
			mySource.PlayOneShot( coin, myVolume );
			//points += 1000;
			SetPointsText();
			//GameController.totalPoints += 1000;
			rb.velocity += transform.forward * 5.0f;
		}*/
		if(collision.gameObject.tag == "Edge")
		{
			pointsEnabled = false;
			transform.LookAt(target);
			StartCoroutine(RestartBall());
		}
		if(collision.gameObject.tag == "Sand")
		{
			inSand = true;
		}
		if(collision.gameObject.tag != "Sand")
		{
			inSand = false;
		}
		if(collision.gameObject.tag == "Rough")
		{
			inRough = true;
		}
		if(collision.gameObject.tag != "Rough")
		{
			inRough = false;
		}
		if(collision.gameObject.tag == "Bush")
		{
			mySource.PlayOneShot( leaves, .5f );
		}
		else if(collision.gameObject.tag == "Boulder")
		{
			mySource.PlayOneShot( putt, myVolume );
		}
	}

	public void Putt()
	{
		if(isMoving == false && ClickPower.mouseDown == false && hasStarted == true)
		{
			//Unfreeze();
			mySource.PlayOneShot(putt,myVolume);
			//rb.velocity = transform.forward * ClickPower.power;
			rb.AddForce(transform.forward * ClickPower.power);
			puttCount += 1;
			PuttCount();
		}
	}

	public void RotateRight()
	{
		if(isMoving == false && resetBallEnabled == false)
		{

			//Rotate right
			//transform.Rotate(0, 30 * Time.deltaTime, 0);

			Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0, 5, 0));
 			rb.MoveRotation (transform.rotation * deltaRotation);

		}
	}

	public void RotateLeft()
	{
		if(isMoving == false && resetBallEnabled == false)
		{
			//Rotate left
			//transform.Rotate(0, -30 * Time.deltaTime, 0);

			Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0, -5, 0));
 			rb.MoveRotation (transform.rotation * deltaRotation);

		}
	}

	void SetPointsText()
	{
		pointsText.text = "POINTS: " + points.ToString();
	}

	public IEnumerator RestartBall()
	{
		yield return new WaitForSeconds(ResetDelay);
		//rb.velocity = transform.forward * 0;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		transform.eulerAngles = new Vector3(originalX, originalY, originalZ);
		transform.position = newPos;
		pointsEnabled = true;
		//transform.rotation = Quaternion.Euler(0, 0, 0);
		//transform.localRotation = Quaternion.identity;
		//transform.LookAt(target);
		
	}

	void SwitchCam()
	{
		MainCamera.enabled = false;
		ShotCamera.enabled = true;
	}
}
