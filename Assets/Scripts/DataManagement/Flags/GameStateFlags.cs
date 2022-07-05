using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStateFlags
{
    private static GameStateFlags Instance = null;
    private static readonly object padlock = new object();
    #region Flags
    public bool Quest_GaveShale = false;
    #endregion

    public static GameStateFlags CurrentState
    {
        get
        {
            lock (padlock)
            {
                if (Instance == null)
                {
                    Instance = new GameStateFlags();
                }
                return Instance;
            }
        }
        set { }
    }

    public void LoadState(GameStateFlags stateToLoad)
    {
        CurrentState = stateToLoad;
    }
}