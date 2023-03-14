using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator logoAni;

    private void Start()
    {
        if (PlayerPrefs.HasKey("hadAudioWarning"))
        {
            if (PlayerPrefs.GetInt("hadAudioWarning") == 0)
            {
                FindObjectOfType<Globals>().hasHadWarning = false;
            }
            else if (PlayerPrefs.GetInt("hadAudioWarning") == 1)
            {
                FindObjectOfType<Globals>().hasHadWarning = true;
            }
        }

        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            FindObjectOfType<Globals>().masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        }
        StartCoroutine(LoadLogin());

        FMODUnity.RuntimeManager.LoadBank("Master");
        if (FMODUnity.RuntimeManager.HasBankLoaded("Master"))
        {
            StartCoroutine(LoadLogin());
        }
    }

    IEnumerator LoadLogin()
    {
        yield return new WaitForSeconds(1);
        logoAni.SetBool("out", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
