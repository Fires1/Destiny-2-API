using Newtonsoft.Json;
using RestSharp;
 namespace DestinySharp {
	public class BungieClient {

public dynamic GetBungieNetUserById(int id)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/User/GetBungieNetUserById/{id}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("id", id);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetUserAliases(int id)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/User/GetUserAliases/{id}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("id", id);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic SearchUsers(string q)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/User/SearchUsers/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("q", q);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetAvailableThemes( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/User/GetAvailableThemes/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetMembershipDataById(int membershipId,BungieMembershipType membershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/User/GetMembershipsById/{membershipId}/{membershipType}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("membershipId", membershipId);
request.AddParameter("membershipType", membershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetMembershipDataForCurrentUser( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/User/GetMembershipsForCurrentUser/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetPartnerships(int membershipId)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/User/{membershipId}/Partnerships/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("membershipId", membershipId);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetTopicsPaged(Forum.ForumTopicsCategoryFiltersEnum categoryFilter,int group,string locales,int page,int pageSize,Forum.ForumTopicsQuickDateEnum quickDate,Forum.ForumTopicsSortEnum sort,string tagstring)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("categoryFilter", categoryFilter);
request.AddParameter("group", group);
request.AddParameter("locales", locales);
request.AddParameter("page", page);
request.AddParameter("pageSize", pageSize);
request.AddParameter("quickDate", quickDate);
request.AddParameter("sort", sort);
request.AddParameter("tagstring", tagstring);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetCoreTopicsPaged(Forum.ForumTopicsCategoryFiltersEnum categoryFilter,string locales,int page,Forum.ForumTopicsQuickDateEnum quickDate,Forum.ForumTopicsSortEnum sort)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/GetCoreTopicsPaged/{page}/{sort}/{quickDate}/{categoryFilter}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("categoryFilter", categoryFilter);
request.AddParameter("locales", locales);
request.AddParameter("page", page);
request.AddParameter("quickDate", quickDate);
request.AddParameter("sort", sort);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetPostsThreadedPaged(bool getParentPost,int page,int pageSize,int parentPostId,int replySize,bool rootThreadMode,string showbanned,Forum.ForumPostSortEnum sortMode)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/GetPostsThreadedPaged/{parentPostId}/{page}/{pageSize}/{replySize}/{getParentPost}/{rootThreadMode}/{sortMode}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("getParentPost", getParentPost);
request.AddParameter("page", page);
request.AddParameter("pageSize", pageSize);
request.AddParameter("parentPostId", parentPostId);
request.AddParameter("replySize", replySize);
request.AddParameter("rootThreadMode", rootThreadMode);
request.AddParameter("showbanned", showbanned);
request.AddParameter("sortMode", sortMode);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetPostsThreadedPagedFromChild(int childPostId,int page,int pageSize,int replySize,bool rootThreadMode,string showbanned,Forum.ForumPostSortEnum sortMode)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/GetPostsThreadedPagedFromChild/{childPostId}/{page}/{pageSize}/{replySize}/{rootThreadMode}/{sortMode}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("childPostId", childPostId);
request.AddParameter("page", page);
request.AddParameter("pageSize", pageSize);
request.AddParameter("replySize", replySize);
request.AddParameter("rootThreadMode", rootThreadMode);
request.AddParameter("showbanned", showbanned);
request.AddParameter("sortMode", sortMode);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetPostAndParent(int childPostId,string showbanned)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/GetPostAndParent/{childPostId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("childPostId", childPostId);
request.AddParameter("showbanned", showbanned);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetPostAndParentAwaitingApproval(int childPostId,string showbanned)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/GetPostAndParentAwaitingApproval/{childPostId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("childPostId", childPostId);
request.AddParameter("showbanned", showbanned);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetTopicForContent(int contentId)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/GetTopicForContent/{contentId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("contentId", contentId);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetForumTagSuggestions(string partialtag)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/GetForumTagSuggestions/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("partialtag", partialtag);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetPoll(int topicId)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/Poll/{topicId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("topicId", topicId);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic JoinFireteamThread(int topicId)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/Recruit/Join/{topicId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("topicId", topicId);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic LeaveFireteamThread(int topicId)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/Recruit/Leave/{topicId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("topicId", topicId);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic KickBanFireteamApplicant(int targetMembershipId,int topicId)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/Recruit/KickBan/{topicId}/{targetMembershipId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("targetMembershipId", targetMembershipId);
request.AddParameter("topicId", topicId);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic ApproveFireteamThread(int topicId)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/Recruit/Approve/{topicId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("topicId", topicId);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetRecruitmentThreadSummaries( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Forum/Recruit/Summaries/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetDestinyManifest( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Manifest/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic SearchDestinyPlayer(string displayName,BungieMembershipType membershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/SearchDestinyPlayer/{membershipType}/{displayName}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("displayName", displayName);
request.AddParameter("membershipType", membershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetProfile(object[] components,int destinyMembershipId,BungieMembershipType membershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("components", components);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("membershipType", membershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetCharacter(int characterId,object[] components,int destinyMembershipId,BungieMembershipType membershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("characterId", characterId);
request.AddParameter("components", components);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("membershipType", membershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetClanWeeklyRewardState(int groupId)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Clan/{groupId}/WeeklyRewardState/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("groupId", groupId);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetItem(object[] components,int destinyMembershipId,int itemInstanceId,BungieMembershipType membershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Item/{itemInstanceId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("components", components);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("itemInstanceId", itemInstanceId);
request.AddParameter("membershipType", membershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetVendors(int characterId,object[] components,int destinyMembershipId,BungieMembershipType membershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("characterId", characterId);
request.AddParameter("components", components);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("membershipType", membershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetVendor(int characterId,object[] components,int destinyMembershipId,BungieMembershipType membershipType,int vendorHash)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("characterId", characterId);
request.AddParameter("components", components);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("membershipType", membershipType);
request.AddParameter("vendorHash", vendorHash);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic TransferItem( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Actions/Items/TransferItem/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic EquipItem( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Actions/Items/EquipItem/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic EquipItems( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Actions/Items/EquipItems/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic SetItemLockState( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Actions/Items/SetLockState/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic InsertSocketPlug( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Actions/Items/InsertSocketPlug/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic ActivateTalentNode( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Actions/Items/ActivateTalentNode/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetPostGameCarnageReport(int activityId)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Stats/PostGameCarnageReport/{activityId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("activityId", activityId);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetHistoricalStatsDefinition( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Stats/Definition/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetClanLeaderboards(int groupId,int maxtop,string modes,string statid)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Stats/Leaderboards/Clans/{groupId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("groupId", groupId);
request.AddParameter("maxtop", maxtop);
request.AddParameter("modes", modes);
request.AddParameter("statid", statid);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetClanAggregateStats(int groupId,string modes)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Stats/AggregateClanStats/{groupId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("groupId", groupId);
request.AddParameter("modes", modes);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetLeaderboards(int destinyMembershipId,int maxtop,BungieMembershipType membershipType,string modes,string statid)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/Leaderboards/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("maxtop", maxtop);
request.AddParameter("membershipType", membershipType);
request.AddParameter("modes", modes);
request.AddParameter("statid", statid);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetLeaderboardsForCharacter(int characterId,int destinyMembershipId,int maxtop,BungieMembershipType membershipType,string modes,string statid)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Stats/Leaderboards/{membershipType}/{destinyMembershipId}/{characterId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("characterId", characterId);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("maxtop", maxtop);
request.AddParameter("membershipType", membershipType);
request.AddParameter("modes", modes);
request.AddParameter("statid", statid);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic SearchDestinyEntities(int page,string searchTerm,string type)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Armory/Search/{type}/{searchTerm}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("page", page);
request.AddParameter("searchTerm", searchTerm);
request.AddParameter("type", type);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetHistoricalStats(int characterId,string dayend,string daystart,int destinyMembershipId,object[] groups,BungieMembershipType membershipType,object[] modes,Destiny.HistoricalStats.Definitions.PeriodType periodType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("characterId", characterId);
request.AddParameter("dayend", dayend);
request.AddParameter("daystart", daystart);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("groups", groups);
request.AddParameter("membershipType", membershipType);
request.AddParameter("modes", modes);
request.AddParameter("periodType", periodType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetHistoricalStatsForAccount(int destinyMembershipId,object[] groups,BungieMembershipType membershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("groups", groups);
request.AddParameter("membershipType", membershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetActivityHistory(int characterId,int count,int destinyMembershipId,BungieMembershipType membershipType,Destiny.HistoricalStats.Definitions.DestinyActivityModeType mode,int page)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/Activities/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("characterId", characterId);
request.AddParameter("count", count);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("membershipType", membershipType);
request.AddParameter("mode", mode);
request.AddParameter("page", page);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetUniqueWeaponHistory(int characterId,int destinyMembershipId,BungieMembershipType membershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/UniqueWeapons/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("characterId", characterId);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("membershipType", membershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetDestinyAggregateActivityStats(int characterId,int destinyMembershipId,BungieMembershipType membershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/AggregateActivityStats/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("characterId", characterId);
request.AddParameter("destinyMembershipId", destinyMembershipId);
request.AddParameter("membershipType", membershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetPublicMilestoneContent(int milestoneHash)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Milestones/{milestoneHash}/Content/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("milestoneHash", milestoneHash);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetPublicMilestones( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Destiny2/Milestones/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetCommunityContent(Forum.ForumTopicsCategoryFiltersEnum mediaFilter,int page,Forum.CommunityContentSortMode sort)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/CommunityContent/Get/{sort}/{mediaFilter}/{page}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("mediaFilter", mediaFilter);
request.AddParameter("page", page);
request.AddParameter("sort", sort);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetCommunityLiveStatuses(int modeHash,int page,Partnerships.PartnershipType partnershipType,Community.CommunityStatusSort sort,string streamLocale)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/CommunityContent/Live/All/{partnershipType}/{sort}/{page}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("modeHash", modeHash);
request.AddParameter("page", page);
request.AddParameter("partnershipType", partnershipType);
request.AddParameter("sort", sort);
request.AddParameter("streamLocale", streamLocale);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetCommunityLiveStatusesForClanmates(int page,Partnerships.PartnershipType partnershipType,Community.CommunityStatusSort sort)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/CommunityContent/Live/Clan/{partnershipType}/{sort}/{page}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("page", page);
request.AddParameter("partnershipType", partnershipType);
request.AddParameter("sort", sort);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetCommunityLiveStatusesForFriends(int page,Partnerships.PartnershipType partnershipType,Community.CommunityStatusSort sort)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/CommunityContent/Live/Friends/{partnershipType}/{sort}/{page}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("page", page);
request.AddParameter("partnershipType", partnershipType);
request.AddParameter("sort", sort);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetFeaturedCommunityLiveStatuses(int page,Partnerships.PartnershipType partnershipType,Community.CommunityStatusSort sort,string streamLocale)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/CommunityContent/Live/Featured/{partnershipType}/{sort}/{page}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("page", page);
request.AddParameter("partnershipType", partnershipType);
request.AddParameter("sort", sort);
request.AddParameter("streamLocale", streamLocale);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetStreamingStatusForMember(int membershipId,BungieMembershipType membershipType,Partnerships.PartnershipType partnershipType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/CommunityContent/Live/Users/{partnershipType}/{membershipType}/{membershipId}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("membershipId", membershipId);
request.AddParameter("membershipType", membershipType);
request.AddParameter("partnershipType", partnershipType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetTrendingCategories( )
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Trending/Categories/");
request.AddHeader("X-API-KEY", APIKey);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetTrendingCategory(string categoryId,int pageNumber)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Trending/Categories/{categoryId}/{pageNumber}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("categoryId", categoryId);
request.AddParameter("pageNumber", pageNumber);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}


public dynamic GetTrendingEntryDetail(string identifier,Trending.TrendingEntryType trendingEntryType)
{
RestClient _client = new RestClient("http://www.bungie.net/d1/Platform/Destiny");
var request = new RestRequest($"/Trending/Details/{trendingEntryType}/{identifier}/");
request.AddHeader("X-API-KEY", APIKey);
request.AddParameter("identifier", identifier);
request.AddParameter("trendingEntryType", trendingEntryType);
var response = _client.Execute(request);
dynamic deserializedResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
return deserializedResponse;
}

	}
}
