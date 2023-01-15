using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class m4_lessonsUI : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;
    [SerializeField] private TextMeshProUGUI m1lockText;
    [SerializeField] private TextMeshProUGUI m2lockText;
    [SerializeField] private TextMeshProUGUI m3lockText;
    [SerializeField] private TextMeshProUGUI m4lockText;
    [SerializeField] private TextMeshProUGUI m5lockText;
    [SerializeField] private TextMeshProUGUI m6lockText;
    [SerializeField] Button m1btn;
    [SerializeField] Button m2btn;
    [SerializeField] Button m3btn;
    [SerializeField] Button m4btn;
    [SerializeField] Button m5btn;
    [SerializeField] Button m6btn;
    [SerializeField] TextMeshProUGUI m1scoreText;
    [SerializeField] TextMeshProUGUI m2scoreText;
    [SerializeField] TextMeshProUGUI m3scoreText;
    [SerializeField] TextMeshProUGUI m4scoreText;
    [SerializeField] TextMeshProUGUI m5scoreText;
    [SerializeField] TextMeshProUGUI m6scoreText;

    private void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        UnlockButtons();
        m1scoreText.text = "Test score " + glbScr.M4FX_T1_Score + " out of 8";
        m2scoreText.text = "Test score " + glbScr.M4FX_T2_Score + " out of 8";
        m3scoreText.text = "Test score " + glbScr.M4FX_T3_Score + " out of 8";
        m4scoreText.text = "Test score " + glbScr.M4FX_T4_Score + " out of 8";
        m5scoreText.text = "Test score " + glbScr.M4FX_T5_Score + " out of 8";
        m6scoreText.text = "Test score " + glbScr.M4FX_T6_Score + " out of 8";
    }
    void UnlockButtons()
    {
        if (glbScr.m4fx_passedTests == 0f)
        {
            m1lockText.text = "Click to begin.";
            m2lockText.text = "Locked";
            m3lockText.text = "Locked";
            m4lockText.text = "Locked";
            m5lockText.text = "Locked";
            m6lockText.text = "Locked";
            m1btn.interactable = true;
            m2btn.interactable = false;
            m3btn.interactable = false;
            m4btn.interactable = false;
            m5btn.interactable = false;
            m6btn.interactable = false;
        }
        else if (glbScr.m4fx_passedTests == 1f)
        {
            m1lockText.text = "Click to begin.";
            m2lockText.text = "Click to begin.";
            m3lockText.text = "Locked";
            m4lockText.text = "Locked";
            m5lockText.text = "Locked";
            m6lockText.text = "Locked";
            m1btn.interactable = true;
            m2btn.interactable = true;
            m3btn.interactable = false;
            m4btn.interactable = false;
            m5btn.interactable = false;
            m6btn.interactable = false;
        }
        else if (glbScr.m4fx_passedTests == 2f)
        {
            m1lockText.text = "Click to begin.";
            m2lockText.text = "Click to begin.";
            m3lockText.text = "Click to begin.";
            m4lockText.text = "Locked";
            m5lockText.text = "Locked";
            m6lockText.text = "Locked";
            m1btn.interactable = true;
            m2btn.interactable = true;
            m3btn.interactable = true;
            m4btn.interactable = false;
            m5btn.interactable = false;
            m6btn.interactable = false;
        }
        else if (glbScr.m4fx_passedTests == 3f)
        {
            m1lockText.text = "Click to begin.";
            m2lockText.text = "Click to begin.";
            m3lockText.text = "Click to begin.";
            m4lockText.text = "Click to begin.";
            m5lockText.text = "Locked";
            m6lockText.text = "Locked";
            m1btn.interactable = true;
            m2btn.interactable = true;
            m3btn.interactable = true;
            m4btn.interactable = true;
            m5btn.interactable = false;
            m6btn.interactable = false;
        }
        else if (glbScr.m4fx_passedTests == 4f)
        {
            m1lockText.text = "Click to begin.";
            m2lockText.text = "Click to begin.";
            m3lockText.text = "Click to begin.";
            m4lockText.text = "Click to begin.";
            m5lockText.text = "Click to begin.";
            m6lockText.text = "Locked";
            m1btn.interactable = true;
            m2btn.interactable = true;
            m3btn.interactable = true;
            m4btn.interactable = true;
            m5btn.interactable = true;
            m6btn.interactable = false;
        }
        else if (glbScr.m4fx_passedTests >= 5f)
        {
            m1lockText.text = "Click to begin.";
            m2lockText.text = "Click to begin.";
            m3lockText.text = "Click to begin.";
            m4lockText.text = "Click to begin.";
            m5lockText.text = "Click to begin.";
            m6lockText.text = "Click to begin.";
            m1btn.interactable = true;
            m2btn.interactable = true;
            m3btn.interactable = true;
            m4btn.interactable = true;
            m5btn.interactable = true;
            m6btn.interactable = true;
        }
        else if (glbScr.m4fx_passedTests == 5f)
        {
            m1lockText.text = "Click to begin.";
            m2lockText.text = "Click to begin.";
            m3lockText.text = "Click to begin.";
            m4lockText.text = "Click to begin.";
            m5lockText.text = "Click to begin.";
            m6lockText.text = "Click to begin.";
            m1btn.interactable = true;
            m2btn.interactable = true;
            m3btn.interactable = true;
            m4btn.interactable = true;
            m5btn.interactable = true;
            m6btn.interactable = true;
        }
    }
}

