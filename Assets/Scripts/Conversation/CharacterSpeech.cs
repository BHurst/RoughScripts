using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpeech {
    public string owner;
    public int speechStage = 1;
    public List<ConversationChunk> ConvoParagraph = new List<ConversationChunk>();
}