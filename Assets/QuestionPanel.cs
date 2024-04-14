using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionPanel : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI questionText;
	[SerializeField] TextMeshProUGUI resultText;
	[SerializeField] TextMeshProUGUI progressionText;
	[SerializeField] UIFadeOut progressionPanel;
	[SerializeField] Color[] colors;
	[SerializeField] Color questionTextColor;
	[SerializeField] Color[] questionPanelColors;
	[SerializeField] Image panelBackground;
	[SerializeField] string[] gradeTexts;
	[SerializeField] TMP_FontAsset[] fonts;

	public void DrawQuestionText(Question _question, int _questionID, int _maxQuestions)
	{
		questionText.font = fonts[0];
		panelBackground.color = questionPanelColors[0];
		questionText.color = questionTextColor;
		questionText.text = _question.questionText;
		resultText.text = "";
		progressionText.text = _questionID + "/" + _maxQuestions;
		progressionPanel.Fade(true, 20);
	}
	public void DrawResults(int _correctAnswers, int _maxQuestions, int _grade)
	{
		progressionPanel.Fade(false, 20);
		questionText.font = fonts[1];
		panelBackground.color = questionPanelColors[1];
		questionText.color = colors[_grade];
		questionText.text = gradeTexts[_grade];
		resultText.text = _correctAnswers + "/" + _maxQuestions;
	}
}
