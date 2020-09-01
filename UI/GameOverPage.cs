using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityCore.Menu;

public class GameOverPage : Page

{
    public PageController pages;
    public Text ScoreText;

    #region Public Function
    public void TryAgain()
    {
        GameController.instance.TryAgain();
        pages.TurnPageOff(type);
    }
    public void GoToHome()
    {
        //turn off page
        pages.TurnPageOff(type);
        //turn on main menu page
        pages.TurnPageOn(PageType.Menu);
    }

    #endregion
    #region Override Functions
    protected override void OnPageEnabled()
    {
        // base.OnPageEnabled();
        ScoreText.text = "Player Score: " + GameController.instance.score.ToString();
    }
    #endregion
}
