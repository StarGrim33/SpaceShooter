using System.Collections;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    private float _delay;

    protected void Update()
    {
        StartCoroutine(Assail());
    }

    protected virtual void Shoot() { }

    protected virtual IEnumerator Assail()
    {
        var waitForSeconds = new WaitForSeconds(_delay);
        yield return waitForSeconds;
    }
}
