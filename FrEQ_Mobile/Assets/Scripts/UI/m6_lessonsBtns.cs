using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class m6_lessonsBtns : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }

    public void m6_l1_Click()
    {
        glbScr.lessonID = "M6_L1";
        glbScr.cutOrBoost = "Boost";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "M6_T1";
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(11);
    }
    public void m6_l2_Click()
    {
        glbScr.lessonID = "M6_L2";
        glbScr.cutOrBoost = "Cut";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "M6_T2";
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(11);
    }
    public void m6_l3_Click()
    {
        glbScr.lessonID = "M6_L3";
        glbScr.cutOrBoost = "Both";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "M6_T3";
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(11);
    }
    public void m6_l4_Click()
    {
        glbScr.lessonID = "M6_L4";
        glbScr.cutOrBoost = "Boost";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "MUS";
        glbScr.appTestID = "M6_T4"; 
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(11);
    }
    public void m6_l5_Click()
    {
        glbScr.lessonID = "M6_L5";
        glbScr.cutOrBoost = "Cut";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "MUS";
        glbScr.appTestID = "M6_T5";
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(11);
    }
    public void m6_l6_Click()
    {
        glbScr.lessonID = "M6_L6";
        glbScr.cutOrBoost = "Both";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "MUS";
        glbScr.appTestID = "M6_T6";
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(11);
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(3);
    }
}
