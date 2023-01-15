using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dbTestResults : MonoBehaviour
{
    private dbTest testScr;
    private Globals glbScr;

    [SerializeField] private Color correctColour;
    [SerializeField] private Color wrongColour;

    [SerializeField] private TextMeshProUGUI ex1correctText1;
    [SerializeField] private TextMeshProUGUI ex2correctText1;
    [SerializeField] private TextMeshProUGUI ex3correctText1;
    [SerializeField] private TextMeshProUGUI ex4correctText1;
    [SerializeField] private TextMeshProUGUI ex5correctText1;
    [SerializeField] private TextMeshProUGUI ex6correctText1;
    [SerializeField] private TextMeshProUGUI ex7correctText1;
    [SerializeField] private TextMeshProUGUI ex8correctText1;
    [SerializeField] private TextMeshProUGUI ex9correctText1;
    [SerializeField] private TextMeshProUGUI ex10correctText1;

    [SerializeField] private TextMeshProUGUI ex1userText1;
    [SerializeField] private TextMeshProUGUI ex2userText1;
    [SerializeField] private TextMeshProUGUI ex3userText1;
    [SerializeField] private TextMeshProUGUI ex4userText1;
    [SerializeField] private TextMeshProUGUI ex5userText1;
    [SerializeField] private TextMeshProUGUI ex6userText1;
    [SerializeField] private TextMeshProUGUI ex7userText1;
    [SerializeField] private TextMeshProUGUI ex8userText1;
    [SerializeField] private TextMeshProUGUI ex9userText1;
    [SerializeField] private TextMeshProUGUI ex10userText1;

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
        testScr = GameObject.Find("Test").GetComponent<dbTest>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }

    private void Update()
    {
        if (glbScr.cutOrBoost == "Both")
        {
            scoreText.text = "- " + testScr.score.ToString() + " out of 40";
        }
        else if (glbScr.cutOrBoost == "Boost" || glbScr.cutOrBoost == "Cut")
        {
            scoreText.text = "- " + testScr.score.ToString() + " out of 20";
        }

        if (glbScr.cutOrBoost == "Both")
        {
            ex1correctText1.text = testScr.ex1correctCbAns1 + " " + testScr.ex1CorrectAnswerText1 + " & " + testScr.ex1correctCbAns2 + " " + testScr.ex1CorrectAnswerText2;
            ex2correctText1.text = testScr.ex2correctCbAns1 + " " + testScr.ex2CorrectAnswerText1 + " & " + testScr.ex2correctCbAns2 + " " + testScr.ex2CorrectAnswerText2;
            ex3correctText1.text = testScr.ex3correctCbAns1 + " " + testScr.ex3CorrectAnswerText1 + " & " + testScr.ex3correctCbAns2 + " " + testScr.ex3CorrectAnswerText2;
            ex4correctText1.text = testScr.ex4correctCbAns1 + " " + testScr.ex4CorrectAnswerText1 + " & " + testScr.ex4correctCbAns2 + " " + testScr.ex4CorrectAnswerText2;
            ex5correctText1.text = testScr.ex5correctCbAns1 + " " + testScr.ex5CorrectAnswerText1 + " & " + testScr.ex5correctCbAns2 + " " + testScr.ex5CorrectAnswerText2;
            ex6correctText1.text = testScr.ex6correctCbAns1 + " " + testScr.ex6CorrectAnswerText1 + " & " + testScr.ex6correctCbAns2 + " " + testScr.ex6CorrectAnswerText2;
            ex7correctText1.text = testScr.ex7correctCbAns1 + " " + testScr.ex7CorrectAnswerText1 + " & " + testScr.ex7correctCbAns2 + " " + testScr.ex7CorrectAnswerText2;
            ex8correctText1.text = testScr.ex8correctCbAns1 + " " + testScr.ex8CorrectAnswerText1 + " & " + testScr.ex8correctCbAns2 + " " + testScr.ex8CorrectAnswerText2;
            ex9correctText1.text = testScr.ex9correctCbAns1 + " " + testScr.ex9CorrectAnswerText1 + " & " + testScr.ex9correctCbAns2 + " " + testScr.ex9CorrectAnswerText2;
            ex10correctText1.text = testScr.ex10correctCbAns1 + " " + testScr.ex10CorrectAnswerText1 + " & " + testScr.ex10correctCbAns2 + " " + testScr.ex10CorrectAnswerText2;
            ex1userText1.text = testScr.ex1userCbAns1 + " " + testScr.ex1UserAnswerText1 + " & " + testScr.ex1userCbAns2 + " " + testScr.ex1UserAnswerText2;
            ex2userText1.text = testScr.ex2userCbAns1 + " " + testScr.ex2UserAnswerText1 + " & " + testScr.ex2userCbAns2 + " " + testScr.ex2UserAnswerText2;
            ex3userText1.text = testScr.ex3userCbAns1 + " " + testScr.ex3UserAnswerText1 + " & " + testScr.ex3userCbAns2 + " " + testScr.ex3UserAnswerText2;
            ex4userText1.text = testScr.ex4userCbAns1 + " " + testScr.ex4UserAnswerText1 + " & " + testScr.ex4userCbAns2 + " " + testScr.ex4UserAnswerText2;
            ex5userText1.text = testScr.ex5userCbAns1 + " " + testScr.ex5UserAnswerText1 + " & " + testScr.ex5userCbAns2 + " " + testScr.ex5UserAnswerText2;
            ex6userText1.text = testScr.ex6userCbAns1 + " " + testScr.ex6UserAnswerText1 + " & " + testScr.ex6userCbAns2 + " " + testScr.ex6UserAnswerText2;
            ex7userText1.text = testScr.ex7userCbAns1 + " " + testScr.ex7UserAnswerText1 + " & " + testScr.ex7userCbAns2 + " " + testScr.ex7UserAnswerText2;
            ex8userText1.text = testScr.ex8userCbAns1 + " " + testScr.ex8UserAnswerText1 + " & " + testScr.ex8userCbAns2 + " " + testScr.ex8UserAnswerText2;
            ex9userText1.text = testScr.ex9userCbAns1 + " " + testScr.ex9UserAnswerText1 + " & " + testScr.ex9userCbAns2 + " " + testScr.ex9UserAnswerText2;
            ex10userText1.text = testScr.ex10userCbAns1 + " " + testScr.ex10UserAnswerText1 + " & " + testScr.ex10userCbAns2 + " " + testScr.ex10UserAnswerText2;
        }
        else if (glbScr.cutOrBoost == "Boost" || glbScr.cutOrBoost == "Cut") {
        
            ex1correctText1.text = testScr.ex1CorrectAnswerText1 + " & " + testScr.ex1CorrectAnswerText2;
            ex2correctText1.text = testScr.ex2CorrectAnswerText1 + " & " + testScr.ex2CorrectAnswerText2;
            ex3correctText1.text = testScr.ex3CorrectAnswerText1 + " & " + testScr.ex3CorrectAnswerText2;
            ex4correctText1.text = testScr.ex4CorrectAnswerText1 + " & " + testScr.ex4CorrectAnswerText2;
            ex5correctText1.text = testScr.ex5CorrectAnswerText1 + " & " + testScr.ex5CorrectAnswerText2;
            ex6correctText1.text = testScr.ex6CorrectAnswerText1 + " & " + testScr.ex6CorrectAnswerText2;
            ex7correctText1.text = testScr.ex7CorrectAnswerText1 + " & " + testScr.ex7CorrectAnswerText2;
            ex8correctText1.text = testScr.ex8CorrectAnswerText1 + " & " + testScr.ex8CorrectAnswerText2;
            ex9correctText1.text = testScr.ex9CorrectAnswerText1 + " & " + testScr.ex9CorrectAnswerText2;
            ex10correctText1.text = testScr.ex10CorrectAnswerText1 + " & " + testScr.ex10CorrectAnswerText1;
            ex1userText1.text = testScr.ex1UserAnswerText1 + " & " + testScr.ex1UserAnswerText2;
            ex2userText1.text = testScr.ex2UserAnswerText1 + " & " + testScr.ex2UserAnswerText2;
            ex3userText1.text = testScr.ex3UserAnswerText1 + " & " + testScr.ex3UserAnswerText2;
            ex4userText1.text = testScr.ex4UserAnswerText1 + " & " + testScr.ex4UserAnswerText2;
            ex5userText1.text = testScr.ex5UserAnswerText1 + " & " + testScr.ex5UserAnswerText2;
            ex6userText1.text = testScr.ex6UserAnswerText1 + " & " + testScr.ex6UserAnswerText2;
            ex7userText1.text = testScr.ex7UserAnswerText1 + " & " + testScr.ex7UserAnswerText2;
            ex8userText1.text = testScr.ex8UserAnswerText1 + " & " + testScr.ex8UserAnswerText2;
            ex9userText1.text = testScr.ex9UserAnswerText1 + " & " + testScr.ex9UserAnswerText2;
            ex10userText1.text = testScr.ex10UserAnswerText1 + " & " + testScr.ex10UserAnswerText2;
        }

        if (glbScr.cutOrBoost == "Both")
        {
            if (testScr.ex1CorrectAnswerText1 == testScr.ex1UserAnswerText1 && testScr.ex1correctCbAns1 == testScr.ex1userCbAns1
                && testScr.ex1CorrectAnswerText2 == testScr.ex1UserAnswerText2 && testScr.ex1correctCbAns2 == testScr.ex1userCbAns2
                || testScr.ex1CorrectAnswerText1 == testScr.ex1UserAnswerText2 && testScr.ex1correctCbAns1 == testScr.ex1userCbAns2
                && testScr.ex1CorrectAnswerText2 == testScr.ex1UserAnswerText1 && testScr.ex1correctCbAns2 == testScr.ex1userCbAns1)
            {
                ex1Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex1CorrectAnswerText1 != testScr.ex1UserAnswerText1 || testScr.ex1correctCbAns1 != testScr.ex1userCbAns1
                || testScr.ex1CorrectAnswerText2 != testScr.ex1UserAnswerText2 || testScr.ex1correctCbAns2 != testScr.ex1userCbAns2)
            {
                ex1Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex2CorrectAnswerText1 == testScr.ex2UserAnswerText1 && testScr.ex2correctCbAns1 == testScr.ex2userCbAns1
                && testScr.ex2CorrectAnswerText2 == testScr.ex2UserAnswerText2 && testScr.ex2correctCbAns2 == testScr.ex2userCbAns2
                || testScr.ex2CorrectAnswerText1 == testScr.ex2UserAnswerText2 && testScr.ex2correctCbAns1 == testScr.ex2userCbAns2
                && testScr.ex2CorrectAnswerText2 == testScr.ex2UserAnswerText1 && testScr.ex2correctCbAns2 == testScr.ex2userCbAns1)
            {
                ex2Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex2CorrectAnswerText1 != testScr.ex2UserAnswerText1 || testScr.ex2correctCbAns1 != testScr.ex2userCbAns1
                || testScr.ex2CorrectAnswerText2 != testScr.ex2UserAnswerText2 || testScr.ex2correctCbAns2 != testScr.ex2userCbAns2)
            {
                ex2Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex3CorrectAnswerText1 == testScr.ex3UserAnswerText1 && testScr.ex3correctCbAns1 == testScr.ex3userCbAns1
                && testScr.ex3CorrectAnswerText2 == testScr.ex3UserAnswerText2 && testScr.ex3correctCbAns2 == testScr.ex3userCbAns2
                || testScr.ex3CorrectAnswerText1 == testScr.ex3UserAnswerText2 && testScr.ex3correctCbAns1 == testScr.ex3userCbAns2
                && testScr.ex3CorrectAnswerText2 == testScr.ex3UserAnswerText1 && testScr.ex3correctCbAns2 == testScr.ex3userCbAns1)
            {
                ex3Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex3CorrectAnswerText1 != testScr.ex3UserAnswerText1 || testScr.ex3correctCbAns1 != testScr.ex3userCbAns1
                || testScr.ex3CorrectAnswerText2 != testScr.ex3UserAnswerText2 || testScr.ex3correctCbAns2 != testScr.ex3userCbAns2)
            {
                ex3Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex4CorrectAnswerText1 == testScr.ex4UserAnswerText1 && testScr.ex4correctCbAns1 == testScr.ex4userCbAns1
                && testScr.ex4CorrectAnswerText2 == testScr.ex4UserAnswerText2 && testScr.ex4correctCbAns2 == testScr.ex4userCbAns2
                || testScr.ex4CorrectAnswerText1 == testScr.ex4UserAnswerText2 && testScr.ex4correctCbAns1 == testScr.ex4userCbAns2
                && testScr.ex4CorrectAnswerText2 == testScr.ex4UserAnswerText1 && testScr.ex4correctCbAns2 == testScr.ex4userCbAns1)
            {
                ex4Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex4CorrectAnswerText1 != testScr.ex4UserAnswerText1 || testScr.ex4correctCbAns1 != testScr.ex4userCbAns1
                || testScr.ex4CorrectAnswerText2 != testScr.ex4UserAnswerText2 || testScr.ex4correctCbAns2 != testScr.ex4userCbAns2)
            {
                ex4Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex5CorrectAnswerText1 == testScr.ex5UserAnswerText1 && testScr.ex5correctCbAns1 == testScr.ex5userCbAns1
                && testScr.ex5CorrectAnswerText2 == testScr.ex5UserAnswerText2 && testScr.ex5correctCbAns2 == testScr.ex5userCbAns2
                || testScr.ex5CorrectAnswerText1 == testScr.ex5UserAnswerText2 && testScr.ex5correctCbAns1 == testScr.ex5userCbAns2
                && testScr.ex5CorrectAnswerText2 == testScr.ex5UserAnswerText1 && testScr.ex5correctCbAns2 == testScr.ex5userCbAns1)
            {
                ex5Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex5CorrectAnswerText1 != testScr.ex5UserAnswerText1 || testScr.ex5correctCbAns1 != testScr.ex5userCbAns1
                || testScr.ex5CorrectAnswerText2 != testScr.ex5UserAnswerText2 || testScr.ex5correctCbAns2 != testScr.ex5userCbAns2)
            {
                ex5Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex6CorrectAnswerText1 == testScr.ex6UserAnswerText1 && testScr.ex6correctCbAns1 == testScr.ex6userCbAns1
                && testScr.ex6CorrectAnswerText2 == testScr.ex6UserAnswerText2 && testScr.ex6correctCbAns2 == testScr.ex6userCbAns2
                || testScr.ex6CorrectAnswerText1 == testScr.ex6UserAnswerText2 && testScr.ex6correctCbAns1 == testScr.ex6userCbAns2
                && testScr.ex6CorrectAnswerText2 == testScr.ex6UserAnswerText1 && testScr.ex6correctCbAns2 == testScr.ex6userCbAns1)
            {
                ex6Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex6CorrectAnswerText1 != testScr.ex6UserAnswerText1 || testScr.ex6correctCbAns1 != testScr.ex6userCbAns1
                || testScr.ex6CorrectAnswerText2 != testScr.ex6UserAnswerText2 || testScr.ex6correctCbAns2 != testScr.ex6userCbAns2)
            {
                ex6Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex7CorrectAnswerText1 == testScr.ex7UserAnswerText1 && testScr.ex7correctCbAns1 == testScr.ex7userCbAns1
                && testScr.ex7CorrectAnswerText2 == testScr.ex7UserAnswerText2 && testScr.ex7correctCbAns2 == testScr.ex7userCbAns2
                || testScr.ex7CorrectAnswerText1 == testScr.ex7UserAnswerText2 && testScr.ex7correctCbAns1 == testScr.ex7userCbAns2
                && testScr.ex7CorrectAnswerText2 == testScr.ex7UserAnswerText1 && testScr.ex7correctCbAns2 == testScr.ex7userCbAns1)
            {
                ex7Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex7CorrectAnswerText1 != testScr.ex7UserAnswerText1 || testScr.ex7correctCbAns1 != testScr.ex7userCbAns1
                || testScr.ex7CorrectAnswerText2 != testScr.ex7UserAnswerText2 || testScr.ex7correctCbAns2 != testScr.ex7userCbAns2)
            {
                ex7Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex8CorrectAnswerText1 == testScr.ex8UserAnswerText1 && testScr.ex8correctCbAns1 == testScr.ex8userCbAns1
                && testScr.ex8CorrectAnswerText2 == testScr.ex8UserAnswerText2 && testScr.ex8correctCbAns2 == testScr.ex8userCbAns2
                || testScr.ex8CorrectAnswerText1 == testScr.ex8UserAnswerText2 && testScr.ex8correctCbAns1 == testScr.ex8userCbAns2
                && testScr.ex8CorrectAnswerText2 == testScr.ex8UserAnswerText1 && testScr.ex8correctCbAns2 == testScr.ex8userCbAns1)
            {
                ex8Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex8CorrectAnswerText1 != testScr.ex8UserAnswerText1 || testScr.ex8correctCbAns1 != testScr.ex8userCbAns1
                || testScr.ex8CorrectAnswerText2 != testScr.ex8UserAnswerText2 || testScr.ex8correctCbAns2 != testScr.ex8userCbAns2)
            {
                ex8Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex9CorrectAnswerText1 == testScr.ex9UserAnswerText1 && testScr.ex9correctCbAns1 == testScr.ex9userCbAns1
                && testScr.ex9CorrectAnswerText2 == testScr.ex9UserAnswerText2 && testScr.ex9correctCbAns2 == testScr.ex9userCbAns2
                || testScr.ex9CorrectAnswerText1 == testScr.ex9UserAnswerText2 && testScr.ex9correctCbAns1 == testScr.ex9userCbAns2
                && testScr.ex9CorrectAnswerText2 == testScr.ex9UserAnswerText1 && testScr.ex9correctCbAns2 == testScr.ex9userCbAns1)
            {
                ex9Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex9CorrectAnswerText1 != testScr.ex2UserAnswerText1 || testScr.ex9correctCbAns1 != testScr.ex9userCbAns1
                || testScr.ex9CorrectAnswerText2 != testScr.ex2UserAnswerText2 || testScr.ex9correctCbAns2 != testScr.ex9userCbAns2)
            {
                ex9Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex10CorrectAnswerText1 == testScr.ex10UserAnswerText1 && testScr.ex10correctCbAns1 == testScr.ex10userCbAns1
                && testScr.ex10CorrectAnswerText2 == testScr.ex10UserAnswerText2 && testScr.ex10correctCbAns2 == testScr.ex10userCbAns2
                || testScr.ex10CorrectAnswerText1 == testScr.ex10UserAnswerText2 && testScr.ex10correctCbAns1 == testScr.ex10userCbAns2
                && testScr.ex10CorrectAnswerText2 == testScr.ex10UserAnswerText1 && testScr.ex10correctCbAns2 == testScr.ex10userCbAns1)
            {
                ex10Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex10CorrectAnswerText1 != testScr.ex10UserAnswerText1 || testScr.ex10correctCbAns1 != testScr.ex10userCbAns1
                || testScr.ex10CorrectAnswerText2 != testScr.ex10UserAnswerText2 || testScr.ex10correctCbAns2 != testScr.ex10userCbAns2)
            {
                ex10Go.GetComponent<Image>().color = wrongColour;
            }
        }
        else if (glbScr.cutOrBoost == "Cut" || glbScr.cutOrBoost == "Boost")
        {
            if (testScr.ex1CorrectAnswerText1 == testScr.ex1UserAnswerText1
                && testScr.ex1CorrectAnswerText2 == testScr.ex1UserAnswerText2
                || testScr.ex1CorrectAnswerText1 == testScr.ex1UserAnswerText2
                && testScr.ex1CorrectAnswerText2 == testScr.ex1UserAnswerText1)
            {
                ex1Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex1CorrectAnswerText1 != testScr.ex1UserAnswerText1
                || testScr.ex1CorrectAnswerText2 != testScr.ex1UserAnswerText2)
            {
                ex1Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex2CorrectAnswerText1 == testScr.ex2UserAnswerText1
                && testScr.ex2CorrectAnswerText2 == testScr.ex2UserAnswerText2
                || testScr.ex2CorrectAnswerText1 == testScr.ex2UserAnswerText2
                && testScr.ex2CorrectAnswerText2 == testScr.ex2UserAnswerText1)
            {
                ex2Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex2CorrectAnswerText1 != testScr.ex2UserAnswerText1
                || testScr.ex2CorrectAnswerText2 != testScr.ex2UserAnswerText2)
            {
                ex2Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex3CorrectAnswerText1 == testScr.ex3UserAnswerText1
                && testScr.ex3CorrectAnswerText2 == testScr.ex3UserAnswerText2
                || testScr.ex3CorrectAnswerText1 == testScr.ex3UserAnswerText2
                && testScr.ex3CorrectAnswerText2 == testScr.ex3UserAnswerText1)
            {
                ex3Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex3CorrectAnswerText1 != testScr.ex3UserAnswerText1
                || testScr.ex3CorrectAnswerText2 != testScr.ex3UserAnswerText2)
            {
                ex3Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex4CorrectAnswerText1 == testScr.ex4UserAnswerText1
                && testScr.ex4CorrectAnswerText2 == testScr.ex4UserAnswerText2
                || testScr.ex4CorrectAnswerText1 == testScr.ex4UserAnswerText2
                && testScr.ex4CorrectAnswerText2 == testScr.ex4UserAnswerText1)
            {
                ex4Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex4CorrectAnswerText1 != testScr.ex4UserAnswerText1
                || testScr.ex4CorrectAnswerText2 != testScr.ex4UserAnswerText2)
            {
                ex4Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex5CorrectAnswerText1 == testScr.ex5UserAnswerText1
                && testScr.ex5CorrectAnswerText2 == testScr.ex5UserAnswerText2
                || testScr.ex5CorrectAnswerText1 == testScr.ex5UserAnswerText2
                && testScr.ex5CorrectAnswerText2 == testScr.ex5UserAnswerText1)
            {
                ex5Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex5CorrectAnswerText1 != testScr.ex5UserAnswerText1
                || testScr.ex5CorrectAnswerText2 != testScr.ex5UserAnswerText2)
            {
                ex5Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex6CorrectAnswerText1 == testScr.ex6UserAnswerText1
                && testScr.ex6CorrectAnswerText2 == testScr.ex6UserAnswerText2
                || testScr.ex6CorrectAnswerText1 == testScr.ex6UserAnswerText2
                && testScr.ex6CorrectAnswerText2 == testScr.ex6UserAnswerText1)
            {
                ex6Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex6CorrectAnswerText1 != testScr.ex6UserAnswerText1
                || testScr.ex6CorrectAnswerText2 != testScr.ex6UserAnswerText2)
            {
                ex6Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex7CorrectAnswerText1 == testScr.ex7UserAnswerText1
                && testScr.ex7CorrectAnswerText2 == testScr.ex7UserAnswerText2
                | testScr.ex7CorrectAnswerText1 == testScr.ex7UserAnswerText2
                && testScr.ex7CorrectAnswerText2 == testScr.ex7UserAnswerText1)
            {
                ex7Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex7CorrectAnswerText1 != testScr.ex7UserAnswerText1
                || testScr.ex7CorrectAnswerText2 != testScr.ex7UserAnswerText2)
            {
                ex7Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex8CorrectAnswerText1 == testScr.ex8UserAnswerText1
                && testScr.ex8CorrectAnswerText2 == testScr.ex8UserAnswerText2
                || testScr.ex8CorrectAnswerText1 == testScr.ex8UserAnswerText2
                && testScr.ex8CorrectAnswerText2 == testScr.ex8UserAnswerText1)
            {
                ex8Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex8CorrectAnswerText1 != testScr.ex8UserAnswerText1
                || testScr.ex8CorrectAnswerText2 != testScr.ex8UserAnswerText2)
            {
                ex8Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex9CorrectAnswerText1 == testScr.ex9UserAnswerText1
                && testScr.ex9CorrectAnswerText2 == testScr.ex9UserAnswerText2
                || testScr.ex9CorrectAnswerText1 == testScr.ex9UserAnswerText2
                && testScr.ex9CorrectAnswerText2 == testScr.ex9UserAnswerText1)
            {
                ex9Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex9CorrectAnswerText1 != testScr.ex2UserAnswerText1
                || testScr.ex9CorrectAnswerText2 != testScr.ex2UserAnswerText2)
            {
                ex9Go.GetComponent<Image>().color = wrongColour;
            }

            if (testScr.ex10CorrectAnswerText1 == testScr.ex10UserAnswerText1
                && testScr.ex10CorrectAnswerText2 == testScr.ex10UserAnswerText2
                ||testScr.ex10CorrectAnswerText1 == testScr.ex10UserAnswerText2
                && testScr.ex10CorrectAnswerText2 == testScr.ex10UserAnswerText1)
            {
                ex10Go.GetComponent<Image>().color = correctColour;
            }
            else if (testScr.ex10CorrectAnswerText1 != testScr.ex10UserAnswerText1
                || testScr.ex10CorrectAnswerText2 != testScr.ex10UserAnswerText2)
            {
                ex10Go.GetComponent<Image>().color = wrongColour;
            }
        }
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene(2);
    }
}

