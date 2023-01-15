using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class m5_lessonButtons : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    private void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }

    //PINK NOISE
    public void m5_l1_Click() 
    {
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
    }
    public void m5_l2_Click()
    {
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
    }
    public void m5_l3_Click()
    {
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
    }
    public void m5_l4_Click()
    {
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
    }
    public void m5_l5_Click()
    {
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
    }
    public void m5_l6_Click()
    {
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
    }
    public void m5_l7_Click()
    {
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
    }
    public void m5_l8_Click()
    {
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
    }
    public void m5_l9_Click()
    {
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
    }
    public void m5_l10_Click()
    {
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
    }
    public void m5_l11_Click()
    {
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
    }
    public void m5_l12_Click()
    {
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
    }

    //MUSIC
    public void m5_l13_Click()
    {
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
    }
    public void m5_l14_Click()
    {
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
    }
    public void m5_l15_Click()
    {
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
    }
    public void m5_l16_Click()
    {
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
    }
    public void m5_l17_Click()
    {
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
    }
    public void m5_l18_Click()
    {
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
    }
    public void m5_l19_Click()
    {
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
    }
    public void m5_l20_Click()
    {
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
    }
    public void m5_l21_Click()
    {
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
    }
    public void m5_l22_Click()
    {
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
    }
    public void m5_l23_Click()
    {
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
    }
    public void m5_l24_Click()
    {
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
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(3);
    }
}