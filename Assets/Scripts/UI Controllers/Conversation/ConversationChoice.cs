using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ConversationChoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {

    public int option = 0;
    //IPointerEnterHandler ipEnter;
    //IPointerExitHandler ipExit;
    //IPointerDownHandler ipDown;
    //IPointerUpHandler ipUp;

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Text>().color = new Color(255, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Text>().color = new Color(0, 0, 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //ConversationManager.ConvoStep(PlayerCharacterUnit.player, WorldInteract.currentConversationNPC, option);
    }
}