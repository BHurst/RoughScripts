using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationFactory
{
    static string[] startOfChunkSeperator = new string[] { "[Chunk]" };
    static string npcChunkMetaData = "[CMD]";
    static string npcChunkMetaDataEnd = "[/CMD]";
    static string[] npcChunkMetaDataSeperator = new string[] { "[CD]" };
    static string[] playerResponseSeperator = new string[] { "[PR]" };
    static string[] playerResponseMetaDataSeperator = new string[] { "[PRD]" };
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
            chunk.numberOfTimesSaid = 0;
            chunk.statementID = i;
            chunk.actualSpeech = "This is part " + i + " of the conversation.";


            for (int y = 0; y < 4; y++)
            {
                PlayerResponse respo = new PlayerResponse();

                respo.actualResponse = "Go to part " + y;
                respo.canBeRepeated = true;
                respo.redirection = y;

                chunk.responses.Add(respo);
            }

            newSpeech.ConvoParagraph.Add(chunk);
        }
        return newSpeech;
    }

    public static CharacterSpeech GetSpeech(string owner, int speechStage)
    {
        return (CharacterSpeech)Activator.CreateInstance(Type.GetType(owner + speechStage));
    }

    public static CharacterSpeech LoadSpeech(string owner, int speechStage)
    {
        TextAsset assetRead = Resources.Load("Scripts/Conversation/Speech" + owner + speechStage) as TextAsset;
        ConversationChunk speech = JsonUtility.FromJson(assetRead.text, typeof(ConversationChunk)) as ConversationChunk;

        CharacterSpeech speechToReturn = new CharacterSpeech();
        
        string[] speechString = assetRead.text.Split(startOfChunkSeperator, StringSplitOptions.RemoveEmptyEntries);
        string chunkMetaData;
        string[] chunkData;
        string[] responses;
        string[] responseData;

        foreach (string section in speechString)
        {
            chunkMetaData = section.Substring(section.IndexOf(npcChunkMetaData) + npcChunkMetaData.Length, section.IndexOf(npcChunkMetaDataEnd) + npcChunkMetaDataEnd.Length);
            chunkData = section.Split(npcChunkMetaDataSeperator, StringSplitOptions.RemoveEmptyEntries);
            ConversationChunk newChunk = new ConversationChunk();

            newChunk.owner = owner;
            newChunk.statementID = int.Parse(chunkData[0]);
            newChunk.actualSpeech = chunkData[1];

            if (chunkData[2] == "1")
                newChunk.hasResponse = true;
            else
                newChunk.hasResponse = false;

            if (chunkData[4] == "1")
                newChunk.hasBeenSaid = true;
            else
                newChunk.hasBeenSaid = false;

            newChunk.numberOfTimesSaid = int.Parse(chunkData[5]);

            responses = chunkData[6].Split(playerResponseSeperator, StringSplitOptions.RemoveEmptyEntries);

            foreach (string response in responses)
            {
                responseData = response.Split(playerResponseMetaDataSeperator, StringSplitOptions.RemoveEmptyEntries);
                PlayerResponse newResponse = new PlayerResponse();

                newResponse.actualResponse = responseData[0];

                if (responseData[1] == "1")
                    newResponse.canBeRepeated = true;
                else
                    newResponse.canBeRepeated = false;

                if (responseData[2] == "1")
                    newResponse.hasBeenSaid = true;
                else
                    newResponse.hasBeenSaid = false;

                
                newResponse.redirection = int.Parse(responseData[6]);

                newChunk.responses.Add(newResponse);
            }

            speechToReturn.ConvoParagraph.Add(newChunk);
        }

        return speechToReturn;
    }
}