using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkGlobals : MonoBehaviour
{

    public static NetworkGlobals sharedInstance = null;

    public bool loggedIn = false;
    public double userID;
    public string username;
    public string userEmail;
    public string firstName;
    public string lastName;
    public string classYear;
    public int userScore;
    public int listenEx;
    public int pracEx;
    public int tests;
    public int testLevel;
    public string versionNumber;
    public string versionCheckNum;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
