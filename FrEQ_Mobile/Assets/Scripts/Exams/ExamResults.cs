using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExamResults : MonoBehaviour
{
    private EqExam eQexamScr; 
    private FxExam fXexamScr;
    private DbExam dBexamScr;
    private NetworkGlobals netGlbscr;
    private Globals glbScr;
    public string totalPossibleScore;

    [SerializeField] private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        eQexamScr = FindObjectOfType<EqExam>();
        fXexamScr = FindObjectOfType<FxExam>();
        dBexamScr = FindObjectOfType<DbExam>();
        netGlbscr = FindObjectOfType<NetworkGlobals>();
        glbScr = FindObjectOfType<Globals>();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = GameObject.Find("EqExam").GetComponent<EqExam>().score.ToString() + " out of " + totalPossibleScore;
        //scoreText.text = GameObject.Find("FxExam").GetComponent<FxExam>().score.ToString() + " out of " + totalPossibleScore;
        //scoreText.text = GameObject.Find("dBExam").GetComponent<DbExam>().score.ToString() + " out of " + totalPossibleScore;
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene(2);
    }
}
