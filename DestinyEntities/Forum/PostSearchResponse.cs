
using System;
using System.Collections.Generic;
using DestinySharp;

namespace Forum
{
    public class PostSearchResponse
    {
public List<object> relatedPosts;
public List<object> authors;
public List<object> groups;
public List<object> searchedTags;
public List<object> polls;
public List<object> recruitmentDetails;
public int availablePages;
public List<object> results;
public int totalResults;
public bool hasMore;
public Queries.PagedQuery query;
public string replacementContinuationToken;
public bool useTotalResults;
}
}