using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    const string _SaveKey = "UserData";
    public User user;

    // Use this for initialization
    void Start()
    {
        string json = PlayerPrefs.GetString(_SaveKey);
        user = JsonUtility.FromJson<User>(json);
        if (user == null)
            user = new User();
        
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            
            LevelUp();

        }
	}
    void LevelUp(){
        
        Save();
    }

    void Save(){
        string json = JsonUtility.ToJson(user);
        PlayerPrefs.SetString(_SaveKey, json);
    }
}
