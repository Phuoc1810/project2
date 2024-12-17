using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance; //Singleton de chia chia khoa toan cuc

    public int totalKeys = 0; //tong so chia khoa thu thap
    public Text keysTexts; //hien thi so luong key cho tung vung dat
    public GameObject boss_UI; //tham chieu den notification boss

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

    //hien thi UI thong bao boss
    void Start()
    {
        boss_UI.SetActive(false);
        if(totalKeys == 4)
        {
            StartCoroutine(HideBossNotification());
        }
    }
    //khoi tao lai key
    public void ResetKey()
    {
        totalKeys = 0;
        UpdateUI();
    }
    public bool HasAllKeys()
    {
        return totalKeys >= 4; //Kiem tra du 4 chia khoa chua
    }

    private IEnumerator HideBossNotification()
    {
        yield return new WaitForSeconds(1.5f);
        if (boss_UI != null)
        {
            boss_UI.SetActive(true);
        }

        yield return new WaitForSeconds(2.5f);
        boss_UI.SetActive(false);
    }
    //gan text UI khi load lai scene chinh
    public void SetKeyTexts(Text newkeyTexts)
    {
        keysTexts = newkeyTexts;
        UpdateUI();
    }
}
