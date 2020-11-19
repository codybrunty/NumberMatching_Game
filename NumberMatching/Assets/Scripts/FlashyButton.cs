﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashyButton : MonoBehaviour{

    [SerializeField] ParticleSystem effect = default;
    [SerializeField] AnimationCurve ease = default;
    int counter = 0;


    private void OnEnable() {
        StartCoroutine(AlphaTweenSprite());
        PunchButton();
    }

    IEnumerator AlphaTweenSprite() {

        float alphaTarget = 0.5f;
        float fillDuration = 0.5f;
        Color spriteColor = gameObject.GetComponent<SpriteRenderer>().color;

        for (float t = 0f; t < fillDuration; t += Time.deltaTime) {
            float normalizedTime = t / fillDuration;
            float alpha = Mathf.Lerp(0, alphaTarget, ease.Evaluate(normalizedTime));
            gameObject.GetComponent<SpriteRenderer>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b,alpha);
            yield return null;
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alphaTarget);
    }

    private void PunchButton() {
        Hashtable hash = new Hashtable();
        hash.Add("scale", new Vector3(1f, 1f, 1f));
        hash.Add("looptype", "pingPong ");
        hash.Add("easetyp", "easeOutQuad");
        hash.Add("oncomplete", "PlayEffect");
        hash.Add("time", .5f);
        iTween.ScaleTo(gameObject, hash);
    }

    private void PlayEffect() {
        counter++;
        if (counter % 2 == 0) {
            effect.Play();
        }
    }

}