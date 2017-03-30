using UnityEngine;
using System.Collections;
using Steamworks;

public class SteamLeaderboards : MonoBehaviour {

    #region Callbacks
    private CallResult<LeaderboardFindResult_t> OnLeaderboardFindResultCallResult;
    private CallResult<LeaderboardScoresDownloaded_t> OnLeaderboardScoresDownloadedCallResult;
    private CallResult<LeaderboardScoreUploaded_t> OnLeaderboardScoreUploadedCallResult;
    private CallResult<LeaderboardUGCSet_t> OnLeaderboardUGCSetCallResult;
    #endregion

    SteamLeaderboard_t m_SteamLeaderboard;
    SteamLeaderboardEntries_t m_SteamLeaderboardEntries;

    void OnEnable()
    {
        OnLeaderboardFindResultCallResult = CallResult<LeaderboardFindResult_t>.Create(OnLeaderboardFindResult);
        OnLeaderboardScoresDownloadedCallResult = CallResult<LeaderboardScoresDownloaded_t>.Create(OnLeaderboardScoresDownloaded);
        OnLeaderboardScoreUploadedCallResult = CallResult<LeaderboardScoreUploaded_t>.Create(OnLeaderboardScoreUploaded);
        OnLeaderboardUGCSetCallResult = CallResult<LeaderboardUGCSet_t>.Create(OnLeaderboardUGCSet);
    }

    void Start()
    {
        if(SteamManager.Initialized)
        {
            FindLeaderboard();
            DownloadLeaderboardEntries();
            DownloadLeaderboardEntriesForUser();
            GetDownloadedLeaderboardEntry();
            UploadLeaderboardScore();
            AttachLeaderboardUGC();
        }
    }

    void FindLeaderboard()
    {
        SteamAPICall_t handle = SteamUserStats.FindLeaderboard("Score");
        OnLeaderboardFindResultCallResult.Set(handle);
        print("SteamUserStats.FindLeaderboard(" + "\"Score\"" + ") : " + handle);
    }

    void DownloadLeaderboardEntries()
    {
        SteamAPICall_t handle = SteamUserStats.DownloadLeaderboardEntries(m_SteamLeaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 1, 5);
        OnLeaderboardScoresDownloadedCallResult.Set(handle);
        print("SteamUserStats.DownloadLeaderboardEntries(" + m_SteamLeaderboard + ", " + ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal + ", " + 1 + ", " + 5 + ") : " + handle);
    }

    void DownloadLeaderboardEntriesForUser()
    {
        CSteamID[] Users = { SteamUser.GetSteamID() };
        SteamAPICall_t handle = SteamUserStats.DownloadLeaderboardEntriesForUsers(m_SteamLeaderboard, Users, Users.Length);
        OnLeaderboardScoresDownloadedCallResult.Set(handle);
        print("SteamUserStats.DownloadLeaderboardEntriesForUsers(" + m_SteamLeaderboard + ", " + Users + ", " + Users.Length + ") : " + handle);
    }

    void GetDownloadedLeaderboardEntry()
    {
        LeaderboardEntry_t LeaderboardEntry;
        bool ret = SteamUserStats.GetDownloadedLeaderboardEntry(m_SteamLeaderboardEntries, 0, out LeaderboardEntry, null, 0);
        print("SteamUserStats.GetDownloadedLeaderboardEntry(" + m_SteamLeaderboardEntries + ", " + 0 + ", " + "out LeaderboardEntry" + ", " + null + ", " + 0 + ") : " + ret + " -- " + LeaderboardEntry);
    }

    void UploadLeaderboardScore()
    {
        SteamAPICall_t handle = SteamUserStats.UploadLeaderboardScore(m_SteamLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, PlayerPrefs.GetInt("Score"), null, 0);
        OnLeaderboardScoreUploadedCallResult.Set(handle);
        print("SteamUserStats.UploadLeaderboardScore(" + m_SteamLeaderboard + ", " + ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate + ", " + PlayerPrefs.GetInt("Score") + ", " + null + ", " + 0 + ") : " + handle);
    }

    void AttachLeaderboardUGC()
    {
        SteamAPICall_t handle = SteamUserStats.AttachLeaderboardUGC(m_SteamLeaderboard, UGCHandle_t.Invalid);
        OnLeaderboardUGCSetCallResult.Set(handle);
        print("SteamUserStats.AttachLeaderboardUGC(" + m_SteamLeaderboard + ", " + UGCHandle_t.Invalid + ") : " + handle);
    }

    void OnLeaderboardFindResult(LeaderboardFindResult_t pCallback, bool bIOFailure)
    {
        Debug.Log("[" + LeaderboardFindResult_t.k_iCallback + " - LeaderboardFindResult] - " + pCallback.m_hSteamLeaderboard + " -- " + pCallback.m_bLeaderboardFound);

        if (pCallback.m_bLeaderboardFound != 0)
        {
            m_SteamLeaderboard = pCallback.m_hSteamLeaderboard;
        }
    }

    void OnLeaderboardScoresDownloaded(LeaderboardScoresDownloaded_t pCallback, bool bIOFailure)
    {
        Debug.Log("[" + LeaderboardScoresDownloaded_t.k_iCallback + " - LeaderboardScoresDownloaded] - " + pCallback.m_hSteamLeaderboard + " -- " + pCallback.m_hSteamLeaderboardEntries + " -- " + pCallback.m_cEntryCount);

        m_SteamLeaderboardEntries = pCallback.m_hSteamLeaderboardEntries;
    }

    void OnLeaderboardScoreUploaded(LeaderboardScoreUploaded_t pCallback, bool bIOFailure)
    {
        Debug.Log("[" + LeaderboardScoreUploaded_t.k_iCallback + " - LeaderboardScoreUploaded] - " + pCallback.m_bSuccess + " -- " + pCallback.m_hSteamLeaderboard + " -- " + pCallback.m_nScore + " -- " + pCallback.m_bScoreChanged + " -- " + pCallback.m_nGlobalRankNew + " -- " + pCallback.m_nGlobalRankPrevious);
    }

    void OnLeaderboardUGCSet(LeaderboardUGCSet_t pCallback, bool bIOFailure)
    {
        Debug.Log("[" + LeaderboardUGCSet_t.k_iCallback + " - LeaderboardUGCSet] - " + pCallback.m_eResult + " -- " + pCallback.m_hSteamLeaderboard);
    }
}
