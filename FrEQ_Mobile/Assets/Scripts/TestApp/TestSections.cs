using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSections : MonoBehaviour
{
    private Globals glbScr;

    [SerializeField] private GameObject musicSec;
    [SerializeField] private GameObject cutBoostSec;

    [SerializeField] private RectTransform freqRect;
    [SerializeField] private RectTransform scrollRect;
    [SerializeField] private RectTransform cutBoostRect;
    [SerializeField] private RectTransform musicRect;

    public void ChangeTestSections()
    {
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();

        if (glbScr.cutOrBoost == "Both" && glbScr.pinkOrMusic == "PN")
        {
            cutBoostSec.SetActive(true);
            musicSec.SetActive(false);
            cutBoostRect.localPosition = new Vector2(cutBoostRect.localPosition.x, 475);
            freqRect.localPosition = new Vector2(freqRect.localPosition.x, 170f);
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 830f);
        }
        else if (glbScr.cutOrBoost == "Both" && glbScr.pinkOrMusic == "MUS")
        {
            cutBoostSec.SetActive(true);
            musicSec.SetActive(true);
            cutBoostRect.localPosition = new Vector2(cutBoostRect.localPosition.x, 230f);
            musicRect.localPosition = new Vector2(musicRect.localPosition.x, 470f);
            freqRect.localPosition = new Vector2(freqRect.localPosition.x, -50f);
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 605f);
        }
        else if (glbScr.cutOrBoost != "Both" && glbScr.pinkOrMusic == "PN")
        {
            cutBoostSec.SetActive(false);
            musicSec.SetActive(false);
            cutBoostRect.localPosition = new Vector2(cutBoostRect.localPosition.x, 475);
            freqRect.localPosition = new Vector2(freqRect.localPosition.x, 450f);
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 1100f);
        }
        else if (glbScr.cutOrBoost != "Both" && glbScr.pinkOrMusic == "MUS")
        {
            cutBoostSec.SetActive(false);
            musicSec.SetActive(true);
            freqRect.localPosition = new Vector2(freqRect.localPosition.x, 265f);
            scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, 930f);
        }
    }
}
