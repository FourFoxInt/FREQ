using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class m3_stats : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    //UI
    [SerializeField] TextMeshProUGUI m3eq_quizTotalText;
    [SerializeField] GameObject m3eq_progress;

    void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        UpdateTotal();
    }

    private void Update()
    {
        if (glbScr.m3eq_passedTests != null)
        {
            m3eq_quizTotalText.text = glbScr.m3eq_passedTests.ToString() + " out of 24";
        }
        m3eq_progress.GetComponent<Image>().fillAmount = glbScr.m3eq_passedTests / 24;

        if (glbScr.m3eq_passedTests == 24 && netGlbScr.classYear == "Year3")
        {
            glbScr.m3locked = false;
        }
    }

    void UpdateTotal()
    {
        glbScr.m3eq_passedTests = 0;
        if (glbScr.M3EQ_T1_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T2_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T3_Score >= 11)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T4_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T5_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T6_Score >= 11)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T7_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T8_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T9_Score >= 11)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T10_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T11_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T12_Score >= 11)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T13_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T14_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T15_Score >= 11)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T16_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T17_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T18_Score >= 11)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T19_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T20_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T21_Score >= 11)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T22_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T23_Score >= 6)
        {
            glbScr.m3eq_passedTests++;
        }
        if (glbScr.M3EQ_T24_Score >= 11)
        {
            glbScr.m3eq_passedTests++;
        }
    }
}
