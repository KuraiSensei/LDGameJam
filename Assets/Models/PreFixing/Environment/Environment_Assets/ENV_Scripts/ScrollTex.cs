using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTex : MonoBehaviour {

	public float scrollY = 0.5f;
	public float scrollX = 0.5f;
	
    void Update(){
        	float OffsetY = Time.time * scrollY;
	float OffsetX = Time.time * scrollX;
	GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (OffsetX, OffsetY);
    }
}
