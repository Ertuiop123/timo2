using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashExplosion : MonoBehaviour
{
    public float explosionTime = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitThenDie());

        IEnumerator WaitThenDie()
        {
            yield return new WaitForSeconds(explosionTime);
            Destroy(gameObject);
        }
    }

}
