using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class Listener : MonoBehaviour
{
    private Globals glbScr;
    private NetworkGlobals netGlbScr;
    private ModuleController modCon;

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
    public string title;
    public string desc;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText;

    //Verification
    private bool freqSelected = false;
    private bool cutBoostSelected = false;

    //Choices
    [SerializeField] private string userCutBoost;
    [SerializeField] private string userFreqString;

    //Audio
    public float userFreq;
    FMOD.Studio.EventInstance fmodEvent;
    public bool isPlaying = false;
    public bool eqOn = false;
    public float gain;
    [SerializeField] private bool firstPlay = true;

    private void Start()
    {
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        modCon = GameObject.Find("Canvas_Main").GetComponent<ModuleController>();

        title = glbScr.currentTitle;
        desc = glbScr.currentDesc;

        titleText.text = title;
        descText.text = desc;

        if (glbScr.pinkOrMusic == "PN")
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/pn");
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/music");
        }

        if (glbScr.cutOrBoost == "Cut")
        {
            gain = 2.5f;
        }
        else if (glbScr.cutOrBoost == "Boost")
        {
            gain = 1.5f;
        }

        ButtonActivations();
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

        if (userCutBoost == "Boost")
        {
            gain = 1.5f;
        }
        else if (userCutBoost == "Cut")
        {
            gain = 2.5f;
        }
        titleText.text = title;
        descText.text = desc;
    }
    public void ButtonActivations()
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
    }
    /// <summary>
    /// Audio Player Code
    /// </summary>
    public void PlayButtonClick()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayExercice());
        }
    }
    IEnumerator PlayExercice()
    {
        modCon.appIsPlaying = true;
        genreDropdown.enabled = false;
        isPlaying = true;
        fmodEvent.setParameterByName("freq", userFreq);
        playBtnText.text = "PLAYING";

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
            fmodEvent.setParameterByName("freq", userFreq);
            fmodEvent.setParameterByName("gain", 0);
            fmodEvent.start();
        }
        else if (!firstPlay)
        {
            fmodEvent.setPaused(false);
        }

        playBtn.GetComponent<Image>().color = playing;
        yield return new WaitForSeconds(3);
        eqOn = true;
        fmodEvent.setParameterByName("gain", gain);
        yield return new WaitForSeconds(3);
        eqOn = false;
        fmodEvent.setParameterByName("gain", 0);
        yield return new WaitForSeconds(2);
        fmodEvent.setPaused(true);
        playBtnText.text = "PLAY";
        playBtn.GetComponent<Image>().color = waiting;
        genreDropdown.enabled = true;
        isPlaying = false;
        //firstPlay = false;
        modCon.appIsPlaying = false;
        netGlbScr.listenEx++;
        netGlbScr.userScore = netGlbScr.userScore + 10;
        StartCoroutine(UpdateStats());
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
        form.AddField("userID", netGlbScr.userID.ToString());
        form.AddField("userScore", netGlbScr.userScore);
        form.AddField("listenEx", netGlbScr.listenEx);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/listenExUpdate.php", form);
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
