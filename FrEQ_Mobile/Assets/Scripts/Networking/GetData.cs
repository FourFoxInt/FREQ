using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GetData : MonoBehaviour
{
    private NetworkGlobals netGlbScr;
    private Globals glbScr;

    private bool userInfoIn = false;
    private bool loginTrack = false;

    [SerializeField] private GameObject error;

    private bool quizChecked = false;
    private bool statsChecked = false;

    Dictionary<string, int> y1scores = new Dictionary<string, int>();
    List<int> y1eqt1scores = new List<int>();
    List<int> y1eqt2scores = new List<int>();
    List<int> y1eqt3scores = new List<int>();
    List<int> y1eqt4scores = new List<int>();
    List<int> y1eqt5scores = new List<int>();
    List<int> y1eqt6scores = new List<int>();
    List<int> y2eqt1scores = new List<int>();
    List<int> y2eqt2scores = new List<int>();
    List<int> y2eqt3scores = new List<int>();
    List<int> y2eqt4scores = new List<int>();
    List<int> y2eqt5scores = new List<int>();
    List<int> y2eqt6scores = new List<int>();
    List<int> y2eqt7scores = new List<int>();
    List<int> y2eqt8scores = new List<int>();
    List<int> y2eqt9scores = new List<int>();
    List<int> y2eqt10scores = new List<int>();
    List<int> y2eqt11scores = new List<int>();
    List<int> y2eqt12scores = new List<int>();
    List<int> y2eqt13scores = new List<int>();
    List<int> y2eqt14scores = new List<int>();
    List<int> y2eqt15scores = new List<int>();
    List<int> y2eqt16scores = new List<int>();
    List<int> y2eqt17scores = new List<int>();
    List<int> y2eqt18scores = new List<int>();
    List<int> y2eqt19scores = new List<int>();
    List<int> y2eqt20scores = new List<int>();
    List<int> y2eqt21scores = new List<int>();
    List<int> y2eqt22scores = new List<int>();
    List<int> y2eqt23scores = new List<int>();
    List<int> y2eqt24scores = new List<int>();
    List<int> y3eqt1scores = new List<int>();
    List<int> y3eqt2scores = new List<int>();
    List<int> y3eqt3scores = new List<int>();
    List<int> y3eqt4scores = new List<int>();
    List<int> y3eqt5scores = new List<int>();
    List<int> y3eqt6scores = new List<int>();
    List<int> y3eqt7scores = new List<int>();
    List<int> y3eqt8scores = new List<int>();
    List<int> y3eqt9scores = new List<int>();
    List<int> y3eqt10scores = new List<int>();
    List<int> y3eqt11scores = new List<int>();
    List<int> y3eqt12scores = new List<int>();
    List<int> y3eqt13scores = new List<int>();
    List<int> y3eqt14scores = new List<int>();
    List<int> y3eqt15scores = new List<int>();
    List<int> y3eqt16scores = new List<int>();
    List<int> y3eqt17scores = new List<int>();
    List<int> y3eqt18scores = new List<int>();
    List<int> y3eqt19scores = new List<int>();
    List<int> y3eqt20scores = new List<int>();
    List<int> y3eqt21scores = new List<int>();
    List<int> y3eqt22scores = new List<int>();
    List<int> y3eqt23scores = new List<int>();
    List<int> y3eqt24scores = new List<int>();
    List<int> y3eqdbt1scores = new List<int>();
    List<int> y3eqdbt2scores = new List<int>();
    List<int> y3eqdbt3scores = new List<int>();
    List<int> y3eqdbt4scores = new List<int>();
    List<int> y3eqdbt5scores = new List<int>();
    List<int> y3eqdbt6scores = new List<int>();

    List<int> y1Fxt1scores = new List<int>();
    List<int> y1Fxt2scores = new List<int>();
    List<int> y1Fxt3scores = new List<int>();
    List<int> y1Fxt4scores = new List<int>();
    List<int> y1Fxt5scores = new List<int>();
    List<int> y1Fxt6scores = new List<int>();

    private void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        error.SetActive(false);
        StartCoroutine(GetUserInfo());
        StartCoroutine(trackLogins());
    }

    IEnumerator GetUserInfo()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.username);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/getUserInfo.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            error.SetActive(true);
        }
        else
        {
            string[] userInfo = www.downloadHandler.text.Split('|');
            netGlbScr.userEmail = userInfo[0];
            netGlbScr.firstName = userInfo[1];
            netGlbScr.lastName = userInfo[2];
            netGlbScr.classYear = userInfo[3];
            netGlbScr.userScore = int.Parse(userInfo[4]);
            netGlbScr.listenEx = int.Parse(userInfo[5]);
            netGlbScr.pracEx = int.Parse(userInfo[6]);
            netGlbScr.tests = int.Parse(userInfo[7]);
            netGlbScr.testLevel = int.Parse(userInfo[8]);
            userInfoIn = true;
            StartCoroutine(Year1QUIZCheck());
            StartCoroutine(GetScores());
        }

        www.Dispose();
    }
    IEnumerator GetScores()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.username);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/y1eqTestScores.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            error.SetActive(true);
        }
        else
        {
            string[] userInfo = www.downloadHandler.text.Split('|');
            int x = 0;
            int y = 1; ;
            for (int i = 1; x < userInfo.Length; i++)
            {
                string testID = userInfo[x];
                //YEAR 1
                if (testID == "Y1EQ_T1")
                {
                    y1eqt1scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1EQ_T2")
                {
                    y1eqt2scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1EQ_T3")
                {
                    y1eqt3scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1EQ_T4")
                {
                    y1eqt4scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1EQ_T5")
                {
                    y1eqt5scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1EQ_T6")
                {
                    y1eqt6scores.Add(int.Parse(userInfo[y]));
                }

                //YEAR 1 FX

                else if (testID == "Y1FX_T1")
                {
                    y1Fxt1scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1FX_T2")
                {
                    y1Fxt2scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1FX_T3")
                {
                    y1Fxt3scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1FX_T4")
                {
                    y1Fxt4scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1FX_T5")
                {
                    y1Fxt5scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y1FX_T6")
                {
                    y1Fxt6scores.Add(int.Parse(userInfo[y]));
                }


                //YEAR 2
                else if (testID == "Y2EQ_T1")
                {
                    y2eqt1scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T2")
                {
                    y2eqt2scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T3")
                {
                    y2eqt3scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T4")
                {
                    y2eqt4scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T5")
                {
                    y2eqt5scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T6")
                {
                    y2eqt6scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T7")
                {
                    y2eqt7scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T8")
                {
                    y2eqt8scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T9")
                {
                    y2eqt9scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T10")
                {
                    y2eqt10scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T11")
                {
                    y2eqt11scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T12")
                {
                    y2eqt12scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T13")
                {
                    y2eqt13scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T14")
                {
                    y2eqt14scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T15")
                {
                    y2eqt15scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T16")
                {
                    y2eqt16scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T17")
                {
                    y2eqt17scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T18")
                {
                    y2eqt18scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T19")
                {
                    y2eqt19scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T20")
                {
                    y2eqt20scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T21")
                {
                    y2eqt21scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T22")
                {
                    y2eqt22scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T23")
                {
                    y2eqt23scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y2EQ_T24")
                {
                    y2eqt24scores.Add(int.Parse(userInfo[y]));
                }
                //YEAR 3
                else if (testID == "Y3EQ_T1")
                {
                    y3eqt1scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T2")
                {
                    y3eqt2scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T3")
                {
                    y3eqt3scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T4")
                {
                    y3eqt4scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T5")
                {
                    y3eqt5scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T6")
                {
                    y3eqt6scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T7")
                {
                    y3eqt7scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T8")
                {
                    y3eqt8scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T9")
                {
                    y3eqt9scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T10")
                {
                    y3eqt10scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T11")
                {
                    y3eqt11scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T12")
                {
                    y3eqt12scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T13")
                {
                    y3eqt13scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T14")
                {
                    y3eqt14scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T15")
                {
                    y3eqt15scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T16")
                {
                    y3eqt16scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T17")
                {
                    y3eqt17scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T18")
                {
                    y3eqt18scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T19")
                {
                    y3eqt19scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T20")
                {
                    y3eqt20scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T21")
                {
                    y3eqt21scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T22")
                {
                    y3eqt22scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T23")
                {
                    y3eqt23scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQ_T24")
                {
                    y3eqt24scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQDB_T1")
                {
                    y3eqdbt1scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQDB_T2")
                {
                    y3eqdbt2scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQDB_T3")
                {
                    y3eqdbt3scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQDB_T4")
                {
                    y3eqdbt4scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQDB_T5")
                {
                    y3eqdbt5scores.Add(int.Parse(userInfo[y]));
                }
                else if (testID == "Y3EQDB_T6")
                {
                    y3eqdbt6scores.Add(int.Parse(userInfo[y]));
                }

                //y1scores.Add(userInfo[x], int.Parse(userInfo[y]));
                x = x + 2;
                y = y + 2;
            }
            SetScores();
        }

        www.Dispose();
    }
    IEnumerator trackLogins()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.username);
        form.AddField("productVersion", netGlbScr.versionNumber);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/trackLogin.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //Debug.Log(www.downloadHandler.text);
            loginTrack = true;
        }

        www.Dispose();
    }

    public void ReturnToLogin()
    {
        SceneManager.LoadScene(1);
    }
    IEnumerator Year1QUIZCheck()
    {

        WWWForm form = new WWWForm();
        form.AddField("userEmail", netGlbScr.userEmail);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/y1QuizCheck.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            error.SetActive(true);
        }
        else
        {
            if (www.downloadHandler.text != "")
            {
                glbScr.M1EQ_INTROQUIZ_Score = int.Parse(www.downloadHandler.text);
            }
            quizChecked = true;
        }
        www.Dispose();
    }
    void SetScores()
    {
        glbScr.M1EQ_T1_Score = Mathf.Max(y1eqt1scores.ToArray());
        glbScr.M1EQ_T2_Score = Mathf.Max(y1eqt2scores.ToArray());
        glbScr.M1EQ_T3_Score = Mathf.Max(y1eqt3scores.ToArray());
        glbScr.M1EQ_T4_Score = Mathf.Max(y1eqt4scores.ToArray());
        glbScr.M1EQ_T5_Score = Mathf.Max(y1eqt5scores.ToArray());
        glbScr.M1EQ_T6_Score = Mathf.Max(y1eqt6scores.ToArray());

        glbScr.M2FX_T1_Score = Mathf.Max(y1Fxt1scores.ToArray());
        glbScr.M2FX_T2_Score = Mathf.Max(y1Fxt2scores.ToArray());
        glbScr.M2FX_T3_Score = Mathf.Max(y1Fxt3scores.ToArray());
        glbScr.M2FX_T4_Score = Mathf.Max(y1Fxt4scores.ToArray());
        glbScr.M2FX_T5_Score = Mathf.Max(y1Fxt5scores.ToArray());
        glbScr.M2FX_T6_Score = Mathf.Max(y1Fxt6scores.ToArray());

        glbScr.M3EQ_T1_Score = Mathf.Max(y2eqt1scores.ToArray());
        glbScr.M3EQ_T2_Score = Mathf.Max(y2eqt2scores.ToArray());
        glbScr.M3EQ_T3_Score = Mathf.Max(y2eqt3scores.ToArray());
        glbScr.M3EQ_T4_Score = Mathf.Max(y2eqt4scores.ToArray());
        glbScr.M3EQ_T5_Score = Mathf.Max(y2eqt5scores.ToArray());
        glbScr.M3EQ_T6_Score = Mathf.Max(y2eqt6scores.ToArray());
        glbScr.M3EQ_T7_Score = Mathf.Max(y2eqt7scores.ToArray());
        glbScr.M3EQ_T8_Score = Mathf.Max(y2eqt8scores.ToArray());
        glbScr.M3EQ_T9_Score = Mathf.Max(y2eqt9scores.ToArray());
        glbScr.M3EQ_T10_Score = Mathf.Max(y2eqt10scores.ToArray());
        glbScr.M3EQ_T11_Score = Mathf.Max(y2eqt11scores.ToArray());
        glbScr.M3EQ_T12_Score = Mathf.Max(y2eqt12scores.ToArray());
        glbScr.M3EQ_T13_Score = Mathf.Max(y2eqt13scores.ToArray());
        glbScr.M3EQ_T14_Score = Mathf.Max(y2eqt14scores.ToArray());
        glbScr.M3EQ_T15_Score = Mathf.Max(y2eqt15scores.ToArray());
        glbScr.M3EQ_T16_Score = Mathf.Max(y2eqt16scores.ToArray());
        glbScr.M3EQ_T17_Score = Mathf.Max(y2eqt17scores.ToArray());
        glbScr.M3EQ_T18_Score = Mathf.Max(y2eqt18scores.ToArray());
        glbScr.M3EQ_T19_Score = Mathf.Max(y2eqt19scores.ToArray());
        glbScr.M3EQ_T20_Score = Mathf.Max(y2eqt20scores.ToArray());
        glbScr.M3EQ_T21_Score = Mathf.Max(y2eqt21scores.ToArray());
        glbScr.M3EQ_T22_Score = Mathf.Max(y2eqt22scores.ToArray());
        glbScr.M3EQ_T23_Score = Mathf.Max(y2eqt23scores.ToArray());
        glbScr.M3EQ_T24_Score = Mathf.Max(y2eqt24scores.ToArray());

        /*        glbScr.M4FX_T1_Score = Mathf.Max(y1Fxt1scores.ToArray());
                glbScr.M4FX_T2_Score = Mathf.Max(y1Fxt2scores.ToArray());
                glbScr.M4FX_T3_Score = Mathf.Max(y1Fxt3scores.ToArray());
                glbScr.M4FX_T4_Score = Mathf.Max(y1Fxt4scores.ToArray());
                glbScr.M4FX_T5_Score = Mathf.Max(y1Fxt5scores.ToArray());
                glbScr.M4FX_T6_Score = Mathf.Max(y1Fxt6scores.ToArray());*/

        glbScr.M5EQ_T1_Score = Mathf.Max(y3eqt1scores.ToArray());
        glbScr.M5EQ_T2_Score = Mathf.Max(y3eqt2scores.ToArray());
        glbScr.M5EQ_T3_Score = Mathf.Max(y3eqt3scores.ToArray());
        glbScr.M5EQ_T4_Score = Mathf.Max(y3eqt4scores.ToArray());
        glbScr.M5EQ_T5_Score = Mathf.Max(y3eqt5scores.ToArray());
        glbScr.M5EQ_T6_Score = Mathf.Max(y3eqt6scores.ToArray());
        glbScr.M5EQ_T7_Score = Mathf.Max(y3eqt7scores.ToArray());
        glbScr.M5EQ_T8_Score = Mathf.Max(y3eqt8scores.ToArray());
        glbScr.M5EQ_T9_Score = Mathf.Max(y3eqt9scores.ToArray());
        glbScr.M5EQ_T10_Score = Mathf.Max(y3eqt10scores.ToArray());
        glbScr.M5EQ_T11_Score = Mathf.Max(y3eqt11scores.ToArray());
        glbScr.M5EQ_T12_Score = Mathf.Max(y3eqt12scores.ToArray());
        glbScr.M5EQ_T13_Score = Mathf.Max(y3eqt13scores.ToArray());
        glbScr.M5EQ_T14_Score = Mathf.Max(y3eqt14scores.ToArray());
        glbScr.M5EQ_T15_Score = Mathf.Max(y3eqt15scores.ToArray());
        glbScr.M5EQ_T16_Score = Mathf.Max(y3eqt16scores.ToArray());
        glbScr.M5EQ_T17_Score = Mathf.Max(y3eqt17scores.ToArray());
        glbScr.M5EQ_T18_Score = Mathf.Max(y3eqt18scores.ToArray());
        glbScr.M5EQ_T19_Score = Mathf.Max(y3eqt19scores.ToArray());
        glbScr.M5EQ_T20_Score = Mathf.Max(y3eqt20scores.ToArray());
        glbScr.M5EQ_T21_Score = Mathf.Max(y3eqt21scores.ToArray());
        glbScr.M5EQ_T22_Score = Mathf.Max(y3eqt22scores.ToArray());
        glbScr.M5EQ_T23_Score = Mathf.Max(y3eqt23scores.ToArray());
        glbScr.M5EQ_T24_Score = Mathf.Max(y3eqt24scores.ToArray());

        glbScr.M6EQDB_T1_Score = Mathf.Max(y3eqdbt1scores.ToArray());
        glbScr.M6EQDB_T2_Score = Mathf.Max(y3eqdbt2scores.ToArray());
        glbScr.M6EQDB_T3_Score = Mathf.Max(y3eqdbt3scores.ToArray());
        glbScr.M6EQDB_T4_Score = Mathf.Max(y3eqdbt4scores.ToArray());
        glbScr.M6EQDB_T5_Score = Mathf.Max(y3eqdbt5scores.ToArray());
        glbScr.M6EQDB_T6_Score = Mathf.Max(y3eqdbt6scores.ToArray());

        FindlatestFxModule();
        FindlatestEqModule();
        SceneManager.LoadScene(3);
    }

    public void DataErrorBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void FindlatestFxModule()
    {
        if (glbScr.M2FX_T1_Score == 0)
        {
            glbScr.currentFxMod = "M2_L1";
            return;
        }
        if (glbScr.M2FX_T2_Score == 0)
        {
            glbScr.currentFxMod = "M2_L2";
            return;
        }
        if (glbScr.M2FX_T3_Score == 0)
        {
            glbScr.currentFxMod = "M2_L3";
            return;
        }
        if (glbScr.M2FX_T4_Score == 0)
        {
            glbScr.currentFxMod = "M2_L4";
            return;
        }
        if (glbScr.M2FX_T5_Score == 0)
        {
            glbScr.currentFxMod = "M2_L5";
            return;
        }
        if (glbScr.M2FX_T6_Score == 0)
        {
            glbScr.currentFxMod = "M2_L6";
            return;
        }

        if (glbScr.M4FX_T1_Score == 0)
        {
            glbScr.currentFxMod = "M4_L1";
            return;
        }
        if (glbScr.M4FX_T2_Score == 0)
        {
            glbScr.currentFxMod = "M4_L2";
            return;
        }
        if (glbScr.M4FX_T3_Score == 0)
        {
            glbScr.currentFxMod = "M4_L3";
            return;
        }
        if (glbScr.M4FX_T4_Score == 0)
        {
            glbScr.currentFxMod = "M4_L4";
            return;
        }
        if (glbScr.M4FX_T5_Score == 0)
        {
            glbScr.currentFxMod = "M4_L5";
            return;
        }
        if (glbScr.M4FX_T6_Score == 0)
        {
            glbScr.currentFxMod = "M4_L6";
            return;
        }
    }

    public void FindlatestEqModule()
    {
        if (glbScr.M1EQ_T1_Score == 0)
        {
            glbScr.currentEqMod = "M1_L1";glbScr.currentEqTitle = "Beginner Frequencies.";
            return;
        }
        if (glbScr.M1EQ_T2_Score == 0)
        {
            glbScr.currentEqMod = "M1_L2";glbScr.currentEqTitle = "Beginner Frequencies.";
            return;
        }
        if (glbScr.M1EQ_T3_Score == 0)
        {
            glbScr.currentEqMod = "M1_L3";glbScr.currentEqTitle = "Beginner Frequencies.";
            return;
        }
        if (glbScr.M1EQ_T4_Score == 0)
        {
            glbScr.currentEqMod = "M1_L4";glbScr.currentEqTitle = "Beginner Frequencies.";
            return;
        }
        if (glbScr.M1EQ_T5_Score == 0)
        {
            glbScr.currentEqMod = "M1_L5";glbScr.currentEqTitle = "Beginner Frequencies.";
            return;
        }
        if (glbScr.M1EQ_T6_Score == 0)
        {
            glbScr.currentEqMod = "M1_L6";glbScr.currentEqTitle = "Beginner Frequencies.";
            return;
        }


        if (glbScr.M3EQ_T1_Score == 0)
        {
            glbScr.currentEqMod = "M3_L1";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T2_Score == 0)
        {
            glbScr.currentEqMod = "M3_L2";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T3_Score == 0)
        {
            glbScr.currentEqMod = "M3_L3";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T4_Score == 0)
        {
            glbScr.currentEqMod = "M3_L4";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T5_Score == 0)
        {
            glbScr.currentEqMod = "M3_L5";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T6_Score == 0)
        {
            glbScr.currentEqMod = "M3_L6";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T7_Score == 0)
        {
            glbScr.currentEqMod = "M3_L7";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T8_Score == 0)
        {
            glbScr.currentEqMod = "M3_L8";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T9_Score == 0)
        {
            glbScr.currentEqMod = "M3_L9";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T10_Score == 0)
        {
            glbScr.currentEqMod = "M3_L10";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T11_Score == 0)
        {
            glbScr.currentEqMod = "M3_L11";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T12_Score == 0)
        {
            glbScr.currentEqMod = "M3_L12";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T13_Score == 0)
        {
            glbScr.currentEqMod = "M3_L13";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T14_Score == 0)
        {
            glbScr.currentEqMod = "M3_L14";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T15_Score == 0)
        {
            glbScr.currentEqMod = "M3_L15";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T16_Score == 0)
        {
            glbScr.currentEqMod = "M3_L16";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T17_Score == 0)
        {
            glbScr.currentEqMod = "M3_L17";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T18_Score == 0)
        {
            glbScr.currentEqMod = "M3_L18";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T19_Score == 0)
        {
            glbScr.currentEqMod = "M3_L19";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T20_Score == 0)
        {
            glbScr.currentEqMod = "M3_L20";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T21_Score == 0)
        {
            glbScr.currentEqMod = "M3_L21";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T22_Score == 0)
        {
            glbScr.currentEqMod = "M3_L22";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T23_Score == 0)
        {
            glbScr.currentEqMod = "M3_L23";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }
        if (glbScr.M3EQ_T24_Score == 0)
        {
            glbScr.currentEqMod = "M3_L24";glbScr.currentEqTitle = "Ten Band Frequencies.";
            return;
        }


        if (glbScr.M5EQ_T1_Score == 0)
        {
            glbScr.currentEqMod = "M5_L1";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T2_Score == 0)
        {
            glbScr.currentEqMod = "M5_L2";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T3_Score == 0)
        {
            glbScr.currentEqMod = "M5_L3";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T4_Score == 0)
        {
            glbScr.currentEqMod = "M5_L4";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T5_Score == 0)
        {
            glbScr.currentEqMod = "M5_L5";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T6_Score == 0)
        {
            glbScr.currentEqMod = "M5_L6";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T7_Score == 0)
        {
            glbScr.currentEqMod = "M5_L7";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T8_Score == 0)
        {
            glbScr.currentEqMod = "M5_L8";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T9_Score == 0)
        {
            glbScr.currentEqMod = "M5_L9";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T10_Score == 0)
        {
            glbScr.currentEqMod = "M5_L10";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T11_Score == 0)
        {
            glbScr.currentEqMod = "M5_L11";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T12_Score == 0)
        {
            glbScr.currentEqMod = "M5_L12";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T13_Score == 0)
        {
            glbScr.currentEqMod = "M5_L13";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T14_Score == 0)
        {
            glbScr.currentEqMod = "M5_L14";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T15_Score == 0)
        {
            glbScr.currentEqMod = "M5_L15";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T16_Score == 0)
        {
            glbScr.currentEqMod = "M5_L16";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T17_Score == 0)
        {
            glbScr.currentEqMod = "M5_L17";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T18_Score == 0)
        {
            glbScr.currentEqMod = "M5_L18";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T19_Score == 0)
        {
            glbScr.currentEqMod = "M5_L19";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T20_Score == 0)
        {
            glbScr.currentEqMod = "M5_L20";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T21_Score == 0)
        {
            glbScr.currentEqMod = "M5_L21";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T22_Score == 0)
        {
            glbScr.currentEqMod = "M5_L22";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T23_Score == 0)
        {
            glbScr.currentEqMod = "M5_L23";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }
        if (glbScr.M5EQ_T24_Score == 0)
        {
            glbScr.currentEqMod = "M5_L24";glbScr.currentEqTitle = "28 Band Frequencies.";
            return;
        }


        if (glbScr.M6EQDB_T1_Score == 0)
        {
            glbScr.currentEqMod = "M6_L1";glbScr.currentEqTitle = "Dual Band Frequencies.";
            return;
        }
        if (glbScr.M6EQDB_T2_Score == 0)
        {
            glbScr.currentEqMod = "M6_L2";glbScr.currentEqTitle = "Dual Band Frequencies.";
            return;
        }
        if (glbScr.M6EQDB_T3_Score == 0)
        {
            glbScr.currentEqMod = "M6_L3";glbScr.currentEqTitle = "Dual Band Frequencies.";
            return;
        }
        if (glbScr.M6EQDB_T4_Score == 0)
        {
            glbScr.currentEqMod = "M6_L4";glbScr.currentEqTitle = "Dual Band Frequencies.";
            return;
        }
        if (glbScr.M6EQDB_T5_Score == 0)
        {
            glbScr.currentEqMod = "M6_L5";glbScr.currentEqTitle = "Dual Band Frequencies.";
            return;
        }
        if (glbScr.M6EQDB_T6_Score == 0)
        {
            glbScr.currentEqMod = "M6_L6";glbScr.currentEqTitle = "Dual Band Frequencies.";
            return;
        }
    }
}
