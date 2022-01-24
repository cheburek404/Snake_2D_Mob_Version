using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeController : MonoBehaviour {
    [SerializeField] private Text soundText;
    private bool muted = false;
    private AudioSource audioSource;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("muted")) {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        } else { Load(); }

        UpdateBtn();
    }
    public void OnBtnPress() {
        if (muted == false) {
            muted = true;
            audioSource.Play();
        } else {
            muted = false;
            audioSource.Pause();
        }
        Save();
        UpdateBtn();
    }
    private void UpdateBtn() {
        if (muted == false)
            soundText.text = "ON";
        else
            soundText.text = "OFF";
    }
    private void Load() { muted = PlayerPrefs.GetInt("muted") == 1; }
    private void Save() { PlayerPrefs.SetInt("muted", muted ? 1 : 0); }
}
