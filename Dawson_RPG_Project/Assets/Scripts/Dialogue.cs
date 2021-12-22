﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue 
{
    [TextArea(1,100)]
    public string[] sentences;
    public string name;
    public string[] ductDialogue;
    public string ductDialogueName;
}
