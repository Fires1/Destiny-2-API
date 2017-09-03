
using System;
using System.Collections.Generic;
using DestinySharp;

namespace Destiny.Definitions
{
    public class DestinyNodeStepDefinition
    {
public int stepIndex;
public int nodeStepHash;
public string interactionDescription;
public int damageTypeHash;
public bool canActivateNextStep;
public int nextStepIndex;
public bool isNextStepRandom;
public List<object> perkHashes;
public int startProgressionBarAtProgress;
public List<object> statHashes;
public bool affectsQuality;
public bool affectsLevel;
public List<object> socketReplacements;
}
}