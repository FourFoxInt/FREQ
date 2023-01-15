using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginError : MonoBehaviour
{
    [SerializeField] private Animator errorAni;
    [SerializeField] private TextMeshProUGUI errorText;

    public void ShowError(string e)
    {
        errorText.text = e;
        errorAni.SetBool("in", true);
    }

    public void HideError(){
        errorAni.SetBool("in", false);
    }
}
