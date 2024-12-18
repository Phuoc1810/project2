using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class playermaneger : MonoBehaviour
{
    public static playermaneger _instance;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider mpSlider;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        setuphpmp();
       
    }
    public void setuphpmp()
    {
        hpSlider.maxValue = player._instance.GetComponent<playersat>().maxhp;
        mpSlider.maxValue = player._instance.GetComponent<playersat>().maxmp;
        updatehpmp();

    }
  
    public void updatehpmp()
    {
        hpSlider.value = player._instance.GetComponent<playersat>().currenthp;
        mpSlider.value = player._instance.GetComponent<playersat>().currentmp;
    }
}
