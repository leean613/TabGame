using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : pickups
{
    public float duration;
    public int multiplier;
    // Start is called before the first frame update
    #region Override Funtions
    protected override void OnPlayerCollect()
    {
        base.OnPlayerCollect();
        game.HandleXscore(multiplier, duration);

    }
    #endregion
}
