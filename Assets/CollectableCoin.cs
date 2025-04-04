using UnityEngine;

public class CollectableCoin : CollectableItem
{
    private void Awake()
    {
        ItemName = "Coin";
    }

    private void OnTriggerEnter(Collider other)
    {
        Inventory playerInv = other.GetComponent<Inventory>();
        if (playerInv != null)
        {
            playerInv.AddItem(this);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0.1f, 0));
    }
}
