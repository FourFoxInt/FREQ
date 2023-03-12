using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ExamUI : MonoBehaviour
{
    private EqExam eQexamScr;
    private FxExam fXexamScr;
    private DbExam dBexamScr;
    private ExamResults examReScr;
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    [SerializeField] private GameObject eQexamCanvas;
    [SerializeField] private GameObject fXexamCanvas;
    [SerializeField] private GameObject dBexamCanvas;

    [SerializeField] private GameObject m2e1btn;
    [SerializeField] private GameObject m2e1info;
    private bool m2e1in;
    [SerializeField] private GameObject m3e1btn;
    [SerializeField] private GameObject m3e1info;
    private bool m3e1in;
    [SerializeField] private GameObject m3e2btn;
    [SerializeField] private GameObject m3e2info;
    private bool m3e2in;
    [SerializeField] private GameObject m4e1btn;
    [SerializeField] private GameObject m4e1info;
    private bool m4e1in;
    [SerializeField] private GameObject m5e1btn;
    [SerializeField] private GameObject m5e1info;
    private bool m5e1in;
    [SerializeField] private GameObject m5e2btn;
    [SerializeField] private GameObject m5e2info;
    private bool m5e2in;
    [SerializeField] private GameObject m6e1btn;
    [SerializeField] private GameObject m6e1info;
    private bool m6e1in;
    [SerializeField] private GameObject m6e2btn;
    [SerializeField] private GameObject m6e2info;
    private bool m6e2in;

    private string examID;

    private bool appOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        examReScr = GameObject.Find("EqExam").GetComponent<ExamResults>();
        eQexamScr = GameObject.Find("EqExam").GetComponent<EqExam>();
        fXexamScr = GameObject.Find("FxExam").GetComponent<FxExam>();
        dBexamScr = GameObject.Find("DbExam").GetComponent<DbExam>();
        m2e1btn.SetActive(false); m3e1btn.SetActive(false); m3e2btn.SetActive(false); m4e1btn.SetActive(false);
        m5e1btn.SetActive(false); m5e2btn.SetActive(false); m6e1btn.SetActive(false); m6e2btn.SetActive(false);
        m2e1info.SetActive(false); m3e1info.SetActive(false); m3e2info.SetActive(false); m4e1info.SetActive(false);
        m5e1info.SetActive(false); m5e2info.SetActive(false); m6e1info.SetActive(false); m6e2info.SetActive(false);
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        StartCoroutine(CheckForExam());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void M2E1Btn()
    {
        appOpen = true;
        glbScr.lessonID = "M2E1";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "10";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "Y2E1";
        glbScr.canHalfMark = false;
        fXexamCanvas.SetActive(true);
        GameObject.Find("AppScripts").GetComponent<ExamResults>().totalPossibleScore = "8";
        //examTextScr.titleString = "Year 2 Exam 3";
    }
    public void M3E1Btn()
    {
        Debug.Log("CLICKED");
        appOpen = true;
        glbScr.currentCourse = "Year 2 EQ";
        glbScr.lessonID = "M3E1";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "10";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "Y2E1";
        glbScr.canHalfMark = false;
        eQexamCanvas.SetActive(true);
        GameObject.Find("AppScripts").GetComponent<ExamResults>().totalPossibleScore = "20";
        //examTextScr.titleString = "Year 2 Exam 1";
    }
    public void M3E2Btn()
    {
        appOpen = true;
        glbScr.lessonID = "YME2";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "10";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "MUS";
        glbScr.appTestID = "Y2E2";
        glbScr.canHalfMark = false;
        eQexamCanvas.SetActive(true);
        GameObject.Find("AppScripts").GetComponent<ExamResults>().totalPossibleScore = "20";
        //examTextScr.titleString = "Year 2 Exam 2";
    }

    public void M4E1Btn()
    {
        appOpen = true;
        glbScr.lessonID = "M4E1";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "10";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "Y2E1";
        glbScr.canHalfMark = false;
        fXexamCanvas.SetActive(true);
        GameObject.Find("AppScripts").GetComponent<ExamResults>().totalPossibleScore = "8";
        //examTextScr.titleString = "Year 2 Exam 4";
    }
    public void M5E1Btn()
    {
        appOpen = true;
        glbScr.lessonID = "M5E1";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "28";
        glbScr.minFreq = 100f;
        glbScr.maxFreq = 380f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "Y3E1";
        glbScr.canHalfMark = true;
        eQexamCanvas.SetActive(true);
        GameObject.Find("AppScripts").GetComponent<ExamResults>().totalPossibleScore = "30";
        //examTextScr.titleString = "Year 3 Exam 1";
    }
    public void M5E2Btn()
    {
        appOpen = true;
        glbScr.currentCourse = "Year 3 EQ";
        glbScr.lessonID = "Y3E2";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "28";
        glbScr.minFreq = 100f;
        glbScr.maxFreq = 380f;
        glbScr.pinkOrMusic = "MUS";
        glbScr.appTestID = "Y3E2";
        glbScr.canHalfMark = true;
        eQexamCanvas.SetActive(true);
        GameObject.Find("AppScripts").GetComponent<ExamResults>().totalPossibleScore = "30";
        //examTextScr.titleString = "Year 3 Exam 2";
    }
    public void M6E1Btn()
    {
        appOpen = true;
        glbScr.lessonID = "M6E1";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "10";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "PN";
        glbScr.appTestID = "Y3E3";
        glbScr.canHalfMark = true;
        dBexamCanvas.SetActive(true);
        GameObject.Find("AppScripts").GetComponent<ExamResults>().totalPossibleScore = "40";
        //examTextScr.titleString = "Year 3 Exam 3";
    }
    public void M6E2Btn()
    {
        appOpen = true;
        glbScr.lessonID = "M6E2";
        glbScr.cutOrBoost = "Both";
        glbScr.anserBtnsType = "10";
        glbScr.minFreq = 0f;
        glbScr.maxFreq = 100f;
        glbScr.pinkOrMusic = "MUS";
        glbScr.appTestID = "Y3E4";
        glbScr.canHalfMark = true;
        dBexamCanvas.SetActive(true);
        GameObject.Find("AppScripts").GetComponent<ExamResults>().totalPossibleScore = "40";
        //examTextScr.titleString = "Year 3 Exam 4";
    }

    IEnumerator CheckForExam()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.username);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/getExam.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {

        }
        else
        {
            examID = www.downloadHandler.text;
            SetExamButton();
        }
        www.Dispose();
    }

    void SetExamButton()
    {
        if (examID == "M2E1")
        {
            m2e1btn.SetActive(true);
            m2e1info.SetActive(true);
        }
        else if (examID == "M3E1")
        {
            m3e1btn.SetActive(true);
            m3e1info.SetActive(true);
        }
        else if (examID == "M3E2")
        {
            m3e2btn.SetActive(true);
            m3e2info.SetActive(true);
        }
        else if (examID == "M4E1")
        {
            m4e1btn.SetActive(true);
            m4e1info.SetActive(true);
        }
        else if (examID == "M5E1")
        {
            m5e1btn.SetActive(true);
            m5e2info.SetActive(true);
        }
        else if (examID == "M5E2")
        {
            m5e2btn.SetActive(true);
            m5e2info.SetActive(true);
        }
        else if (examID == "M6E1")
        {
            m6e1btn.SetActive(true);
            m6e1info.SetActive(true);
        }
        else if (examID == "M6E2")
        {
            m6e2btn.SetActive(true);
            m6e2info.SetActive(true);
        }
    }
}
