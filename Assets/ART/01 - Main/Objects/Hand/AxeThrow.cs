using UnityEngine;
using System.Collections;  // IEnumerator için gerekli olan using directive

public class AxeThrow : MonoBehaviour
{
    public GameObject axe;
    public Transform hand;

    public float throwSpeed = 10f;
    public float destroyDelay = 5f;
    public float rotateSpeed = 100f;

    private Rigidbody axeRb;
    private bool hasThrown = false;

    void Start()
    {
        axeRb = axe.GetComponent<Rigidbody>();
    }

    // Animasyon event'i tarafından çağrılacak metod
    public void ThrowAxeStart()
    {
        if (!hasThrown)
        {
            hasThrown = true;
            axe.transform.parent = null;
            axeRb.isKinematic = false;
            axeRb.velocity = hand.forward * throwSpeed;

            // Döndürme işlemini başlat
            StartCoroutine(RotateAxe());

            Destroy(axe, destroyDelay);
        }
    }

    IEnumerator RotateAxe()
    {
        while (true)
        {
            axe.transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
