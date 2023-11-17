using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class m2_lessonButtons : MonoBehaviour
{

    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    private void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }

        public void m2_Intro_Click()
    {
        glbScr.lessonID = "M2_I";
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(9);
    }
    public void m2_l1_Click()
    {
        glbScr.lessonID = "M2_L1";
        glbScr.anserBtnsType = "Amplitude";
        glbScr.minFx = 0f;
        glbScr.maxFx = 40f;
        glbScr.appTestID = "M2_T1";
        glbScr.canNoChange = true;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(10);
    }
    public void m2_l2_Click()
    {
        glbScr.lessonID = "M2_L2";
        glbScr.anserBtnsType = "Distortion";
        glbScr.minFx = 40f;
        glbScr.maxFx = 60f;
        glbScr.appTestID = "M2_T2";
        glbScr.canNoChange = true;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(10);
    }
    public void m2_l3_Click()
    {
        glbScr.lessonID = "M2_L3";
        glbScr.anserBtnsType = "Stereo";
        glbScr.minFx = 60f;
        glbScr.maxFx = 90f;
        glbScr.appTestID = "M2_T3";
        glbScr.canNoChange = true;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(10);
    }
    public void m2_l4_Click()
    {
        glbScr.lessonID = "M2_L4";
        glbScr.anserBtnsType = "AmpDist";
        glbScr.minFx = 0f;
        glbScr.maxFx = 60f;
        glbScr.appTestID = "M2_T4";
        glbScr.canNoChange = true;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(10);
    }
    public void m2_l5_Click()
    {
        glbScr.lessonID = "M2_L5";
        glbScr.anserBtnsType = "DistStereo";
        glbScr.minFx = 40f;
        glbScr.maxFx = 90f;
        glbScr.appTestID = "M2_T5";
        glbScr.canNoChange = true;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(10);
    }
    public void m2_l6_Click()
    {
        glbScr.lessonID = "M2_L6";
        glbScr.anserBtnsType = "All";
        glbScr.minFx = 0f;
        glbScr.maxFx = 90f;
        glbScr.appTestID = "M2_T6";
        glbScr.canNoChange = true;
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(10);
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(3);
    }
}
