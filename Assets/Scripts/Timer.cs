using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class Timer:MonoBehaviour
{
    [SerializeField] Image forceBarImage;
    public float holdTime { get; private set; }

    public  void StartTimer()
    {
        ResetForceBar();
        StartCoroutine("TimeCounter");
    }
    public  void StopTimer()
    {
        ResetForceBar();
        StopCoroutine("TimeCounter");
    }
    public void ResetTimer()
    {
        holdTime = 0f;
    }
    IEnumerator TimeCounter()
    {
        for (holdTime = 0f; holdTime <= 0.25f; holdTime += Time.deltaTime)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            forceBarImage.fillAmount = holdTime * 4;
        }
    }
    void ResetForceBar()
    {
        forceBarImage.fillAmount = 0f;
    }
}
