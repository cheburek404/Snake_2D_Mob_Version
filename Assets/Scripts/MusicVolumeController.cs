using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicVolumeController : MonoBehaviour {
    [SerializeField] private Text musText;
    public AudioMixerGroup Mixer;
    private float volume;

    public void Start(){
        SettingsVolumeLoad();
    }

    public void OnClickBtn() {
        if (musText.text == "ON") {
            Mixer.audioMixer.SetFloat("MusicVolume", -80);
            musText.text = "OFF";
        } else {
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
            musText.text = "ON";
        }
        PlayerPrefs.SetString("musMute", musText.text);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SettingsVolumeLoad() {
        musText.text = PlayerPrefs.GetString("musMute");
        if (PlayerPrefs.HasKey("MusicVolume")) {
            volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}
