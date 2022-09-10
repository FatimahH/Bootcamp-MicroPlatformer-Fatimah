using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float thrust = 1.0f;
    [SerializeField] private GameObject myParticles;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(thrust, 0, 0), ForceMode.Impulse);

        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(5f);

        Instantiate(myParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
