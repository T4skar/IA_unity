using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    float speed;
    bool turning = false;

    void Start() {

        speed = Random.Range(FlockManager.flockManeger.minSpeed, FlockManager.flockManeger.maxSpeed);
    }


    void Update() {

        Bounds _bounds = new Bounds(FlockManager.flockManeger.transform.position, FlockManager.flockManeger.flyLimits * 2.0f);

        if (!_bounds.Contains(transform.position)) {

            turning = true;
        } else {

            turning = false;
        }

        if (turning) {

            Vector3 direction = FlockManager.flockManeger.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                FlockManager.flockManeger.rotationSpeed * Time.deltaTime);
        } else {


            if (Random.Range(0, 100) < 10) {

                speed = Random.Range(FlockManager.flockManeger.minSpeed, FlockManager.flockManeger.maxSpeed);
            }


            if (Random.Range(0, 100) < 10) {
                ApplyRules();
            }
        }

        this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }

    private void ApplyRules() {

        GameObject[] GO;
        GO = FlockManager.flockManeger.allBee;

        Vector3 vCentre = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;

        float goSpeed = 0.01f;
        float mDistance;
        int groupSize = 0;

        foreach (GameObject go in GO) {

            if (go != this.gameObject) {

                mDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if (mDistance <= FlockManager.flockManeger.neighbourDistance) {

                    vCentre += go.transform.position;
                    groupSize++;

                    if (mDistance < 1.0f) {

                        vAvoid = vAvoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    goSpeed = goSpeed + anotherFlock.speed;
                }
            }
        }

        if (groupSize > 0) {

            vCentre = vCentre / groupSize + (FlockManager.flockManeger.goalPos - this.transform.position);
            speed = goSpeed / groupSize;

            if (speed > FlockManager.flockManeger.maxSpeed) {

                speed = FlockManager.flockManeger.maxSpeed;
            }

            Vector3 direction = (vCentre + vAvoid) - transform.position;
            if (direction != Vector3.zero) {

                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(direction),
                    FlockManager.flockManeger.rotationSpeed * Time.deltaTime);
            }
        }
    }
}