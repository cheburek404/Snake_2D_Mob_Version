using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{
    [HideInInspector]
    public Vector2 _direction = Vector2.right;
    public UIButton rightButton;
    public UIButton leftButton;
    public UIButton upButton;
    public UIButton downButton;

    private List<Transform> _segments;
    public Transform segmentPrefab;

    private void Start() {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    private void Update() {
        if (this._direction.x != 0.0f){
            if (Input.GetKeyDown(KeyCode.UpArrow) || upButton.isDown){
                _direction = Vector2.up;
            }else if (Input.GetKeyDown(KeyCode.DownArrow) || downButton.isDown){
                _direction = Vector2.down;
            }
        }else if (this._direction.y != 0.0f){
            if (Input.GetKeyDown(KeyCode.LeftArrow) || leftButton.isDown){
                _direction = Vector2.left;
            }else if (Input.GetKeyDown(KeyCode.RightArrow) || rightButton.isDown){
                _direction = Vector2.right;
            }
        }
    }

    private void FixedUpdate(){
        for (int i = _segments.Count - 1; i > 0; i--){
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + this._direction.x,
            Mathf.Round(this.transform.position.y) + this._direction.y);
    }

    public void Grow(){
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Food") {
            Grow();
        } else if (col.tag == "Border" || col.tag == "Tail") {
            Handheld.Vibrate();
            SceneManager.LoadScene(2);
        }
    }
}
