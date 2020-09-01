using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battu : pickups
{
    public float duration;

    // Start is called before the first frame update
    #region Override Funtions
    protected override void OnPlayerCollect()
    {
        base.OnPlayerCollect();
        game.HandleBattu(duration);
    }   
    #endregion
}
