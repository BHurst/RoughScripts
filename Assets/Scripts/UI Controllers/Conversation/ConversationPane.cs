using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class ConversationPane : MonoBehaviour
{
    public CharacterSpeech currentSpeech;
    public GameObject mainPanel;
    public GameObject QASection;
    public TextMeshProUGUI NPCQuestionText;
    public TextMeshProUGUI PlayerResponseText;
    public GameObject lectureSection;
    public TextMeshProUGUI NPCLectureText;
    ConversationChunk currentStep;
    GameObject userInterface;

    List<int> availableOptions;

    void Start()
    {
        mainPanel.transform.position = transform.position;
        mainPanel.SetActive(false);
        availableOptions = new List<int>();
    }

    public void Show(RootCharacter npc)
    {
        mainPanel.SetActive(true);
        WorldInteract.conversationActive = true;
        PlayerCharacterUnit.player.talkTarget = npc;
        currentStep = npc.speech.ConvoParagraph[0];
        foreach (GameEvent ge in currentStep.interactions)
            ge.DoEvent();
        WriteConversationStatement(npc.unitName, currentStep.actualSpeech, false);
    }

    public void Hide()
    {
        mainPanel.SetActive(false);
        currentStep = null;
        WorldInteract.conversationActive = false;
    }

    public void ConvoStep(RootCharacter player, RootCharacter npc, int option)
    {
        if (!currentStep.hasResponse)
        {
            if (currentStep.redirection != -1)
            {
                currentStep = npc.speech.ConvoParagraph[currentStep.redirection];
                WriteConversationStatement(npc.unitName, currentStep.actualSpeech, false);
            }
            else
                Hide();

            if (currentStep != null)
            {
                foreach (GameEvent ge in currentStep.interactions)
                    ge.DoEvent();
                if (currentStep.endsConversation)
                    Hide();
            }
        }
        else if (option < availableOptions.Count)
        {
            if (PlayerResponseRequirement.CheckRequirements(currentStep.responses[availableOptions[option]].responseRequirements))
            {
                foreach (var item in currentStep.responses[availableOptions[option]].responseRequirements)
                {
                    if (item.requirementType == PlayerResponseRequirement.RequirementType.Quest)
                        QuestManager.GetQuestByID(item.QuestRequirement_id).AdvancePhase();
                    if (item.requirementLostWhenMet)
                        item.TakeRequirement();
                }
            }

            if (currentStep.responses[availableOptions[option]].redirection != -1)
            {
                currentStep = npc.speech.ConvoParagraph[currentStep.responses[availableOptions[option]].redirection];
                WriteConversationStatement(npc.unitName, currentStep.actualSpeech, false);
            }
            else
                Hide();

            if (currentStep != null)
            {
                foreach (GameEvent ge in currentStep.interactions)
                    ge.DoEvent();
                if (currentStep.endsConversation)
                    Hide();
            }
        }
    }

    public void WriteConversationOptions()
    {
        int responseNum = 1;
        int availableResponseNum = 1;
        string textToWrite = "";
        availableOptions.Clear();

        foreach (PlayerResponse response in currentStep.responses)
        {
            if (PlayerResponseRequirement.CheckRequirements(response.responseRequirements))
            {
                if (responseNum == 1)
                    textToWrite = responseNum.ToString() + ". " + response.actualResponse;
                else
                    textToWrite = textToWrite + "\n" + responseNum.ToString() + ". " + response.actualResponse;
                availableOptions.Add(availableResponseNum - 1);
                responseNum++;
            }
            availableResponseNum++;
        }
        PlayerResponseText.SetText(textToWrite);
    }

    public void WriteConversationStatement(string speaker, string statement, bool saidByPlayer)
    {
        if (currentStep.hasResponse == true && saidByPlayer == false)
        {
            NPCQuestionText.SetText("\n\n" + speaker + "  -  " + statement);
            lectureSection.SetActive(false);
            QASection.SetActive(true);
            WriteConversationOptions();
        }
        else
        {
            NPCLectureText.SetText("\n\n" + speaker + "  -  " + statement);
            lectureSection.SetActive(true);
            QASection.SetActive(false);
        }
    }
}