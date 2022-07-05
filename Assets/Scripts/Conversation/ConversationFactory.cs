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
}