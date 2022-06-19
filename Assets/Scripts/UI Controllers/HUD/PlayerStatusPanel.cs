using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusPanel : MonoBehaviour
{
    public GameObject parentGrid;
    public PlayerCharacterUnit player;
    private void Awake()
    {
        player = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
        player.StatusGained += StatusPanel_AddStatus;
        player.StatusLost += StatusPanel_RemoveStatus;
    }

    private void StatusPanel_AddStatus(object sender, Status e)
    {
        AddStatus(e);
    }

    private void StatusPanel_RemoveStatus(object sender, Status e)
    {
        RemoveStatus(e);
    }

    public void AddStatus(Status status)
    {
        GameObject statusIcon = Instantiate(Resources.Load("Prefabs/UIComponents/Status"), new Vector3(), new Quaternion()) as GameObject;
        SinglePlayerStatusIcon newStatusIcon = statusIcon.GetComponent<SinglePlayerStatusIcon>();

        newStatusIcon.status = status;
        newStatusIcon.image.sprite = Resources.Load<Sprite>(newStatusIcon.status.imageLocation);

        newStatusIcon.transform.SetParent(parentGrid.transform);
    }

    public void RemoveStatus(Status status)
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<SinglePlayerStatusIcon>().status.statusId == status.statusId)
                Destroy(child.gameObject);
        }
    }
}