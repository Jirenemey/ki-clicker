using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    public static GameLogic instance;
    public Text kiText;
    public Text kiText2;
    public Text kps;
    public Text upgradeClickText;
    public Text saibamenText;
    public Text humanText;
    public Text lowClassSaiyanText;
    public GameObject upgradeScreen;
    public float ki = 0.0f;
    public float TotalKi = 0.0f;
    public float energy = 100.0f;
    private float converter;
    private float multiplier = 1.0f;
    private int dragonBalls = 0;
    private float form = 1.0f;
    private float click = 1.0f;
    private int upgradeClick = 1;
    private int clicksPurchased = 0;
    private float upgradeClickPrice = 20.0f;
    private float clickUpgrade = 1.0f;
    private int saibamen = 15;
    private int saibamenPurchased = 0;
    private float saibamenPrice = 200.0f;
    private float saibamenUpgrade = 1.0f;
    private int human = 120;
    private int humanPurchased = 0;
    private float humanPrice = 2500.0f;
    private float humanUpgrade = 1.0f;
    private int lowClassSaiyan = 2000;
    private int lowClassSaiyanPurchased = 0;
    private float lowClassSaiyanPrice = 40000.0f;
    private float lowClassSaiyanUpgrade = 1.0f;
    private float timer = 0.0f;
    public float waitTime = 0.1f;
    

 
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        lowClassSaiyan = 2000;
        timer += Time.deltaTime;

        if(timer > waitTime){

            ki += (Items()/10) * multiplier * form;

            timer -= waitTime;
        }

        Debug.Log(ki);
        Debug.Log(saibamenPrice);

        DisplayUpradeClickCost();
        DisplayUpgradeSaibamenCost();
        DisplayUpgradeHumanCost();
        DisplayUpgradeLowClassSaiyanCost();
        DisplayKi();
        KiPerSecond();
        SaveGame();
    }

    public void ChargeKi(){
        ki += click * multiplier * form * clickUpgrade;
    }

    public float Items(){
        TotalKi = 0.0f;
        TotalKi += saibamen * saibamenPurchased * saibamenUpgrade;
        TotalKi += human * humanPurchased * humanUpgrade;
        TotalKi += lowClassSaiyan * lowClassSaiyanPurchased * lowClassSaiyanUpgrade;
        return TotalKi;
    }

    public void UpgradeClick(){
        if(ki > upgradeClickPrice){
            ki -= upgradeClickPrice;
            click += upgradeClick;
            clicksPurchased++;
            upgradeClickPrice = (upgradeClickPrice) * Mathf.Pow(1.15f, click);
        } else{
            Debug.Log("Insufficient Ki!");
        }
        if(clicksPurchased % 25 == 0){
            clickUpgrade += 0.25f;
        }
    }

    public void PurchaseSaibamen(){
        if(ki > saibamenPrice){
            ki -= saibamenPrice;
            saibamenPurchased++;
            saibamenPrice = (saibamenPrice) * Mathf.Pow(1.15f, saibamenPurchased);
        } else{
            Debug.Log("Insufficient Ki!");
        }
        if(saibamenPurchased % 25 == 0){
            saibamenUpgrade += 0.25f;
        }
    }

    public void PurchaseHuman(){
        if(ki > humanPrice){
            ki -= humanPrice;
            humanPurchased++;
            humanPrice = (humanPrice) * Mathf.Pow(1.15f, humanPurchased);
        } else{
            Debug.Log("Insufficient Ki!");
        }
        if(humanPurchased % 25 == 0){
            humanUpgrade += 0.25f;
        }
    }

    public void PurchaseLowClassSaiyan(){
        if(ki > lowClassSaiyanPrice){
            ki -= lowClassSaiyanPrice;
            lowClassSaiyanPurchased++;
            lowClassSaiyanPrice = (lowClassSaiyanPrice) * Mathf.Pow(1.15f, lowClassSaiyanPurchased);
        } else{
            Debug.Log("Insufficient Ki!");
        }
        if(lowClassSaiyanPurchased % 25 == 0){
            lowClassSaiyanUpgrade += 0.25f;
        }
    }

    public void DisplayKi(){
        if(ki < 1000){
            kiText.text = ki.ToString("F0") + " KI";
        } else if(ki < 1000000){
            converter = ki/1000f;
            kiText.text = converter.ToString("F2") + "K KI";
        } else if(ki < 1000000000){
            converter = ki/1000000f;
            kiText.text = converter.ToString("F2") + "M KI";
        } else if(ki < 1000000000000){
            converter = ki/1000000000f;
            kiText.text = converter.ToString("F2") + "B KI";
        } else if(ki < 1000000000000000){
            converter = ki/1000000000000f;
            kiText.text = converter.ToString("F2") + "T KI";
        }

        if(ki < 1000){
            kiText2.text = ki.ToString("F0") + " KI";
        } else if(ki < 1000000){
            converter = ki/1000f;
            kiText2.text = converter.ToString("F2") + "K KI";
        } else if(ki < 1000000000){
            converter = ki/1000000f;
            kiText2.text = converter.ToString("F2") + "M KI";
        } else if(ki < 1000000000000){
            converter = ki/1000000000f;
            kiText2.text = converter.ToString("F2") + "B KI";
        } else if(ki < 1000000000000000){
            converter = ki/1000000000000f;
            kiText2.text = converter.ToString("F2") + "T KI";
        }
    }

    public void KiPerSecond(){
        kps.text = Items().ToString("F0");
    }

    public void DisplayUpradeClickCost(){
        upgradeClickText.text = clicksPurchased.ToString() + " Upgrade Click: " + upgradeClickPrice.ToString("F0");
    }

    public void DisplayUpgradeSaibamenCost(){
        saibamenText.text = saibamenPurchased.ToString() + " Saibamen: " + saibamenPrice.ToString("F0");
    }

    public void DisplayUpgradeHumanCost(){
        humanText.text = humanPurchased.ToString() + " Human: " + humanPrice.ToString("F0"); 
    }

    public void DisplayUpgradeLowClassSaiyanCost(){
        lowClassSaiyanText.text = lowClassSaiyanPurchased.ToString() + " Low Class Saiyan: " + lowClassSaiyanPrice.ToString("F0");
    }

    public void DisplayUpgrades(){
        upgradeScreen.SetActive(true);
    }

    public void CloseUpgrades(){
        upgradeScreen.SetActive(false);
    }

    void SaveGame(){
        PlayerPrefs.SetFloat("Ki", ki);
        PlayerPrefs.SetFloat("Energy", energy);
        PlayerPrefs.SetFloat("Multiplier", multiplier);
        PlayerPrefs.SetInt("Dragon Balls", dragonBalls);
        PlayerPrefs.SetInt("Clicks purchased", clicksPurchased);
        PlayerPrefs.SetFloat("Clicks", click);
        PlayerPrefs.SetFloat("Upgrade Click Price", upgradeClickPrice);
        PlayerPrefs.SetFloat("Click Uprade", clickUpgrade);
        PlayerPrefs.SetInt("Saibamen", saibamen);
        PlayerPrefs.SetFloat("Saibamen Price", saibamenPrice);
        PlayerPrefs.SetInt("Saibamen purchased", saibamenPurchased);
        PlayerPrefs.SetFloat("Saibamen Upgrade", saibamenUpgrade);
        PlayerPrefs.SetInt("Human", human);
        PlayerPrefs.SetFloat("Human Price", humanPrice);
        PlayerPrefs.SetInt("Human purchased", humanPurchased);
        PlayerPrefs.SetFloat("Human Upgrade", humanUpgrade);
        PlayerPrefs.SetInt("Low Class Saiyan", lowClassSaiyan);
        PlayerPrefs.SetFloat("Low Class Saiyan Price", lowClassSaiyanPrice);
        PlayerPrefs.SetInt("Low Class Saiyan purchased", lowClassSaiyanPurchased);
        PlayerPrefs.SetFloat("Low Class Saiyan Upgrade", lowClassSaiyanUpgrade);
        Debug.Log("Data saved.");
    }

    void LoadGame(){
        if (PlayerPrefs.HasKey("Ki")){
            ki = PlayerPrefs.GetFloat("Ki");
            energy = PlayerPrefs.GetFloat("Energy");
            multiplier = PlayerPrefs.GetFloat("Multiplier");
            dragonBalls = PlayerPrefs.GetInt("Dragon Balls");
            clicksPurchased = PlayerPrefs.GetInt("Clicks purchased");
            click = PlayerPrefs.GetFloat("Clicks");
            upgradeClickPrice = PlayerPrefs.GetFloat("Upgrade Click Price");
            clickUpgrade = PlayerPrefs.GetFloat("Click Upgrade");
            saibamen = PlayerPrefs.GetInt("Saibamen");
            saibamenPrice = PlayerPrefs.GetFloat("Saibamen Price");
            saibamenPurchased = PlayerPrefs.GetInt("Saibamen purchased");
            saibamenUpgrade = PlayerPrefs.GetFloat("Saibamen Upgrade");
            human = PlayerPrefs.GetInt("Human");
            humanPrice = PlayerPrefs.GetFloat("Human Price");
            humanPurchased = PlayerPrefs.GetInt("Human purchased");
            humanUpgrade = PlayerPrefs.GetFloat("Human Upgrade");
            lowClassSaiyan = PlayerPrefs.GetInt("Low Class Saiyan");
            lowClassSaiyanPrice = PlayerPrefs.GetFloat("Low Class Saiyan Price");
            lowClassSaiyanPurchased = PlayerPrefs.GetInt("Low Class Saiyan purchased");
            lowClassSaiyanUpgrade = PlayerPrefs.GetFloat("Low Class Saiyan Upgrade");
        }
        else{
            Debug.Log("No save data.");
        }
    }


}
