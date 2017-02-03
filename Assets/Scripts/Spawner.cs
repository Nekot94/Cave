using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject spawnObject;
    [SerializeField] private GameObject background;


    public int count;

    private float offset;
    private float x, y;
    private float maxX, maxY;

	// Use this for initialization
	void Start () {
        SpriteRenderer backgroundSprite = background.GetComponent<SpriteRenderer>();
        BoxCollider2D backgroundCollider = background.GetComponent<BoxCollider2D>();
        CircleCollider2D spawnCollider = spawnObject.GetComponent<CircleCollider2D>();
        offset = Mathf.Min(backgroundCollider.size.x, backgroundCollider.size.y) + spawnCollider.radius;
        Debug.Log(offset);

        Debug.Log(backgroundSprite.sprite.bounds.size.x / 2 - offset);

        maxX = backgroundSprite.sprite.bounds.size.x / 2 - offset;
        maxY = backgroundSprite.sprite.bounds.size.y / 2 - offset;

        Spawn(count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn(int count) {
        for (int i = 0; i < count; i++) {
            x = Random.Range(-maxX, maxX);
            y = Random.Range(-maxY, maxY);
            Instantiate(spawnObject, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
