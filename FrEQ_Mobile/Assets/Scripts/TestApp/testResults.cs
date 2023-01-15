using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class testResults : MonoBehaviour
{
    private Test testScr;
    private NetworkGlobals netGlbscr;
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
    [SerializeField] private TextMeshProUGUI ex9correctText;
    [SerializeField] private TextMeshProUGUI ex10correctText;

    [SerializeField] private TextMeshProUGUI ex1userText;
    [SerializeField] private TextMeshProUGUI ex2userText;
    [SerializeField] private TextMeshProUGUI ex3userText;
    [SerializeField] private TextMeshProUGUI ex4userText;
    [SerializeField] private TextMeshProUGUI ex5userText;
    [SerializeField] private TextMeshProUGUI ex6userText;
    [SerializeField] private TextMeshProUGUI ex7userText;
    [SerializeField] private TextMeshProUGUI ex8userText;
    [SerializeField] private TextMeshProUGUI ex9userText;
    [SerializeField] private TextMeshProUGUI ex10userText;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject ex1Go;
    [SerializeField] private GameObject ex2Go;
    [SerializeField] private GameObject ex3Go;
    [SerializeField] private GameObject ex4Go;
    [SerializeField] private GameObject ex5Go;
    [SerializeField] private GameObject ex6Go;
    [SerializeField] private GameObject ex7Go;
    [SerializeField] private GameObject ex8Go;
    [SerializeField] private GameObject ex9Go;
    [SerializeField] private GameObject ex10Go;

    private void Start()
    {
        testScr = GameObject.Find("Test").GetComponent<Test>();
        netGlbscr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }

    private void Update()
    {
        if (glbScr.cutOrBoost == "Both" && glbScr.currentCourse == "M1" || glbScr.cutOrBoost == "Both" && glbScr.currentCourse == "M1")
        {
            scoreText.text = "- " + testScr.score.ToString() + " out of 20";
        }
        else if (glbScr.cutOrBoost == "Both" && netGlbscr.classYear == "Year3")
        {
            scoreText.text = "- " + testScr.score.ToString() + " out of 30";
        }
        else if (glbScr.cutOrBoost == "Boost" && glbScr.currentCourse == "M5" || glbScr.cutOrBoost == "Cut" && glbScr.currentCourse == "M5")
        {
            scoreText.text = "- " + testScr.score.ToString() + " out of 20";
        }
        else if (glbScr.cutOrBoost == "Boost" && glbScr.currentCourse == "M1" || glbScr.cutOrBoost == "Cut" && glbScr.currentCourse == "M1" ||
            glbScr.cutOrBoost == "Boost" && glbScr.currentCourse == "M3" || glbScr.cutOrBoost == "Cut" && glbScr.currentCourse == "M3")
        {
            scoreText.text = testScr.score.ToString() + " out of 10";
        }

        if (glbScr.cutOrBoost == "Both")
        {
            ex1correctText.text = testScr.ex1correctCbAns + " " + testScr.ex1CorrectAnswerText;
            ex2correctText.text = testScr.ex2correctCbAns + " " + testScr.ex2CorrectAnswerText;
            ex3correctText.text = testScr.ex3correctCbAns + " " + testScr.ex3CorrectAnswerText;
            ex4correctText.text = testScr.ex4correctCbAns + " " + testScr.ex4CorrectAnswerText;
            ex5correctText.text = testScr.ex5correctCbAns + " " + testScr.ex5CorrectAnswerText;
            ex6correctText.text = testScr.ex6correctCbAns + " " + testScr.ex6CorrectAnswerText;
            ex7correctText.text = testScr.ex7correctCbAns + " " + testScr.ex7CorrectAnswerText;
            ex8correctText.text = testScr.ex8correctCbAns + " " + testScr.ex8CorrectAnswerText;
            ex9correctText.text = testScr.ex9correctCbAns + " " + testScr.ex9CorrectAnswerText;
            ex10correctText.text = testScr.ex10correctCbAns + " " + testScr.ex10CorrectAnswerText;
            ex1userText.text = testScr.ex1userCbAns + " " + testScr.ex1UserAnswerText;
            ex2userText.text = testScr.ex2userCbAns + " " + testScr.ex2UserAnswerText;
            ex3userText.text = testScr.ex3userCbAns + " " + testScr.ex3UserAnswerText;
            ex4userText.text = testScr.ex4userCbAns + " " + testScr.ex4UserAnswerText;
            ex5userText.text = testScr.ex5userCbAns + " " + testScr.ex5UserAnswerText;
            ex6userText.text = testScr.ex6userCbAns + " " + testScr.ex6UserAnswerText;
            ex7userText.text = testScr.ex7userCbAns + " " + testScr.ex7UserAnswerText;
            ex8userText.text = testScr.ex8userCbAns + " " + testScr.ex8UserAnswerText;
            ex9userText.text = testScr.ex9userCbAns + " " + testScr.ex9UserAnswerText;
            ex10userText.text = testScr.ex10userCbAns + " " + testScr.ex10UserAnswerText;
        }
        else if (glbScr.cutOrBoost == "Boost" || glbScr.cutOrBoost == "Cut")
        {
            ex1correctText.text = testScr.ex1CorrectAnswerText;
            ex2correctText.text = testScr.ex2CorrectAnswerText;
            ex3correctText.text = testScr.ex3CorrectAnswerText;
            ex4correctText.text = testScr.ex4CorrectAnswerText;
            ex5correctText.text = testScr.ex5CorrectAnswerText;
            ex6correctText.text = testScr.ex6CorrectAnswerText;
            ex7correctText.text = testScr.ex7CorrectAnswerText;
            ex8correctText.text = testScr.ex8CorrectAnswerText;
            ex9correctText.text = testScr.ex9CorrectAnswerText;
            ex10correctText.text = testScr.ex10CorrectAnswerText;
            ex1userText.text = testScr.ex1UserAnswerText;
            ex2userText.text = testScr.ex2UserAnswerText;
            ex3userText.text = testScr.ex3UserAnswerText;
            ex4userText.text = testScr.ex4UserAnswerText;
            ex5userText.text = testScr.ex5UserAnswerText;
            ex6userText.text = testScr.ex6UserAnswerText;
            ex7userText.text = testScr.ex7UserAnswerText;
            ex8userText.text = testScr.ex8UserAnswerText;
            ex9userText.text = testScr.ex9UserAnswerText;
            ex10userText.text = testScr.ex10UserAnswerText;
        }

        if (glbScr.cutOrBoost == "Both")
        {
            if (testScr.ex1CorrectAnswerText == testScr.ex1UserAnswerText && testScr.ex1correctCbAns == testScr.ex1userCbAns)
            {
                ex1Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex1CorrectAnswerText != testScr.ex1UserAnswerText || testScr.ex1correctCbAns != testScr.ex1userCbAns)
            {
                ex1Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex2CorrectAnswerText == testScr.ex2UserAnswerText && testScr.ex2correctCbAns == testScr.ex2userCbAns)
            {
                ex2Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex2CorrectAnswerText != testScr.ex2UserAnswerText || testScr.ex2correctCbAns != testScr.ex2userCbAns)
            {
                ex2Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex3CorrectAnswerText == testScr.ex3UserAnswerText && testScr.ex3correctCbAns == testScr.ex3userCbAns)
            {
                ex3Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex3CorrectAnswerText != testScr.ex3UserAnswerText || testScr.ex3correctCbAns != testScr.ex3userCbAns)
            {
                ex3Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex4CorrectAnswerText == testScr.ex4UserAnswerText && testScr.ex4correctCbAns == testScr.ex4userCbAns)
            {
                ex4Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex4CorrectAnswerText != testScr.ex4UserAnswerText || testScr.ex4correctCbAns != testScr.ex4userCbAns)
            {
                ex4Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex5CorrectAnswerText == testScr.ex5UserAnswerText && testScr.ex5correctCbAns == testScr.ex5userCbAns)
            {
                ex5Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex5CorrectAnswerText != testScr.ex5UserAnswerText || testScr.ex5correctCbAns != testScr.ex5userCbAns)
            {
                ex5Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex6CorrectAnswerText == testScr.ex6UserAnswerText && testScr.ex6correctCbAns == testScr.ex6userCbAns)
            {
                ex6Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex6CorrectAnswerText != testScr.ex6UserAnswerText || testScr.ex6correctCbAns != testScr.ex6userCbAns)
            {
                ex6Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex7CorrectAnswerText == testScr.ex7UserAnswerText && testScr.ex7correctCbAns == testScr.ex7userCbAns)
            {
                ex7Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex7CorrectAnswerText != testScr.ex7UserAnswerText || testScr.ex7correctCbAns != testScr.ex7userCbAns)
            {
                ex7Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex8CorrectAnswerText == testScr.ex8UserAnswerText && testScr.ex8correctCbAns == testScr.ex8userCbAns)
            {
                ex8Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex8CorrectAnswerText != testScr.ex8UserAnswerText || testScr.ex8correctCbAns != testScr.ex8userCbAns)
            {
                ex8Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex9CorrectAnswerText == testScr.ex9UserAnswerText && testScr.ex9correctCbAns == testScr.ex9userCbAns)
            {
                ex9Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex9CorrectAnswerText != testScr.ex2UserAnswerText || testScr.ex9correctCbAns != testScr.ex9userCbAns)
            {
                ex9Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex10CorrectAnswerText == testScr.ex10UserAnswerText && testScr.ex10correctCbAns == testScr.ex10userCbAns)
            {
                ex10Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex10CorrectAnswerText != testScr.ex10UserAnswerText || testScr.ex10correctCbAns != testScr.ex10userCbAns)
            {
                ex10Go.GetComponent<Image>().color = wrongColour;
            }
        }
        else if (glbScr.cutOrBoost == "Cut" || glbScr.cutOrBoost == "Boost")
        {
            if (testScr.ex1CorrectAnswerText == testScr.ex1UserAnswerText)
            {
                ex1Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex1CorrectAnswerText != testScr.ex1UserAnswerText)
            {
                ex1Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex2CorrectAnswerText == testScr.ex2UserAnswerText)
            {
                ex2Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex2CorrectAnswerText != testScr.ex2UserAnswerText)
            {
                ex2Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex3CorrectAnswerText == testScr.ex3UserAnswerText)
            {
                ex3Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex3CorrectAnswerText != testScr.ex3UserAnswerText)
            {
                ex3Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex4CorrectAnswerText == testScr.ex4UserAnswerText)
            {
                ex4Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex4CorrectAnswerText != testScr.ex4UserAnswerText)
            {
                ex4Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex5CorrectAnswerText == testScr.ex5UserAnswerText)
            {
                ex5Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex5CorrectAnswerText != testScr.ex5UserAnswerText)
            {
                ex5Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex6CorrectAnswerText == testScr.ex6UserAnswerText)
            {
                ex6Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex6CorrectAnswerText != testScr.ex6UserAnswerText)
            {
                ex6Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex7CorrectAnswerText == testScr.ex7UserAnswerText)
            {
                ex7Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex7CorrectAnswerText != testScr.ex7UserAnswerText)
            {
                ex7Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex8CorrectAnswerText == testScr.ex8UserAnswerText)
            {
                ex8Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex8CorrectAnswerText != testScr.ex8UserAnswerText)
            {
                ex8Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex9CorrectAnswerText == testScr.ex9UserAnswerText)
            {
                ex9Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex9CorrectAnswerText != testScr.ex2UserAnswerText)
            {
                ex9Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex10CorrectAnswerText == testScr.ex10UserAnswerText)
            {
                ex10Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex10CorrectAnswerText != testScr.ex10UserAnswerText)
            {
                ex10Go.GetComponent<Image>().color = wrongColour;
            }
        }
    }

    public void HomeBtn()
    {
            SceneManager.LoadScene(3);
    }
}
