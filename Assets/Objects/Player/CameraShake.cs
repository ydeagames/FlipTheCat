using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(DoShake(duration, magnitude));
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var t = elapsed / duration;
            var q = Mathf.Sin(t * Mathf.PI);
            var x = pos.x + Random.Range(-1f, 1f) * magnitude * q;
            var y = pos.y + Random.Range(-1f, 1f) * magnitude * q;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = pos;
    }
}