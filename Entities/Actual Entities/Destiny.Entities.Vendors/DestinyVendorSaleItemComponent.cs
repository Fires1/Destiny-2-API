
using System;
using System.Collections.Generic;
using DestinySharp;

namespace Destiny.Entities.Vendors
{
    public class DestinyVendorSaleItemComponent
    {
public int vendorItemIndex;
public int itemHash;
public List<object> costs;
public List<object> requiredUnlocks;
public List<object> unlockStatuses;
public List<object> failureIndexes;
}
}