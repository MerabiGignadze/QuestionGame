using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{
	[SerializeField] AnswerPanel answerPanel;
	[SerializeField] Image buttonImage;
	[SerializeField] TextMeshProUGUI buttonText;
	public enum ButtonState { Idle, Correct, Incorrect }
	[SerializeField] ButtonState activeButtonState;
	[SerializeField] Color[] buttonColors;
	[SerializeField] Color[] textColors;
	[SerializeField] int buttonId;
	[SerializeField] bool activeButton;

	public void UpdateButton(ButtonState _buttonState)
	{
		activeButtonState = _buttonState;
		buttonImage.color = buttonColors[(int)activeButtonState];
		buttonText.color = textColors[(int)activeButtonState];
	}
	public void PushButton()
	{
		if (!activeButton) { return; }
		answerPanel.PushAnswerButton(buttonId);
	}
	public void SetAnswerText(string _answerText)
	{
		buttonText.text = _answerText;
	}
	public int GetAnswerID()
	{
		return buttonId;
	}
	public void ActivateButton(bool _active)
	{
		activeButton = _active;
	}
}
