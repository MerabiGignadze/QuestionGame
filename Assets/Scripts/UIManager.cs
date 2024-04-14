using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public UIFadeOut startScreen;
	public UIFadeOut hud;
	public UIFadeOut winScreen;
	public UIFadeOut loseScreen;

	public enum Screen { StartScreen, WinScreen, LoseScreen, Hud }

	public void SwitchScreen(Screen _screenToSet)
	{
		switch (_screenToSet)
		{
			case Screen.StartScreen:
				startScreen.Fade(true, 30);
				hud.Fade(false, 30);
				winScreen.Fade(false, 30);
				loseScreen.Fade(false, 30);
				break;
			case Screen.WinScreen:
				winScreen.Fade(true, 30);
				startScreen.Fade(false, 30);
				loseScreen.Fade(false, 30);
				winScreen.GetComponent<WinScreenController>().DrawWinScreen();
				break;
			case Screen.LoseScreen:
				loseScreen.Fade(true, 30);
				startScreen.Fade(false, 30);
				hud.Fade(false, 30);
				winScreen.Fade(false, 30);
				break;
			case Screen.Hud:
				hud.Fade(true, 30);
				startScreen.Fade(false, 30);
				winScreen.Fade(false, 30);
				loseScreen.Fade(false, 30);
				break;
		}
	}
}
