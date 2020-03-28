using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationFactory
{
    static string[] chunkSeperator = new string[] { "[C]" };
    static string[] chunkDataSeperator = new string[] { "[CD]" };
    static string[] playerResponseSeperator = new string[] { "[PR]" };
    static string[] playerResponseDataSeperator = new string[] { "[PRD]" };
    public static CharacterSpeech AddDefaultConversation(string owner)
    {
        CharacterSpeech newSpeech = new CharacterSpeech();
        newSpeech.ConvoParagraph = new List<ConversationChunk>();

        newSpeech.owner = owner;

        for (int i = 0; i < 4; i++)
        {
            ConversationChunk chunk = new ConversationChunk();

            chunk.owner = owner;
            chunk.hasBeenSaid = false;
            chunk.hasResponse = true;
            chunk.hasPartyInterjection = false;
            chunk.numberOfTimesSaid = 0;
            chunk.statementID = i;
            chunk.actualSpeech = "This is part " + i + " of the conversation.";


            for (int y = 0; y < 4; y++)
            {
                PlayerResponses respo = new PlayerResponses();

                respo.actualResponse = "Go to part " + y;
                respo.canBeRepeated = true;
                respo.redirection = y;

                chunk.responses.Add(respo);
            }

            newSpeech.ConvoParagraph.Add(chunk);
        }
        return newSpeech;
    }

    public static CharacterSpeech LoadSpeech(string owner, int speechStage)
    {
        CharacterSpeech speechToReturn = new CharacterSpeech();
        TextAsset assetRead = Resources.Load("Speech/" + owner + speechStage) as TextAsset;
        string[] speechString = assetRead.text.Split(chunkSeperator, StringSplitOptions.RemoveEmptyEntries);
        string[] chunkData;
        string[] responses;
        string[] responseData;

        foreach (string section in speechString)
        {
            chunkData = section.Split(chunkDataSeperator, StringSplitOptions.RemoveEmptyEntries);
            ConversationChunk newChunk = new ConversationChunk();

            newChunk.owner = owner;
            newChunk.statementID = int.Parse(chunkData[0]);
            newChunk.actualSpeech = chunkData[1];

            if (chunkData[2] == "1")
                newChunk.hasResponse = true;
            else
                newChunk.hasResponse = false;

            if (chunkData[3] == "1")
                newChunk.hasPartyInterjection = true;
            else
                newChunk.hasPartyInterjection = false;

            if (chunkData[4] == "1")
                newChunk.hasBeenSaid = true;
            else
                newChunk.hasBeenSaid = false;

            newChunk.numberOfTimesSaid = int.Parse(chunkData[5]);

            responses = chunkData[6].Split(playerResponseSeperator, StringSplitOptions.RemoveEmptyEntries);

            foreach (string response in responses)
            {
                responseData = response.Split(playerResponseDataSeperator, StringSplitOptions.RemoveEmptyEntries);
                PlayerResponses newResponse = new PlayerResponses();

                newResponse.actualResponse = responseData[0];

                if (responseData[1] == "1")
                    newResponse.canBeRepeated = true;
                else
                    newResponse.canBeRepeated = false;

                if (responseData[2] == "1")
                    newResponse.hasBeenSaid = true;
                else
                    newResponse.hasBeenSaid = false;

                newResponse.worldStateRequirement = responseData[3];
                newResponse.itemRequirement = responseData[4];
                newResponse.statRequirement = responseData[5];
                newResponse.redirection = int.Parse(responseData[6]);

                newChunk.responses.Add(newResponse);
            }

            speechToReturn.ConvoParagraph.Add(newChunk);
        }

        return speechToReturn;
    }
}