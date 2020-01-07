using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour 
{
	public Rigidbody rb;
	public GameObject startpoint;
	public float speed = 5.25f;
	public float ResetDelay = 1.0f;
	public Text pointsText;
	public static float scoreTime;
	public static float points;
	public static bool stopped;
	public AudioSource mySource;
	public AudioClip jump;
	public AudioClip stop;
	public float myVolume = 1.0f;

	private Vector3 lastPosition;
	private Transform myTransform;
	public Vector3 newPos;

	private float originalX;
	private float originalY;
	private float originalZ;

	public static float moveTimer;
	public static bool started = false;
	public bool isGoing = false;

	public Vector3 normalizedDirection;
	public Transform goTarget;

	//private Vector2 touchOrigin = -Vector2.one;

	public bool turnRight;
	public bool turnLeft;

	
	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
		lastPosition = myTransform.position;
		moveTimer = 0.0f;
		newPos = startpoint.transform.position;
		originalX = transform.localEulerAngles.x;
		originalY = transform.localEulerAngles.y;
		originalZ = transform.localEulerAngles.z;
		started = false;
		rb.constraints = RigidbodyConstraints.FreezeAll;
		scoreTime = 0;
		points = 0;
		goTarget = GameObject.FindGameObjectWithTag("Gotodirection").transform;
		normalizedDirection = (goTarget.position - transform.position).normalized;
		turnRight = false;
		turnLeft = false;
		stopped = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(started == true)
		{
			rb.constraints = RigidbodyConstraints.None;
			scoreTime +=Time.deltaTime;
			if(isGoing == true && rb.velocity.magnitude < .04f)
			{
				//print("too slow");
				StartCoroutine(RestartBall());
			}
		}
	}

	void FixedUpdate()
	{
		rb.maxAngularVelocity = speed; //rotation speed
		if(started == true)
		{
			moveTimer += Time.deltaTime;
			transform.position += normalizedDirection * speed * Time.deltaTime;
			SetPointsText();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "EndGameCollider")
		{
			mySource.PlayOneShot( stop, myVolume );
			speed = 0;
			stopped = true;
			rb.constraints = RigidbodyConstraints.FreezeAll;
			StartCoroutine(RestartBall());
			print("end game");
		}

		if(other.gameObject.tag == "Going")
		{
			print("I'm going");
			isGoing = true;
		}

		if(other.gameObject.tag == "JumpPoints")
		{
			mySource.PlayOneShot( jump, myVolume );
			points += 100f;
			rb.AddForce(0, 300, 0, ForceMode.Impulse);
		}

		if(other.gameObject.tag == "Gotodirection")
		{
			Destroy(other);
		}
	}

	void SetPointsText()
	{
		pointsText.text = "POINTS: " + points.ToString();
	}

	public IEnumerator RestartBall()
	{
		yield return new WaitForSeconds(ResetDelay);
		started = false;
		rb.constraints = RigidbodyConstraints.FreezeAll;
		CameraFade.StartAlphaFade( Color.black, false, 2f, 2f, () => { SceneManager.LoadScene("Scene6_Score"); } );
		moveTimer = 0.0f;
	}
}
