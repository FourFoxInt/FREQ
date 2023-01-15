using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ProfileUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameText;
    private NetworkGlobals netGlbScr;

    private void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        if (netGlbScr.firstName != "" && netGlbScr.firstName != "...")
        {
            usernameText.text = netGlbScr.firstName + " " + netGlbScr.lastName;
        }
        else
        {
            usernameText.text = netGlbScr.username;
        }
    }
}
