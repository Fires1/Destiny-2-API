
using System;
using System.Collections.Generic;
using DestinySharp;

namespace Destiny.Entities.Characters
{
    public class DestinyCharacterActivitiesComponent
    {
public string dateActivityStarted;
public List<object> availableActivities;
public int currentActivityHash;
public int currentActivityModeHash;
public int lastCompletedStoryHash;
}
}