using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleports : MonoBehaviour {

    [SerializeField] GameObject background;


    public float minTime = 2f;
    public float maxTime = 5f;

    private float offset;
    private float x, y;
    private float maxX, maxY;

    // Use this for initialization
    void Start () {
        SpriteRenderer backgroundSprite = background.GetComponent<SpriteRenderer>();
        BoxCollider2D backgroundCollider = background.GetComponent<BoxCollider2D>();
        CircleCollider2D spawnCollider = GetComponent<CircleCollider2D>();
        offset = Mathf.Min(backgroundCollider.size.x, backgroundCollider.size.y) + spawnCollider.radius;

        maxX = backgroundSprite.sprite.bounds.size.x / 2 - offset;
        maxY = backgroundSprite.sprite.bounds.size.y / 2 - offset;
        Debug.Log(maxX);

        StartCoroutine(Teleport());
    }
	
	// Update is called once per frame
	void Update () {
        
	}

   IEnumerator Teleport() {
        float seconds;
        while (true) {
            seconds = Random.Range(minTime, maxTime);
            x = Random.Range(-maxX, maxX);
            y = Random.Range(-maxY, maxY);
            transform.position = new Vector3(x, y, 0);
            transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
            yield return new WaitForSeconds(0.2f);
            transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
            yield return new WaitForSeconds(seconds);
        }

    }


}
