using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventManager : MonoBehaviour
{
    public static UIEventManager main;
    public CharacterTalentsPane ctP;
    public CharacterLevel cL;
    private void Awake()
    {
        main = this;
        ctP = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();
        cL = PlayerCharacterUnit.player.level;
    }

    private void Start()
    {
        RigLevelUp();
    }

    public void RigLevelUp()
    {
        cL.LevelMilestone += ctP.Event_UpdateLevel;
    }
}