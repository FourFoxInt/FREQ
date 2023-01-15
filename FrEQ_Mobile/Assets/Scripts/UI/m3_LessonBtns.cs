using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class m3_LessonBtns : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    private void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }

    //PINK NOISE
    public void m3_l1_Click()
    {
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
    }
    public void m3_l2_Click()
    {
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
    }
    public void m3_l3_Click()
    {
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
    }
    public void m3_l4_Click()
    {
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
    }
    public void m3_l5_Click()
    {
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
    }
    public void m3_l6_Click()
    {
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
    }
    public void m3_l7_Click()
    {
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
    }
    public void m3_l8_Click()
    {
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
    }
    public void m3_l9_Click()
    {
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
    }
    public void m3_l10_Click()
    {
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
    }
    public void m3_l11_Click()
    {
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
    }
    public void m3_l12_Click()
    {
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
    }

    //MUSIC
    public void m3_l13_Click()
    {
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
    }
    public void m3_l14_Click()
    {
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
    }
    public void m3_l15Click()
    {
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
    }
    public void m3_l16_Click()
    {
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
    }
    public void m3_l17_Click()
    {
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
    }
    public void m3_l18_Click()
    {
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
    }
    public void m3_l19_Click()
    {
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
    }
    public void m3_l20_Click()
    {
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
    }
    public void m3_l21_Click()
    {
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
    }
    public void m3_l22_Click()
    {
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
    }
    public void m3_l23_Click()
    {
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
    }
    public void m3_l24_Click()
    {
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
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(3);
    }
}
