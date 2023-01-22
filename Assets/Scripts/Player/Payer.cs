using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Stash))]

public class Payer : MonoBehaviour
{
    private Stash stash;
    private float nextTimeToPay = 0;
    private float Delay = 0.1f;
    private void Awake()
    {
        stash = GetComponent<Stash>();
        nextTimeToPay = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (stash.CollectedCount <= 0)
            return;


        if (other.CompareTag("Unlockable"))
        {
            nextTimeToPay = Time.time + Delay;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (stash.CollectedCount <= 0)
            return;


        if (other.CompareTag("Unlockable"))
        {
            if (Time.time < nextTimeToPay)
                return;

            nextTimeToPay = Time.time + Delay;

            if (other.TryGetComponent(out UnlockArea unlockable))
            {
                StartPayment(unlockable);
            }
        }
    }

    private void StartPayment(UnlockArea unlockable)
    {
        if (unlockable.unlockableData.RemainingPrice <= 0)
            return;

        var stashable = stash.RemoveStash();
        if (stashable == null)
            return;

        unlockable.Pay(stashable);
    }
}
