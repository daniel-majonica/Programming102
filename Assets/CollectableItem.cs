using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public string ItemName = "undefined";

    private void OnTriggerEnter(Collider other)
    {
        Inventory playerInv = other.GetComponent<Inventory>();
        if (playerInv != null)
        {
            playerInv.AddItem(this);
            Destroy(gameObject);
        }
    }
}
