using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    public static GameLogic instance;
    private string convertedText;
    private Text kiText;
    public Text kiText2;
    public Text kps;
    public Text stats;
    public Text zenkaiText;
    public Text moneyText;
    public Text upgradeClickText;
    public Text saibamenText;
    public Text humanText;
    public Text lowClassSaiyanText;
    public Text namekianText;
    public Text androidText;
    public Text majinText;
    private double ki = 1000000000.0;
    private double TotalKi = 0.0;
    private double converter;
    private double multiplier = 1000000000000000.0;
    private int dragonBalls = 0;
    private int zenkai = 0;
    private double zenkaiPrice = 100000000;
    private double form = 1.0;
    private double money = 10000000000000000000000000.0;
    private double click = 1.0;
    private double kiUpgrade = 1.0;
    private int clicksPurchased = 0;
    private double upgradeClickPrice = 20.0;
    private double upgradeClickOriginalPrice = 20.0;
    private double clickUpgrade = 1.0;
    private int saibamen = 150000000;
    private int saibamenPurchased = 0;
    private double saibamenPrice = 200.0;
    private double saibamenOriginalPrice = 200.0;
    private double saibamenKPS;
    private int human = 120;
    private int humanPurchased = 0;
    private double humanPrice = 2500.0;
    private double humanOriginalPrice = 2500.0;
    private double humanKPS;
    private int lowClassSaiyan = 2000;
    private int lowClassSaiyanPurchased = 0;
    private double lowClassSaiyanPrice = 40000.0;
    private double lowClassSaiyanOriginalPrice = 40000.0;
    private double lowClassSaiyanKPS;
    private int namekian = 32000;
    private int namekianPurchased = 0;
    private double namekianPrice = 500000.0;
    private double namekianOriginalPrice = 500000.0;
    private double namekianKPS;
    private int android = 400000;
    private int androidPurchased = 0;
    private double androidPrice = 8000000.0;
    private double androidOriginalPrice = 8000000.0;
    private double androidKPS;
    private int majin = 5000000;
    private int majinPurchased = 0;
    private double majinPrice = 100000000.0;
    private double majinOriginalPrice = 100000000.0;
    private double majinKPS;
    private double timer = 0.0;
    public double waitTime = 0.1f;
    private double animationTimer = 0.0;
    private double animationReset = 1.0;
    //10x
    private bool kaioken = false;
    public Text kaiokenText;
    //50x
    private bool superSaiyan = false;
    public Text superSaiyanText;
    //100x
    private bool superSaiyan2 = false;
    public Text superSaiyan2Text;
    //400x
    private bool superSaiyan3 = false;
    public Text superSaiyan3Text;
    //1000x
    private bool superSaiyanGod = false;
    public Text superSaiyanGodText;
    //5000x
    private bool superSaiyan4 = false;
    public Text superSaiyan4Text;
    //25000x
    private bool superSaiyanBlue = false;
    public Text superSaiyanBlueText;
    //100000x
    private bool superSaiyan5 = false;
    public Text superSaiyan5Text;
    //1000000x
    private bool ultraInstinct = false;
    public Text ultraInstinctText;
    //1000000x
    private bool ultraEgo = false;
    public Text ultraEgoText;
    //10000000x
    private bool godOfDestruction = false;
    public Text godOfDestructionText;
    //50000000x
    private bool angel = false;
    public Text angelText;
    //1000000000x
    private bool creator = false;
    public Text creatorText;
    private int setting = 1;
    private int clickTenCount = 0;
    private int saibamenTenCount = 0;
    private int humanTenCount = 0;
    private int lowClassSaiyanTenCount = 0;
    private int namekianTenCount = 0;
    private int androidTenCount = 0;
    private int majinTenCount = 0;
    
    public Animator animator;
 
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
        PlayerPrefs.DeleteAll();
       //LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        kiText = GameObject.Find("KI").GetComponent<Text>();
        timer += Time.deltaTime;
        animationTimer += Time.deltaTime;

        if(timer > waitTime){

            ki += (Items()/10);

            timer -= waitTime;
        }
        if(animationTimer > animationReset){

            animator.SetBool("KiCharge", false);

            animationTimer -= animationReset;
        }

        //Debug.Log(ki);
        //Debug.Log(upgradeClickPrice);

        IndividualKiPerSecond();
        DisplayUpradeClickCost();
        DisplayUpgradeSaibamenCost();
        DisplayUpgradeHumanCost();
        DisplayUpgradeLowClassSaiyanCost();
        DisplayUpgradeNamekianCost();
        DisplayUpgradeAndroidCost();
        DisplayUpgradeMajinCost();
        DisplayKi();
        KiPerSecond();
        DisplayMoney();
        Forms();
        DisplayFormCosts();
        Stats();
        DisplayZenkai();
        Prices();
        SaveGame();

    }

    public void ChargeKi(){
        ki += click * multiplier * form * clickUpgrade;
        animationTimer = 0.0;
        animator.SetBool("KiCharge", true);
    }

    public double Items(){
        TotalKi = 0.0;
        TotalKi = saibamenKPS + humanKPS + lowClassSaiyanKPS + namekianKPS + androidKPS + majinKPS;
        return TotalKi;
    }

    public void Forms(){
        form = 1.0;
        if(kaioken){
            form *= 2;
        }
        if(superSaiyan){
            form *= 5;
        }
        if(superSaiyan2){
            form *= 10;
        }
        if(superSaiyan3){
            form *= 20;
        }
        if(superSaiyanGod){
            form *= 30;
        }
        if(superSaiyan4){
            form *= 50;
        }
        if(superSaiyanBlue){
            form *= 75;
        }
        if(superSaiyan5){
            form *= 100;
        }
        if(ultraInstinct){
            form *= 1000;
        }
        if(ultraEgo){
            form *= 1000;
        }
        if(godOfDestruction){
            form *= 5000;
        }
        if(angel){
            form *= 10000;
        }
        if(creator){
            form *= 100000;
        }

        
    }



    public void PurchaseKaioken(){
        if(money > 10000){
            money -= 10000;
            kaioken = true;
        }
    }

    public void PurchaseSuperSaiyan(){
        if(money > 15000){
            money -= 15000;
            superSaiyan = true;
        }
    }

    public void PurchaseSuperSaiyan2(){
        if(money > 20000){
            money -= 20000;
            superSaiyan2 = true;
        }
    }
    public void PurchaseSuperSaiyan3(){
        if(money > 25000){
            money -= 25000;
            superSaiyan3 = true;
        }
    }

    public void PurchaseSuperSaiyanGod(){
        if(money > 30000){
            money -= 30000;
            superSaiyanGod = true;
        }
    }

    public void PurchaseSuperSaiyan4(){
        if(money > 50000){
            money -= 50000;
            superSaiyan4 = true;
        }
    }

    public void PurchaseSuperSaiyanBlue(){
        if(money > 75000){
            money -= 75000;
            superSaiyanBlue = true;
        }
    }

    public void PurchaseSuperSaiyan5(){
        if(money > 100000){
            money -= 100000;
            superSaiyan5 = true;
        }
    }

    public void PurchaseUltraInstinct(){
        if(money > 1000000){
            money -= 500000;
            ultraInstinct = true;
        }
    }

    public void PurchaseUltraEgo(){
        if(money > 1000000){
            money -= 500000;
            ultraEgo = true;
        }
    }

    public void PurchaseGodOfDestruction(){
        if(money > 5000000){
            money -= 1000000;
            godOfDestruction = true;
        }
    }

    public void PurchaseAngel(){
        if(money > 10000000){
            money -= 10000000;
            angel = true;
        }
    }

    public void PurchaseCreator(){
        if(money > 100000000){
            money -= 100000000;
            creator = true;
        }
    }
    

    public void Zenkai(){
        if(ki > zenkaiPrice){
            zenkai++;
            ki = 0;
            kiUpgrade = 1.0;
            click = 1.0;
            clickUpgrade = 1.0;
            clicksPurchased = 0;
            upgradeClickPrice = upgradeClickOriginalPrice;
            saibamenPurchased = 0;
            saibamenPrice = saibamenOriginalPrice;
            humanPurchased = 0;
            humanPrice = humanOriginalPrice;
            lowClassSaiyanPurchased = 0;
            lowClassSaiyanPrice = lowClassSaiyanOriginalPrice;
            namekianPurchased = 0;
            namekianPrice = namekianOriginalPrice;
            androidPurchased = 0;
            androidPrice = androidOriginalPrice;
            majinPurchased = 0;
            majinPrice = majinOriginalPrice;
            money += 1000;
            zenkaiPrice *= 1.6f;
            multiplier *= 1.2f;
            if(multiplier > 1000000.0){
                multiplier = 1000000.0;
            }
        }
    }
    
    public void Setting(int purchaseSetting){
        setting = purchaseSetting;
    }

    private double PriceCalculator(double upgradePrice, double originalUpgradePrice, int upgradePurchased, int setting){
        double price = 0.0;
        for(int i = 0; i < setting; i++){
            price += (originalUpgradePrice) * Mathf.Pow(1.15f, upgradePurchased + setting - i - 1);
        }
        upgradePrice = price;
        return upgradePrice;

    }
    private void Prices(){
        upgradeClickPrice = PriceCalculator(upgradeClickPrice, upgradeClickOriginalPrice, clicksPurchased, setting);
        saibamenPrice = PriceCalculator(saibamenPrice, saibamenOriginalPrice, saibamenPurchased, setting);
        humanPrice = PriceCalculator(humanPrice, humanOriginalPrice, humanPurchased, setting);
        lowClassSaiyanPrice = PriceCalculator(lowClassSaiyanPrice, lowClassSaiyanOriginalPrice, lowClassSaiyanPurchased, setting);
        namekianPrice = PriceCalculator(namekianPrice, namekianOriginalPrice, namekianPurchased, setting);
        androidPrice = PriceCalculator(androidPrice, androidOriginalPrice, androidPurchased, setting);
        majinPrice = PriceCalculator(majinPrice, majinOriginalPrice, majinPurchased, setting);
    }
    public void UpgradeClick(){
            if(ki > upgradeClickPrice){
                ki -= upgradeClickPrice;
                clicksPurchased += setting;
                click = clicksPurchased + 1;
                if(setting == 1){
                    if(clicksPurchased % 10 == 0){
                        clickUpgrade += 5.0;
                        money += 10.0;
                    }
                    if(clicksPurchased % 25 == 0){
                        clickTenCount = 0;
                        clickUpgrade *= 2.0;
                        money += 25.0;
                    }
                } else if(setting == 10){
                    clickTenCount++;
                    clickUpgrade += 5.0;
                    money += 10.0;
                    if(clicksPurchased % 100 % 25 == 0 || clickTenCount == 3){
                        clickTenCount = 0;
                        clickUpgrade *= 2.0;
                        money += 25.0;
                    }
                } else{
                    for(int i = 0; i < 10; i++){
                        clickUpgrade += 5.0;
                        money += 10.0;
                    }
                    for(int j = 0; j < 4; j++){
                         clickUpgrade *= 2.0;
                        money += 25.0;
                    }
                }
            } else{
                Debug.Log("Insufficient Ki!");
            }
    }

    public void PurchaseSaibamen(){
        
        if(ki > saibamenPrice){
            ki -= saibamenPrice;
            saibamenPurchased += setting;
            if(setting == 1){
                
                if(saibamenPurchased % 10 == 0){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                if(saibamenPurchased % 25 == 0){
                    saibamenTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else if(setting == 10){
                saibamenTenCount++;
                kiUpgrade += 0.1f;
                money += 10.0;
                if(saibamenPurchased % 100 % 25 == 0 || saibamenTenCount == 3){
                    saibamenTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else{
                for(int i = 0; i < 10; i++){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                for(int j = 0; j < 4; j++){
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            }
        } else{
            Debug.Log("Insufficient Ki!");
        }
    }

    public void PurchaseHuman(){
        
        if(ki > humanPrice){

            ki -= humanPrice;
            humanPurchased += setting;

            if(setting == 1){
                
                if(humanPurchased % 10 == 0){
                    humanTenCount = 0;
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                if(humanPurchased % 25 == 0){
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else if(setting == 10){
                humanTenCount++;
                kiUpgrade += 0.1f;
                money += 10.0;
                if(humanPurchased % 100 % 25 == 0 || humanTenCount == 3){
                    humanTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else{
                for(int i = 0; i < 10; i++){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                for(int j = 0; j < 4; j++){
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            }

        } else{
            Debug.Log("Insufficient Ki!");
        }
    }

    public void PurchaseLowClassSaiyan(){
        
        if(ki > lowClassSaiyanPrice){

            ki -= lowClassSaiyanPrice;
            lowClassSaiyanPurchased += setting;

            if(setting == 1){
                
                if(lowClassSaiyanPurchased % 10 == 0){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                if(lowClassSaiyanPurchased % 25 == 0){
                    lowClassSaiyanTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else if(setting == 10){
                lowClassSaiyanTenCount++;
                kiUpgrade += 0.1f;
                money += 10.0;
                if(lowClassSaiyanPurchased % 100 % 25 == 0 || lowClassSaiyanTenCount == 3){
                    lowClassSaiyanTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else{
                for(int i = 0; i < 10; i++){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                for(int j = 0; j < 4; j++){
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            }
        } else{
            Debug.Log("Insufficient Ki!");
        }
    }

    public void PurchaseNamekian(){
        
        if(ki > namekianPrice){
            ki-= namekianPrice;
            namekianPurchased += setting;

            if(setting == 1){
                
                if(namekianPurchased % 10 == 0){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                if(namekianPurchased % 25 == 0){
                    androidTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else if(setting == 10){
                namekianTenCount++;
                kiUpgrade += 0.1f;
                money += 10.0;
                if(namekianPurchased % 100 % 25 == 0 || namekianTenCount == 3){
                    namekianTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else{
                for(int i = 0; i < 10; i++){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                for(int j = 0; j < 4; j++){
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            }
        } else{
            Debug.Log("Insufficient KI!");
        }
    }

    public void PurchaseAndroid(){
        
        if(ki > androidPrice){
            ki-= androidPrice;
            androidPurchased += setting;

            if(setting == 1){
                
                if(androidPurchased % 10 == 0){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                if(androidPurchased % 25 == 0){
                    androidTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else if(setting == 10){
                androidTenCount++;
                kiUpgrade += 0.1f;
                money += 10.0;
                if(androidPurchased % 100 % 25 == 0 || androidTenCount == 3){
                    androidTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else{
                for(int i = 0; i < 10; i++){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                for(int j = 0; j < 4; j++){
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            }
        } else{
            Debug.Log("Insufficient KI!");
        }
    }

    public void PurchaseMajin(){
        
        if(ki > majinPrice){
            ki-= majinPrice;
            majinPurchased += setting;

            if(setting == 1){
                
                if(majinPurchased % 10 == 0){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                if(majinPurchased % 25 == 0){
                    majinTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else if(setting == 10){
                majinTenCount++;
                kiUpgrade += 0.1f;
                money += 10.0;
                if(majinPurchased % 100 % 25 == 0 || majinTenCount == 3){
                    majinTenCount = 0;
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            } else{
                for(int i = 0; i < 10; i++){
                    kiUpgrade += 0.1f;
                    money += 10.0;
                }
                for(int j = 0; j < 4; j++){
                    kiUpgrade += 0.25f;
                    money += 25.0;
                }
            }
        } else{
            Debug.Log("Insufficient KI!");
        }
    }


    private string Converter(double ki, string unit, string dec){

        if(ki < 1000){
            convertedText = ki.ToString(dec) + unit;
        } else if(ki < 1000000){
            converter = ki/1000.0;
            convertedText = converter.ToString(dec) + "K" + unit;
        } else if(ki < 1000000000){
            converter = ki/1000000.0;
            convertedText = converter.ToString(dec) + "M" + unit;
        } else if(ki < 1000000000000){
            converter = ki/1000000000.0;
            convertedText = converter.ToString(dec) + "B" + unit;
        } else if(ki < 1000000000000000){
            converter = ki/1000000000000.0;
            convertedText = converter.ToString(dec) + "T" + unit;
        } else if(ki < 1000000000000000000.0){
            converter = ki/1000000000000000.0;
            convertedText = converter.ToString(dec) + "Q" + unit;
        } else if(ki < 1000000000000000000000.0){
            converter = ki/1000000000000000000.0;
            convertedText = converter.ToString(dec) + "QU" + unit;
        } else if(ki < 1000000000000000000000000.0){
            converter = ki/1000000000000000000000.0;
            convertedText = converter.ToString(dec) + "S" + unit;
        }else if(ki < 1000000000000000000000000000.0){
            converter = ki/1000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "SE" + unit;
        }else if(ki < 1000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "O" + unit;
        }else if(ki < 1000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "N" + unit;
        } else if(ki < 1000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "D" + unit;
        } else if(ki < 1000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "UD" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "DD" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "TD" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "QD" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "QUD" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "SD" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "SED" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "OD" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "ND" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "V" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "UV" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "DV" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "TV" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "QV" + unit;
        } else if(ki < 1000000000000000000000000000000000000000000000000000000000000000000000000000000000.0){
            converter = ki/1000000000000000000000000000000000000000000000000000000000000000000000000000000.0;
            convertedText = converter.ToString(dec) + "QUV" + unit;
        } 
        else {
            convertedText = "BIG NUMBER!";
        }
        
        return convertedText;
    }
    public void DisplayKi(){

        kiText.text = Converter(ki, " KI", "F2");
        kiText2.text = Converter(ki, " KI", "F2");

    }

    private void KiPerSecond(){
        kps.text = Converter(Items(), "", "F0");
    }

    private void DisplayMoney(){
        moneyText.text = Converter(money, " Money", "F1");
    }

    private void DisplayUpradeClickCost(){
        upgradeClickText.text = clicksPurchased.ToString() + " Upgrade Click: " + Converter(upgradeClickPrice, " KI", "F2");
    }

    private void DisplayUpgradeSaibamenCost(){
        saibamenText.text = saibamenPurchased.ToString() + " Saibamen: " + Converter(saibamenPrice, " KI", "F2");
    }

    private void DisplayUpgradeHumanCost(){
        humanText.text = humanPurchased.ToString() + " Human: " + Converter(humanPrice, " KI", "F2");
    }

    private void DisplayUpgradeLowClassSaiyanCost(){
        lowClassSaiyanText.text = lowClassSaiyanPurchased.ToString() + " Low Class Saiyan: " + Converter(lowClassSaiyanPrice, " KI", "F2");
    }

    private void DisplayUpgradeNamekianCost(){
        namekianText.text = namekianPurchased.ToString() + " Namekian: " + Converter(namekianPrice, " KI", "F2");
    }

    private void DisplayUpgradeAndroidCost(){
        androidText.text = androidPurchased.ToString() + " Android: " + Converter(androidPrice, " KI", "F2");
    }

    private void DisplayUpgradeMajinCost(){
        majinText.text = majinPurchased.ToString() + " Majin: " + Converter(majinPrice, " KI", "F2");
    }

    private void DisplayFormCosts(){
        if(!kaioken){
            kaiokenText.text = "(10k money) Kaioken: Permanent 2x multiplier";
        } else{
            kaiokenText.text = "Purchased Kaioken (2x)";
        }
        if(!superSaiyan){
            superSaiyanText.text = "(15k money) Super Saiyan: Permanent 5x multiplier";
        } else{
            superSaiyanText.text = "Purchased Super Saiyan (5x)";
        }

        if(!superSaiyan2){
            superSaiyan2Text.text = "(20k money) Super Saiyan 2: Permanent 10x multiplier";
        } else{
            superSaiyan2Text.text = "Purchased Super Saiyan 2 (10x)";
        }
        if(!superSaiyan3){
            superSaiyan3Text.text = "(25k money) Super Saiyan 3: Permanent 20x multiplier";
        } else{
            superSaiyan3Text.text = "Purchased Super Saiyan 3 (20x)";
        }
        if(!superSaiyanGod){
            superSaiyanGodText.text = "(30k money) Super Saiyan God: Permanent 30x multiplier";
        } else{
            superSaiyanGodText.text = "Purchased Super Saiyan God (30x)";
        }
        if(!superSaiyan4){
            superSaiyan4Text.text = "(50k money) Super Saiyan 4: Permanent 50x multiplier";
        } else{
            superSaiyan4Text.text = "Purchased Super Saiyan 4 (50x)";
        }
        if(!superSaiyanBlue){
            superSaiyanBlueText.text = "(75k money) Super Saiyan Blue: Permanent 75x multiplier";
        } else{
            superSaiyanBlueText.text = "Purchased Super Saiyan Blue (75x)";
        }
        if(!superSaiyan5){
            superSaiyan5Text.text = "(100k money) Super Saiyan 5: Permanent 100x multiplier";
        } else{
            superSaiyan5Text.text = "Purchased Super Saiyan 5 (100x)";
        }
        if(!ultraInstinct){
            ultraInstinctText.text = "(1m money) Ultra Instinct: Permanent 1,000x multiplier";
        } else{
            ultraInstinctText.text = "Purchased Ultra Instinct (1,000x)";
        }
        if(!ultraEgo){
            ultraEgoText.text = "(1m money) Ultra Ego: Permanent 1,000x multiplier";
        } else{
            ultraEgoText.text = "Purchased Ultra Ego (1,000x)";
        }
        if(!godOfDestruction){
            godOfDestructionText.text = "(5m money) God Of Destruction: Permanent 5,000x multiplier";
        } else{
            godOfDestructionText.text = "Purchased God Of Destruction (5,000x)";
        }
        if(!angel){
            angelText.text = "(10m money) Angel: Permanent 10,000x multiplier";
        } else{
            angelText.text = "Purchased Angel (10,000x)";
        }
        if(!creator){
            creatorText.text = "(100m money) Creator: Permanent 100,000x multiplier";
        } else{
            creatorText.text = "Purchased Creator (100,000x)";
        }
    }

    private void IndividualKiPerSecond(){
        saibamenKPS = saibamenPurchased * saibamen * kiUpgrade * multiplier * form;
        humanKPS = humanPurchased * human * kiUpgrade * multiplier * form;
        lowClassSaiyanKPS = lowClassSaiyanPurchased * lowClassSaiyan * kiUpgrade * multiplier * form;
        namekianKPS = namekianPurchased * namekian * kiUpgrade * multiplier * form;
        androidKPS = androidPurchased * android * kiUpgrade * multiplier * form;
        saibamenKPS = saibamenPurchased * saibamen * kiUpgrade * multiplier * form;
        majinKPS = majinPurchased * majin * kiUpgrade * multiplier * form;
        if(saibamenKPS < 0){
            saibamenKPS = 1000000000000000000000000000000000000000000000000000000000000000000000.0 * kiUpgrade;
        }
        if(humanKPS < 0){
            humanKPS = 1000000000000000000000000000000000000000000000000000000000000000000000.0* kiUpgrade;
        }
        if(lowClassSaiyanKPS < 0){
            lowClassSaiyanKPS = 1000000000000000000000000000000000000000000000000000000000000000000000.0* kiUpgrade;
        }
        if(namekianKPS < 0){
            namekianKPS = 1000000000000000000000000000000000000000000000000000000000000000000000.0* kiUpgrade;
        }
        if(androidKPS < 0){
            androidKPS = 1000000000000000000000000000000000000000000000000000000000000000000000.0* kiUpgrade;
        }
        if(majinKPS < 0){
            majinKPS = 1000000000000000000000000000000000000000000000000000000000000000000000.0* kiUpgrade;
        }
    }

    private void Stats(){
        stats.text = "Click Multiplier: " + Converter(clickUpgrade, "x", "F2")
                     + "\nKi Multiplier: " + Converter(kiUpgrade, "x", "F2")
                     + "\nZenkais: " + zenkai.ToString()
                     + "\nZenkai Multiplier: " + Converter(multiplier, "x", "F2")
                     + "\nForm Multiplier: " + Converter((double)form, "x", "F0")
                     + "\nSaibamen: " + Converter(saibamenKPS, " KI/s", "F0")
                     + "\nHuman: " + Converter(humanKPS, " KI/s", "F0")
                     + "\nLow Class Saiyan: " + Converter(lowClassSaiyanKPS, "KI/s", "F0")
                     + "\nNamekian: " + Converter(namekianKPS, " KI/s", "F0")
                     + "\nAndroid: " + Converter(androidKPS, " KI/s", "F0")
                     + "\nMajin: " + Converter(majinKPS, " KI/s", "F0");
    }

    private void DisplayZenkai(){
        zenkaiText.text = "Would you like to Zenkai for " + Converter(zenkaiPrice, "", "F0") + " Ki? (You will only reset all Ki upgrades and Ki)";
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    public static void SetDouble(string key, double value)
    {
        PlayerPrefs.SetString(key, DoubleToString(value));
    }
    public static double GetDouble(string key, double defaultValue)
    {
        string defaultVal = DoubleToString(defaultValue);
        return StringToDouble(PlayerPrefs.GetString(key, defaultVal));
    }
    public static double GetDouble(string key)
    {
        return GetDouble(key, 0d);
    }
    
    private static string DoubleToString(double target)
    {
        return target.ToString("R");
    }
    private static double StringToDouble(string target)
    {
        if (string.IsNullOrEmpty(target))
            return 0d;
    
        return double.Parse(target);
    }

    void SaveGame(){
        SetDouble("Ki", ki);
        SetDouble("Multiplier", multiplier);
        PlayerPrefs.SetInt("Dragon Balls", dragonBalls);
        PlayerPrefs.SetInt("Zenkais", zenkai);
        SetDouble("Money", money);
        SetDouble("ZenkaiPrice", zenkaiPrice);
        PlayerPrefs.SetInt("Clicks purchased", clicksPurchased);
        SetDouble("Clicks", click);
        SetDouble("Ki Upgrade", kiUpgrade);
        SetDouble("Upgrade Click Price", upgradeClickPrice);
        SetDouble("Click Upgrade", clickUpgrade);
        PlayerPrefs.SetInt("Click count", clickTenCount);
        PlayerPrefs.SetInt("Saibamen", saibamen);
        SetDouble("Saibamen Price", saibamenPrice);
        PlayerPrefs.SetInt("Saibamen purchased", saibamenPurchased);
        PlayerPrefs.SetInt("Saibamen count", saibamenTenCount);
        PlayerPrefs.SetInt("Human", human);
        SetDouble("Human Price", humanPrice);
        PlayerPrefs.SetInt("Human purchased", humanPurchased);
        PlayerPrefs.SetInt("Human count", humanTenCount);
        PlayerPrefs.SetInt("Low Class Saiyan", lowClassSaiyan);
        SetDouble("Low Class Saiyan Price", lowClassSaiyanPrice);
        PlayerPrefs.SetInt("Low Class Saiyan purchased", lowClassSaiyanPurchased);
        PlayerPrefs.SetInt("Low Class Saiyan count", lowClassSaiyanTenCount);
        PlayerPrefs.SetInt("Namekian", namekian);
        SetDouble("Namekian Price", namekianPrice);
        PlayerPrefs.SetInt("Namekian purchased", namekianPurchased);
        PlayerPrefs.SetInt("Namekian count", namekianTenCount);
        PlayerPrefs.SetInt("Android", android);
        SetDouble("Android Price", androidPrice);
        PlayerPrefs.SetInt("Android purchased", androidPurchased);
        PlayerPrefs.SetInt("Android count", androidTenCount);
        PlayerPrefs.SetInt("Majin", majin);
        SetDouble("Majin Price", majinPrice);
        PlayerPrefs.SetInt("Majin purchased", majinPurchased);
        PlayerPrefs.SetInt("Majin count", majinTenCount);

        PlayerPrefs.SetInt("Kaioken", boolToInt(kaioken));
        PlayerPrefs.SetInt("Super Saiyan", boolToInt(superSaiyan));
        PlayerPrefs.SetInt("Super Saiyan2", boolToInt(superSaiyan2));
        PlayerPrefs.SetInt("Super Saiyan3", boolToInt(superSaiyan3));
        PlayerPrefs.SetInt("Super Saiyan God", boolToInt(superSaiyanGod));
        PlayerPrefs.SetInt("Super Saiyan4", boolToInt(superSaiyan4));
        PlayerPrefs.SetInt("Super Saiyan Blue", boolToInt(superSaiyanBlue));
        PlayerPrefs.SetInt("Super Saiyan5", boolToInt(superSaiyan5));
        PlayerPrefs.SetInt("Ultra Instinct", boolToInt(ultraInstinct));
        PlayerPrefs.SetInt("Ultra Ego", boolToInt(ultraEgo));
        PlayerPrefs.SetInt("GoD", boolToInt(godOfDestruction));
        PlayerPrefs.SetInt("Angel", boolToInt(angel));
        PlayerPrefs.SetInt("Creator", boolToInt(creator));
        Debug.Log("Data saved.");
    }

    void LoadGame(){
        if (PlayerPrefs.HasKey("Ki")){
            ki = GetDouble("Ki");
            multiplier = GetDouble("Multiplier");
            dragonBalls = PlayerPrefs.GetInt("Dragon Balls");
            zenkai = PlayerPrefs.GetInt("Zenkais");
            money = GetDouble("Money");
            zenkaiPrice = GetDouble("ZenkaiPrice");
            clicksPurchased = PlayerPrefs.GetInt("Clicks purchased");
            click = GetDouble("Clicks");
            clickTenCount = PlayerPrefs.GetInt("Click count");
            kiUpgrade = GetDouble("Ki Upgrade");
            upgradeClickPrice = GetDouble("Upgrade Click Price");
            clickUpgrade = GetDouble("Click Upgrade");
            saibamen = PlayerPrefs.GetInt("Saibamen");
            saibamenPrice = GetDouble("Saibamen Price");
            saibamenPurchased = PlayerPrefs.GetInt("Saibamen purchased");
            saibamenTenCount = PlayerPrefs.GetInt("Saibamen count");
            human = PlayerPrefs.GetInt("Human");
            humanPrice = GetDouble("Human Price");
            humanPurchased = PlayerPrefs.GetInt("Human purchased");
            humanTenCount = PlayerPrefs.GetInt("Human count");
            lowClassSaiyan = PlayerPrefs.GetInt("Low Class Saiyan");
            lowClassSaiyanPrice = GetDouble("Low Class Saiyan Price");
            lowClassSaiyanPurchased = PlayerPrefs.GetInt("Low Class Saiyan purchased");
            lowClassSaiyanTenCount = PlayerPrefs.GetInt("Low Class Saiyan count");
            namekian = PlayerPrefs.GetInt("Namekian");
            namekianPrice = GetDouble("Namekian Price");
            namekianPurchased = PlayerPrefs.GetInt("Namekian purchased");
            namekianTenCount = PlayerPrefs.GetInt("Namekian count");
            android = PlayerPrefs.GetInt("Android");
            androidPrice = GetDouble("Android Price");
            androidPurchased = PlayerPrefs.GetInt("Android purchased");
            androidTenCount = PlayerPrefs.GetInt("Android count");
            majin = PlayerPrefs.GetInt("Majin");
            majinPrice = GetDouble("Majin Price");
            majinPurchased = PlayerPrefs.GetInt("Majin purchased");
            majinTenCount = PlayerPrefs.GetInt("Majin count");

            kaioken = intToBool(PlayerPrefs.GetInt("Kaioken"));
            superSaiyan = intToBool(PlayerPrefs.GetInt("Super Saiyan"));
            superSaiyan2 = intToBool(PlayerPrefs.GetInt("Super Saiyan2"));
            superSaiyan3 = intToBool(PlayerPrefs.GetInt("Super Saiyan3"));
            superSaiyanGod = intToBool(PlayerPrefs.GetInt("Super Saiyan God"));
            superSaiyan4 = intToBool(PlayerPrefs.GetInt("Super Saiyan4"));
            superSaiyanBlue = intToBool(PlayerPrefs.GetInt("Super Saiyan Blue"));
            superSaiyan5 = intToBool(PlayerPrefs.GetInt("Super Saiyan5"));
            ultraInstinct = intToBool(PlayerPrefs.GetInt("Ultra Instinct"));
            ultraEgo = intToBool(PlayerPrefs.GetInt("Ultra Ego"));
            godOfDestruction = intToBool(PlayerPrefs.GetInt("GoD"));
            angel = intToBool(PlayerPrefs.GetInt("Angel"));
            creator = intToBool(PlayerPrefs.GetInt("Creator"));
        }
        else{
            Debug.Log("No save data.");
        }
    }


}
