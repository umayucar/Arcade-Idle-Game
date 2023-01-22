using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yacht : MonoBehaviour
{
    public GameObject PlayersYacht;
    public GameObject AreasYacht;
    public GameObject yachtQuitButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Yacht"))
        {
            PlayersYacht.SetActive(true);
            AreasYacht.SetActive(false);
            yachtQuitButton.SetActive(true);
        }
    }

    public void ExitYacth()
    {
        PlayersYacht.SetActive(false);
        AreasYacht.SetActive(true);
        this.transform.position = new Vector3(100, this.transform.position.y, -1);
        yachtQuitButton.SetActive(false);
    }


}
