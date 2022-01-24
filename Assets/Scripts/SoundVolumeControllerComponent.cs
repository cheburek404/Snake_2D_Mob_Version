using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundVolumeControllerComponent : MonoBehaviour {
    [SerializeField] private Text soundText;
    public AudioMixerGroup Mixer;

    public void LoadMenu() => SceneManager.LoadScene(0);

    void Start() {
        soundText.text = PlayerPrefs.GetString("soundMute");
    }

    public void OnClickBtn() {
        if (soundText.text == "ON") {
            Mixer.audioMixer.SetFloat("SoundVolume", -80);
            soundText.text = "OFF";
        } else {
            Mixer.audioMixer.SetFloat("SoundVolume", 0);
            soundText.text = "ON";
        }
        PlayerPrefs.SetString("soundMute", soundText.text);
    }
}
