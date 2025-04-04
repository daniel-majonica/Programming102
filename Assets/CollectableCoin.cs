using UnityEngine;

public class CollectableCoin : CollectableItem
{
    private void Awake()
    {
        ScoreValue = 3;
        ItemName = "Coin";

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0.1f, 0));
    }
}
