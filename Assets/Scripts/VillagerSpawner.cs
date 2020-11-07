using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour
{
    private float _timer = 0;
    public GameObject character;
    [SerializeField]public float maxTime = 0;
    void Start()
    {
        GameObject newCharacter = Instantiate(character);
        newCharacter.transform.position = transform.position;
    }
    
    void Update()
    {
        if (_timer > maxTime)
        {
            GameObject newCharacter = Instantiate(character);
            newCharacter.transform.position = transform.position;
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
}
