using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance; //Singleton de chia chia khoa toan cuc

    public int[] keysPerLand = new int[4]; //So chia khoa ma nguoi choi thu thap trong moi vung dat

    private void Awake()
    {
        //Dam bao chi co 1 KeyManager
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   public void AddKey(int landIndex)
    {
        if(landIndex >= 0 && landIndex < keysPerLand.Length)
        {
            keysPerLand[landIndex]++; // tang so chia khoa cho vung dat chi dinh
        }
    }
    public bool HasAllKeys(int landIndex)
    {
        return keysPerLand[landIndex] >= 4; //Kiem tra du 4 chia khoa chua
    }
}
