using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class m1_lessonBtns : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    private void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }
    public void m1_Intro_Click()
    {
        glbScr.lessonID = "M1_Intro";
        glbScr.cutOrBoost = "Boost";
        glbScr.anserBtnsType = "Beginner";
        glbScr.minFreq = 380.1f;
        glbScr.maxFreq = 410f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "M1_T1";
        glbScr.canHalfMark = false;
        glbScr.currentTitle = "";
        glbScr.currentDesc = "";
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(13);
    }
    public void m1_l1_Click()
    {
        glbScr.lessonID = "M1_L1";
        glbScr.cutOrBoost = "Boost";
        glbScr.anserBtnsType = "Beginner";
        glbScr.minFreq = 380.1f;
        glbScr.maxFreq = 410f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "M1_T1";
        glbScr.canHalfMark = false;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(5);
    }
    public void m1_l2_Click()
    {
        glbScr.lessonID = "M1_L2";
        glbScr.cutOrBoost = "Cut";
        glbScr.anserBtnsType = "Beginner";
        glbScr.minFreq = 380.1f;
        glbScr.maxFreq = 410f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "M1_T2";
        glbScr.canHalfMark = false;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(5);
    }
    public void m1_l3_Click()
    {
        glbScr.lessonID = "M1_L3";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "Beginner";
        glbScr.minFreq = 380.1f;
        glbScr.maxFreq = 410f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "M1_T3";
        glbScr.canHalfMark = false;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(5);
    }
    public void m1_l4_Click()
    {
        glbScr.lessonID = "M1_L4";
        glbScr.cutOrBoost = "Boost";
        glbScr.anserBtnsType = "Beginner";
        glbScr.minFreq = 380.1f;
        glbScr.maxFreq = 410f;
        glbScr.pinkOrMusic = "MUS";
        glbScr.appTestID = "M1_T4";
        glbScr.canHalfMark = false;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(5);
    }
    public void m1_l5_Click()
    {
        glbScr.lessonID = "M1_L5";
        glbScr.cutOrBoost = "Cut";
        glbScr.anserBtnsType = "Beginner";
        glbScr.minFreq = 380.1f;
        glbScr.maxFreq = 410f;
        glbScr.pinkOrMusic = "MUS";
        glbScr.appTestID = "M1_T5";
        glbScr.canHalfMark = false;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(5);
    }
    public void m1_l6_Click()
    {
        glbScr.lessonID = "M1_L6";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "Beginner";
        glbScr.minFreq = 380.1f;
        glbScr.maxFreq = 410f;
        glbScr.pinkOrMusic = "MUS";
        glbScr.appTestID = "M1_T6";
        glbScr.canHalfMark = false;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(5);
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(3);
    }
}
