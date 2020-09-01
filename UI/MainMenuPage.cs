using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityCore.Menu;
using UnityCore.Audio;

public class MainMenuPage : Page
{
    


    public PageController pages;
    #region Public Function
    public void StartGame()
    {
       GameController.instance.TryAgain();
       pages.TurnPageOff(type);
    }

    #endregion
    #region Override Functions
    protected override void OnPageEnabled()
    {
       AudioController.instance.PlayAudio(UnityCore.Audio.AudioType.ST_01,true,1);
        Debug.Log("run onpage enabled");
    }
    #endregion
}
    

