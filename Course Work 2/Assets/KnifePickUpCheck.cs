using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickUpCheck : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private GameState gs;

    private void Start()
    {
        gs = GameState.Instance;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gs.give_Cigaret_To_Cook == false)
            {
                SceneLoader sl = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
                gs.caughtWithKnife = true;
                sl.LoadNignt();
            }
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
