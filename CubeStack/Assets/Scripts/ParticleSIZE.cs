using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSIZE : MonoBehaviour
{
    public float SloweIt;
    public float particleSize;
    void Start()
    {
        StartCoroutine(ScaleOverTime(1));
    }

    IEnumerator ScaleOverTime(float time)
    {
        Vector3 scaleNode = transform.localScale;
        Vector3 scaleTo = new Vector3(particleSize, particleSize, transform.localScale.z);
        float Timer = 0.0f;
        while (Timer <= time)
        {
            transform.localScale = Vector3.Lerp(scaleNode, scaleTo, Timer / time);
            Timer += Time.deltaTime*1/SloweIt;
            yield return null;
        }
        Destroy(gameObject);
    }
}
