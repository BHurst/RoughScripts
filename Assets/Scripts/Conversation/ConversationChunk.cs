using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationChunk
{
    public string owner;
    public int statementID;
    public string actualSpeech;
    public bool endsConversation;
    public bool hasResponse;
    public bool hasBeenSaid;
    public int numberOfTimesSaid;
    public int redirection;
    public List<PlayerResponse> responses = new List<PlayerResponse>();
    public List<SpeechInteractions.Interaction> interactions = new List<SpeechInteractions.Interaction>();
}