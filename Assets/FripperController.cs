using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
	int fingerCount = 0;

	bool leftTouch = false;
	bool rightTouch = false;
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20f;
	//弾いた時の傾き
	private float flickAngle = -20f;

	// Use this for initialization
	void Start ()
	{
		//HinjiJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint> ();

		//フリッパーの傾きを設定
		SetAngle (this.defaultAngle);

	}

	// Update is called once per frame
	void Update ()
	{
		CheckTouch ();
		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
	}

	void CheckTouch ()
	{
		if (Input.touchCount > 0) {
			foreach (Touch t in Input.touches) {
				if (t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled) {
					//Debug.Log ("x=" + t.position.x + " y=" + t.position.y);
					if (t.position.x > Screen.width / 2) {
						rightTouch = true;
					}
					if (t.position.x < Screen.width / 2) {
						leftTouch = true;
					}
				} else {
					if (t.position.x > Screen.width / 2) {
						rightTouch = false;
					}
					if (t.position.x < Screen.width / 2) {
						leftTouch = false;
					}
				}
			}
		}	
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle)
	{
		//Vecotr3のように代入できない
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}