using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class Practice : MonoBehaviour
{
    private Globals glbScr;
    private ModuleController modCon;
    private NetworkGlobals netGlbScr;

    //COLOURS
    [SerializeField] private Color selected;
    [SerializeField] private Color notSelected;
    [SerializeField] private Color playing;
    [SerializeField] private Color waiting;

    //Cut Boost Buttons
    [SerializeField] private GameObject cutBoostBtns;
    [SerializeField] private GameObject cutBtn;
    [SerializeField] private GameObject boostBtn;
    [SerializeField] private bool cutBtnSel;
    [SerializeField] private bool boostBtnSel;

    //Music dropdown
    [SerializeField] GameObject audioDropdown;
    [SerializeField] TMP_Dropdown genreDropdown;
    [SerializeField] private int genreValue;

    //Freq Buttons
    [SerializeField] private GameObject lowBtn;[SerializeField] private GameObject midBtn;[SerializeField] private GameObject highBtn;
    [SerializeField] private GameObject h31Btn;[SerializeField] private GameObject h40Btn;[SerializeField] private GameObject h50Btn;
    [SerializeField] private GameObject h63Btn;[SerializeField] private GameObject h80Btn;[SerializeField] private GameObject h100Btn;
    [SerializeField] private GameObject h125Btn;[SerializeField] private GameObject h160Btn;[SerializeField] private GameObject h200Btn;
    [SerializeField] private GameObject h250Btn;[SerializeField] private GameObject h315Btn;[SerializeField] private GameObject h400Btn;
    [SerializeField] private GameObject h500Btn;[SerializeField] private GameObject h630Btn;[SerializeField] private GameObject h800Btn;
    [SerializeField] private GameObject k1Btn;[SerializeField] private GameObject k125Btn;[SerializeField] private GameObject k16Btn;
    [SerializeField] private GameObject k2Btn;[SerializeField] private GameObject k25Btn;[SerializeField] private GameObject k315Btn;
    [SerializeField] private GameObject k4Btn;[SerializeField] private GameObject k5Btn;[SerializeField] private GameObject k63Btn;
    [SerializeField] private GameObject k8Btn;[SerializeField] private GameObject k10Btn;[SerializeField] private GameObject k12500Btn;
    [SerializeField] private GameObject k16000Btn;

    [SerializeField] private GameObject buttonHolder;
    [SerializeField] private int buttonCount;

    //Freq Bools
    [SerializeField] private bool lowBtnSel;[SerializeField] private bool midBtnSel;[SerializeField] private bool highBtnSel;
    [SerializeField] private bool h31BtnSel;[SerializeField] private bool h40BtnSel;[SerializeField] private bool h50BtnSel;
    [SerializeField] private bool h63BtnSel;[SerializeField] private bool h80BtnSel;[SerializeField] private bool h100BtnSel;
    [SerializeField] private bool h125BtnSel;[SerializeField] private bool h160BtnSel;[SerializeField] private bool h200BtnSel;
    [SerializeField] private bool h250BtnSel;[SerializeField] private bool h315BtnSel;[SerializeField] private bool h400BtnSel;
    [SerializeField] private bool h500BtnSel;[SerializeField] private bool h630BtnSel;[SerializeField] private bool h800BtnSel;
    [SerializeField] private bool k1BtnSel;[SerializeField] private bool k125BtnSel;[SerializeField] private bool k16BtnSel;
    [SerializeField] private bool k2BtnSel;[SerializeField] private bool k25BtnSel;[SerializeField] private bool k315BtnSel;
    [SerializeField] private bool k4BtnSel;[SerializeField] private bool k5BtnSel;[SerializeField] private bool k63BtnSel;
    [SerializeField] private bool k8BtnSel;[SerializeField] private bool k10BtnSel;[SerializeField] private bool k12500BtnSel;
    [SerializeField] private bool k16000BtnSel;

    //UI
    [SerializeField] private TextMeshProUGUI playBtnText;
    [SerializeField] private Button playBtn;
    [SerializeField] private Button submitBtn;
    public string title;
    public string desc;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI previousText;
    [SerializeField] private TextMeshProUGUI playText;

    //Verification
    private bool freqSelected = false;
    private bool cutBoostSelected = false;

    //Choices
    [SerializeField] private string userCutBoost;
    [SerializeField] private string userFreqString;
    [SerializeField] private string ranCutBoostString;
    [SerializeField] private string ranFreqString;
    [SerializeField] private float ranFreq;
    [SerializeField] private string curAnsString;
    [SerializeField] private float previousAns;

    //Audio
    public float userFreq;
    private string selCb;
    FMOD.Studio.EventInstance fmodEvent;
    public bool isPlaying = false;
    public bool eqOn = false;
    public float gain = 1.5f;
    [SerializeField] private bool firstPlay = true;
    [SerializeField] private AudioSource audSource;
    [SerializeField] private AudioClip newExClip;

    //RESULTS
    private int attempts = 0;
    private int correct = 0;
    [SerializeField] private GameObject rightGO;
    [SerializeField] private GameObject wrongGO;

    private void Start()
    {
        freqSelected = false;
        modCon = GameObject.Find("Canvas_Main").GetComponent<ModuleController>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();

        ButtonActivations();
        CutBoostBtnActivation();
        MusicDropdownActivation();

        title = glbScr.currentTitle;
        desc = glbScr.currentDesc;

        titleText.text = title;
        descText.text = desc;
    }
    private void Update()
    {
        GenreChange();

        if (!isPlaying)
        {
            playBtn.GetComponent<Button>().interactable = true;
            
        }
        else if (isPlaying)
        {
            playBtn.GetComponent<Button>().interactable = false;
        }

        if(glbScr.cutOrBoost == "Cut")
        {
            gain = 2.5f;
            curAnsString = ranFreqString;
        }
        else if (glbScr.cutOrBoost == "Boost")
        {
            gain = 1.5f;
            curAnsString = ranFreqString;
        }
        else if(glbScr.cutOrBoost == "Both")
        {
            curAnsString = ranCutBoostString + " " + ranFreqString;
        }
        scoreText.text = correct.ToString() + " out of " + attempts.ToString();
        titleText.text = title;
        descText.text = desc;

        if (isPlaying)
        {
            submitBtn.GetComponent<Button>().interactable = false;
        }
        else if (!isPlaying && freqSelected)
        {
            submitBtn.GetComponent<Button>().interactable = true;
        }
        else if (!isPlaying && !freqSelected)
        {
            submitBtn.GetComponent<Button>().interactable = false;
        }
    }
    void RandomiseFreq()
    {
        float ran = Random.Range(glbScr.minFreq, glbScr.maxFreq);

        //Ten band freqs
        if (ran >= 0 && ran <= 10)
        {
            ranFreq = 1;
            ranFreqString = "31 Hz";
        }
        else if (ran >= 10.01 && ran <= 20)
        {
            ranFreq = 4;
            ranFreqString = "63 Hz";
        }
        else if (ran >= 20.01 && ran <= 30)
        {
            ranFreq = 7;
            ranFreqString = "125 Hz";
        }
        else if (ran >= 30.01 && ran <= 40)
        {
            ranFreq = 10;
            ranFreqString = "250 Hz";
        }
        else if (ran >= 40.01 && ran <= 50)
        {
            ranFreq = 13;
            ranFreqString = "500 Hz";
        }
        else if (ran >= 50.01 && ran <= 60)
        {
            ranFreq = 16;
            ranFreqString = "1 kHz";
        }
        else if (ran >= 60.01 && ran <= 70)
        {
            ranFreq = 19;
            ranFreqString = "2 kHz";
        }
        else if (ran >= 70.01 && ran <= 80)
        {
            ranFreq = 22;
            ranFreqString = "4 kHz";
        }
        else if (ran >= 80.01 && ran <= 90)
        {
            ranFreq = 25;
            ranFreqString = "8 kHz";
        }
        else if (ran >= 90.01 && ran <= 100)
        {
            ranFreq = 28;
            ranFreqString = "16 kHz";
        }

        //28 Band Freqs
        if (ran >= 100 && ran <= 110)
        {
            ranFreq = 1;
            ranFreqString = "31 Hz";
        }
        else if (ran >= 110.01 && ran <= 120)
        {
            ranFreq = 2;
            ranFreqString = "40 Hz";
        }
        else if (ran >= 120.01 && ran <= 130)
        {
            ranFreq = 3;
            ranFreqString = "50 Hz";
        }
        else if (ran >= 130.01 && ran <= 140)
        {
            ranFreq = 4;
            ranFreqString = "63 Hz";
        }
        else if (ran >= 140.01 && ran <= 150)
        {
            ranFreq = 5;
            ranFreqString = "80 Hz";
        }
        else if (ran >= 150.01 && ran <= 160)
        {
            ranFreq = 6;
            ranFreqString = "100 Hz";
        }
        else if (ran >= 160.01 && ran <= 170)
        {
            ranFreq = 7;
            ranFreqString = "125 Hz";
        }
        else if (ran >= 170.01 && ran <= 180)
        {
            ranFreq = 8;
            ranFreqString = "160 Hz";
        }
        else if (ran >= 180.01 && ran <= 190)
        {
            ranFreq = 9;
            ranFreqString = "200 Hz";
        }
        else if (ran >= 190.01 && ran <= 200)
        {
            ranFreq = 10;
            ranFreqString = "250 Hz";
        }
        else if (ran >= 200.01 && ran <= 210)
        {
            ranFreq = 11;
            ranFreqString = "315 Hz";
        }
        else if (ran >= 210.01 && ran <= 220)
        {
            ranFreq = 12;
            ranFreqString = "400 Hz";
        }
        else if (ran >= 220.01 && ran <= 230)
        {
            ranFreq = 13;
            ranFreqString = "500 Hz";
        }
        else if (ran >= 230.01 && ran <= 240)
        {
            ranFreq = 14;
            ranFreqString = "630 Hz";
        }
        else if (ran >= 240.01 && ran <= 250)
        {
            ranFreq = 15;
            ranFreqString = "800 Hz";
        }
        else if (ran >= 250.01 && ran <= 260)
        {
            ranFreq = 16;
            ranFreqString = "1 kHz";
        }
        else if (ran >= 260.01 && ran <= 270)
        {
            ranFreq = 17;
            ranFreqString = "1.25 kHz";
        }
        else if (ran >= 270.01 && ran <= 280)
        {
            ranFreq = 18;
            ranFreqString = "1.6 kHz";
        }
        else if (ran >= 280 && ran <= 290)
        {
            ranFreq = 19;
            ranFreqString = "2 kHz";
        }
        else if (ran >= 290.01 && ran <= 300)
        {
            ranFreq = 20;
            ranFreqString = "2.5 kHz";
        }
        else if (ran >= 300.01 && ran <= 310)
        {
            ranFreq = 21;
            ranFreqString = "3.15 kHz";
        }
        else if (ran >= 310.01 && ran <= 320)
        {
            ranFreq = 22;
            ranFreqString = "4 kHz";
        }
        else if (ran >= 320.01 && ran <= 330)
        {
            ranFreq = 23;
            ranFreqString = "5 kHz";
        }
        else if (ran >= 330.01 && ran <= 340)
        {
            ranFreq = 24;
            ranFreqString = "6.3 kHz";
        }
        else if (ran >= 340.01 && ran <= 350)
        {
            ranFreq = 25;
            ranFreqString = "8 kHz";
        }
        else if (ran >= 350.01 && ran <= 360)
        {
            ranFreq = 26;
            ranFreqString = "10 kHz";
        }
        else if (ran >= 360.01 && ran <= 370)
        {
            ranFreq = 27;
            ranFreqString = "12.5 kHz";
        }
        else if (ran >= 370.01 && ran <= 380)
        {
            ranFreq = 28;
            ranFreqString = "16 kHz";
        }

        //Beginner Freqs
        else if (ran >= 380.01 && ran <= 390)
        {
            ranFreq = 5;
            ranFreqString = "80 Hz (Low)";
        }
        else if (ran >= 390.01 && ran <= 400)
        {
            ranFreq = 19;
            ranFreqString = "2 kHz (Mid)";
        }
        else if (ran >= 400.01 && ran <= 410)
        {
            ranFreq = 25;
            ranFreqString = "8 kHz (High)";
        }
        if (ranFreq == previousAns)
        {
            RandomiseFreq();
        }
    }
    void RandonCutBoost()
    {
        float ran = Random.Range(0, 20);
        if (ran >= 0 && ran <= 10)
        {
            selCb = "Cut";
            gain = 2.5f;
        }
        else if (ran >= 10.01 && ran <= 20)
        {
            selCb = "Boost";
            gain = 1.5f;
        }
    }
    void ButtonActivations()
    {
        if (glbScr.anserBtnsType == "Beginner")
        {
            lowBtn.SetActive(true); midBtn.SetActive(true); highBtn.SetActive(true);
            h31Btn.SetActive(false); h40Btn.SetActive(false); h50Btn.SetActive(false);
            h63Btn.SetActive(false); h80Btn.SetActive(false); h100Btn.SetActive(false);
            h125Btn.SetActive(false); h160Btn.SetActive(false); h200Btn.SetActive(false);
            h250Btn.SetActive(false); h315Btn.SetActive(false); h400Btn.SetActive(false);
            h500Btn.SetActive(false); h630Btn.SetActive(false); h800Btn.SetActive(false);
            k1Btn.SetActive(false); k125Btn.SetActive(false); k16Btn.SetActive(false);
            k2Btn.SetActive(false); k25Btn.SetActive(false); k315Btn.SetActive(false);
            k4Btn.SetActive(false); k5Btn.SetActive(false); k63Btn.SetActive(false);
            k8Btn.SetActive(false); k10Btn.SetActive(false); k12500Btn.SetActive(false);
            k16000Btn.SetActive(false);
        }
        if (glbScr.anserBtnsType == "10Low")
        {
            lowBtn.SetActive(false); midBtn.SetActive(false); highBtn.SetActive(false);
            h31Btn.SetActive(true); h40Btn.SetActive(false); h50Btn.SetActive(false);
            h63Btn.SetActive(true); h80Btn.SetActive(false); h100Btn.SetActive(false);
            h125Btn.SetActive(true); h160Btn.SetActive(false); h200Btn.SetActive(false);
            h250Btn.SetActive(true); h315Btn.SetActive(false); h400Btn.SetActive(false);
            h500Btn.SetActive(true); h630Btn.SetActive(false); h800Btn.SetActive(false);
            k1Btn.SetActive(false); k125Btn.SetActive(false); k16Btn.SetActive(false);
            k2Btn.SetActive(false); k25Btn.SetActive(false); k315Btn.SetActive(false);
            k4Btn.SetActive(false); k5Btn.SetActive(false); k63Btn.SetActive(false);
            k8Btn.SetActive(false); k10Btn.SetActive(false); k12500Btn.SetActive(false);
            k16000Btn.SetActive(false);
        }
        if (glbScr.anserBtnsType == "10Mid")
        {
            lowBtn.SetActive(false); midBtn.SetActive(false); highBtn.SetActive(false);
            h31Btn.SetActive(false); h40Btn.SetActive(false); h50Btn.SetActive(false);
            h63Btn.SetActive(false); h80Btn.SetActive(false); h100Btn.SetActive(false);
            h125Btn.SetActive(true); h160Btn.SetActive(false); h200Btn.SetActive(false);
            h250Btn.SetActive(true); h315Btn.SetActive(false); h400Btn.SetActive(false);
            h500Btn.SetActive(true); h630Btn.SetActive(false); h800Btn.SetActive(false);
            k1Btn.SetActive(true); k125Btn.SetActive(false); k16Btn.SetActive(false);
            k2Btn.SetActive(true); k25Btn.SetActive(false); k315Btn.SetActive(false);
            k4Btn.SetActive(false); k5Btn.SetActive(false); k63Btn.SetActive(false);
            k8Btn.SetActive(false); k10Btn.SetActive(false); k12500Btn.SetActive(false);
            k16000Btn.SetActive(false);
        }
        if (glbScr.anserBtnsType == "10High")
        {
            lowBtn.SetActive(false); midBtn.SetActive(false); highBtn.SetActive(false);
            h31Btn.SetActive(false); h40Btn.SetActive(false); h50Btn.SetActive(false);
            h63Btn.SetActive(false); h80Btn.SetActive(false); h100Btn.SetActive(false);
            h125Btn.SetActive(false); h160Btn.SetActive(false); h200Btn.SetActive(false);
            h250Btn.SetActive(false); h315Btn.SetActive(false); h400Btn.SetActive(false);
            h500Btn.SetActive(false); h630Btn.SetActive(false); h800Btn.SetActive(false);
            k1Btn.SetActive(true); k125Btn.SetActive(false); k16Btn.SetActive(false);
            k2Btn.SetActive(true); k25Btn.SetActive(false); k315Btn.SetActive(false);
            k4Btn.SetActive(true); k5Btn.SetActive(false); k63Btn.SetActive(false);
            k8Btn.SetActive(true); k10Btn.SetActive(false); k12500Btn.SetActive(false);
            k16000Btn.SetActive(true);
        }
        if (glbScr.anserBtnsType == "10")
        {
            lowBtn.SetActive(false); midBtn.SetActive(false); highBtn.SetActive(false);
            h31Btn.SetActive(true); h40Btn.SetActive(false); h50Btn.SetActive(false);
            h63Btn.SetActive(true); h80Btn.SetActive(false); h100Btn.SetActive(false);
            h125Btn.SetActive(true); h160Btn.SetActive(false); h200Btn.SetActive(false);
            h250Btn.SetActive(true); h315Btn.SetActive(false); h400Btn.SetActive(false);
            h500Btn.SetActive(true); h630Btn.SetActive(false); h800Btn.SetActive(false);
            k1Btn.SetActive(true); k125Btn.SetActive(false); k16Btn.SetActive(false);
            k2Btn.SetActive(true); k25Btn.SetActive(false); k315Btn.SetActive(false);
            k4Btn.SetActive(true); k5Btn.SetActive(false); k63Btn.SetActive(false);
            k8Btn.SetActive(true); k10Btn.SetActive(false); k12500Btn.SetActive(false);
            k16000Btn.SetActive(true);
        }
        if (glbScr.anserBtnsType == "28Low")
        {
            lowBtn.SetActive(false); midBtn.SetActive(false); highBtn.SetActive(false);
            h31Btn.SetActive(true); h40Btn.SetActive(true); h50Btn.SetActive(true);
            h63Btn.SetActive(true); h80Btn.SetActive(true); h100Btn.SetActive(true);
            h125Btn.SetActive(true); h160Btn.SetActive(true); h200Btn.SetActive(true);
            h250Btn.SetActive(true); h315Btn.SetActive(false); h400Btn.SetActive(false);
            h500Btn.SetActive(false); h630Btn.SetActive(false); h800Btn.SetActive(false);
            k1Btn.SetActive(false); k125Btn.SetActive(false); k16Btn.SetActive(false);
            k2Btn.SetActive(false); k25Btn.SetActive(false); k315Btn.SetActive(false);
            k4Btn.SetActive(false); k5Btn.SetActive(false); k63Btn.SetActive(false);
            k8Btn.SetActive(false); k10Btn.SetActive(false); k12500Btn.SetActive(false);
            k16000Btn.SetActive(false);
        }
        if (glbScr.anserBtnsType == "28Mid")
        {
            lowBtn.SetActive(false); midBtn.SetActive(false); highBtn.SetActive(false);
            h31Btn.SetActive(false); h40Btn.SetActive(false); h50Btn.SetActive(false);
            h63Btn.SetActive(false); h80Btn.SetActive(false); h100Btn.SetActive(false);
            h125Btn.SetActive(false); h160Btn.SetActive(false); h200Btn.SetActive(false);
            h250Btn.SetActive(true); h315Btn.SetActive(true); h400Btn.SetActive(true);
            h500Btn.SetActive(true); h630Btn.SetActive(true); h800Btn.SetActive(true);
            k1Btn.SetActive(true); k125Btn.SetActive(true); k16Btn.SetActive(true);
            k2Btn.SetActive(true); k25Btn.SetActive(false); k315Btn.SetActive(false);
            k4Btn.SetActive(false); k5Btn.SetActive(false); k63Btn.SetActive(false);
            k8Btn.SetActive(false); k10Btn.SetActive(false); k12500Btn.SetActive(false);
            k16000Btn.SetActive(false);
        }
        if (glbScr.anserBtnsType == "28High")
        {
            lowBtn.SetActive(false); midBtn.SetActive(false); highBtn.SetActive(false);
            h31Btn.SetActive(false); h40Btn.SetActive(false); h50Btn.SetActive(false);
            h63Btn.SetActive(false); h80Btn.SetActive(false); h100Btn.SetActive(false);
            h125Btn.SetActive(false); h160Btn.SetActive(false); h200Btn.SetActive(false);
            h250Btn.SetActive(false); h315Btn.SetActive(false); h400Btn.SetActive(false);
            h500Btn.SetActive(false); h630Btn.SetActive(false); h800Btn.SetActive(false);
            k1Btn.SetActive(false); k125Btn.SetActive(false); k16Btn.SetActive(false);
            k2Btn.SetActive(true); k25Btn.SetActive(true); k315Btn.SetActive(true);
            k4Btn.SetActive(true); k5Btn.SetActive(true); k63Btn.SetActive(true);
            k8Btn.SetActive(true); k10Btn.SetActive(true); k12500Btn.SetActive(true);
            k16000Btn.SetActive(true);
        }
        if (glbScr.anserBtnsType == "28")
        {
            lowBtn.SetActive(false); midBtn.SetActive(false); highBtn.SetActive(false);
            h31Btn.SetActive(true); h40Btn.SetActive(true); h50Btn.SetActive(true);
            h63Btn.SetActive(true); h80Btn.SetActive(true); h100Btn.SetActive(true);
            h125Btn.SetActive(true); h160Btn.SetActive(true); h200Btn.SetActive(true);
            h250Btn.SetActive(true); h315Btn.SetActive(true); h400Btn.SetActive(true);
            h500Btn.SetActive(true); h630Btn.SetActive(true); h800Btn.SetActive(true);
            k1Btn.SetActive(true); k125Btn.SetActive(true); k16Btn.SetActive(true);
            k2Btn.SetActive(true); k25Btn.SetActive(true); k315Btn.SetActive(true);
            k4Btn.SetActive(true); k5Btn.SetActive(true); k63Btn.SetActive(true);
            k8Btn.SetActive(true); k10Btn.SetActive(true); k12500Btn.SetActive(true);
            k16000Btn.SetActive(true);
        }

        foreach (Transform child in buttonHolder.transform)
        {
            if (child.gameObject.activeSelf)
                buttonCount++;
        }

        buttonHolder.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonHolder.transform.GetComponent<RectTransform>().sizeDelta.x, 110 * buttonCount);
    }
    void CutBoostBtnActivation()
    {
        if (glbScr.cutOrBoost == "Both")
        {
            cutBoostBtns.SetActive(true);
        }
        else if (glbScr.cutOrBoost == "Boost" || glbScr.cutOrBoost == "Cut")
        {
            cutBoostBtns.SetActive(false);
        }
    }
    void MusicDropdownActivation()
    {
        if (glbScr.pinkOrMusic == "PN")
        {
            audioDropdown.SetActive(false);
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            audioDropdown.SetActive(true);
        }
    }
    public void GenreDropdown()
    {
        genreValue = genreDropdown.value;
        fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        firstPlay = true;
    }
    public void cutBtnClick()
    {
        cutBtnSel = true;
        boostBtnSel = false;
        cutBtn.GetComponent<Image>().color = selected;
        boostBtn.GetComponent<Image>().color = notSelected;
        userCutBoost = "Cut";
        cutBoostSelected = true;
    }
    public void boostBtnClick()
    {
        cutBtnSel = false;
        boostBtnSel = true;
        cutBtn.GetComponent<Image>().color = notSelected;
        boostBtn.GetComponent<Image>().color = selected;
        userCutBoost = "Boost";
        cutBoostSelected = true;
    }

    /// <summary>
    /// FREQ BUTTON FUNCTIONS
    /// </summary>
    public void lowBtnClick()
    {
        lowBtnSel = true;
        midBtnSel = false;
        highBtnSel = false;
        lowBtn.GetComponent<Image>().color = selected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        userFreq = 5;
        userFreqString = "80 Hz (Low)";
        freqSelected = true;
    }
    public void midBtnClick()
    {
        lowBtnSel = false;
        midBtnSel = true;
        highBtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = selected;
        highBtn.GetComponent<Image>().color = notSelected;
        userFreq = 19;
        userFreqString = "2 kHz (Mid)";
        freqSelected = true;
    }
    public void highBtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = true;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = selected;
        userFreq = 25;
        userFreqString = "8 kHz (High)";
        freqSelected = true;
    }
    public void h31BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = true;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = selected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 1;
        userFreqString = "31 Hz";
        freqSelected = true;
    }
    public void h40BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = true;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = selected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 2;
        userFreqString = "40 Hz";
        freqSelected = true;
    }
    public void h50BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = true;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = selected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 3;
        userFreqString = "50 Hz";
        freqSelected = true;
    }
    public void h63BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = true;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = selected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 4;
        userFreqString = "63 Hz";
        freqSelected = true;
    }
    public void h80BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = true;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = selected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 5;
        userFreqString = "80 Hz";
        freqSelected = true;
    }
    public void h100BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = true;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = selected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 6;
        userFreqString = "100 Hz";
        freqSelected = true;
    }
    public void h125BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = true;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = selected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 7;
        userFreqString = "125 Hz";
        freqSelected = true;
    }
    public void h160BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = true;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = selected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 8;
        userFreqString = "160 Hz";
        freqSelected = true;
    }
    public void h200BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = true;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = selected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 9;
        userFreqString = "200 Hz";
        freqSelected = true;
    }
    public void h250BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = true;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = selected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 10;
        userFreqString = "250 Hz";
        freqSelected = true;
    }
    public void h315BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = true;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = selected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 11;
        userFreqString = "315 Hz";
        freqSelected = true;
    }
    public void h400BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = true;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = selected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 12;
        userFreqString = "400 Hz";
        freqSelected = true;
    }
    public void h500BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = true;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = selected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 13;
        userFreqString = "500 Hz";
        freqSelected = true;
    }
    public void h630BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = true;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = selected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 14;
        userFreqString = "630 Hz";
        freqSelected = true;
    }
    public void h800BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = true;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = selected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 15;
        userFreqString = "800 Hz";
        freqSelected = true;
    }
    public void k1BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = true;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = selected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 16;
        userFreqString = "1 kHz";
        freqSelected = true;
    }
    public void k125BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = true;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = selected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 17;
        userFreqString = "1.25 kHz";
        freqSelected = true;
    }
    public void k16BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = true;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = selected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 18;
        userFreqString = "1.6 kHz";
        freqSelected = true;
    }
    public void k2BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = true;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = selected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 19;
        userFreqString = "2 kHz";
        freqSelected = true;
    }
    public void k25BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = true;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = selected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 20;
        userFreqString = "2.5 Hz";
        freqSelected = true;
    }
    public void k315BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = true;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = selected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 21;
        userFreqString = "3.16 kHz";
        freqSelected = true;
    }
    public void k4BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = true;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = selected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 22;
        userFreqString = "4 kHz";
        freqSelected = true;
    }
    public void k5BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = true;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = selected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 1;
        userFreqString = "31 Hz";
        freqSelected = true;
    }
    public void k63BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = true;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = selected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 24;
        userFreqString = "6.3 kHz";
        freqSelected = true;
    }
    public void k8BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = true;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = selected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 25;
        userFreqString = "8 kHz";
        freqSelected = true;
    }
    public void k10BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = true;
        k12500BtnSel = false;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = selected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 26;
        userFreqString = "10 kHz";
        freqSelected = true;
    }
    public void k12500BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = true;
        k16000BtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = selected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        userFreq = 27;
        userFreqString = "12.5 kHz";
        freqSelected = true;
    }
    public void k16000BtnClick()
    {
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = true;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = selected;
        userFreq = 28;
        userFreqString = "16 kHz";
        freqSelected = true;
    }
    public void PlayButtonClick()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayExercise());
        }
    }
    IEnumerator PlayExercise()
    {
        modCon.appIsPlaying = true;
        if (glbScr.pinkOrMusic == "MUS")
        {
            genreDropdown.enabled = false;
        }

        if (firstPlay)
        {
            RandomiseFreq();
            if (glbScr.cutOrBoost == "Both")
            {
                RandonCutBoost();
            }
        }

        isPlaying = true;
        playBtn.GetComponent<Image>().color = playing;
        audSource.clip = newExClip;
        audSource.loop = false;
        audSource.Play();

        yield return new WaitForSeconds(2);

        audSource.Stop();

        if (firstPlay)
        {
            if (glbScr.pinkOrMusic == "PN")
            {
                fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/pn");
            }
            else if (glbScr.pinkOrMusic == "MUS")
            {
                fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/music");
            }

            fmodEvent.setParameterByName("freq", ranFreq);
            fmodEvent.start();
            isPlaying = true;
        }
        else if (!firstPlay)
        {
            fmodEvent.setPaused(false);
            isPlaying = true;
        }
        firstPlay = false;
        fmodEvent.setParameterByName("freq", ranFreq);
        fmodEvent.setParameterByName("gain", 0);

        if (glbScr.pinkOrMusic == "PN")
        {
            yield return new WaitForSeconds(3);
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            yield return new WaitForSeconds(4);
        }
        
        eqOn = true;
        fmodEvent.setParameterByName("freq", ranFreq);
        fmodEvent.setParameterByName("gain", gain);

        if (glbScr.pinkOrMusic == "PN")
        {
            yield return new WaitForSeconds(3);
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            yield return new WaitForSeconds(4);
        }
        fmodEvent.setParameterByName("freq", ranFreq);
        fmodEvent.setParameterByName("gain", 0);
        eqOn = false;
        yield return new WaitForSeconds(3);
        fmodEvent.setPaused(true);
        isPlaying = false;
        playBtn.GetComponent<Image>().color = waiting;
        if (glbScr.pinkOrMusic == "MUS")
        {
            genreDropdown.enabled = true;
        }
        modCon.appIsPlaying = false;
    }
    public void SubmitBtnClick()
    {
        if (glbScr.cutOrBoost == "Cut" || glbScr.cutOrBoost == "Boost")
        {
            if (ranFreq == userFreq)
            {
                previousAns = ranFreq;
                attempts += 1;
                correct += 1;
                netGlbScr.pracEx++;
                netGlbScr.userScore = netGlbScr.userScore + 30;
                firstPlay = true;
                previousText.text = "Previous: " + curAnsString;
                StartCoroutine(ansRight());
                ResetAllButtons();
            } else if (ranFreq != userFreq)
            {
                previousAns = ranFreq;
                attempts += 1;
                netGlbScr.pracEx++;
                netGlbScr.userScore = netGlbScr.userScore + 10;
                StartCoroutine(ansWrong());
                previousText.text = "Previous: "+curAnsString;
                ResetAllButtons();
            }
        } else if (glbScr.cutOrBoost == "Both")
        {
            if (ranFreq == userFreq && selCb == userCutBoost)
            {
                previousAns = ranFreq;
                attempts += 1;
                correct += 1;
                netGlbScr.pracEx++;
                netGlbScr.userScore = netGlbScr.userScore + 30;
                firstPlay = true;
                previousText.text = "Previous: " + selCb + " " + curAnsString;
                StartCoroutine(ansRight());
                ResetAllButtons();
            } else if (ranFreq == userFreq || selCb == userCutBoost)
            {
                previousAns = ranFreq;
                attempts += 1;
                netGlbScr.pracEx++;
                firstPlay = true;
                netGlbScr.userScore = netGlbScr.userScore + 10;
                previousText.text = "Previous: " + selCb + " " + curAnsString;
                StartCoroutine(ansWrong());
                ResetAllButtons();
            }
        }
        StartCoroutine(UpdateStats());
    }
    public IEnumerator ansRight()
    {
        rightGO.SetActive(true);
        yield return new WaitForSeconds(1);
        rightGO.SetActive(false);
    }
    public IEnumerator ansWrong()
    {
        wrongGO.SetActive(true);
        yield return new WaitForSeconds(1);
        wrongGO.SetActive(false);
    }
    void ResetAllButtons()
    {
        cutBtnSel = false;
        boostBtnSel = false;
        cutBtn.GetComponent<Image>().color = notSelected;
        boostBtn.GetComponent<Image>().color = notSelected;
        lowBtnSel = false;
        midBtnSel = false;
        highBtnSel = false;
        lowBtn.GetComponent<Image>().color = notSelected;
        midBtn.GetComponent<Image>().color = notSelected;
        highBtn.GetComponent<Image>().color = notSelected;
        h31BtnSel = false;
        h40BtnSel = false;
        h50BtnSel = false;
        h63BtnSel = false;
        h80BtnSel = false;
        h100BtnSel = false;
        h125BtnSel = false;
        h160BtnSel = false;
        h200BtnSel = false;
        h250BtnSel = false;
        h315BtnSel = false;
        h400BtnSel = false;
        h500BtnSel = false;
        h630BtnSel = false;
        h800BtnSel = false;
        k1BtnSel = false;
        k125BtnSel = false;
        k16BtnSel = false;
        k2BtnSel = false;
        k25BtnSel = false;
        k315BtnSel = false;
        k4BtnSel = false;
        k5BtnSel = false;
        k63BtnSel = false;
        k8BtnSel = false;
        k10BtnSel = false;
        k12500BtnSel = false;
        k16000BtnSel = false;
        cutBoostSelected = false;
        h31Btn.GetComponent<Image>().color = notSelected;
        h40Btn.GetComponent<Image>().color = notSelected;
        h50Btn.GetComponent<Image>().color = notSelected;
        h63Btn.GetComponent<Image>().color = notSelected;
        h80Btn.GetComponent<Image>().color = notSelected;
        h100Btn.GetComponent<Image>().color = notSelected;
        h125Btn.GetComponent<Image>().color = notSelected;
        h160Btn.GetComponent<Image>().color = notSelected;
        h200Btn.GetComponent<Image>().color = notSelected;
        h250Btn.GetComponent<Image>().color = notSelected;
        h315Btn.GetComponent<Image>().color = notSelected;
        h400Btn.GetComponent<Image>().color = notSelected;
        h500Btn.GetComponent<Image>().color = notSelected;
        h630Btn.GetComponent<Image>().color = notSelected;
        h800Btn.GetComponent<Image>().color = notSelected;
        k1Btn.GetComponent<Image>().color = notSelected;
        k125Btn.GetComponent<Image>().color = notSelected;
        k16Btn.GetComponent<Image>().color = notSelected;
        k2Btn.GetComponent<Image>().color = notSelected;
        k25Btn.GetComponent<Image>().color = notSelected;
        k315Btn.GetComponent<Image>().color = notSelected;
        k4Btn.GetComponent<Image>().color = notSelected;
        k5Btn.GetComponent<Image>().color = notSelected;
        k63Btn.GetComponent<Image>().color = notSelected;
        k8Btn.GetComponent<Image>().color = notSelected;
        k10Btn.GetComponent<Image>().color = notSelected;
        k12500Btn.GetComponent<Image>().color = notSelected;
        k16000Btn.GetComponent<Image>().color = notSelected;
        cutBoostSelected = false;
        freqSelected = false;
        RandomiseFreq();
        RandonCutBoost();
    }
    void GenreChange()
    {
        if (genreValue == 0)
        {
            //genreValue = "Acoustic";
            fmodEvent.setParameterByName("track", 1);
        }
        else if (genreValue == 1)
        {
            //genre = "Rock";
            fmodEvent.setParameterByName("track", 2);
        }
        else if (genreValue == 2)
        {
            //genre = "Pop";
            fmodEvent.setParameterByName("track", 3);
        }
        else if (genreValue == 3)
        {
            //genre = "Indie";
            fmodEvent.setParameterByName("track", 4);
        }
    }
    //NETWORKING
    IEnumerator UpdateStats()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.userID.ToString());
        form.AddField("userScore", netGlbScr.userScore);
        form.AddField("pracEx", netGlbScr.pracEx);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/pracExUpdate.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

        }
        www.Dispose();
    }
}
