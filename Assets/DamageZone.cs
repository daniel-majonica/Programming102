using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public float Damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        FirstPersonMovement player = other.GetComponent<FirstPersonMovement>();
        if(player != null)
        {
            player.TakeDamage(Damage);
        }
    }
}
