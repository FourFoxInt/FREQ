using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CheckConnection : MonoBehaviour
{
    [SerializeField] private GameObject conStatus;

    private void Start()
    {
        conStatus.SetActive(false);
        StartCoroutine(CheckCon());
    }

    IEnumerator CheckCon()
    {
        WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/checkCon.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            conStatus.SetActive(true);
        }
        else
        {
            conStatus.SetActive(false);
        }

        www.Dispose();
    }
}
