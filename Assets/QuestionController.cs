using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
	public List<Question> questions;
	[SerializeField] GameManagers gameManagers;
	[SerializeField] AnswerPanel answerPanel;
	[SerializeField] QuestionPanel questionPanel;
	[SerializeField] int activeQuestionID;
	int rightAnswers;

	public void StarQuestionGame()
	{
		activeQuestionID = 0;
		rightAnswers = 0;
		NewQuestion();
		answerPanel.ShowAnswerPanel(true);
	}
	public void NewQuestion()
	{
		questionPanel.DrawQuestionText(questions[activeQuestionID], activeQuestionID + 1, questions.Count);
		answerPanel.UpdateAnswerPanel(questions[activeQuestionID]);
	}
	public void AnswerTheQuestion(int _answerId)
	{
		answerPanel.RevealRightAnswer(questions[activeQuestionID], _answerId);
		if (RightAnswer(_answerId))
		{
			rightAnswers++;
		}
		StartCoroutine(NextQuestion());
	}
	IEnumerator NextQuestion()
	{
		yield return new WaitForSeconds(2);
		if (activeQuestionID < questions.Count - 1)
		{
			activeQuestionID++;
			NewQuestion();
		}
		else
		{
			EndGame();
		}
	}
	void EndGame()
	{
		questionPanel.DrawResults(rightAnswers, questions.Count, GetGrade());
		answerPanel.ShowAnswerPanel(false);
		gameManagers.EndLevelel(GameManagers.EndLelelCondition.Win);
	}
	int GetGrade()
	{
		int grade = 0;

		if (rightAnswers > 1 && rightAnswers < 5) { grade = 1; }
		if (rightAnswers >= 5) { grade = 2; }

		return grade;
	}
	bool RightAnswer(int _answerId)
	{
		if (questions[activeQuestionID].rightAnswerID == _answerId)
		{
			return true;
		}
		return false;
	}
}
[System.Serializable]
public class Question
{
	[TextArea(3, 10)]
	public string questionText;
	public string[] answers;
	public int rightAnswerID;
}
