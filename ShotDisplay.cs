using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDisplay : MonoBehaviour 
{
	public Rigidbody holeInOnePrefab;
	public Rigidbody dblEaglePrefab;
	public Rigidbody eaglePrefab;
	public Rigidbody birdiePrefab;
	public Rigidbody parPrefab;
	public Rigidbody bogeyPrefab;
	public Rigidbody dblBogeyPrefab;
	public Rigidbody trplBogeyPrefab;
	public Transform shotSpawn;
	public float DisplayDelay = 10.0f;
	public float speed = 15.0f;
	public Transform target;

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Ball")
		{
			/*if(Ball.puttMade == true)
			{*/
				if(Ball.puttCount == 1)
				{
					StartCoroutine(HoleInOne());
				}

				if(Ball.puttCount == 2)
				{
					if(Ball.holePar == 3)
					{
						StartCoroutine(Birdie());
					}
					if(Ball.holePar == 4)
					{
						StartCoroutine(Eagle());
					}
					if(Ball.holePar == 5)
					{
						StartCoroutine(DblEagle());
					}
					//StartCoroutine(Birdie());
				}

				if(Ball.puttCount == 3)
				{
					if(Ball.holePar == 3)
					{
						StartCoroutine(Par());
					}
					if(Ball.holePar == 4)
					{
						StartCoroutine(Birdie());
					}
					if(Ball.holePar == 5)
					{
						StartCoroutine(Eagle());
					}
					//StartCoroutine(Par());
				}

				if(Ball.puttCount == 4)
				{
					if(Ball.holePar == 3)
					{
						StartCoroutine(Bogey());
					}
					if(Ball.holePar == 4)
					{
						StartCoroutine(Par());
					}
					if(Ball.holePar == 5)
					{
						StartCoroutine(Birdie());
					}
					//StartCoroutine(Bogey());
				}

				if(Ball.puttCount == 5)
				{
					if(Ball.holePar == 3)
					{
						StartCoroutine(DblBogey());
					}
					if(Ball.holePar == 4)
					{
						StartCoroutine(Bogey());
					}
					if(Ball.holePar == 5)
					{
						StartCoroutine(Par());
					}
					//StartCoroutine(DblBogey());
				}

				if(Ball.puttCount == 6)
				{
					if(Ball.holePar == 3)
					{
						StartCoroutine(TrplBogey());
					}
					if(Ball.holePar == 4)
					{
						StartCoroutine(DblBogey());
					}
					if(Ball.holePar == 5)
					{
						StartCoroutine(Bogey());
					}
					//StartCoroutine(TrplBogey());
				}
			/*}*/
		}
	}

	public IEnumerator HoleInOne()
	{
		Rigidbody holeInOneInstance = Instantiate(holeInOnePrefab, shotSpawn.position, holeInOnePrefab.rotation) as Rigidbody;
		holeInOneInstance.transform.LookAt(target);
		holeInOneInstance.velocity = transform.TransformDirection(Vector3.up * speed);
		yield return new WaitForSeconds(DisplayDelay);
	}

	public IEnumerator DblEagle()
	{
		Rigidbody dblEagleInstance = Instantiate(dblEaglePrefab, shotSpawn.position, dblEaglePrefab.rotation) as Rigidbody;
		dblEagleInstance.transform.LookAt(target);
		dblEagleInstance.velocity = transform.TransformDirection(Vector3.up * speed);
		yield return new WaitForSeconds(DisplayDelay);
	}

	public IEnumerator Eagle()
	{
		Rigidbody eagleInstance = Instantiate(eaglePrefab, shotSpawn.position, eaglePrefab.rotation) as Rigidbody;
		eagleInstance.transform.LookAt(target);
		eagleInstance.velocity = transform.TransformDirection(Vector3.up * speed);
		yield return new WaitForSeconds(DisplayDelay);
	}

	public IEnumerator Birdie()
	{
		Rigidbody birdieInstance = Instantiate(birdiePrefab, shotSpawn.position, birdiePrefab.rotation) as Rigidbody;
		birdieInstance.transform.LookAt(target);
		birdieInstance.velocity = transform.TransformDirection(Vector3.up * speed);
		yield return new WaitForSeconds(DisplayDelay);
	}

	public IEnumerator Par()
	{
		Rigidbody parInstance = Instantiate(parPrefab, shotSpawn.position, parPrefab.rotation) as Rigidbody;
		parInstance.transform.LookAt(target);
		parInstance.velocity = transform.TransformDirection(Vector3.up * speed);
		yield return new WaitForSeconds(DisplayDelay);
	}

	public IEnumerator Bogey()
	{
		Rigidbody bogeyInstance = Instantiate(bogeyPrefab, shotSpawn.position, bogeyPrefab.rotation) as Rigidbody;
		bogeyInstance.transform.LookAt(target);
		bogeyInstance.velocity = transform.TransformDirection(Vector3.up * speed);
		yield return new WaitForSeconds(DisplayDelay);
	}

	public IEnumerator DblBogey()
	{
		Rigidbody dblBogeyInstance = Instantiate(dblBogeyPrefab, shotSpawn.position, dblBogeyPrefab.rotation) as Rigidbody;
		dblBogeyInstance.transform.LookAt(target);
		dblBogeyInstance.velocity = transform.TransformDirection(Vector3.up * speed);
		yield return new WaitForSeconds(DisplayDelay);
	}

	public IEnumerator TrplBogey()
	{
		Rigidbody trplBogeyInstance = Instantiate(trplBogeyPrefab, shotSpawn.position, trplBogeyPrefab.rotation) as Rigidbody;
		trplBogeyInstance.transform.LookAt(target);
		trplBogeyInstance.velocity = transform.TransformDirection(Vector3.up * speed);
		yield return new WaitForSeconds(DisplayDelay);
	}
	
}
