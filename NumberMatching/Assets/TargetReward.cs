﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReward : MonoBehaviour
{
    [SerializeField] GameObject switchButton = default;
    [SerializeField] GameObject coinGRP = default;
    public float scaleDuration = 0.5f;
    public float holdDuration = 0.5f;
    public float moveDuration = 0.5f;
    public AnimationCurve ease;

    private Vector3 startingPos;
    private Vector3 startingScale;

    private SwitchButton switchButtonScript;

    private void Awake() {
        switchButtonScript = switchButton.GetComponent<SwitchButton>();
    }

    private void Start() {
        startingPos = coinGRP.transform.position;
        startingScale = coinGRP.transform.localScale;
    }

    public void TargetHitRevealAnimation() {
        coinGRP.SetActive(true);
        ScaleUpCoin();
        StartCoroutine(MoveCoin());
        StartCoroutine(MoveOverTime());
    }

    private void ScaleUpCoin() {
        Hashtable hash = new Hashtable();
        hash.Add("scale", new Vector3(1f, 1f, 0f));
        hash.Add("time", scaleDuration);
        iTween.ScaleTo(coinGRP, hash);
    }

    IEnumerator MoveCoin() {
        yield return new WaitForSeconds(0f);
        Vector3 pos = coinGRP.transform.position;
        Hashtable hash = new Hashtable();
        hash.Add("position", new Vector3(pos.x, pos.y + 55f, pos.z));
        hash.Add("time", holdDuration + scaleDuration);
        iTween.MoveTo(coinGRP, hash);
    }

    IEnumerator MoveOverTime() {
        yield return new WaitForSeconds(scaleDuration);
        yield return new WaitForSeconds(holdDuration);


        Vector3 oldPos = coinGRP.transform.position;
        Vector3 newPos = switchButton.transform.position;


        for (float t = 0; t < moveDuration; t += Time.deltaTime) {
            coinGRP.transform.position = Vector3.Lerp(oldPos, newPos, ease.Evaluate(t / moveDuration));
            yield return null;
        }

        coinGRP.transform.position = newPos;
        coinGRP.SetActive(false);
        coinGRP.transform.position = startingPos;
        coinGRP.transform.localScale = startingScale;
        AddSwitches();
    }

    private void AddSwitches() {
        switchButtonScript.AddSwitches(5);
        SoundManager.SM.PlayOneShotSound("yahoo");
    }

}
