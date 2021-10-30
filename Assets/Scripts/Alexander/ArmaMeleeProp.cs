using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaMeleeProp : MonoBehaviour
{
    void Update()
    {
        RotateItem();
    }
    void RotateItem()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<AtaqueMelee>().usos < 3)
        {
            other.GetComponent<AtaqueMelee>().usos = 3;
            Destroy(gameObject);
        }
    }
}
