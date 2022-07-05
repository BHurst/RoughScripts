using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class QuestManager
{
    public static List<BaseQuest> QuestList;

    public static void CreateQuestList()
    {
        QuestList = new List<BaseQuest>();
        DirectoryInfo questsDir = new DirectoryInfo("Assets/Scripts/Quests/AllQuests");
        FileInfo[] info = questsDir.GetFiles("*.cs", SearchOption.AllDirectories);
        foreach (FileInfo item in info)
        {
            BaseQuest instance = (BaseQuest)Activator.CreateInstance(Type.GetType(item.Name.ToString().Split(".")[0]));
            QuestList.Add(instance);
            Debug.Log("Quest " + instance.questName + " added to list");
        }
    }

    public static BaseQuest GetQuestByID(int id)
    {
        return QuestList.Find(x => x.questId == id);
    }
}