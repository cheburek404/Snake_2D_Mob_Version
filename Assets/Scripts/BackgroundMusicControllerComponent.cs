using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicControllerComponent : MonoBehaviour {
    /*[Header("Tags")]
    [SerializeField] private string createdTag;

    private void Awake() {
        GameObject obj = GameObject.FindWithTag(this.createdTag);
        if (obj != null) {
            Destroy(this.gameObject);
        } else {
            this.gameObject.tag = this.createdTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }*/
    private static BackgroundMusicControllerComponent bm;

    private void Awake() {
        if (bm == null) {
            bm = this;
            DontDestroyOnLoad(bm);
        } else {
            Destroy(gameObject);
        }
    }
}
