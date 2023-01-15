using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameText;
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    private void Start()
    {
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        if (netGlbScr.firstName != "" && netGlbScr.firstName != "...")
        {
            usernameText.text = netGlbScr.firstName + " " + netGlbScr.lastName;
        }
        else
        {
            usernameText.text = netGlbScr.username;
        }
    }

    public void M1_Click()
    {
        glbScr.currentCourse = "M1";
        SceneManager.LoadScene(4);
    }
    public void M2_Click()
    {
        glbScr.currentCourse = "M2";
        SceneManager.LoadScene(8);
    }
    public void M3_Click()
    {
        glbScr.currentCourse = "M3";
        SceneManager.LoadScene(6);
    }
    public void M4_Click()
    {
        //glbScr.currentCourse = "M4";
        //SceneManager.LoadScene(4);
    }
    public void M5_Click()
    {
        glbScr.currentCourse = "M5";
        SceneManager.LoadScene(7);
    }
    public void M6_Click()
    {
        glbScr.currentCourse = "M6";
        SceneManager.LoadScene(9);
    }

    public void currentFxBtn()
    {
        string mod = glbScr.currentFxMod.Substring(0, 2);
        switch (mod)
        {
            case "M2":
                CurrentFxClick_M2();
                break;
            case "M4":
                CurrentFxClick_M4();
                break;
        }
    }

    public void currentEqBtn()
    {
        string mod = glbScr.currentEqMod.Substring(0, 2);
        switch (mod)
        {
            case "M1":
                CurrentEqClick_M1();
                break;
            case "M3":
                CurrentEqClick_M3();
                break;
            case "M5":
                CurrentEqClick_M5();
                break;
            case "M6":
                CurrentEqClick_M6();
                break;
        }
    }

    void CurrentEqClick_M1()
    {
        switch (glbScr.currentEqMod)
        {
            case "M1_L1":
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
                break;
            case "M1_L2":
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
                break;
            case "M1_L3":
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
                break;
            case "M1_L4":
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
                break;
            case "M1_L5":
                glbScr.lessonID = "M1_L5";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "Beginner";
                glbScr.minFreq = 380.1f;
                glbScr.maxFreq = 410f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M1_T51";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M1_L6":
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
                break;
        }
    }

    void CurrentEqClick_M3()
    {
        switch (glbScr.currentEqMod)
        {
            case "M3_L1":
                glbScr.lessonID = "M3_L1";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "10Low";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 50f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T1";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L2":
                glbScr.lessonID = "M3_L2";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "10Low";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 50f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T2";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L3":
                glbScr.lessonID = "M3_L3";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "10Low";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 50f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T3";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L4":
                glbScr.lessonID = "M3_L4";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "10Mid";
                glbScr.minFreq = 20f;
                glbScr.maxFreq = 70f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T4";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L5":
                glbScr.lessonID = "M3_L5";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "10Mid";
                glbScr.minFreq = 20f;
                glbScr.maxFreq = 70f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T5";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L6":
                glbScr.lessonID = "M3_L6";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "10Mid";
                glbScr.minFreq = 20f;
                glbScr.maxFreq = 70f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T6";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L7":
                glbScr.lessonID = "M3_L7";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "10High";
                glbScr.minFreq = 50f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T7";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L8":
                glbScr.lessonID = "M3_L8";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "10High";
                glbScr.minFreq = 50f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T8";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L9":
                glbScr.lessonID = "M3_L9";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "10High";
                glbScr.minFreq = 50f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T9";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L10":
                glbScr.lessonID = "M3_L10";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "10";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T10";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L11":
                glbScr.lessonID = "M3_L11";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "10";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T11";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L12":
                glbScr.lessonID = "M3_L12";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "10";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M3_T12";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L13":
                glbScr.lessonID = "M3_L13";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "10Low";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 50f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T13";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L14":
                glbScr.lessonID = "M3_L14";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "10Low";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 50f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T14";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L15":
                glbScr.lessonID = "M3_L15";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "10Low";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 50f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T15";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L16":
                glbScr.lessonID = "M3_L16";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "10Mid";
                glbScr.minFreq = 20f;
                glbScr.maxFreq = 70f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T16";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L17":
                glbScr.lessonID = "M3_L17";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "10Mid";
                glbScr.minFreq = 20f;
                glbScr.maxFreq = 70f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T17";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L18":
                glbScr.lessonID = "M3_L18";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "10Mid";
                glbScr.minFreq = 20f;
                glbScr.maxFreq = 70f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T18";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L19":
                glbScr.lessonID = "M3_L19";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "10High";
                glbScr.minFreq = 50f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T19";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L20":
                glbScr.lessonID = "M3_L20";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "10High";
                glbScr.minFreq = 50f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T20";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L21":
                glbScr.lessonID = "M3_L21";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "10High";
                glbScr.minFreq = 50f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "Y2EQ_T21";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L22":
                glbScr.lessonID = "M3_L22";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "10";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T22";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L23":
                glbScr.lessonID = "M3_L23";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "10";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T23";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M3_L24":
                glbScr.lessonID = "M3_L24";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "10";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M3_T24";
                glbScr.canHalfMark = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
        }
    }

    void CurrentEqClick_M5()
    {
        switch (glbScr.currentEqMod)
        {
            case "M5_L1":
                glbScr.lessonID = "M5EQ_M1";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "28Low";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 200f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T1";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L2":
                glbScr.lessonID = "M5EQ_M2";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "28Low";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 200f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T2";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L3":
                glbScr.lessonID = "M5EQ_M3";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "28Low";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 200f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T3";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L4":
                glbScr.lessonID = "M5EQ_M4";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "28Mid";
                glbScr.minFreq = 190.01f;
                glbScr.maxFreq = 290f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T4";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L5":
                glbScr.lessonID = "M5EQ_M5";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "28Mid";
                glbScr.minFreq = 190.01f;
                glbScr.maxFreq = 290f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T5";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L6":
                glbScr.lessonID = "M5EQ_M6";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "28Mid";
                glbScr.minFreq = 190.01f;
                glbScr.maxFreq = 290f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T6";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L7":
                glbScr.lessonID = "M5EQ_M7";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "28High";
                glbScr.minFreq = 280f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T7";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L8":
                glbScr.lessonID = "M5EQ_M8";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "28High";
                glbScr.minFreq = 280f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T8";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L9":
                glbScr.lessonID = "M5EQ_M9";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "28High";
                glbScr.minFreq = 280f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T9";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L10":
                glbScr.lessonID = "M5EQ_M10";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "28";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T10";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L11":
                glbScr.lessonID = "M5EQ_M11";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "28";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T11";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L12":
                glbScr.lessonID = "M5EQ_M12";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "28";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M5EQ_T12";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L13":
                glbScr.lessonID = "M5EQ_M13";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "28Low";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 200f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T13";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L14":
                glbScr.lessonID = "M5EQ_M14";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "28Low";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 200f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T14";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L15":
                glbScr.lessonID = "M5EQ_M15";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "28Low";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 200f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T15";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L16":
                glbScr.lessonID = "M5EQ_M16";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "28Mid";
                glbScr.minFreq = 190.01f;
                glbScr.maxFreq = 290f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T16";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L17":
                glbScr.lessonID = "M5EQ_M17";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "28Mid";
                glbScr.minFreq = 190.01f;
                glbScr.maxFreq = 290f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T17";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L18":
                glbScr.lessonID = "M5EQ_M18";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "28Mid";
                glbScr.minFreq = 190.01f;
                glbScr.maxFreq = 290f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T18";
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                glbScr.canHalfMark = true;
                SceneManager.LoadScene(5);
                break;
            case "M5_L19":
                glbScr.lessonID = "M5EQ_M19";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "28High";
                glbScr.minFreq = 280f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T19";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L20":
                glbScr.lessonID = "M5EQ_M20";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "28High";
                glbScr.minFreq = 280f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T20";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L21":
                glbScr.lessonID = "M5EQ_M21";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "28High";
                glbScr.minFreq = 280f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T21";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L22":
                glbScr.lessonID = "M5EQ_M22";
                glbScr.cutOrBoost = "Boost";
                glbScr.anserBtnsType = "28";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T22";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L23":
                glbScr.lessonID = "M5EQ_M23";
                glbScr.cutOrBoost = "Cut";
                glbScr.anserBtnsType = "28";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T23";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
            case "M5_L24":
                glbScr.lessonID = "M5EQ_M24";
                glbScr.cutOrBoost = "Both";
                glbScr.anserBtnsType = "28";
                glbScr.minFreq = 100f;
                glbScr.maxFreq = 380f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M5EQ_T24";
                glbScr.canHalfMark = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(5);
                break;
        }
    }

    void CurrentEqClick_M6()
    {
        switch (glbScr.currentEqMod)
        {
            case "M6_L1":
                glbScr.lessonID = "M6_L1";
                glbScr.cutOrBoost = "Boost";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M6_T1";
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(11);
                break;
            case "M6_L2":
                glbScr.lessonID = "M6_L2";
                glbScr.cutOrBoost = "Cut";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M6_T2";
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(11);
                break;
            case "M6_L3":
                glbScr.lessonID = "M6_L3";
                glbScr.cutOrBoost = "Both";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "PN";
                glbScr.appTestID = "M6_T3";
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(11);
                break;
            case "M6_L4":
                glbScr.lessonID = "M6_L4";
                glbScr.cutOrBoost = "Boost";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M6_T4";
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(11);
                break;
            case "M6_L5":
                glbScr.lessonID = "M6_L5";
                glbScr.cutOrBoost = "Cut";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M6_T5";
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(11);
                break;
            case "M6_L6":
                glbScr.lessonID = "M6_L6";
                glbScr.cutOrBoost = "Both";
                glbScr.minFreq = 0f;
                glbScr.maxFreq = 100f;
                glbScr.pinkOrMusic = "MUS";
                glbScr.appTestID = "M6_T6";
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(11);
                break;
        }
    }

    void CurrentFxClick_M2()
    {
        switch (glbScr.currentEqMod)
        {
            case "M2_L1":
                glbScr.lessonID = "M2_L1";
                glbScr.anserBtnsType = "Amplitude";
                glbScr.minFx = 0f;
                glbScr.maxFx = 40f;
                glbScr.appTestID = "M2_T1";
                glbScr.canNoChange = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M2_L2":
                glbScr.lessonID = "M2_L2";
                glbScr.anserBtnsType = "Distortion";
                glbScr.minFx = 40f;
                glbScr.maxFx = 60f;
                glbScr.appTestID = "M2_T2";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M2_L3":
                glbScr.lessonID = "M2_L3";
                glbScr.anserBtnsType = "Stereo";
                glbScr.minFx = 60f;
                glbScr.maxFx = 90f;
                glbScr.appTestID = "M2_T3";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M2_L4":
                glbScr.lessonID = "M2_L4";
                glbScr.anserBtnsType = "AmpDist";
                glbScr.minFx = 0f;
                glbScr.maxFx = 60f;
                glbScr.appTestID = "M2_T4";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M2_L5":
                glbScr.lessonID = "M2_L5";
                glbScr.anserBtnsType = "DistStereo";
                glbScr.minFx = 40f;
                glbScr.maxFx = 90f;
                glbScr.appTestID = "M2_T5";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M2_L6":
                glbScr.lessonID = "M2_L6";
                glbScr.anserBtnsType = "All";
                glbScr.minFx = 0f;
                glbScr.maxFx = 90f;
                glbScr.appTestID = "M2_T6";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
        }
    }

    void CurrentFxClick_M4()
    {
        switch (glbScr.currentEqMod)
        {
            case "M4_L1":
                glbScr.lessonID = "M4_L1";
                glbScr.anserBtnsType = "Amplitude";
                glbScr.minFx = 0f;
                glbScr.maxFx = 40f;
                glbScr.appTestID = "M4_T1";
                glbScr.canNoChange = false;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M4_L2":
                glbScr.lessonID = "M4_L2";
                glbScr.anserBtnsType = "Distortion";
                glbScr.minFx = 40f;
                glbScr.maxFx = 60f;
                glbScr.appTestID = "M4_T2";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M4_L3":
                glbScr.lessonID = "M4_L3";
                glbScr.anserBtnsType = "Stereo";
                glbScr.minFx = 60f;
                glbScr.maxFx = 90f;
                glbScr.appTestID = "M4_T3";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M4_L4":
                glbScr.lessonID = "M4_L4";
                glbScr.anserBtnsType = "AmpDist";
                glbScr.minFx = 0f;
                glbScr.maxFx = 60f;
                glbScr.appTestID = "M4_T4";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M4_L5":
                glbScr.lessonID = "M4_L5";
                glbScr.anserBtnsType = "DistStereo";
                glbScr.minFx = 40f;
                glbScr.maxFx = 90f;
                glbScr.appTestID = "M4_T5";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
            case "M4_L6":
                glbScr.lessonID = "M4_L6";
                glbScr.anserBtnsType = "All";
                glbScr.minFx = 0f;
                glbScr.maxFx = 90f;
                glbScr.appTestID = "M4_T6";
                glbScr.canNoChange = true;
                PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(10);
                break;
        }
    }
}
