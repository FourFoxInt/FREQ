using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class m6_stats : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    //UI
    [SerializeField] TextMeshProUGUI y3eqdb_quizTotalText;
    [SerializeField] GameObject y3eqdb_progress;

    void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        UpdateTotal();
    }

    private void Update()
    {
        y3eqdb_quizTotalText.text = glbScr.m6eqDb_passedTests.ToString() + " out of 6";
        y3eqdb_progress.GetComponent<Image>().fillAmount = glbScr.m6eqDb_passedTests / 6;
    }

    void UpdateTotal()
    {
        glbScr.m6eqDb_passedTests = 0;
        if (glbScr.M6EQDB_T1_Score >= 11)
        {
            glbScr.m6eqDb_passedTests++;
        }
        if (glbScr.M6EQDB_T2_Score >= 11)
        {
            glbScr.m6eqDb_passedTests++;
        }
        if (glbScr.M6EQDB_T3_Score >= 21)
        {
            glbScr.m6eqDb_passedTests++;
        }
        if (glbScr.M6EQDB_T4_Score >= 11)
        {
            glbScr.m6eqDb_passedTests++;
        }
        if (glbScr.M6EQDB_T5_Score >= 11)
        {
            glbScr.m6eqDb_passedTests++;
        }
        if (glbScr.M6EQDB_T6_Score >= 21)
        {
            glbScr.m6eqDb_passedTests++;
        }
    }
}
