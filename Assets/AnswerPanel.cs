using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPanel : MonoBehaviour
{
	[SerializeField] QuestionController questionController;
	[SerializeField] AnswerButton[] answerButtons;
	Question currentQuestion;
	[SerializeField] UIFadeOut visibility;

	public void InitializeButtons()
	{

	}
	public void UpdateAnswerPanel(Question _question)
	{
		currentQuestion = _question;
		int id = 0;
		foreach (AnswerButton button in answerButtons)
		{
			button.SetAnswerText(currentQuestion.answers[id]);
			id++;
			ActivateButtons(true);
		}
	}
	public void RevealRightAnswer(Question _question, int _usersAnswer)
	{
		int rightAnswerID = _question.rightAnswerID;

		for (int i = 0; i < answerButtons.Length; i++)
		{
			if (i == _usersAnswer)
			{
				if (_question.rightAnswerID == _usersAnswer)
				{
					answerButtons[i].UpdateButton(AnswerButton.ButtonState.Correct);
				}
				else
				{
					answerButtons[i].UpdateButton(AnswerButton.ButtonState.Incorrect);
				}
			}
			else
			{
				if (_question.rightAnswerID == i)
				{
					answerButtons[i].UpdateButton(AnswerButton.ButtonState.Correct);
				}
				else
				{
					answerButtons[i].UpdateButton(AnswerButton.ButtonState.Idle);
				}
			}
		}
	}
	public void PushAnswerButton(int _id)
	{
		questionController.AnswerTheQuestion(_id);
		ActivateButtons(false);
	}
	void ActivateButtons(bool _activate)
	{
		foreach (AnswerButton button in answerButtons)
		{
			button.ActivateButton(_activate);
			if (_activate) { button.UpdateButton(AnswerButton.ButtonState.Idle); }
		}
	}
	public void ShowAnswerPanel(bool _show)
	{
		visibility.Fade(_show, 20);
	}
}
