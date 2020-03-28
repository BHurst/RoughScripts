using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class ConversationManager : MonoBehaviour
{

    static GameObject chatPane;
    static Scrollbar chatPaneScrollB;
    static Text chatPaneContainer;
    static GameObject chatPlayerOptions;
    static ConversationChunk currentStep;
    GameObject userInterface;
    static float currentTargetPos = 0;
    static bool AutoScroll = false;
    static float timer = 0;

    static StringBuilder sb = new StringBuilder();

    void Start()
    {
        userInterface = GameObject.Find("UserInterface");
        chatPane = userInterface.transform.Find("ChatContainerCanvas/ChatContainer").gameObject;
        chatPaneScrollB = chatPane.GetComponentInChildren<Scrollbar>();
        chatPaneContainer = chatPane.transform.Find("ChatFadePanel/ConversationSV/Viewport/TextBlockContainer/AllPreviousStatements").GetComponent<Text>();
        chatPlayerOptions = chatPane.transform.Find("ChatFadePanel/ConversationSV/Viewport/TextBlockContainer/PlayerOptionsList").gameObject; ;
    }

    public static void ConvoStart(RootUnit npc)
    {
        chatPane.SetActive(true);
        currentStep = npc.speech.ConvoParagraph[0];
        WriteConversationStatement(npc.unitName, npc.speech.ConvoParagraph[0].actualSpeech, false);
        AutoScroll = true;
        timer = 0;
        WorldInteract.worldInteractionAllowed = false;
        WorldInteract.menuOpen = true;
    }

    public static void ConvoStep(RootUnit player, RootUnit npc, int option)
    {
        if (option < currentStep.responses.Count)
        {
            ClearPlayerOptions();
            WriteConversationStatement(player.unitName, currentStep.responses[option].actualResponse, true);
            WriteConversationStatement(npc.unitName, npc.speech.ConvoParagraph[option].actualSpeech, false);
            currentStep = npc.speech.ConvoParagraph[option];
            AutoScroll = true;
            timer = 0;
        }
    }

    public void ConvoEnd()
    {
        chatPane.SetActive(false);
        ClearPlayerOptions();
        chatPaneScrollB.value = 0;
        WorldInteract.worldInteractionAllowed = true;
        WorldInteract.menuOpen = false;
    }

    public static void WriteConversationOptions()
    {
        int responseNum = 1;

        foreach (PlayerResponses response in currentStep.responses)
        {
            GameObject textOption = GameObject.Instantiate(Resources.Load("Prefabs/Conversation/PlayerOption")) as GameObject;
            textOption.transform.SetParent(chatPlayerOptions.transform, false);

            textOption.GetComponent<Text>().text = responseNum + ". " + response.actualResponse;
            textOption.GetComponent<ConversationChoice>().option = response.redirection;
            responseNum++;
        }

        //LayoutRebuilder.MarkLayoutForRebuild(chatPlayerOptions.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(chatPlayerOptions.GetComponent<RectTransform>());
    }

    public static void WriteConversationEnd()
    {
        GameObject textContainer = GameObject.Instantiate(Resources.Load("Prefabs/Conversation/StatementContainer")) as GameObject;
        textContainer.transform.SetParent(chatPaneContainer.transform, false);

        //WriteToChatLog(speaker, statement);
    }

    public static void WriteConversationStatement(string speaker, string statement, bool saidByPlayer)
    {
        sb.Append("\n\n" + speaker + "  -  " + statement);

        chatPaneContainer.text = sb.ToString();

        if (chatPaneContainer.text.Length - chatPaneContainer.text.ToString().Replace("\n\n", "").Length > 300)
        {
            sb.Remove(0, chatPaneContainer.text.IndexOf("\n\n") + 1);
        }

        if (currentStep.hasResponse == true && saidByPlayer == false)
            WriteConversationOptions();
        else
        {

        }
    }

    public static void ClearPlayerOptions()
    {
        //Hitting multiple options at the same time creates multiple option lists. I don't see a better way to make sure only one ever exists.
        List<Transform> temp = new List<Transform>();

        foreach (Transform child in chatPlayerOptions.transform)
        {
            temp.Add(child);
        }

        temp.ForEach(x => Destroy(x.gameObject));
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(AutoScroll == true && timer > .05f)
            chatPaneScrollB.value = Mathf.Lerp(chatPaneScrollB.value, currentTargetPos, 5f * Time.deltaTime);

        if (chatPaneScrollB.value == 0 && timer > 1f)
            AutoScroll = false;
    }
}