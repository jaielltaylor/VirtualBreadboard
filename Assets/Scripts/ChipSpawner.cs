using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipSpawner : MonoBehaviour
{
    public GameObject chip;

    public void SpawnChip()
    {
        if (this.name == "HexInverterSpawn")
        {
            Debug.Log("My name is..." + this.name);
            Instantiate(chip, new Vector3(0f, 7.5f, -139.87f), Quaternion.identity);
        }
        else if (this.name == "Quad2InputAndSpawn")
        {
            Debug.Log("My name is..." + this.name);
            Instantiate(chip, new Vector3(0f, 7.5f, -139.87f), Quaternion.identity);
        }
        else if (this.name == "Quad2InputNandSpawn")
        {
            Debug.Log("My name is..." + this.name);
            Instantiate(chip, new Vector3(0f, 7.5f, -139.87f), Quaternion.identity);
        }
        else if (this.name == "Quad2InputOrSpawn")
        {
            Debug.Log("My name is..." + this.name);
            Instantiate(chip, new Vector3(0f, 7.5f, -139.87f), Quaternion.identity);
        }
        else if (this.name == "Quad2InputNorSpawn")
        {
            Debug.Log("My name is..." + this.name);
            Instantiate(chip, new Vector3(0f, 7.5f, -139.87f), Quaternion.identity);
        }
        else if (this.name == "Quad2InputXorSpawn")
        {
            Debug.Log("My name is..." + this.name);
            Instantiate(chip, new Vector3(0f, 7.5f, -139.87f), Quaternion.identity);
        }
        else if (this.name == "Quad2InputXnorSpawn")
        {
            Debug.Log("My name is..." + this.name);
            Instantiate(chip, new Vector3(0f, 7.5f, -139.87f), Quaternion.identity);
        }
        else if (this.name == "Triple3InputNandSpawn")
        {
            Debug.Log("My name is..." + this.name);
            Instantiate(chip, new Vector3(0f, 7.5f, -139.87f), Quaternion.identity);
        }
        else if (this.name == "Triple3InputAndSpawn")
        {
            Debug.Log("My name is..." + this.name);
            Instantiate(chip, new Vector3(0f, 7.5f, -139.87f), Quaternion.identity);
        }
    }
}
