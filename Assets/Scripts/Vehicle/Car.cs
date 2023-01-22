using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject PlayersCar;
    public GameObject AreasCar;
    public GameObject carQuitButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            PlayersCar.SetActive(true);
            AreasCar.SetActive(false);
            carQuitButton.SetActive(true);

        }
    }

    public void CarQuit()
    {
        PlayersCar.SetActive(false);
        AreasCar.SetActive(true);
        this.transform.position = new Vector3(this.transform.position.x - 3, this.transform.position.y, this.transform.position.z);
        carQuitButton.SetActive(false);

    }
}
