using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    private GameObject slicedBanana;

    public void CreateSlicedGameObject()
    {
        GameObject inst =
            Instantiate(slicedBanana, transform.position, transform.rotation);

        GameManager.Instance.AddScore(2);

        Rigidbody[] rbSlices =
            inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (var slices in rbSlices)
        {
            slices.transform.rotation = Random.rotation;
            slices
                .AddExplosionForce(Random.Range(500, 1000),
                transform.position,
                5f);
        }

        GameManager.Instance.PlayeSliceSound();

        Destroy(inst, 5f);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Blade myBlade = other.GetComponent<Blade>();

        if (!myBlade)
        {
            return;
        }
        CreateSlicedGameObject();
    }
}
