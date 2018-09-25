using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour {

    [Header("水平方向")]
    public float MoveX;

    [Header("水平方向")]
    public float MoveY;

    [Header("推力")]
    public float push;

    Rigidbody2D rb2D; //剛體

    /*[Header("分數文字UI")]
    public Text countText;

    [Header("過關文字UI")]
    public Text winText;

    int score;//分數
    */
    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        //rb2D = 取得組件<剛體2D> ();
        //countText.text = "當前分數:0分";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveX = Input.GetAxis("Horizontal");
        //水平移動 = 輸入.取得軸向("水平");
        MoveY = Input.GetAxis("Vertical");
        //垂直移動 = 輸入.取得軸向("垂直");
        Vector2 movement = new Vector2(MoveX, MoveY);
        //2維向量 移動方向 = 新的2維向量(水平移動,垂直移動);
        rb2D.AddForce(push * movement);
        //剛體的施加力量(推力*移動方向);
	}
    void OnTriggerEnter2D(Collider2D other)//當該物件(UFO)經過其他圓形碰撞器時
    {
        Debug.Log(name + "觸發了" + other.name);
        if (other.CompareTag("PickUp"))//當被碰撞體的標籤屬於PickUp
        {
            //score++;
           // setScoreText();
            other.gameObject.SetActive(false);
            //被碰撞體的遊戲物件.屬性顯示設定=false
        }
    }

    /*void setScoreText()
    {
        countText.text = "當前分數:" + score.ToString()+"分";

        if(score>=12)
        {
            winText.gameObject.SetActive(true);
        }
    }*/
}
