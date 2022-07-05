using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Goodie1 : CharacterSpeech
{
    public Goodie1()
    {
        owner = "Goodie1";
        speechStage = 0;
        ConvoParagraph = new List<ConversationChunk>();

        ConversationChunk newChunk1 = new ConversationChunk();
        newChunk1.statementID = 0;
        newChunk1.hasResponse = false;
        newChunk1.redirection = 1;
        newChunk1.hasBeenSaid = false;
        newChunk1.numberOfTimesSaid = 0;
        newChunk1.actualSpeech = "I'm here to help.";
        newChunk1.responses = new List<PlayerResponse>();

        ConvoParagraph.Add(newChunk1);

        ConversationChunk newChunk2 = new ConversationChunk();
        newChunk2.statementID = 1;
        newChunk2.hasResponse = false;
        newChunk2.redirection = 2;
        newChunk2.hasBeenSaid = false;
        newChunk2.numberOfTimesSaid = 0;
        newChunk2.actualSpeech = "Maybe";
        newChunk2.responses = new List<PlayerResponse>();

        ConvoParagraph.Add(newChunk2);

        ConversationChunk newChunk3 = new ConversationChunk();
        newChunk3.statementID = 2;
        newChunk3.hasResponse = true;
        newChunk3.hasBeenSaid = false;
        newChunk3.numberOfTimesSaid = 0;
        newChunk3.actualSpeech = "What would you like to do?";
        newChunk3.responses = new List<PlayerResponse>();

        PlayerResponse newChunk3Response1 = new PlayerResponse();
        newChunk3Response1.canBeRepeated = true;
        newChunk3Response1.hasBeenSaid = false;
        newChunk3Response1.responseRequirements = new List<PlayerResponseRequirement>();
        newChunk3Response1.redirection = 0;
        newChunk3Response1.actualResponse = "Could you repeat that?";
        newChunk3.responses.Add(newChunk3Response1);

        PlayerResponse newChunk3Response2 = new PlayerResponse();
        newChunk3Response2.canBeRepeated = true;
        newChunk3Response2.hasBeenSaid = false;
        newChunk3Response2.responseRequirements = new List<PlayerResponseRequirement>();
        newChunk3Response2.redirection = 3;
        newChunk3Response2.actualResponse = "Kill me.";
        newChunk3.responses.Add(newChunk3Response2);

        PlayerResponse newChunk3Response3 = new PlayerResponse();
        newChunk3Response3.canBeRepeated = true;
        newChunk3Response3.hasBeenSaid = false;
        newChunk3Response3.responseRequirements = new List<PlayerResponseRequirement>();
        newChunk3Response3.redirection = 5;
        newChunk3Response3.actualResponse = "What are you selling?";
        newChunk3.responses.Add(newChunk3Response3);

        PlayerResponse newChunk3Response4 = new PlayerResponse();
        newChunk3Response4.canBeRepeated = true;
        newChunk3Response4.hasBeenSaid = false;
        newChunk3Response4.responseRequirements = new List<PlayerResponseRequirement>() {
            new PlayerResponseRequirement() { ItemRequirement_itemID = 00001, requirementType = PlayerResponseRequirement.RequirementType.Item, requirementLostWhenMet = true },
            new PlayerResponseRequirement() { requirementType = PlayerResponseRequirement.RequirementType.Quest, QuestRequirement_id = 00001, QuestRequirement_questPhase = 0} };
        newChunk3Response4.redirection = 4;
        newChunk3Response4.actualResponse = "Want some shale?";
        newChunk3.responses.Add(newChunk3Response4);

        PlayerResponse newChunk3Response5 = new PlayerResponse();
        newChunk3Response5.canBeRepeated = true;
        newChunk3Response5.hasBeenSaid = false;
        newChunk3Response5.responseRequirements = new List<PlayerResponseRequirement>();
        newChunk3Response5.redirection = -1;
        newChunk3Response5.actualResponse = "Goodbye.";
        newChunk3.responses.Add(newChunk3Response5);

        ConvoParagraph.Add(newChunk3);

        ConversationChunk newChunk4 = new ConversationChunk();
        newChunk4.statementID = 3;
        newChunk4.hasResponse = false;
        newChunk4.endsConversation = true;
        newChunk4.redirection = -1;
        newChunk4.hasBeenSaid = false;
        newChunk4.numberOfTimesSaid = 0;
        newChunk4.actualSpeech = "";
        newChunk4.interactions.Add(new GameEvent_KillPlayer());

        ConvoParagraph.Add(newChunk4);

        ConversationChunk newChunk5 = new ConversationChunk();
        newChunk5.statementID = 4;
        newChunk5.hasResponse = false;
        newChunk5.redirection = -1;
        newChunk5.hasBeenSaid = false;
        newChunk5.numberOfTimesSaid = 0;
        newChunk5.actualSpeech = "Thanks!";
        newChunk5.interactions.Add(new GameEvent_Quest_GiveShale());

        ConvoParagraph.Add(newChunk5);

        ConversationChunk newChunk6 = new ConversationChunk();
        newChunk6.statementID = 5;
        newChunk6.hasResponse = false;
        newChunk6.endsConversation = true;
        newChunk6.redirection = -1;
        newChunk6.hasBeenSaid = false;
        newChunk6.numberOfTimesSaid = 0;
        newChunk6.actualSpeech = "";
        newChunk6.interactions.Add(new GameEvent_OpenStore());

        ConvoParagraph.Add(newChunk6);
    }
}