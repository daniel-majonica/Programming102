using System;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public event Action <GameObject> OnTriggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterEvent?.Invoke(other.gameObject);
    }
}
