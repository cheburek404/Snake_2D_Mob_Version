using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour {

    private const int countdownTime = 3;
    public Text countdownText;
    public GameObject pause;

    public void ResumeGame() {
        Time.timeScale = 0f;
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart() {
        int temp = countdownTime;
        countdownText.gameObject.SetActive(true);
        pause.SetActive(false);
        while (temp > 0) {
            countdownText.text = temp.ToString();
            yield return new WaitForSecondsRealtime(1f);
            temp--;
        }
        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);
        countdownText.gameObject.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1f;
    }
}
