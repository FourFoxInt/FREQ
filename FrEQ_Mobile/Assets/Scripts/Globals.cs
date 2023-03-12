using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals sharedInstance = null;
    //GLOBAL VARIABLES
    public string currentCourse;
    public string lessonID;
    public string currentTitle;
    public string currentDesc;

    //PLAYER VARIABLES
    public string cutOrBoost;
    public string pinkOrMusic;
    public string anserBtnsType;
    public float minFreq;
    public float maxFreq;
    public float minFx;
    public float maxFx;
    public string appTestID;
    public string globalTestId;
    public int passMark;
    public bool canHalfMark = false;
    public bool canNoChange = false;

    //Continue journey section
    public string currentFxMod;
    public string currentFxTitle;
    public string currentEqMod;
    public string currentEqTitle;

    //Module stats
    public float m1eq_passedTests;
    public int M1EQ_INTROQUIZ_Score;
    public int M1EQ_T1_Score;
    public int M1EQ_T2_Score;
    public int M1EQ_T3_Score;
    public int M1EQ_T4_Score;
    public int M1EQ_T5_Score;
    public int M1EQ_T6_Score;

    //Module stats
    public bool m2FXlocked = true;
    public float m2fx_passedTests;
    public int M2FX_T1_Score;
    public int M2FX_T2_Score;
    public int M2FX_T3_Score;
    public int M2FX_T4_Score;
    public int M2FX_T5_Score;
    public int M2FX_T6_Score;

    //Module stats
    public bool m3locked = true;
    public float m3eq_passedTests;
    public int M3EQ_T1_Score;
    public int M3EQ_T2_Score;
    public int M3EQ_T3_Score;
    public int M3EQ_T4_Score;
    public int M3EQ_T5_Score;
    public int M3EQ_T6_Score;
    public int M3EQ_T7_Score;
    public int M3EQ_T8_Score;
    public int M3EQ_T9_Score;
    public int M3EQ_T10_Score;
    public int M3EQ_T11_Score;
    public int M3EQ_T12_Score;
    public int M3EQ_T13_Score;
    public int M3EQ_T14_Score;
    public int M3EQ_T15_Score;
    public int M3EQ_T16_Score;
    public int M3EQ_T17_Score;
    public int M3EQ_T18_Score;
    public int M3EQ_T19_Score;
    public int M3EQ_T20_Score;
    public int M3EQ_T21_Score;
    public int M3EQ_T22_Score;
    public int M3EQ_T23_Score;
    public int M3EQ_T24_Score;

    //Module stats
    public bool m4FXlocked = true;
    public float m4fx_passedTests;
    public int M4FX_T1_Score;
    public int M4FX_T2_Score;
    public int M4FX_T3_Score;
    public int M4FX_T4_Score;
    public int M4FX_T5_Score;
    public int M4FX_T6_Score;

    public bool m5locked = true;
    public float m5eq_passedTests;
    public int M5EQ_T1_Score;
    public int M5EQ_T2_Score;
    public int M5EQ_T3_Score;
    public int M5EQ_T4_Score;
    public int M5EQ_T5_Score;
    public int M5EQ_T6_Score;
    public int M5EQ_T7_Score;
    public int M5EQ_T8_Score;
    public int M5EQ_T9_Score;
    public int M5EQ_T10_Score;
    public int M5EQ_T11_Score;
    public int M5EQ_T12_Score;
    public int M5EQ_T13_Score;
    public int M5EQ_T14_Score;
    public int M5EQ_T15_Score;
    public int M5EQ_T16_Score;
    public int M5EQ_T17_Score;
    public int M5EQ_T18_Score;
    public int M5EQ_T19_Score;
    public int M5EQ_T20_Score;
    public int M5EQ_T21_Score;
    public int M5EQ_T22_Score;
    public int M5EQ_T23_Score;
    public int M5EQ_T24_Score;

    public bool m6dblocked = true;
    public float m6eqDb_passedTests;
    public int M6EQDB_T1_Score;
    public int M6EQDB_T2_Score;
    public int M6EQDB_T3_Score;
    public int M6EQDB_T4_Score;
    public int M6EQDB_T5_Score;
    public int M6EQDB_T6_Score;

    [Header("Audio Settings")]
    public float masterVolume = 1f;
    public bool hasHadWarning = false;

    private void Update()
    {
        if (cutOrBoost == "Both")
        {
            passMark = 13;
        }
        else if (cutOrBoost == "Cut" || cutOrBoost == "Boost")
        {
            passMark = 6;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
