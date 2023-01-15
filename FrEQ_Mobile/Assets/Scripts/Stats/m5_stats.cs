using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class m5_stats : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    //UI
    [SerializeField] TextMeshProUGUI m5eq_quizTotalText;
    [SerializeField] GameObject m5eq_progress;

    void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        UpdateTotal();
    }

    private void Update()
    {
        m5eq_quizTotalText.text = glbScr.m5eq_passedTests.ToString() + " out of 24";
        m5eq_progress.GetComponent<Image>().fillAmount = glbScr.m5eq_passedTests / 24;

        if (glbScr.m5eq_passedTests == 24 && netGlbScr.classYear == "Year3")
        {
            glbScr.m6dblocked = false;
        }
    }

    void UpdateTotal()
    {
        glbScr.m5eq_passedTests = 0;
        if (glbScr.M5EQ_T1_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T2_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T3_Score >= 16)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T4_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T5_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T6_Score >= 16)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T7_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T8_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T9_Score >= 16)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T10_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T11_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T12_Score >= 16)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T13_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T14_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T15_Score >= 16)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T16_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T17_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T18_Score >= 16)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T19_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T20_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T21_Score >= 16)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T22_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T23_Score >= 11)
        {
            glbScr.m5eq_passedTests++;
        }
        if (glbScr.M5EQ_T24_Score >= 16)
        {
            glbScr.m5eq_passedTests++;
        }
    }
}


