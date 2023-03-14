using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioWarning : MonoBehaviour
{
    [Header("References")]
    private Globals globals;
    [SerializeField] private Button playBtn;
    [SerializeField] private Button playSampleBtn;
    [SerializeField] private Button closeBtn;
    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private Slider masterVolSlider;
    FMOD.Studio.Bus masterBus;
    FMOD.Studio.EventInstance fmodEvent;
    [SerializeField] private GameObject warningPanel;

    [Header("Settings")]
    private bool samplePlaying = false;

    void Start()
    {
        playSampleBtn.interactable = false;
        globals = FindObjectOfType<Globals>();
        masterBus = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        if (!globals.hasHadWarning)
        {
            masterVolSlider.value = 0.5f;
            globals.masterVolume = masterVolSlider.value;
        }
        masterBus.setVolume(globals.masterVolume);
        fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/music");
        fmodEvent.setParameterByName("track", 3);
        closeBtn.interactable = false;
    }

    void Update()
    {
        if (FMODUnity.RuntimeManager.HasBankLoaded("Master"))
        {
            playSampleBtn.interactable = true;
        }else{
            playSampleBtn.interactable = false;
        }
    }

    public void PlaySampleBtn()
    {
        if (!samplePlaying)
        {
            samplePlaying = true;
            fmodEvent.start();
            playText.text = "STOP SAMPLE";
        }
        else if (samplePlaying)
        {
            samplePlaying = false;
            fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            playText.text = "PLAY SAMPLE";
        }
    }

    public void WarningSliderMove()
    {
        globals.masterVolume = masterVolSlider.value;
        masterBus.setVolume(globals.masterVolume);
        closeBtn.interactable = true;
    }

    public void CloseBtn()
    {
        globals.masterVolume = masterVolSlider.value;
        masterBus.setVolume(globals.masterVolume);
        fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        warningPanel.SetActive(false);
        PlayerPrefs.SetInt("hadAudioWarning", 1);
        PlayerPrefs.SetFloat("MasterVolume", globals.masterVolume);
    }
}
