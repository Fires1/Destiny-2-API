
using System;
using System.Collections.Generic;
using DestinySharp;

namespace Destiny.Definitions
{
    public class DestinyTalentNodeDefinition
    {
public int nodeIndex;
public int nodeHash;
public int row;
public int column;
public List<object> prerequisiteNodeIndexes;
public int binaryPairNodeIndex;
public bool autoUnlocks;
public bool lastStepRepeats;
public bool isRandom;
public bool isRandomRepurchasable;
public List<object> steps;
public List<object> exclusiveWithNodeHashes;
public int randomStartProgressionBarAtProgression;
public string layoutIdentifier;
public int groupHash;
public int loreHash;
public string nodeStyleIdentifier;
public bool ignoreForCompletion;
}
}