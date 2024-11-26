using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance; //Singleton de chia chia khoa toan cuc

    public int totalKeys = 0; //tong so chia khoa thu thap
    public Text keysTexts; //hien thi so luong key cho tung vung dat

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
   public void AddKey()
    {
        totalKeys++;
        UpdateUI();
    }
    //cap nhat text UI hien thi so chia khoa
    public void UpdateUI()
    {
        if(keysTexts != null)
        {
            keysTexts.text = totalKeys.ToString();
        }
    }
    public bool HasAllKeys()
    {
        return totalKeys >= 4; //Kiem tra du 4 chia khoa chua
    }
    //gan text UI khi load lai scene chinh
    public void SetKeyTexts(Text newkeyTexts)
    {
        keysTexts = newkeyTexts;
        UpdateUI();
    }
}
