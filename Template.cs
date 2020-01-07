using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Template : MonoBehaviour 
{
	public Transform[] OneSpawn;
	public Transform[] TwoSpawn;
	public Transform[] ThreeSpawn;
	public Transform[] FourSpawn;
	public Transform[] FiveSpawn;
	public Transform[] SixSpawn;

	public GameObject[] OnePrefab;
	public GameObject[] TwoPrefab;
	public GameObject[] ThreePrefab;
	public GameObject[] FourPrefab;
	public GameObject[] FivePrefab;
	public GameObject[] SixPrefab;

	public GameObject[] OneOpen;
	public GameObject[] OneHOpen;
	public GameObject[] OneClosed;

	public GameObject[] TwoOpen;
	public GameObject[] TwoHOpen;
	public GameObject[] TwoClosed;

	public GameObject[] ThreeOpen;
	public GameObject[] ThreeHOpen;
	public GameObject[] ThreeClosed;
	public GameObject[] ThreeGapEnd;
	public GameObject[] ThreeHJumpOpen;
	public GameObject[] ThreeJumpOpen;

	public GameObject[] FourOpen;
	public GameObject[] FourHOpen;
	public GameObject[] FourClosed;

	public GameObject[] FiveOpen;
	public GameObject[] FiveHOpen;
	public GameObject[] FiveClosed;

	public GameObject[] SixOpen;
	public GameObject[] SixHOpen;
	public GameObject[] SixClosed;
	public GameObject[] SixGapEnd;
	public GameObject[] SixHJumpOpen;
	public GameObject[] SixJumpOpen;

	public Transform[] PlaceHolderSpawn;
	public GameObject[] StarsPrefab;
	public GameObject[] TempPrefab;
	public GameObject[] Stars;
	public GameObject[] Empties;
	public GameObject starTemplateInstance;

	public Transform[] BkgrndSpawn;
	public GameObject[] BkgrndPrefab;
	public GameObject[] TempPrefab1;
	public GameObject[] Bkgrnd;
	public GameObject bkgrndTemplateInstance;

	public GameObject chosenObject;
	public bool destroyPrefabs = false;

	public float CleanUPDelay = 30.0f;
	public GameObject templateInstance1;
	public GameObject templateInstance2;
	public GameObject templateInstance3;
	public GameObject templateInstance4;
	public GameObject templateInstance5;
	public GameObject templateInstance6;
	// Use this for initialization
	void Awake()
	{
		RandomizeArrays();
		FillTemplate();
		FillPointsTemplate();
		FillBkgrndTemplate();
	}
	void Start () 
	{
		/*RandomizeArrays();
		FillTemplateOne();
		FillTemplateTwo();
		FillTemplateThree();
		FillTemplateFour();
		FillTemplateFive();
		FillTemplateSix();*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		destroyPrefabs = DestroyTemplate.destroyTemplateChild;
	}

	void LateUpdate()
	{
		if (destroyPrefabs == true)
		{
			/*print("ending it");
			Destroy(this.templateInstance1.gameObject);
			Destroy(this.templateInstance2.gameObject);
			Destroy(this.templateInstance3.gameObject);
			Destroy(this.templateInstance4.gameObject);
			Destroy(this.templateInstance5.gameObject);
			Destroy(this.templateInstance6.gameObject);*/
			/* for(int i = 0; i < OnePrefab.Length; i++)//(int i = OnePrefab.Length; i >= 0; i--)
			 {
				 Destroy(OnePrefab[i].gameObject);
				 print("Destroyed");
			 }
			 for(int i = TwoPrefab.Length; i >= 0; i--)
			 {
				 Destroy(TwoPrefab[i].gameObject);
			 }
			 for(int i = ThreePrefab.Length; i >= 0; i--)
			 {
				 Destroy(ThreePrefab[i].gameObject);
			 }*/
		}
	}

	void FillTemplate()
	{
		if(Ball.moveTimer <= 30)
		{
			Array.Copy(OneOpen, 0, OnePrefab, 0, 4);
		}
		if(Ball.moveTimer >= 30 && Ball.moveTimer <= 60)
		{
			Array.Copy(OneOpen, 0, OnePrefab, 0, 3);
			Array.Copy(OneHOpen,0, OnePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 60 && Ball.moveTimer <= 90)
		{
			Array.Copy(OneOpen, 0, OnePrefab, 0, 2);
			Array.Copy(OneHOpen,0, OnePrefab, 2, 2);
		}
		if(Ball.moveTimer >= 90 && Ball.moveTimer <= 120)
		{
			Array.Copy(OneOpen, 0, OnePrefab, 0, 1);
			Array.Copy(OneHOpen,0, OnePrefab, 1, 3);
		}
		if(Ball.moveTimer >= 120 && Ball.moveTimer <= 150)
		{
			Array.Copy(OneHOpen,0, OnePrefab, 0, 4);
		}
		if(Ball.moveTimer >= 150 && Ball.moveTimer <= 180)
		{
			Array.Copy(OneHOpen, 0, OnePrefab, 0, 3);
			Array.Copy(OneClosed,0, OnePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 210 && Ball.moveTimer <= 240)
		{
			Array.Copy(OneHOpen, 0, OnePrefab, 0, 2);
			Array.Copy(OneClosed,0, OnePrefab, 2, 2);
		}
		if(Ball.moveTimer >= 270 && Ball.moveTimer <= 300)
		{
			Array.Copy(OneHOpen, 0, OnePrefab, 0, 1);
			Array.Copy(OneClosed,0, OnePrefab, 1, 3);
		}
		if(Ball.moveTimer >= 300 && Ball.moveTimer <= 330)
		{
			//Insert finish template then go to win scene
		}
		//Array.Copy(OneOpen, 0, OnePrefab, 0, 4);
		//Array.Copy(OneHOpen,0, OnePrefab, 4, 4);
		for (int t = 0; t < OnePrefab.Length; t++ )
		{
			GameObject tmp = OnePrefab[t];
			int r = Random.Range(t, OnePrefab.Length);
			OnePrefab[t] = OnePrefab[r];
			OnePrefab[r] = tmp;
		}
		for(int i = 0; i < 4; i++)
		{
			templateInstance1 = Instantiate(OnePrefab[i], OneSpawn[i].position, OneSpawn[i].rotation) as GameObject;
			//CleanUpOne();
		}

		if(Ball.moveTimer <= 30)
		{
			Array.Copy(TwoOpen, 0, TwoPrefab, 0, 4);
		}
		if(Ball.moveTimer >= 30 && Ball.moveTimer <= 60)
		{
			Array.Copy(TwoOpen, 0, TwoPrefab, 0, 3);
			Array.Copy(TwoHOpen,0, TwoPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 60 && Ball.moveTimer <= 90)
		{
			Array.Copy(TwoOpen, 0, TwoPrefab, 0, 2);
			Array.Copy(TwoHOpen,0, TwoPrefab, 2, 2);
		}
		if(Ball.moveTimer >= 90 && Ball.moveTimer <= 120)
		{
			Array.Copy(TwoOpen, 0, TwoPrefab, 0, 1);
			Array.Copy(TwoHOpen,0, TwoPrefab, 1, 3);
		}
		if(Ball.moveTimer >= 120 && Ball.moveTimer <= 150)
		{
			Array.Copy(TwoHOpen,0, TwoPrefab, 0, 4);
		}
		if(Ball.moveTimer >= 150 && Ball.moveTimer <= 180)
		{
			Array.Copy(TwoHOpen, 0, TwoPrefab, 0, 3);
			Array.Copy(TwoClosed,0, TwoPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 210 && Ball.moveTimer <= 240)
		{
			Array.Copy(TwoHOpen, 0, TwoPrefab, 0, 2);
			Array.Copy(TwoClosed,0, TwoPrefab, 2, 2);
		}
		if(Ball.moveTimer >= 270 && Ball.moveTimer <= 300)
		{
			Array.Copy(TwoHOpen, 0, TwoPrefab, 0, 1);
			Array.Copy(TwoClosed,0, TwoPrefab, 1, 3);
		}
		if(Ball.moveTimer >= 300 && Ball.moveTimer <= 330)
		{
			//Insert finish template then go to win scene
		}
		//Array.Copy(TwoOpen, 0, TwoPrefab, 0, 4);
		//Array.Copy(TwoHOpen,0, TwoPrefab, 4, 4);
		//Array.Copy(TwoOpen, 0, TwoPrefab, 0, 4);
		//Array.Copy(TwoHOpen,0, TwoPrefab, 4, 4);
		for (int t = 0; t < TwoPrefab.Length; t++ )
		{
			GameObject tmp = TwoPrefab[t];
			int r = Random.Range(t, TwoPrefab.Length);
			TwoPrefab[t] = TwoPrefab[r];
			TwoPrefab[r] = tmp;
		}
		for(int i = 0; i < 4; i++)
		{
			templateInstance2 = Instantiate(TwoPrefab[i], TwoSpawn[i].position, TwoSpawn[i].rotation) as GameObject;
		}

				if(Ball.moveTimer <= 30)
		{
			Array.Copy(ThreeOpen, 0, ThreePrefab, 0, 3);
			Array.Copy(ThreeJumpOpen,0, ThreePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 30 && Ball.moveTimer <= 60)
		{
			Array.Copy(ThreeOpen, 0, ThreePrefab, 0, 2);
			Array.Copy(ThreeHOpen,0, ThreePrefab, 2, 1);
			Array.Copy(ThreeJumpOpen,0, ThreePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 60 && Ball.moveTimer <= 90)
		{
			Array.Copy(ThreeOpen, 0, ThreePrefab, 0, 1);
			Array.Copy(ThreeHOpen,0, ThreePrefab, 1, 1);
			Array.Copy(ThreeJumpOpen,0, ThreePrefab, 2, 1);
			Array.Copy(ThreeHJumpOpen,0, ThreePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 90 && Ball.moveTimer <= 120)
		{
			Array.Copy(ThreeHOpen, 0, ThreePrefab, 0, 1);
			Array.Copy(ThreeHJumpOpen,0, ThreePrefab, 1, 2);
			Array.Copy(ThreeClosed,0, ThreePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 120 && Ball.moveTimer <= 150)
		{
			Array.Copy(ThreeHJumpOpen,0, ThreePrefab, 0, 2);
			Array.Copy(ThreeGapEnd,0, ThreePrefab, 2, 2);
		}
		if(Ball.moveTimer >= 150 && Ball.moveTimer <= 180)
		{
			Array.Copy(ThreeHOpen, 0, ThreePrefab, 0, 1);
			Array.Copy(ThreeHJumpOpen, 0, ThreePrefab, 1, 1);
			Array.Copy(ThreeClosed,0, ThreePrefab, 2, 1);
			Array.Copy(ThreeGapEnd,0, ThreePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 210 && Ball.moveTimer <= 240)
		{
			Array.Copy(ThreeHJumpOpen, 0, ThreePrefab, 0, 2);
			Array.Copy(ThreeClosed,0, ThreePrefab, 2, 1);
			Array.Copy(ThreeGapEnd,0, ThreePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 270 && Ball.moveTimer <= 300)
		{
			Array.Copy(ThreeHJumpOpen, 0, ThreePrefab, 0, 1);
			Array.Copy(ThreeClosed,0, ThreePrefab, 1, 2);
			Array.Copy(ThreeGapEnd,0, ThreePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 300 && Ball.moveTimer <= 330)
		{
			//Insert finish template then go to win scene
		}
		
		for (int t = 0; t < ThreePrefab.Length; t++ )
		{
			GameObject tmp = ThreePrefab[t];
			int r = Random.Range(t, ThreePrefab.Length);
			ThreePrefab[t] = ThreePrefab[r];
			ThreePrefab[r] = tmp;
		}
		for(int i = 0; i < 4; i++)
		{
			templateInstance3 = Instantiate(ThreePrefab[i], ThreeSpawn[i].position, ThreeSpawn[i].rotation) as GameObject;
		}

		if(Ball.moveTimer <= 30)
		{
			Array.Copy(FourOpen, 0, FourPrefab, 0, 4);
		}
		if(Ball.moveTimer >= 30 && Ball.moveTimer <= 60)
		{
			Array.Copy(FourOpen, 0, FourPrefab, 0, 3);
			Array.Copy(FourHOpen,0, FourPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 60 && Ball.moveTimer <= 90)
		{
			Array.Copy(FourOpen, 0, FourPrefab, 0, 2);
			Array.Copy(FourHOpen,0, FourPrefab, 2, 2);
		}
		if(Ball.moveTimer >= 90 && Ball.moveTimer <= 120)
		{
			Array.Copy(FourOpen, 0, FourPrefab, 0, 1);
			Array.Copy(FourHOpen,0, FourPrefab, 1, 3);
		}
		if(Ball.moveTimer >= 120 && Ball.moveTimer <= 150)
		{
			Array.Copy(FourHOpen,0, FourPrefab, 0, 4);
		}
		if(Ball.moveTimer >= 150 && Ball.moveTimer <= 180)
		{
			Array.Copy(FourHOpen, 0, FourPrefab, 0, 3);
			Array.Copy(FourClosed,0, FourPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 210 && Ball.moveTimer <= 240)
		{
			Array.Copy(FourHOpen, 0, FourPrefab, 0, 2);
			Array.Copy(FourClosed,0, FourPrefab, 2, 2);
		}
		if(Ball.moveTimer >= 270 && Ball.moveTimer <= 300)
		{
			Array.Copy(FourHOpen, 0, FourPrefab, 0, 1);
			Array.Copy(FourClosed,0, FourPrefab, 1, 3);
		}
		if(Ball.moveTimer >= 300 && Ball.moveTimer <= 330)
		{
			//Insert finish template then go to win scene
		}
		//Array.Copy(FourOpen, 0, FourPrefab, 0, 4);
		//Array.Copy(FourHOpen,0, FourPrefab, 4, 4);
		//Array.Copy(FourOpen, 0, FourPrefab, 0, 4);
		//Array.Copy(FourHOpen,0, FourPrefab, 4, 4);
		for (int t = 0; t < FourPrefab.Length; t++ )
		{
			GameObject tmp = FourPrefab[t];
			int r = Random.Range(t, FourPrefab.Length);
			FourPrefab[t] = FourPrefab[r];
			FourPrefab[r] = tmp;
		}
		for(int i = 0; i < 4; i++)
		{
			templateInstance4 = Instantiate(FourPrefab[i], FourSpawn[i].position, FourSpawn[i].rotation) as GameObject;
		}

		if(Ball.moveTimer <= 30)
		{
			Array.Copy(FiveOpen, 0, FivePrefab, 0, 4);
		}
		if(Ball.moveTimer >= 30 && Ball.moveTimer <= 60)
		{
			Array.Copy(FiveOpen, 0, FivePrefab, 0, 3);
			Array.Copy(FiveHOpen,0, FivePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 60 && Ball.moveTimer <= 90)
		{
			Array.Copy(FiveOpen, 0, FivePrefab, 0, 2);
			Array.Copy(FiveHOpen,0, FivePrefab, 2, 2);
		}
		if(Ball.moveTimer >= 90 && Ball.moveTimer <= 120)
		{
			Array.Copy(FiveOpen, 0, FivePrefab, 0, 1);
			Array.Copy(FiveHOpen,0, FivePrefab, 1, 3);
		}
		if(Ball.moveTimer >= 120 && Ball.moveTimer <= 150)
		{
			Array.Copy(FiveHOpen,0, FivePrefab, 0, 4);
		}
		if(Ball.moveTimer >= 150 && Ball.moveTimer <= 180)
		{
			Array.Copy(FiveHOpen, 0, FivePrefab, 0, 3);
			Array.Copy(FiveClosed,0, FivePrefab, 3, 1);
		}
		if(Ball.moveTimer >= 210 && Ball.moveTimer <= 240)
		{
			Array.Copy(FiveHOpen, 0, FivePrefab, 0, 2);
			Array.Copy(FiveClosed,0, FivePrefab, 2, 2);
		}
		if(Ball.moveTimer >= 270 && Ball.moveTimer <= 300)
		{
			Array.Copy(FiveHOpen, 0, FivePrefab, 0, 1);
			Array.Copy(FiveClosed,0, FivePrefab, 1, 3);
		}
		if(Ball.moveTimer >= 300 && Ball.moveTimer <= 330)
		{
			//Insert finish template then go to win scene
		}
		//Array.Copy(FiveOpen, 0, FivePrefab, 0, 4);
		//Array.Copy(FiveHOpen,0, FivePrefab, 4, 4);
		//Array.Copy(FiveOpen, 0, FivePrefab, 0, 4);
		//Array.Copy(FiveHOpen,0, FivePrefab, 4, 4);
		for (int t = 0; t < FivePrefab.Length; t++ )
		{
			GameObject tmp = FivePrefab[t];
			int r = Random.Range(t, FivePrefab.Length);
			FivePrefab[t] = FivePrefab[r];
			FivePrefab[r] = tmp;
		}
		for(int i = 0; i < 4; i++)
		{
			templateInstance5 = Instantiate(FivePrefab[i], FiveSpawn[i].position, FiveSpawn[i].rotation) as GameObject;
		}

				if(Ball.moveTimer <= 30)
		{
			Array.Copy(SixOpen, 0, SixPrefab, 0, 3);
			Array.Copy(SixJumpOpen,0, SixPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 30 && Ball.moveTimer <= 60)
		{
			Array.Copy(SixOpen, 0, SixPrefab, 0, 2);
			Array.Copy(SixHOpen,0, SixPrefab, 2, 1);
			Array.Copy(SixJumpOpen,0, SixPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 60 && Ball.moveTimer <= 90)
		{
			Array.Copy(SixOpen, 0, SixPrefab, 0, 1);
			Array.Copy(SixHOpen,0, SixPrefab, 1, 1);
			Array.Copy(SixJumpOpen,0, SixPrefab, 2, 1);
			Array.Copy(SixHJumpOpen,0, SixPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 90 && Ball.moveTimer <= 120)
		{
			Array.Copy(SixHOpen, 0, SixPrefab, 0, 1);
			Array.Copy(SixHJumpOpen,0, SixPrefab, 1, 2);
			Array.Copy(SixClosed,0, SixPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 120 && Ball.moveTimer <= 150)
		{
			Array.Copy(SixHJumpOpen,0, SixPrefab, 0, 2);
			Array.Copy(SixGapEnd,0, SixPrefab, 2, 2);
		}
		if(Ball.moveTimer >= 150 && Ball.moveTimer <= 180)
		{
			Array.Copy(SixHOpen, 0, SixPrefab, 0, 1);
			Array.Copy(SixHJumpOpen, 0, SixPrefab, 1, 1);
			Array.Copy(SixClosed,0, SixPrefab, 2, 1);
			Array.Copy(SixGapEnd,0, SixPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 210 && Ball.moveTimer <= 240)
		{
			Array.Copy(SixHJumpOpen, 0, SixPrefab, 0, 2);
			Array.Copy(SixClosed,0, SixPrefab, 2, 1);
			Array.Copy(SixGapEnd,0, SixPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 270 && Ball.moveTimer <= 300)
		{
			Array.Copy(SixHJumpOpen, 0, SixPrefab, 0, 1);
			Array.Copy(SixClosed,0, SixPrefab, 1, 2);
			Array.Copy(SixGapEnd,0, SixPrefab, 3, 1);
		}
		if(Ball.moveTimer >= 300 && Ball.moveTimer <= 330)
		{
			//Insert finish template then go to win scene
		}
		
		for (int t = 0; t < SixPrefab.Length; t++ )
		{
			GameObject tmp = SixPrefab[t];
			int r = Random.Range(t, SixPrefab.Length);
			SixPrefab[t] = SixPrefab[r];
			SixPrefab[r] = tmp;
		}
		for(int i = 0; i < 4; i++)
		{
			templateInstance6 = Instantiate(SixPrefab[i], SixSpawn[i].position, SixSpawn[i].rotation) as GameObject;
		}
	}
	
	void FillPointsTemplate()
	{
		Array.Copy(Empties, 0, TempPrefab, 0, 10);
		Array.Copy(Stars, 0, TempPrefab, 9, 4);
		Array.Copy(Empties, 0, TempPrefab, 13, 15);

		for (int t = 0; t < TempPrefab.Length; t++ )
		{
			GameObject tmp = TempPrefab[t];
			int r = Random.Range(t, TempPrefab.Length);
			TempPrefab[t] = TempPrefab[r];
			TempPrefab[r] = tmp;
		}

		Array.Copy(TempPrefab, 0, StarsPrefab, 0, 24);

		for (int t = 0; t < StarsPrefab.Length; t++ )
		{
			GameObject tmp = StarsPrefab[t];
			int r = Random.Range(t, StarsPrefab.Length);
			StarsPrefab[t] = StarsPrefab[r];
			StarsPrefab[r] = tmp;
		}

		for(int i = 0; i < 4; i++)
		{
			starTemplateInstance = Instantiate(StarsPrefab[i], PlaceHolderSpawn[i].position, PlaceHolderSpawn[i].rotation) as GameObject;
			//CleanUpOne();
		}
	}

	void FillBkgrndTemplate()
	{
		Array.Copy(Bkgrnd, 0, TempPrefab1, 0, 4);

		for (int t = 0; t < TempPrefab1.Length; t++ )
		{
			GameObject tmp = TempPrefab1[t];
			int r = Random.Range(t, TempPrefab1.Length);
			TempPrefab1[t] = TempPrefab1[r];
			TempPrefab1[r] = tmp;
		}

		Array.Copy(TempPrefab1, 0, BkgrndPrefab, 0, 4);

		for (int t = 0; t < BkgrndPrefab.Length; t++ )
		{
			GameObject tmp = BkgrndPrefab[t];
			int r = Random.Range(t, BkgrndPrefab.Length);
			BkgrndPrefab[t] = BkgrndPrefab[r];
			BkgrndPrefab[r] = tmp;
		}

		for(int i = 0; i < 4; i++)
		{
			bkgrndTemplateInstance = Instantiate(BkgrndPrefab[i], BkgrndSpawn[i].position, BkgrndSpawn[i].rotation) as GameObject;
			//CleanUpOne();
		}
	}
	void RandomizeArrays()
	{
		for (int t = 0; t < OneOpen.Length; t++ )
		{
			GameObject tmp = OneOpen[t];
			int r = Random.Range(t, OneOpen.Length);
			OneOpen[t] = OneOpen[r];
			OneOpen[r] = tmp;
		}
		for (int t = 0; t < OneHOpen.Length; t++ )
		{
			GameObject tmp = OneHOpen[t];
			int r = Random.Range(t, OneHOpen.Length);
			OneHOpen[t] = OneHOpen[r];
			OneHOpen[r] = tmp;
		}
		for (int t = 0; t < OneClosed.Length; t++ )
		{
			GameObject tmp = OneClosed[t];
			int r = Random.Range(t, OneClosed.Length);
			OneClosed[t] = OneClosed[r];
			OneClosed[r] = tmp;
		}
		for (int t = 0; t < TwoOpen.Length; t++ )
		{
			GameObject tmp = TwoOpen[t];
			int r = Random.Range(t, TwoOpen.Length);
			TwoOpen[t] = TwoOpen[r];
			TwoOpen[r] = tmp;
		}
		for (int t = 0; t < TwoHOpen.Length; t++ )
		{
			GameObject tmp = TwoHOpen[t];
			int r = Random.Range(t, TwoHOpen.Length);
			TwoHOpen[t] = TwoHOpen[r];
			TwoHOpen[r] = tmp;
		}
		for (int t = 0; t < TwoClosed.Length; t++ )
		{
			GameObject tmp = TwoClosed[t];
			int r = Random.Range(t, TwoClosed.Length);
			TwoClosed[t] = TwoClosed[r];
			TwoClosed[r] = tmp;
		}
		for (int t = 0; t < ThreeOpen.Length; t++ )
		{
			GameObject tmp = ThreeOpen[t];
			int r = Random.Range(t, ThreeOpen.Length);
			ThreeOpen[t] = ThreeOpen[r];
			ThreeOpen[r] = tmp;
		}
		for (int t = 0; t < ThreeHOpen.Length; t++ )
		{
			GameObject tmp = ThreeHOpen[t];
			int r = Random.Range(t, ThreeHOpen.Length);
			ThreeHOpen[t] = ThreeHOpen[r];
			ThreeHOpen[r] = tmp;
		}
		for (int t = 0; t < ThreeClosed.Length; t++ )
		{
			GameObject tmp = ThreeClosed[t];
			int r = Random.Range(t, ThreeClosed.Length);
			ThreeClosed[t] = ThreeClosed[r];
			ThreeClosed[r] = tmp;
		}
		for (int t = 0; t < ThreeGapEnd.Length; t++ )
		{
			GameObject tmp = ThreeGapEnd[t];
			int r = Random.Range(t, ThreeGapEnd.Length);
			ThreeGapEnd[t] = ThreeGapEnd[r];
			ThreeGapEnd[r] = tmp;
		}
		for (int t = 0; t < ThreeHJumpOpen.Length; t++ )
		{
			GameObject tmp = ThreeHJumpOpen[t];
			int r = Random.Range(t, ThreeHJumpOpen.Length);
			ThreeHJumpOpen[t] = ThreeHJumpOpen[r];
			ThreeHJumpOpen[r] = tmp;
		}
		for (int t = 0; t < ThreeJumpOpen.Length; t++ )
		{
			GameObject tmp = ThreeJumpOpen[t];
			int r = Random.Range(t, ThreeJumpOpen.Length);
			ThreeJumpOpen[t] = ThreeJumpOpen[r];
			ThreeJumpOpen[r] = tmp;
		}
		for (int t = 0; t < FourOpen.Length; t++ )
		{
			GameObject tmp = FourOpen[t];
			int r = Random.Range(t, FourOpen.Length);
			FourOpen[t] = FourOpen[r];
			FourOpen[r] = tmp;
		}
		for (int t = 0; t < FourHOpen.Length; t++ )
		{
			GameObject tmp = FourHOpen[t];
			int r = Random.Range(t, FourHOpen.Length);
			FourHOpen[t] = FourHOpen[r];
			FourHOpen[r] = tmp;
		}
		for (int t = 0; t < FourClosed.Length; t++ )
		{
			GameObject tmp = FourClosed[t];
			int r = Random.Range(t, FourClosed.Length);
			FourClosed[t] = FourClosed[r];
			FourClosed[r] = tmp;
		}
		for (int t = 0; t < FiveOpen.Length; t++ )
		{
			GameObject tmp = FiveOpen[t];
			int r = Random.Range(t, FiveOpen.Length);
			FiveOpen[t] = FiveOpen[r];
			FiveOpen[r] = tmp;
		}
		for (int t = 0; t < FiveHOpen.Length; t++ )
		{
			GameObject tmp = FiveHOpen[t];
			int r = Random.Range(t, FiveHOpen.Length);
			FiveHOpen[t] = FiveHOpen[r];
			FiveHOpen[r] = tmp;
		}
		for (int t = 0; t < FiveClosed.Length; t++ )
		{
			GameObject tmp = FiveClosed[t];
			int r = Random.Range(t, FiveClosed.Length);
			FiveClosed[t] = FiveClosed[r];
			FiveClosed[r] = tmp;
		}
		for (int t = 0; t < SixOpen.Length; t++ )
		{
			GameObject tmp = SixOpen[t];
			int r = Random.Range(t, SixOpen.Length);
			SixOpen[t] = SixOpen[r];
			SixOpen[r] = tmp;
		}
		for (int t = 0; t < SixHOpen.Length; t++ )
		{
			GameObject tmp = SixHOpen[t];
			int r = Random.Range(t, SixHOpen.Length);
			SixHOpen[t] = SixHOpen[r];
			SixHOpen[r] = tmp;
		}
		for (int t = 0; t < SixClosed.Length; t++ )
		{
			GameObject tmp = SixClosed[t];
			int r = Random.Range(t, SixClosed.Length);
			SixClosed[t] = SixClosed[r];
			SixClosed[r] = tmp;
		}
		for (int t = 0; t < SixGapEnd.Length; t++ )
		{
			GameObject tmp = SixGapEnd[t];
			int r = Random.Range(t, SixGapEnd.Length);
			SixGapEnd[t] = SixGapEnd[r];
			SixGapEnd[r] = tmp;
		}
		for (int t = 0; t < SixHJumpOpen.Length; t++ )
		{
			GameObject tmp = SixHJumpOpen[t];
			int r = Random.Range(t, SixHJumpOpen.Length);
			SixHJumpOpen[t] = SixHJumpOpen[r];
			SixHJumpOpen[r] = tmp;
		}
		for (int t = 0; t < SixJumpOpen.Length; t++ )
		{
			GameObject tmp = SixJumpOpen[t];
			int r = Random.Range(t, SixJumpOpen.Length);
			SixJumpOpen[t] = SixJumpOpen[r];
			SixJumpOpen[r] = tmp;
		}
		for (int t = 0; t < Stars.Length; t++ )
		{
			GameObject tmp = Stars[t];
			int r = Random.Range(t, Stars.Length);
			Stars[t] = Stars[r];
			Stars[r] = tmp;
		}
		for (int t = 0; t < Bkgrnd.Length; t++ )
		{
			GameObject tmp = Bkgrnd[t];
			int r = Random.Range(t, Bkgrnd.Length);
			Bkgrnd[t] = Bkgrnd[r];
			Bkgrnd[r] = tmp;
		}
	}

	
}
