using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawaner : MonoBehaviour {
    [Header("遊戲物件")]
    public GameObject prefab;

    [Header("重力")]
    [Range(-1,1)]
    public float gravity;

    float lastSpawn;

    [Header("摩擦力")]
    [Range(0, 10)]
    public float prafabFriction;

    [Header("彈力")]
    [Range(0, 1)]
    public float prefabBounciness;

    [Header("多久產生一次(秒)")]
    [Range(0, 2)]
    public float timeInterval;

	// Use this for initialization
	void Start () {
        lastSpawn = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        instantiateGameObjects(prefab);
	}

    public void instantiateGameObjects(GameObject prefab)
    {
        Rigidbody2D prefabRigidbody2D = prefab.GetComponent<Rigidbody2D>();
        prefabRigidbody2D.gravityScale = gravity;
        prefabRigidbody2D.sharedMaterial.friction = prafabFriction;
        prefabRigidbody2D.sharedMaterial.bounciness = prefabBounciness;

        if(Time.time-lastSpawn>=timeInterval)
        {
            Instantiate(prefab, transform.position, prefab.transform.rotation);
            lastSpawn = Time.time;
        }
    }
}
