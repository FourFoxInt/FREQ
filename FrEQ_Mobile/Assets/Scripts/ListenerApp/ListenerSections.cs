using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerSections : MonoBehaviour
{
    private Globals glbScr;

    [SerializeField] private GameObject musicSec;
    [SerializeField] private GameObject cutBoostSec;

    [SerializeField] private RectTransform freqRect;
    [SerializeField] private RectTransform scrollRect;
    [SerializeField] private RectTransform cutBoostRect;
    [SerializeField] private RectTransform musicRect;

    public void ChangeListenSections()
    {
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();

        if (glbScr.cutOrBoost == "Both" && glbScr.pinkOrMusic == "PN")
        {
            cutBoostSec.SetActive(true);
            musicSec.SetActive(false);
            cutBoostRect.localPosition = new Vector2(cutBoostRect.localPosition.x, 645);
            freqRect.localPosition = new Vector2(freqRect.localPosition.x, 340f);
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 1010f);
        }
        else if (glbScr.cutOrBoost == "Both" && glbScr.pinkOrMusic == "MUS")
        {
            cutBoostSec.SetActive(true);
            musicSec.SetActive(true);
            cutBoostRect.localPosition = new Vector2(cutBoostRect.localPosition.x, 450f);
            musicRect.localPosition = new Vector2(musicRect.localPosition.x, 690f);
            freqRect.localPosition = new Vector2(freqRect.localPosition.x, 170f);
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 825f);
        }
        else if (glbScr.cutOrBoost != "Both" && glbScr.pinkOrMusic == "PN")
        {
            cutBoostSec.SetActive(false);
            musicSec.SetActive(false);
            cutBoostRect.localPosition = new Vector2(cutBoostRect.localPosition.x, 645);
            freqRect.localPosition = new Vector2(freqRect.localPosition.x, 650f);
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 1470f);
        }
        else if (glbScr.cutOrBoost != "Both" && glbScr.pinkOrMusic == "MUS")
        {
            cutBoostSec.SetActive(false);
            musicSec.SetActive(true);
            freqRect.localPosition = new Vector2(freqRect.localPosition.x, 435f);
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 1100f);
        }
    }
}
