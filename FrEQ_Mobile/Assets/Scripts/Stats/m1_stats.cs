using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class m1_stats : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    //UI
    [SerializeField] TextMeshProUGUI m1eq_testsCompletedText;
    [SerializeField] GameObject m1eq_progress;

    void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        UpdateTotal();
    }

    private void Update()
    {
        m1eq_testsCompletedText.text = glbScr.m1eq_passedTests.ToString() + " out of 7";
        m1eq_progress.GetComponent<Image>().fillAmount = glbScr.m1eq_passedTests / 7;

        if (glbScr.m1eq_passedTests == 7 && netGlbScr.classYear == "Year2" || glbScr.m1eq_passedTests == 7 && netGlbScr.classYear == "Year3")
        {
            glbScr.m3locked = false;
        }
    }

    void UpdateTotal()
    {
        glbScr.m1eq_passedTests = 0;
        if (glbScr.M1EQ_INTROQUIZ_Score >= 3)
        {
            glbScr.m1eq_passedTests++;
        }
        if (glbScr.M1EQ_T1_Score >= 6)
        {
            glbScr.m1eq_passedTests++;
        }
        if (glbScr.M1EQ_T2_Score >= 6)
        {
            glbScr.m1eq_passedTests++;
        }
        if (glbScr.M1EQ_T3_Score >= 11)
        {
            glbScr.m1eq_passedTests++;
        }
        if (glbScr.M1EQ_T4_Score >= 6)
        {
            glbScr.m1eq_passedTests++;
        }
        if (glbScr.M1EQ_T5_Score >= 6)
        {
            glbScr.m1eq_passedTests++;
        }
        if (glbScr.M1EQ_T6_Score >= 11)
        {
            glbScr.m1eq_passedTests++;
        }
    }
}