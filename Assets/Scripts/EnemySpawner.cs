using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]public float maxTime = 0;
    
    private float _timer = 0;
    public GameObject Enemy;
    [SerializeField] public float Wait = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject newEnemy = Instantiate(Enemy);
        newEnemy.transform.position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > maxTime )
        {
            GameObject newEnemy = Instantiate(Enemy);
            newEnemy.transform.position = transform.position ;
            
            Destroy(newEnemy,15);
            _timer = 0;

        }

        _timer += Time.deltaTime;
    }

    
}
