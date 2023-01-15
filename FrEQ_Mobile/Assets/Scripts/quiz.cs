using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class quiz : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    [SerializeField] private int curQuestion = 1;
    [SerializeField] private int numberOfQuestions = 3;
    [SerializeField] private int q1UserAns = 0;
    [SerializeField] private int q1Ans = 0;
    [SerializeField] private int q2UserAns = 0;
    [SerializeField] private int q2Ans = 0;
    [SerializeField] private int q3UserAns = 0;
    [SerializeField] private int q3Ans = 0;
    private int score = 0;

    //UI
    [SerializeField] private bool a1sel; [SerializeField] private bool a2sel;
    [SerializeField] private bool a3sel; [SerializeField] private bool a4sel;
    [SerializeField] private GameObject a1btn; [SerializeField] private GameObject a2btn;
    [SerializeField] private GameObject a3btn; [SerializeField] private GameObject a4btn;
    [SerializeField] private TextMeshProUGUI curQuestionNumText;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI ans1Text; [SerializeField] private TextMeshProUGUI ans2Text;
    [SerializeField] private TextMeshProUGUI ans3Text; [SerializeField] private TextMeshProUGUI ans4Text;
    [SerializeField] private Color32 selected;
    [SerializeField] private Color32 notSelected;
    [SerializeField] private GameObject nextBtnGO;
    [SerializeField] private GameObject prevBtnGo;
    [SerializeField] private GameObject submitBtnGo;
    [SerializeField] private GameObject areYouSureGO;

    //Results UI
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI midResText;
    [SerializeField] private TextMeshProUGUI sectionsText;
    [SerializeField] private GameObject resultsGO;
    [SerializeField] private GameObject badTextGO;
    [SerializeField] private GameObject goodTextGO;
    [SerializeField] private GameObject midTextGO;
    [SerializeField] private GameObject sectionsTextGO;
    [SerializeField] private string wrongSection1;
    [SerializeField] private string wrongSection2;
    [SerializeField] private string wrongSection3;
    [SerializeField] private string wrongSections;

    //RESULT CHECK
    [SerializeField] private GameObject blockerGO;
    [SerializeField] private GameObject passedGO;
    [SerializeField] private GameObject quizCanvas;

    void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }
    void Update()
    {
        if (curQuestion > numberOfQuestions)
        {
            curQuestion = numberOfQuestions;
        }
        else if (curQuestion <= 1)
        {
            curQuestion = 1;
        }

        curQuestionNumText.text = "Question " + curQuestion.ToString() + " of " + numberOfQuestions.ToString();

        SetQA();
        SetAns();
        WrongSections();
    }

    public void A1Btn()
    {
        a1sel = true;
        a2sel = false;
        a3sel = false;
        a4sel = false;
        a1btn.GetComponent<Image>().color = selected;
        a2btn.GetComponent<Image>().color = notSelected;
        a3btn.GetComponent<Image>().color = notSelected;
        a4btn.GetComponent<Image>().color = notSelected;
        if (curQuestion == 1)
        {
            q1UserAns = 1;
        }
        else if (curQuestion == 2)
        {
            q2UserAns = 1;
        }
        else if (curQuestion == 3)
        {
            q3UserAns = 1;
        }
    }
    public void A2Btn()
    {
        a1sel = false;
        a2sel = true;
        a3sel = false;
        a4sel = false;
        a1btn.GetComponent<Image>().color = notSelected;
        a2btn.GetComponent<Image>().color = selected;
        a3btn.GetComponent<Image>().color = notSelected;
        a4btn.GetComponent<Image>().color = notSelected;
        if (curQuestion == 1)
        {
            q1UserAns = 2;
        }
        else if (curQuestion == 2)
        {
            q2UserAns = 2;
        }
        else if (curQuestion == 3)
        {
            q3UserAns = 2;
        }
    }
    public void A3Btn()
    {
        a1sel = false;
        a2sel = false;
        a3sel = true;
        a4sel = false;
        a1btn.GetComponent<Image>().color = notSelected;
        a2btn.GetComponent<Image>().color = notSelected;
        a3btn.GetComponent<Image>().color = selected;
        a4btn.GetComponent<Image>().color = notSelected;
        if (curQuestion == 1)
        {
            q1UserAns = 3;
        }
        else if (curQuestion == 2)
        {
            q2UserAns = 3;
        }
        else if (curQuestion == 3)
        {
            q3UserAns = 3;
        }
    }
    public void A4Btn()
    {
        a1sel = false;
        a2sel = false;
        a3sel = false;
        a4sel = true;
        a1btn.GetComponent<Image>().color = notSelected;
        a2btn.GetComponent<Image>().color = notSelected;
        a3btn.GetComponent<Image>().color = notSelected;
        a4btn.GetComponent<Image>().color = selected;
        if (curQuestion == 1)
        {
            q1UserAns = 4;
        }
        else if (curQuestion == 2)
        {
            q2UserAns = 4;
        }
        else if (curQuestion == 3)
        {
            q3UserAns = 4;
        }
    }
    void SetQA()
    {
        if (curQuestion == 1)
        {
            questionText.text = "What is considered the auditory spectrum for human hearing?";
            ans1Text.text = "20 Hz to 2000 Hz";
            ans2Text.text = "2000Hz to 20kHz";
            ans3Text.text = "20Hz to 20kHz";
            ans4Text.text = "20Hz to 16kHz";
            prevBtnGo.SetActive(false);
            nextBtnGO.SetActive(true);
            submitBtnGo.SetActive(false);
            q1Ans = 3;
        }
        else if (curQuestion == 2)
        {
            questionText.text = "Boosting low end frequencies would most likely affect which instruments?";
            ans1Text.text = "Violin & cello.";
            ans2Text.text = "Cymbals & Snare.";
            ans3Text.text = "Keyboard & Vocals.";
            ans4Text.text = "Kick drum & bass guitar.";
            prevBtnGo.SetActive(true);
            nextBtnGO.SetActive(true);
            submitBtnGo.SetActive(false);
            q2Ans = 4;
        }
        else if (curQuestion == 3)
        {
            questionText.text = "What is Pink Noise?";
            ans1Text.text = "All frequencies of the auditory spectrum, at different intensity that the human ear perceives as flat.";
            ans2Text.text = "All frequencies of the auditory spectrum, at equal intensity.";
            ans3Text.text = "A lack of noise.";
            ans4Text.text = "All frequencies of the Auditory spectrum, played at random intensity.";
            prevBtnGo.SetActive(true);
            nextBtnGO.SetActive(false);
            q3Ans = 1;
            if (q1UserAns != 0 && q2UserAns != 0 && q3UserAns != 0)
            {
                submitBtnGo.SetActive(true);
            }
        }
    }

    void SetAns()
    {
        if (curQuestion == 1)
        {
            if (q1UserAns == 0)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q1UserAns == 1)
            {
                a1btn.GetComponent<Image>().color = selected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q1UserAns == 2)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = selected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q1UserAns == 3)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = selected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q1UserAns == 4)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = selected;
            }
        }
        else if (curQuestion == 2)
        {
            if (q2UserAns == 0)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q2UserAns == 1)
            {
                a1btn.GetComponent<Image>().color = selected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q2UserAns == 2)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = selected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q2UserAns == 3)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = selected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q2UserAns == 4)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = selected;
            }
        }
        else if (curQuestion == 3)
        {
            if (q3UserAns == 0)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q3UserAns == 1)
            {
                a1btn.GetComponent<Image>().color = selected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q3UserAns == 2)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = selected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q3UserAns == 3)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = selected;
                a4btn.GetComponent<Image>().color = notSelected;
            }
            else if (q3UserAns == 4)
            {
                a1btn.GetComponent<Image>().color = notSelected;
                a2btn.GetComponent<Image>().color = notSelected;
                a3btn.GetComponent<Image>().color = notSelected;
                a4btn.GetComponent<Image>().color = selected;
            }
        }
    }

    void Results()
    {
        if (q1Ans == q1UserAns)
        {
            score += 1;
        }
        if (q2Ans == q2UserAns)
        {
            score += 1;
        }
        if (q3Ans == q3UserAns)
        {
            score += 1;
        }

        if (score == 0)
        {
            badTextGO.SetActive(true);
        }
        else if (score == 1 || score == 2)
        {
            midTextGO.SetActive(true);
            sectionsTextGO.SetActive(true);
            //resetBtn.SetActive(true);
        }
        else if (score == 3)
        {
            goodTextGO.SetActive(true);
            //resetBtn.SetActive(false);
            if (netGlbScr.testLevel >= 0)
            {
                netGlbScr.testLevel = 1;
                netGlbScr.userScore = netGlbScr.userScore + 100;
                StartCoroutine(PostUserInfo());
            }
        }
        scoreText.text = score + " out of " + numberOfQuestions;
        sectionsText.text = wrongSections;
        resultsGO.SetActive(true);
        blockerGO.SetActive(true);
        glbScr.M1EQ_INTROQUIZ_Score = score;
        StartCoroutine(PostResults());
    }

    void WrongSections()
    {
        if (q1Ans != q1UserAns)
        {
            wrongSection1 = "Audio Spectrum";
        }
        else if (q1Ans == q1UserAns)
        {
            wrongSection1 = "";
        }
        if (q2Ans != q2UserAns)
        {
            wrongSection2 = "Frequency Ranges";
        }
        else if (q2Ans == q2UserAns)
        {
            wrongSection2 = "";
        }
        if (q3Ans != q3UserAns)
        {
            wrongSection3 = "Pink Noise";
        }
        else if (q3Ans == q3UserAns)
        {
            wrongSection3 = "";
        }

        wrongSections = wrongSection1 + " " + wrongSection2 + " " + wrongSection3;
    }

    public void ResetBtn()
    {
        SceneManager.LoadScene(4);
    }

    IEnumerator PostResults()
    {
        WWWForm form = new WWWForm();
        form.AddField("userEmail", netGlbScr.userEmail);
        form.AddField("userClass", netGlbScr.classYear);
        form.AddField("score", glbScr.M1EQ_INTROQUIZ_Score);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/M1Q_PostResults.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            //UnityEngine.Debug.Log(www.error);
            //GameObject.Find("Globals").GetComponent<results>().UploadError();
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            if (score > glbScr.M1EQ_INTROQUIZ_Score)
            {
                glbScr.M1EQ_INTROQUIZ_Score = score;
            }
        }

        www.Dispose();
    }

    IEnumerator PostUserInfo()
    {
        WWWForm form = new WWWForm();
        form.AddField("userEmail", netGlbScr.userEmail);
        form.AddField("userScore", netGlbScr.userScore);
        form.AddField("testLevel", netGlbScr.testLevel);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/M1QuizPostUserInfo.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            UnityEngine.Debug.Log(www.error);
            //GameObject.Find("Globals").GetComponent<results>().UploadError();
        }
        else
        {
            UnityEngine.Debug.Log(www.downloadHandler.text);
            if (www.downloadHandler.text == "New record created successfully")
            {
                //netGlbScr.testUploaded = true;
            }
        }
        www.Dispose();
    }
    public void NextBtn()
    {
        curQuestion += 1;
    }
    public void PrevBtn()
    {
        curQuestion -= 1;
    }
    public void SubmitBtn()
    {
        Results();
    }

    public void subYesBtn()
    {
        Results();
    }

    public void subNoBtn()
    {
        areYouSureGO.SetActive(false);
    }

    public void CloseQuiz()
    {
        curQuestion = 1;
        numberOfQuestions = 3;
        q1UserAns = 0;
        q2UserAns = 0;
        q3UserAns = 0;
        score = 0;
        quizCanvas.SetActive(false);
    }
}
