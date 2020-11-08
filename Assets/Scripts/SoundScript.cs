using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundScript : MonoBehaviour
{
    public class BGSoundScript : MonoBehaviour {

        // Use this for initialization
        void Start () {
		
        }

        //Play Global
        private static BGSoundScript instance = null;
        public static BGSoundScript Instance
        {
            get { return instance; }
        }

        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                instance = this;
            }

            DontDestroyOnLoad(this.gameObject);
            
            if ((SceneManager.GetActiveScene().buildIndex == 7))
            {
                Destroy(gameObject);
            }
        }
        //Play Gobal End

        // Update is called once per frame
        void Update () {
		
        }
    }

}
