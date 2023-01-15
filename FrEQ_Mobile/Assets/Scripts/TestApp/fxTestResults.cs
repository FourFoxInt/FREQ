using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fxTestResults : MonoBehaviour
{
    private fxTest fxTestScr;
    private Globals glbScr;

    [SerializeField] private Color correctColour;
    [SerializeField] private Color wrongColour;

    [SerializeField] private TextMeshProUGUI ex1correctText;
    [SerializeField] private TextMeshProUGUI ex2correctText;
    [SerializeField] private TextMeshProUGUI ex3correctText;
    [SerializeField] private TextMeshProUGUI ex4correctText;
    [SerializeField] private TextMeshProUGUI ex5correctText;
    [SerializeField] private TextMeshProUGUI ex6correctText;
    [SerializeField] private TextMeshProUGUI ex7correctText;
    [SerializeField] private TextMeshProUGUI ex8correctText;

    [SerializeField] private TextMeshProUGUI ex1userText;
    [SerializeField] private TextMeshProUGUI ex2userText;
    [SerializeField] private TextMeshProUGUI ex3userText;
    [SerializeField] private TextMeshProUGUI ex4userText;
    [SerializeField] private TextMeshProUGUI ex5userText;
    [SerializeField] private TextMeshProUGUI ex6userText;
    [SerializeField] private TextMeshProUGUI ex7userText;
    [SerializeField] private TextMeshProUGUI ex8userText;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject ex1Go;
    [SerializeField] private GameObject ex2Go;
    [SerializeField] private GameObject ex3Go;
    [SerializeField] private GameObject ex4Go;
    [SerializeField] private GameObject ex5Go;
    [SerializeField] private GameObject ex6Go;
    [SerializeField] private GameObject ex7Go;
    [SerializeField] private GameObject ex8Go;

    private void Start()
    {
        fxTestScr = GameObject.Find("Test").GetComponent<fxTest>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }

    private void Update()
    {

        scoreText.text = fxTestScr.score.ToString() + " out of 8";

            ex1correctText.text = fxTestScr.ex1CorrectAnswerText;
            ex2correctText.text = fxTestScr.ex2CorrectAnswerText;
            ex3correctText.text = fxTestScr.ex3CorrectAnswerText;
            ex4correctText.text = fxTestScr.ex4CorrectAnswerText;
            ex5correctText.text = fxTestScr.ex5CorrectAnswerText;
            ex6correctText.text = fxTestScr.ex6CorrectAnswerText;
            ex7correctText.text = fxTestScr.ex7CorrectAnswerText;
            ex8correctText.text = fxTestScr.ex8CorrectAnswerText;

            ex1userText.text = fxTestScr.ex1UserAnswerText;
            ex2userText.text = fxTestScr.ex2UserAnswerText;
            ex3userText.text = fxTestScr.ex3UserAnswerText;
            ex4userText.text = fxTestScr.ex4UserAnswerText;
            ex5userText.text = fxTestScr.ex5UserAnswerText;
            ex6userText.text = fxTestScr.ex6UserAnswerText;
            ex7userText.text = fxTestScr.ex7UserAnswerText;
            ex8userText.text = fxTestScr.ex8UserAnswerText;


            if (fxTestScr.ex1CorrectAnswerText == fxTestScr.ex1UserAnswerText)
            {
                ex1Go.GetComponent<Image>().color = correctColour;
            }
            else if (fxTestScr.ex1CorrectAnswerText != fxTestScr.ex1UserAnswerText)
            {
                ex1Go.GetComponent<Image>().color = wrongColour;
            }

            if (fxTestScr.ex2CorrectAnswerText == fxTestScr.ex2UserAnswerText)
            {
                ex2Go.GetComponent<Image>().color = correctColour;
            }
            else if (fxTestScr.ex2CorrectAnswerText != fxTestScr.ex2UserAnswerText)
            {
                ex2Go.GetComponent<Image>().color = wrongColour;
            }

            if (fxTestScr.ex3CorrectAnswerText == fxTestScr.ex3UserAnswerText)
            {
                ex3Go.GetComponent<Image>().color = correctColour;
            }
            else if (fxTestScr.ex3CorrectAnswerText != fxTestScr.ex3UserAnswerText)
            {
                ex3Go.GetComponent<Image>().color = wrongColour;
            }

            if (fxTestScr.ex4CorrectAnswerText == fxTestScr.ex4UserAnswerText)
            {
                ex4Go.GetComponent<Image>().color = correctColour;
            }
            else if (fxTestScr.ex4CorrectAnswerText != fxTestScr.ex4UserAnswerText)
            {
                ex4Go.GetComponent<Image>().color = wrongColour;
            }

            if (fxTestScr.ex5CorrectAnswerText == fxTestScr.ex5UserAnswerText)
            {
                ex5Go.GetComponent<Image>().color = correctColour;
            }
            else if (fxTestScr.ex5CorrectAnswerText != fxTestScr.ex5UserAnswerText)
            {
                ex5Go.GetComponent<Image>().color = wrongColour;
            }

            if (fxTestScr.ex6CorrectAnswerText == fxTestScr.ex6UserAnswerText)
            {
                ex6Go.GetComponent<Image>().color = correctColour;
            }
            else if (fxTestScr.ex6CorrectAnswerText != fxTestScr.ex6UserAnswerText)
            {
                ex6Go.GetComponent<Image>().color = wrongColour;
            }

            if (fxTestScr.ex7CorrectAnswerText == fxTestScr.ex7UserAnswerText)
            {
                ex7Go.GetComponent<Image>().color = correctColour;
            }
            else if (fxTestScr.ex7CorrectAnswerText != fxTestScr.ex7UserAnswerText)
            {
                ex7Go.GetComponent<Image>().color = wrongColour;
            }

            if (fxTestScr.ex8CorrectAnswerText == fxTestScr.ex8UserAnswerText)
            {
                ex8Go.GetComponent<Image>().color = correctColour;
            }
            else if (fxTestScr.ex8CorrectAnswerText != fxTestScr.ex8UserAnswerText)
            {
                ex8Go.GetComponent<Image>().color = wrongColour;
            }
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene(2);
    }
}
