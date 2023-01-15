using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class m4_stats : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    //UI
    [SerializeField] TextMeshProUGUI m4eq_testsCompletedText;
    [SerializeField] GameObject m4eq_progress;

    void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        UpdateTotal();
    }

    private void Update()
    {
        m4eq_testsCompletedText.text = glbScr.m1eq_passedTests.ToString() + " out of 7";
        m4eq_progress.GetComponent<Image>().fillAmount = glbScr.m1eq_passedTests / 7;

        if (glbScr.m1eq_passedTests == 7 && netGlbScr.classYear == "Year2" || glbScr.m1eq_passedTests == 7 && netGlbScr.classYear == "Year3")
        {
            glbScr.m3locked = false;
        }
    }

    void UpdateTotal()
    {
        glbScr.m4fx_passedTests = 0;
        if (glbScr.M4FX_T1_Score >= 5)
        {
            glbScr.m4fx_passedTests++;
        }
        if (glbScr.M4FX_T2_Score >= 5)
        {
            glbScr.m4fx_passedTests++;
        }
        if (glbScr.M4FX_T3_Score >= 5)
        {
            glbScr.m4fx_passedTests++;
        }
        if (glbScr.M4FX_T4_Score >= 5)
        {
            glbScr.m4fx_passedTests++;
        }
        if (glbScr.M4FX_T5_Score >= 5)
        {
            glbScr.m4fx_passedTests++;
        }
        if (glbScr.M4FX_T6_Score >= 5)
        {
            glbScr.m4fx_passedTests++;
        }
    }
}


