using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationChunk {
    public string owner;
    public int statementID;
    public string actualSpeech;
    public bool hasResponse;
    public bool hasPartyInterjection;
    public bool hasBeenSaid;
    public int numberOfTimesSaid;
    public List<PlayerResponses> responses = new List<PlayerResponses>();
}