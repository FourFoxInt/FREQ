using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EqExam : MonoBehaviour
{
    private Globals glbScr;
    private NetworkGlobals netGlbScr;
    public bool canHalfMark = false;
    [SerializeField] private GameObject eqExamGO;

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
    [SerializeField] private GameObject freqButtonsGroup;
    [SerializeField] private GameObject freqButtonsScroll;
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
    [SerializeField] private Button submitBtn;

    //Freq Bools
    private bool lowBtnSel; private bool midBtnSel; private bool highBtnSel;
    private bool h31BtnSel; private bool h40BtnSel; private bool h50BtnSel;
    private bool h63BtnSel; private bool h80BtnSel; private bool h100BtnSel;
    private bool h125BtnSel; private bool h160BtnSel; private bool h200BtnSel;
    private bool h250BtnSel; private bool h315BtnSel; private bool h400BtnSel;
    private bool h500BtnSel; private bool h630BtnSel; private bool h800BtnSel;
    private bool k1BtnSel; private bool k125BtnSel; private bool k16BtnSel;
    private bool k2BtnSel; private bool k25BtnSel; private bool k315BtnSel;
    private bool k4BtnSel; private bool k5BtnSel; private bool k63BtnSel;
    private bool k8BtnSel; private bool k10BtnSel; private bool k12500BtnSel;
    private bool k16000BtnSel;

    //UI
    [SerializeField] private TextMeshProUGUI playBtnText;
    [SerializeField] private Button playBtn;
    public string title;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI previousText;
    [SerializeField] private TextMeshProUGUI playText;
    private int curEx = 1;
    [SerializeField] private GameObject closeTestCanvas;
    [SerializeField] private Button closeTestBtn;
    [SerializeField] private GameObject testSubErrorCanvas;
    [SerializeField] private GameObject successText;

    //Verification
    [SerializeField] private bool freqSelected = false;
    [SerializeField] private bool cutBoostSelected = false;
    public bool testComplete = false;
    public bool testRunning = false;

    //Choices
    [SerializeField] private string userCutBoost;
    [SerializeField] private string userFreqString;
    [SerializeField] private string ranCutBoostString;
    [SerializeField] private string ranFreqString;
    [SerializeField] private float ranFreq;
    [SerializeField] private string curAnsString;
    public int score;
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
    //Example Intro Audio Clips. 
    [SerializeField] private AudioClip ex1Clip;[SerializeField] private AudioClip ex2Clip;[SerializeField] private AudioClip ex3Clip;[SerializeField] private AudioClip ex4Clip;[SerializeField] private AudioClip ex5Clip;
    [SerializeField] private AudioClip ex6Clip;[SerializeField] private AudioClip ex7Clip;[SerializeField] private AudioClip ex8Clip;[SerializeField] private AudioClip ex9Clip;[SerializeField] private AudioClip ex10Clip;

    public float ex1CorrectAnswer; public string ex1CorrectAnswerText;
    public float ex2CorrectAnswer; public string ex2CorrectAnswerText;
    public float ex3CorrectAnswer; public string ex3CorrectAnswerText;
    public float ex4CorrectAnswer; public string ex4CorrectAnswerText;
    public float ex5CorrectAnswer; public string ex5CorrectAnswerText;
    public float ex6CorrectAnswer; public string ex6CorrectAnswerText;
    public float ex7CorrectAnswer; public string ex7CorrectAnswerText;
    public float ex8CorrectAnswer; public string ex8CorrectAnswerText;
    public float ex9CorrectAnswer; public string ex9CorrectAnswerText;
    public float ex10CorrectAnswer; public string ex10CorrectAnswerText;

    public string ex1correctCbAns;
    public string ex2correctCbAns;
    public string ex3correctCbAns;
    public string ex4correctCbAns;
    public string ex5correctCbAns;
    public string ex6correctCbAns;
    public string ex7correctCbAns;
    public string ex8correctCbAns;
    public string ex9correctCbAns;
    public string ex10correctCbAns;

    public float ex1UserAnswer; public string ex1UserAnswerText;
    public float ex2UserAnswer; public string ex2UserAnswerText;
    public float ex3UserAnswer; public string ex3UserAnswerText;
    public float ex4UserAnswer; public string ex4UserAnswerText;
    public float ex5UserAnswer; public string ex5UserAnswerText;
    public float ex6UserAnswer; public string ex6UserAnswerText;
    public float ex7UserAnswer; public string ex7UserAnswerText;
    public float ex8UserAnswer; public string ex8UserAnswerText;
    public float ex9UserAnswer; public string ex9UserAnswerText;
    public float ex10UserAnswer; public string ex10UserAnswerText;

    public string ex1userCbAns;
    public string ex2userCbAns;
    public string ex3userCbAns;
    public string ex4userCbAns;
    public string ex5userCbAns;
    public string ex6userCbAns;
    public string ex7userCbAns;
    public string ex8userCbAns;
    public string ex9userCbAns;
    public string ex10userCbAns;

    [SerializeField] private GameObject resultsCanvas;

    private void Start()
    {
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();

        ButtonActivations();
        CutBoostBtnActivation();

        titleText.text = title;
    }

    private void Update()
    {
        GenreChange();
        ButtonActivations();
        MusicDropdownActivation();

        if (isPlaying)
        {
            playText.text = "PLAYING EX " + curEx.ToString();
            closeTestBtn.interactable = false;
        }
        else if (!isPlaying && !firstPlay)
        {
            playText.text = "REPLAY";
            closeTestBtn.interactable = true;
        }
        else if (!isPlaying)
        {
            playText.text = "PLAY EX " + curEx.ToString() + " out of 10";
            if (closeTestBtn != null)
            {
                closeTestBtn.interactable = true;
            }
        }

        if (isPlaying || firstPlay)
        {
            submitBtn.GetComponent<Button>().interactable = false;
        }
        else if (!isPlaying && freqSelected)
        {
            submitBtn.GetComponent<Button>().interactable = true;
        }

        if (glbScr.cutOrBoost == "Cut")
        {
            gain = 2.5f;
            curAnsString = ranFreqString;
        }
        else if (glbScr.cutOrBoost == "Boost")
        {
            gain = 1.5f;
            curAnsString = ranFreqString;
        }
        titleText.text = title;

/*        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(PostResults());
        }*/
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
            cutBoostBtns.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -380);
            freqButtonsGroup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -680);
            freqButtonsScroll.GetComponent<RectTransform>().sizeDelta = new Vector2(freqButtonsScroll.GetComponent<RectTransform>().sizeDelta.x, 940);
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            audioDropdown.SetActive(true);
            cutBoostBtns.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -620);
            freqButtonsGroup.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -890.6f);
            freqButtonsScroll.GetComponent<RectTransform>().sizeDelta = new Vector2(freqButtonsScroll.GetComponent<RectTransform>().sizeDelta.x, 650);
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
        userFreqString = "2.5 kHz";
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
        userFreqString = "3.15 kHz";
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
        userFreqString = "5 kHz";
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
        if (curEx == 1)
        {
            testRunning = true;
        }
        if (!isPlaying)
        {
            StartCoroutine(PlayExercise());
        }
    }
    IEnumerator PlayExercise()
    {
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
            else if (glbScr.cutOrBoost == "Boost")
            {
                selCb = "Boost";
            }
            else if (glbScr.cutOrBoost == "Cut")
            {
                selCb = "Cut";
            }
        }
        IntroClip();
        isPlaying = true;
        yield return new WaitForSeconds(0.1f);
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
        fmodEvent.setParameterByName("gain", gain);

        if (glbScr.pinkOrMusic == "PN")
        {
            yield return new WaitForSeconds(3);
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            yield return new WaitForSeconds(4);
        }

        fmodEvent.setParameterByName("gain", 0);
        eqOn = false;
        yield return new WaitForSeconds(2);
        fmodEvent.setPaused(true);
        isPlaying = false;
        if (glbScr.pinkOrMusic == "MUS")
        {
            genreDropdown.enabled = true;
        }
    }
    public void SubmitBtnClick()
    {
        if (glbScr.cutOrBoost == "Boost" || glbScr.cutOrBoost == "Cut")
        {
            if (ranFreq == userFreq)
            {
                firstPlay = true;
                if (glbScr.currentCourse == "Year 3 EQ")
                {
                    score += 2;
                }
                else if (glbScr.currentCourse != "Year 3 EQ")
                {
                    score += 1;
                }
                previousAns = ranFreq;
                ResetAllButtons();
                SetAnswers();
            }
            else if (ranFreq != userFreq)
            {
                if (glbScr.canHalfMark)
                {
                    isHalfMark();
                }
                firstPlay = true;
                previousAns = ranFreq;
                ResetAllButtons();
                SetAnswers();
            }
        }
        else if (glbScr.cutOrBoost == "Both")
        {
            if (ranFreq == userFreq && selCb == userCutBoost)
            {
                firstPlay = true;
                previousAns = ranFreq;
                if (glbScr.currentCourse == "Year 3 EQ")
                {
                    score += 3;
                }
                else if (glbScr.currentCourse != "Year 3 EQ")
                {
                    score += 2;
                }
                ResetAllButtons();
                SetAnswers();
            }
            else if (ranFreq == userFreq && selCb != userCutBoost)
            {
                firstPlay = true;
                if (glbScr.currentCourse == "Year 3 EQ")
                {
                    score += 2;
                }
                else if (glbScr.currentCourse != "Year 3 EQ")
                {
                    score += 1;
                }
                previousAns = ranFreq;
                ResetAllButtons();
                SetAnswers();
            }
            else if (ranFreq != userFreq && selCb == userCutBoost)
            {
                if (glbScr.canHalfMark)
                {
                    isHalfMark();
                }
                firstPlay = true;
                previousAns = ranFreq;
                score += 1;
                ResetAllButtons();
                SetAnswers();
            }
            else if (ranFreq != userFreq && selCb != userCutBoost)
            {
                if (glbScr.canHalfMark)
                {
                    isHalfMark();
                }
                firstPlay = true;
                previousAns = ranFreq;
                ResetAllButtons();
                SetAnswers();
            }
        }

        if (curEx != 10)
        {
            curEx += 1;
        }
        else if (curEx == 10)
        {
            testRunning = false;
            Results();
            if (score >= glbScr.passMark)
            {
                TestLevelCheck();
            }
        }
    }
    void Results()
    {
        scoreText.text = score.ToString() + " out of 20";
        resultsCanvas.SetActive(true);
        StartCoroutine(PostResults());

        netGlbScr.userScore += score * 10;
        netGlbScr.tests += 1;
        //StartCoroutine(UpdateStats());
        //netGlbScript.sessionTests = netGlbScript.sessionTests + 1;
        //testCanvas.SetActive(false);
    }
    void SetAnswers()
    {
        if (curEx == 1)
        {
            ex1CorrectAnswer = ranFreq;
            ex1UserAnswer = userFreq;

            if (glbScr.cutOrBoost == "Both")
            {
                ex1correctCbAns = selCb;
                ex1userCbAns = userCutBoost;
                ex1CorrectAnswerText = ranFreqString;
                ex1UserAnswerText = userFreqString;
            }

            ex1CorrectAnswerText = ranFreqString;
            ex1UserAnswerText = userFreqString;
        }
        if (curEx == 2)
        {
            ex2CorrectAnswer = ranFreq;
            ex2UserAnswer = userFreq;

            if (glbScr.cutOrBoost == "Both")
            {
                ex2correctCbAns = selCb;
                ex2userCbAns = userCutBoost;
            }
            ex2CorrectAnswerText = ranFreqString;
            ex2UserAnswerText = userFreqString;
        }
        if (curEx == 3)
        {
            ex3CorrectAnswer = ranFreq;
            ex3UserAnswer = userFreq;
            if (glbScr.cutOrBoost == "Both")
            {
                ex3correctCbAns = selCb;
                ex3userCbAns = userCutBoost;
            }
            ex3CorrectAnswerText = ranFreqString;
            ex3UserAnswerText = userFreqString;
        }
        if (curEx == 4)
        {
            ex4CorrectAnswer = ranFreq;
            ex4UserAnswer = userFreq;
            if (glbScr.cutOrBoost == "Both")
            {
                ex4correctCbAns = selCb;
                ex4userCbAns = userCutBoost;
            }
            ex4CorrectAnswerText = ranFreqString;
            ex4UserAnswerText = userFreqString;
        }
        if (curEx == 5)
        {
            ex5CorrectAnswer = ranFreq;
            ex5UserAnswer = userFreq;
            if (glbScr.cutOrBoost == "Both")
            {
                ex5correctCbAns = selCb;
                ex5userCbAns = userCutBoost;
            }
            ex5CorrectAnswerText = ranFreqString;
            ex5UserAnswerText = userFreqString;
        }
        if (curEx == 6)
        {
            ex6CorrectAnswer = ranFreq;
            ex6UserAnswer = userFreq;
            if (glbScr.cutOrBoost == "Both")
            {
                ex6correctCbAns = selCb;
                ex6userCbAns = userCutBoost;
            }
            ex6CorrectAnswerText = ranFreqString;
            ex6UserAnswerText = userFreqString;
        }
        if (curEx == 7)
        {
            ex7CorrectAnswer = ranFreq;
            ex7UserAnswer = userFreq;
            if (glbScr.cutOrBoost == "Both")
            {
                ex7correctCbAns = selCb;
                ex7userCbAns = userCutBoost;
            }
            ex7CorrectAnswerText = ranFreqString;
            ex7UserAnswerText = userFreqString;
        }
        if (curEx == 8)
        {
            ex8CorrectAnswer = ranFreq;
            ex8UserAnswer = userFreq;
            if (glbScr.cutOrBoost == "Both")
            {
                ex8correctCbAns = selCb;
                ex8userCbAns = userCutBoost;
            }
            ex8CorrectAnswerText = ranFreqString;
            ex8UserAnswerText = userFreqString;
        }
        if (curEx == 9)
        {
            ex9CorrectAnswer = ranFreq;
            ex9UserAnswer = userFreq;
            if (glbScr.cutOrBoost == "Both")
            {
                ex9correctCbAns = selCb;
                ex9userCbAns = userCutBoost;
            }
            ex9CorrectAnswerText = ranFreqString;
            ex9UserAnswerText = userFreqString;
        }
        if (curEx == 10)
        {
            ex10CorrectAnswer = ranFreq;
            ex10UserAnswer = userFreq;
            if (glbScr.cutOrBoost == "Both")
            {
                ex10correctCbAns = selCb;
                ex10userCbAns = userCutBoost;
            }
            ex10CorrectAnswerText = ranFreqString;
            ex10UserAnswerText = userFreqString;
        }
    }
    void IntroClip()
    {
        if (curEx == 1)
        {
            audSource.clip = ex1Clip;
        }
        else if (curEx == 2)
        {
            audSource.clip = ex2Clip;
        }
        else if (curEx == 3)
        {
            audSource.clip = ex3Clip;
        }
        else if (curEx == 4)
        {
            audSource.clip = ex4Clip;
        }
        else if (curEx == 5)
        {
            audSource.clip = ex5Clip;
        }
        else if (curEx == 6)
        {
            audSource.clip = ex6Clip;
        }
        else if (curEx == 7)
        {
            audSource.clip = ex7Clip;
        }
        else if (curEx == 8)
        {
            audSource.clip = ex8Clip;
        }
        else if (curEx == 9)
        {
            audSource.clip = ex9Clip;
        }
        else if (curEx == 10)
        {
            audSource.clip = ex10Clip;
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
    public void ResetAllButtons()
    {
        successText.SetActive(false);
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
    public void RestartTest()
    {
        ResetAllButtons();
        curEx = 1;
        score = 0;
        firstPlay = true;
        testComplete = false;
        resultsCanvas.SetActive(false);
    }
    IEnumerator PostResults()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.username);
        form.AddField("appTestID", glbScr.appTestID);
        form.AddField("score", score);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/postTestResult.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            UnityEngine.Debug.Log(www.error);
            testSubErrorCanvas.SetActive(true);
        }
        else
        {
            UnityEngine.Debug.Log(www.downloadHandler.text);
            successText.SetActive(true);
        }
        www.Dispose();
    }
    void TestLevelCheck()
    {

        if (glbScr.appTestID == "Y1EQ_M1" || glbScr.globalTestId == "M1T1")
        {
            if (netGlbScr.testLevel <= 1)
            {
                netGlbScr.testLevel = 2;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M2" || glbScr.globalTestId == "M1T2")
        {
            if (netGlbScr.testLevel <= 2)
            {
                netGlbScr.testLevel = 3;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M3" || glbScr.globalTestId == "M1T3")
        {
            if (netGlbScr.testLevel <= 3)
            {
                netGlbScr.testLevel = 4;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M4" || glbScr.globalTestId == "M2T1")
        {
            if (netGlbScr.testLevel <= 4)
            {
                netGlbScr.testLevel = 5;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M5" || glbScr.globalTestId == "M2T2")
        {
            if (netGlbScr.testLevel <= 5)
            {
                netGlbScr.testLevel = 6;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M6" || glbScr.globalTestId == "M2T3")
        {
            if (netGlbScr.testLevel <= 6)
            {
                netGlbScr.testLevel = 7;
            }
        }

        //YEAR 2
        else if (glbScr.appTestID == "Y2EQ_M1" || glbScr.globalTestId == "M3T1")
        {
            if (netGlbScr.testLevel <= 7)
            {
                netGlbScr.testLevel = 8;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M2" || glbScr.globalTestId == "M3T2")
        {
            if (netGlbScr.testLevel <= 8)
            {
                netGlbScr.testLevel = 9;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M3" || glbScr.globalTestId == "M3T3")
        {
            if (netGlbScr.testLevel <= 9)
            {
                netGlbScr.testLevel = 10;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M4" || glbScr.globalTestId == "M4T1")
        {
            if (netGlbScr.testLevel <= 10)
            {
                netGlbScr.testLevel = 11;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M5" || glbScr.globalTestId == "M4T2")
        {
            if (netGlbScr.testLevel <= 11)
            {
                netGlbScr.testLevel = 12;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M6" || glbScr.globalTestId == "M4T3")
        {
            if (netGlbScr.testLevel <= 12)
            {
                netGlbScr.testLevel = 13;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M7" || glbScr.globalTestId == "M5T1")
        {
            if (netGlbScr.testLevel <= 13)
            {
                netGlbScr.testLevel = 14;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M8" || glbScr.globalTestId == "M5T2")
        {
            if (netGlbScr.testLevel <= 14)
            {
                netGlbScr.testLevel = 15;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M9" || glbScr.globalTestId == "M5T3")
        {
            if (netGlbScr.testLevel <= 15)
            {
                netGlbScr.testLevel = 16;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M10" || glbScr.globalTestId == "M6T1")
        {
            if (netGlbScr.testLevel <= 16)
            {
                netGlbScr.testLevel = 17;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M11" || glbScr.globalTestId == "M6T2")
        {
            if (netGlbScr.testLevel <= 17)
            {
                netGlbScr.testLevel = 18;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M12" || glbScr.globalTestId == "M6T3")
        {
            if (netGlbScr.testLevel <= 18)
            {
                netGlbScr.testLevel = 19;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M13" || glbScr.globalTestId == "M7T1")
        {
            if (netGlbScr.testLevel <= 19)
            {
                netGlbScr.testLevel = 20;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M14" || glbScr.globalTestId == "M7T2")
        {
            if (netGlbScr.testLevel <= 20)
            {
                netGlbScr.testLevel = 21;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M15" || glbScr.globalTestId == "M7T3")
        {
            if (netGlbScr.testLevel <= 21)
            {
                netGlbScr.testLevel = 22;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M16" || glbScr.globalTestId == "M8T1")
        {
            if (netGlbScr.testLevel <= 22)
            {
                netGlbScr.testLevel = 23;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M17" || glbScr.globalTestId == "M8T2")
        {
            if (netGlbScr.testLevel <= 23)
            {
                netGlbScr.testLevel = 24;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M18" || glbScr.globalTestId == "M8T3")
        {
            if (netGlbScr.testLevel <= 24)
            {
                netGlbScr.testLevel = 25;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M19" || glbScr.globalTestId == "M9T1")
        {
            if (netGlbScr.testLevel <= 25)
            {
                netGlbScr.testLevel = 26;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M20" || glbScr.globalTestId == "M9T2")
        {
            if (netGlbScr.testLevel <= 26)
            {
                netGlbScr.testLevel = 27;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M21" || glbScr.globalTestId == "M9T3")
        {
            if (netGlbScr.testLevel <= 27)
            {
                netGlbScr.testLevel = 28;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M22" || glbScr.globalTestId == "M10T1")
        {
            if (netGlbScr.testLevel <= 28)
            {
                netGlbScr.testLevel = 29;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M23" || glbScr.globalTestId == "M10T2")
        {
            if (netGlbScr.testLevel <= 29)
            {
                netGlbScr.testLevel = 30;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M24" || glbScr.globalTestId == "M10T3")
        {
            if (netGlbScr.testLevel <= 30)
            {
                netGlbScr.testLevel = 31;
            }
        }

        //YEAR3
        else if (glbScr.appTestID == "Y3EQ_M1" || glbScr.globalTestId == "M11T1")
        {
            if (netGlbScr.testLevel <= 31)
            {
                netGlbScr.testLevel = 32;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M2" || glbScr.globalTestId == "M11T2")
        {
            if (netGlbScr.testLevel <= 32)
            {
                netGlbScr.testLevel = 33;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M3" || glbScr.globalTestId == "M11T3")
        {
            if (netGlbScr.testLevel <= 33)
            {
                netGlbScr.testLevel = 34;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M4" || glbScr.globalTestId == "M12T1")
        {
            if (netGlbScr.testLevel <= 34)
            {
                netGlbScr.testLevel = 35;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M5" || glbScr.globalTestId == "M12T2")
        {
            if (netGlbScr.testLevel <= 35)
            {
                netGlbScr.testLevel = 36;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M6" || glbScr.globalTestId == "M12T3")
        {
            if (netGlbScr.testLevel <= 36)
            {
                netGlbScr.testLevel = 37;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M7" || glbScr.globalTestId == "M13T1")
        {
            if (netGlbScr.testLevel <= 37)
            {
                netGlbScr.testLevel = 38;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M8" || glbScr.globalTestId == "M13T2")
        {
            if (netGlbScr.testLevel <= 38)
            {
                netGlbScr.testLevel = 39;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M9" || glbScr.globalTestId == "M13T3")
        {
            if (netGlbScr.testLevel <= 39)
            {
                netGlbScr.testLevel = 40;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M10" || glbScr.globalTestId == "M14T1")
        {
            if (netGlbScr.testLevel <= 40)
            {
                netGlbScr.testLevel = 41;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M11" || glbScr.globalTestId == "M14T2")
        {
            if (netGlbScr.testLevel <= 41)
            {
                netGlbScr.testLevel = 42;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M12" || glbScr.globalTestId == "M14T3")
        {
            if (netGlbScr.testLevel <= 42)
            {
                netGlbScr.testLevel = 43;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M13" || glbScr.globalTestId == "M15T1")
        {
            if (netGlbScr.testLevel <= 43)
            {
                netGlbScr.testLevel = 44;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M14" || glbScr.globalTestId == "M15T2")
        {
            if (netGlbScr.testLevel <= 44)
            {
                netGlbScr.testLevel = 45;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M15" || glbScr.globalTestId == "M15T3")
        {
            if (netGlbScr.testLevel <= 45)
            {
                netGlbScr.testLevel = 46;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M16" || glbScr.globalTestId == "M16T1")
        {
            if (netGlbScr.testLevel <= 46)
            {
                netGlbScr.testLevel = 47;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M17" || glbScr.globalTestId == "M16T2")
        {
            if (netGlbScr.testLevel <= 47)
            {
                netGlbScr.testLevel = 48;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M18" || glbScr.globalTestId == "M16T3")
        {
            if (netGlbScr.testLevel <= 48)
            {
                netGlbScr.testLevel = 49;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M19" || glbScr.globalTestId == "M17T1")
        {
            if (netGlbScr.testLevel <= 49)
            {
                netGlbScr.testLevel = 50;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M20" || glbScr.globalTestId == "M17T2")
        {
            if (netGlbScr.testLevel <= 50)
            {
                netGlbScr.testLevel = 51;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M21" || glbScr.globalTestId == "M17T3")
        {
            if (netGlbScr.testLevel <= 51)
            {
                netGlbScr.testLevel = 52;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M22" || glbScr.globalTestId == "M18T1")
        {
            if (netGlbScr.testLevel <= 52)
            {
                netGlbScr.testLevel = 53;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M23" || glbScr.globalTestId == "M18T2")
        {
            if (netGlbScr.testLevel <= 53)
            {
                netGlbScr.testLevel = 54;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M24" || glbScr.globalTestId == "M18T3")
        {
            if (netGlbScr.testLevel <= 54)
            {
                netGlbScr.testLevel = 55;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M25" || glbScr.globalTestId == "M19T1")
        {
            if (netGlbScr.testLevel <= 55)
            {
                netGlbScr.testLevel = 56;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M26" || glbScr.globalTestId == "M19T2")
        {
            if (netGlbScr.testLevel <= 56)
            {
                netGlbScr.testLevel = 57;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M27" || glbScr.globalTestId == "M19T3")
        {
            if (netGlbScr.testLevel <= 57)
            {
                netGlbScr.testLevel = 58;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M28" || glbScr.globalTestId == "M20T1")
        {
            if (netGlbScr.testLevel <= 58)
            {
                netGlbScr.testLevel = 59;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M29" || glbScr.globalTestId == "M20T2")
        {
            if (netGlbScr.testLevel <= 59)
            {
                netGlbScr.testLevel = 60;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M30" || glbScr.globalTestId == "M20T3")
        {
            if (netGlbScr.testLevel <= 61)
            {
                netGlbScr.testLevel = 62;
            }
        }
    }
    public void TestCloseBtn()
    {
        if (testRunning)
        {
            closeTestCanvas.SetActive(true);
        }
        else
        {
            ResetAllButtons();
            RestartTest();
            CloseAppButton();
        }
    }
    public void YesClose()
    {
        closeTestCanvas.SetActive(false);
        ResetAllButtons();
        RestartTest();
        CloseAppButton();
    }
    public void NoClose()
    {
        closeTestCanvas.SetActive(false);
    }
    public void isHalfMark()
    {
        Debug.Log("IS HALF MARK RAN");
        if (ranFreq == 1 && userFreq == 2)
        {
            score = score + 1;
        }
        else if (ranFreq == 2 && userFreq == 1 || ranFreq == 2 && userFreq == 3)
        {
            score = score + 1;
        }
        else if (ranFreq == 3 && userFreq == 2 || ranFreq == 3 && userFreq == 4)
        {
            score = score + 1;
        }
        else if (ranFreq == 4 && userFreq == 3 || ranFreq == 4 && userFreq == 5)
        {
            score = score + 1;
        }
        else if (ranFreq == 5 && userFreq == 4 || ranFreq == 5 && userFreq == 6)
        {
            score = score + 1;
        }
        else if (ranFreq == 6 && userFreq == 5 || ranFreq == 6 && userFreq == 7)
        {
            score = score + 1;
        }
        else if (ranFreq == 7 && userFreq == 6 || ranFreq == 7 && userFreq == 8)
        {
            score = score + 1;
        }
        else if (ranFreq == 8 && userFreq == 7 || ranFreq == 8 && userFreq == 9)
        {
            score = score + 1;
        }
        else if (ranFreq == 9 && userFreq == 8 || ranFreq == 9 && userFreq == 10)
        {
            score = score + 1;
        }
        else if (ranFreq == 10 && userFreq == 9 || ranFreq == 10 && userFreq == 11)
        {
            score = score + 1;
        }
        else if (ranFreq == 11 && userFreq == 10 || ranFreq == 11 && userFreq == 12)
        {
            score = score + 1;
        }
        else if (ranFreq == 12 && userFreq == 11 || ranFreq == 12 && userFreq == 13)
        {
            score = score + 1;
        }
        else if (ranFreq == 13 && userFreq == 12 || ranFreq == 13 && userFreq == 14)
        {
            score = score + 1;
        }
        else if (ranFreq == 14 && userFreq == 13 || ranFreq == 14 && userFreq == 15)
        {
            score = score + 1;
        }
        else if (ranFreq == 15 && userFreq == 14 || ranFreq == 15 && userFreq == 16)
        {
            score = score + 1;
        }
        else if (ranFreq == 16 && userFreq == 15 || ranFreq == 16 && userFreq == 17)
        {
            score = score + 1;
        }
        else if (ranFreq == 17 && userFreq == 6 || ranFreq == 17 && userFreq == 18)
        {
            score = score + 1;
        }
        else if (ranFreq == 18 && userFreq == 17 || ranFreq == 18 && userFreq == 19)
        {
            score = score + 1;
        }
        else if (ranFreq == 19 && userFreq == 18 || ranFreq == 19 && userFreq == 20)
        {
            score = score + 1;
        }
        else if (ranFreq == 20 && userFreq == 19 || ranFreq == 20 && userFreq == 21)
        {
            score = score + 1;
        }
        else if (ranFreq == 21 && userFreq == 20 || ranFreq == 21 && userFreq == 22)
        {
            score = score + 1;
        }
        else if (ranFreq == 22 && userFreq == 21 || ranFreq == 22 && userFreq == 23)
        {
            score = score + 1;
        }
        else if (ranFreq == 23 && userFreq == 22 || ranFreq == 23 && userFreq == 24)
        {
            score = score + 1;
        }
        else if (ranFreq == 24 && userFreq == 23)
        {
            score = score + 1;
        }
    }
    public void ReSubBtn()
    {
        testSubErrorCanvas.SetActive(false);
        StartCoroutine(PostResults());
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene(3);
    }

    void CloseAppButton()
    {
        eqExamGO.SetActive(false);
        closeTestCanvas.SetActive(false);
    }
}
