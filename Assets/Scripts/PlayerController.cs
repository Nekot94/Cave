using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour {
    public float speed = 1.0f;
    public Text countText;
    public Text winText;
    public int winCount = 10;


    private Rigidbody2D rb2d;
    private int count;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        countText.text = "Очки: " + count.ToString() + "/" + winCount.ToString();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal,moveVertical);
        rb2d.AddForce(movement * speed);
        

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            collision.gameObject.SetActive(false);
            count += 1;
            countText.text = "Очки: " + count.ToString() + "/" + winCount.ToString();
        }
        if (count >= winCount) {
            winText.text = "Ты победил";
            StartCoroutine(NextScene(3f));
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Enemy")) {
            winText.text = "Ты проиграл";
            winText.color = Color.red;
            StartCoroutine(Restart(3f));
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    IEnumerator NextScene(float time) {
        yield return new WaitForSeconds(time);
        string sceneName = SceneManager.GetActiveScene().name;
        string nextSceneName = "Scene" + ((int)(sceneName[sceneName.Length - 1] - '0') + 1).ToString();
        SceneManager.LoadScene(nextSceneName);
    }


    IEnumerator Restart(float time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
