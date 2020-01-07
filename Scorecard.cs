using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorecard : MonoBehaviour 
{
	public Text pointsText;
	//public Text totalPointsText;
	public Text scoreText;
	public Text totalScoreText;
	public static int txtScore;
	public static int txtTotalScore;
	public static int txtPoints;
	//public static int txtTotalPoints;
	public Text[] checkMarks1;
	public Text[] checkMarks2;
	public Text[] checkMarks3;
	public Text[] checkMarks4;
	public Text[] checkMarks5;
	public Text[] checkMarks6;
	public Text[] checkMarks7;
	public Text[] checkMarks8;
	public Text[] checkMarks9;

	// Use this for initialization
	void Start () 
	{
		txtPoints = 0;
		txtPoints = Ball.points;
		//txtTotalPoints = 0;
		//txtTotalPoints = GameController.totalPoints;
		//txtTotalPoints += txtPoints;
		SetPointsText();
		FillCard();
		//SetFinalPointsText();
		//SetScoreText();
	}

	void Update()
	{
	}
	
	void SetPointsText()
	{
		pointsText.text = "POINTS FOR THIS HOLE: " + txtPoints.ToString();
	}

	/*void SetFinalPointsText()
	{
		totalPointsText.text = "FINAL POINTS: " + txtTotalPoints.ToString();
	}*/

	/*void SetScoreText()
	{
		scoreText.text = "SCORE FOR THIS HOLE: " + txtScore.ToString();
		totalScoreText.text = "FINAL SCORE: " + txtTotalScore.ToString();
	}*/

	void FillCard()
	{
		for (int i = 0; i < Ball.puttCount1; i++)
		{
			checkMarks1[i].text = "X";
		}

		for (int i = 0; i < Ball.puttCount2; i++)
		{
			checkMarks2[i].text = "X";
		}

		for (int i = 0; i < Ball.puttCount3; i++)
		{
			checkMarks3[i].text = "X";
		}

		for (int i = 0; i < Ball.puttCount4; i++)
		{
			checkMarks4[i].text = "X";
		}

		for (int i = 0; i < Ball.puttCount5; i++)
		{
			checkMarks5[i].text = "X";
		}

		for (int i = 0; i < Ball.puttCount6; i++)
		{
			checkMarks6[i].text = "X";
		}

		for (int i = 0; i < Ball.puttCount7; i++)
		{
			checkMarks7[i].text = "X";
		}

		for (int i = 0; i < Ball.puttCount8; i++)
		{
			checkMarks8[i].text = "X";
		}

		for (int i = 0; i < Ball.puttCount9; i++)
		{
			checkMarks9[i].text = "X";
		}
	}
}
