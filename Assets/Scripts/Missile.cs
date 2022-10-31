using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 30.0f;
    public int damage = 10;
    void Start()
    {
        StartCoroutine("deathTimer");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator deathTimer() 
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
