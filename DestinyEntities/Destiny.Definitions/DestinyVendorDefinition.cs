
using System;
using System.Collections.Generic;
using DestinySharp;

namespace Destiny.Definitions
{
    public class DestinyVendorDefinition
    {
public Destiny.Definitions.DestinyVendorDisplayPropertiesDefinition displayProperties;
public string buyString;
public string sellString;
public int displayItemHash;
public bool inhibitBuying;
public bool inhibitSelling;
public int factionHash;
public int resetIntervalMinutes;
public int resetOffsetMinutes;
public List<object> failureStrings;
public List<object> unlockRanges;
public string vendorIdentifier;
public string vendorPortrait;
public string vendorBanner;
public bool enabled;
public bool visible;
public string vendorCategoryIdentifier;
public string vendorSubcategoryIdentifier;
public bool consolidateCategories;
public List<object> actions;
public List<object> categories;
public List<object> originalCategories;
public List<object> displayCategories;
public List<object> interactions;
public List<object> inventoryFlyouts;
public List<object> itemList;
public List<object> services;
public List<object> acceptedItems;
public int hash;
public int index;
public bool redacted;
}
}