using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {


    private float lotSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        //回転を開始する角度を設定
        this.transform.Rotate(0f,Random.Range(0,360),0f);
	}
	
	// Update is called once per frame
	void Update () {
        //回転
        this.transform.Rotate(0f,lotSpeed,0f);
	}
}
