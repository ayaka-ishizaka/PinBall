using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePoeZ = -6.5f;

	//初期化
	private int point = 0;

	//ゲームオーバーを表示するテキスト
	private GameObject gameoverText;

	//ポイントを表示するテキスト
	private GameObject pointText;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//シーン中のPointTextオブジェクトを取得
		this.pointText = GameObject.Find("PointText");
	}

	//衝突した時に得点を加算
	void OnCollisionEnter (Collision collision) {

		//ターゲットの種類を判別
		string yourTag = collision.gameObject.tag;

		//得点を加算
		this.point += point;

		//ターゲットの種類によって取得できる得点を変更
		if (yourTag == "SmallStarTag") {
			point += 10;
		} else if (yourTag == "LargeStarTag") {
			point += 20;
		} else if (yourTag == "SmallCloudTag") {
			point += 30;
		} else if (yourTag == "LargeCloudTag") {
			point += 40;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePoeZ) {
			//GameOverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}

		//PointTextに得点を表示
		this.pointText.GetComponent<Text> ().text = "得点:" + point;
	}
}
