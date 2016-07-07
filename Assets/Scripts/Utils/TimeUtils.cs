﻿using System.Collections;
using UnityEngine;
using Utils;

public class TimeUtils : MonoBehaviour {

    public void FixedUpdateDelay(RetVoidTakeVoid cb) {
        StartCoroutine(DelayByFrameCoroutine(cb));
    }

	public void TimeDelay(float delay, RetVoidTakeVoid cb) {
        StartCoroutine(DelayCoroutine(delay, cb));
    }

    public void RepeatEvery(float period, RetBoolTakeVoid cb) {
        StartCoroutine(RepeatEveryCoroutine(period, cb));
    }

    private IEnumerator DelayCoroutine(float delay, RetVoidTakeVoid cb) {
        yield return new WaitForSeconds(delay);
        cb();
    }

    private IEnumerator RepeatEveryCoroutine(float period, RetBoolTakeVoid cb) {
        while (cb()) {
            yield return new WaitForSeconds(period);
        }
    }

    private IEnumerator DelayByFrameCoroutine(RetVoidTakeVoid cb) {
        yield return new WaitForFixedUpdate();
        cb();
    }

}