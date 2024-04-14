﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
	public UIManager uiManager;
	public enum EndLelelCondition { Lose, Win }
	public HapticsController haptics;
	public SoundPlayer soundPlayer;
	[SerializeField] QuestionController questionController;

	private void Start()
	{
		GoToStartScreen();
	}
	public void GoToStartScreen()
	{
		uiManager.SwitchScreen(UIManager.Screen.StartScreen);
	}
	public void StartLevel()
	{
		StartCoroutine(StartLevelRoutine());
	}
	public void EndLevelel(EndLelelCondition _endCondition)
	{
		switch (_endCondition)
		{
			case EndLelelCondition.Lose:
				StartCoroutine(LoseRoutine());
				break;
			case EndLelelCondition.Win:
				StartCoroutine(WinRoutine());
				break;
		}
	}
	IEnumerator StartLevelRoutine()
	{
		uiManager.SwitchScreen(UIManager.Screen.Hud);
		questionController.StarQuestionGame();
		yield return new WaitForSeconds(1);
	}
	IEnumerator WinRoutine()
	{
		yield return new WaitForSeconds(1);
		uiManager.SwitchScreen(UIManager.Screen.WinScreen);
	}
	IEnumerator LoseRoutine()
	{
		yield return new WaitForSeconds(1);
		uiManager.SwitchScreen(UIManager.Screen.LoseScreen);
	}
}
