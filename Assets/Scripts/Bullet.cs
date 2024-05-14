using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float time = 3f;

    private void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
