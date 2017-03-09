using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFadeInFadeOut : MonoBehaviour {

    // Lets an object fade in out

    public float fadeSpeed = 1.0f;
    public float maxAlpha = 0.2f;

    private MeshRenderer meshRenderer;
    private Color maxAlphaColor;
    private Color minAlphaColor;

	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        maxAlphaColor = meshRenderer.material.color;
        minAlphaColor = maxAlphaColor;
        minAlphaColor.a = maxAlpha;
	}
	
	void Update () {
        meshRenderer.material.color = Color.Lerp(minAlphaColor, maxAlphaColor, Mathf.PingPong(Time.time * fadeSpeed, 1));
    }
}
