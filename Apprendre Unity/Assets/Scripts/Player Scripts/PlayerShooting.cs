using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject shootObject;
    public Transform shootPoint;
    public float shootRate;
    bool shoot;
    float nextShotDelay = -1;

    private void Update() {
        GetInputs();
        Shoot();
    }

    private void Shoot() {
        if (nextShotDelay > 0) {
            nextShotDelay -= Time.deltaTime;
            return;
        }
        else if (shoot) {
            Instantiate(shootObject, shootPoint.position, Quaternion.identity);
            nextShotDelay = shootRate;
            shoot = false;
        }
    }

    private void GetInputs() {
        shoot = Input.GetButton("Fire");
    }
}
