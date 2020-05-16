using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerScript : MonoBehaviour
{
    public string gameId = "3401098";
    public string placementId = "banner1";
    public bool testMode = false;

    void Start () {
        Advertisement.Initialize (gameId, testMode);
        Advertisement.Banner.SetPosition (BannerPosition.TOP_CENTER);
        StartCoroutine (ShowBannerWhenReady ());
    }

    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady (placementId)) {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Banner.Show (placementId);
    }
}
