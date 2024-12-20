using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private CardReader _cardReader;

    [SerializeField]
    private float spellCard;
    [SerializeField]
    public float argent;
    [SerializeField]
    public TextMeshProUGUI spellCardText;
    [SerializeField]
    public TextMeshProUGUI argentText;
    [SerializeField]
    private TextMeshProUGUI PrixupgradeCirno;
    public TextMeshProUGUI upgradeCirno;

    [SerializeField]
    private TextMeshProUGUI PrixupgradeAya;
    public TextMeshProUGUI upgradeAya;

    public TextMeshProUGUI PrixupgradeSuika;
    public TextMeshProUGUI upgradeSuika;

    public TextMeshProUGUI PrixupgradeReimu;
    public TextMeshProUGUI upgradeReimu;

    public TextMeshProUGUI PrixupgradeKaguya;
    public TextMeshProUGUI upgradeKaguya;

    public TextMeshProUGUI PrixupgradeYukari;
    public TextMeshProUGUI upgradeYukari;

    public TextMeshProUGUI PrixupgradeRemilia;
    public TextMeshProUGUI upgradeRemilia;

    public float ennemiNomber;

    public bool Cirno = false;
    private int prixUpgradeCirno = 1;
    private int cashCirno = 1;

    //private bool plush;

    private bool Aya = false;
    private int prixUpgradeAya = 2;
    private int cashAya = 2;

    private bool Suika = false;
    private int prixUpgradeSuika= 4;
    private int cashSuika = 4;

    private bool Reimu = false;
    private int prixUpgradeReimu = 6;
    private int cashReimu = 6;

    private bool Kaguya = false;
    private int prixUpgradeKaguya = 8;
    private int cashKaguya = 8;

    private bool Yukari = false;
    private int prixUpgradeYukari = 10;
    private int cashYukari = 10;

    private bool Remilia = false;
    private int prixUpgradeRemilia = 12;
    private int cashRemilia = 12;

    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = WaitAndPrint();
        StartCoroutine(coroutine);


        PrixupgradeCirno.text = prixUpgradeCirno.ToString();
        PrixupgradeAya.text = prixUpgradeAya.ToString();
        PrixupgradeSuika.text = prixUpgradeSuika.ToString();
        PrixupgradeReimu.text = prixUpgradeReimu.ToString();
        PrixupgradeKaguya.text = prixUpgradeKaguya.ToString();
        PrixupgradeYukari.text = prixUpgradeYukari.ToString();
        PrixupgradeRemilia.text = prixUpgradeRemilia.ToString();

        upgradeCirno.text = "Am�lioration de la Cirno Fumo : +2 (" + cashCirno + ")".ToString();
        upgradeAya.text = "Am�lioration de la Aya Fumo : +4 (" + cashAya + ")".ToString();
        upgradeSuika.text = "Am�lioration de la Suika Fumo : +6 (" + cashSuika + ")".ToString();
        upgradeReimu.text = "Am�lioration de la Reimu Fumo : +8 (" + cashReimu + ")".ToString();
        upgradeKaguya.text = "Am�lioration de la Kaguya Fumo : +10 (" + cashKaguya + ")".ToString();
        upgradeYukari.text = "Am�lioration de la Yukari Fumo : +12 (" + cashYukari + ")".ToString();
        upgradeRemilia.text = "Am�lioration de la Remilia Fumo : +14 (" + cashRemilia + ")".ToString();

    }



    public void ChangeSpellCard(float moreSpellCard)
    {
        spellCard += moreSpellCard;
        spellCardText.text = "SpellCard : " + spellCard.ToString();
    }

    public void RiseSpellCard(float spellCard)
    {
        ChangeSpellCard(spellCard);
    }

    public void ChangeArgent(float moreArgent)
    {
        argent += moreArgent;
        argentText.text = "Argent : " + argent.ToString();
    }

    public void RiseArgent(float argent)
    {
        ChangeArgent(argent);
    }

    public void TrueCirno()
    {
        if (!Cirno)
        {
            Cirno = true;
           
            Manager.Instance.cardReader.EnnemiPlus();
            
        }
       
    }
    public void TrueAya()
    {
        if (!Aya)
        {
            Aya = true;
            Manager.Instance.cardReader.EnnemiPlus();
        }
    }
    public void TrueSuika()
    {
        if (!Suika)
        {
            Suika = true;
            Manager.Instance.cardReader.EnnemiPlus();
        }
    }
    public void TrueReimu()
    {
        if (!Reimu)
        {
            Reimu = true;
            Manager.Instance.cardReader.EnnemiPlus();
        }
    }
    public void TrueKaguya()
    {
        if (!Kaguya)
        {
            Kaguya = true;
            Manager.Instance.cardReader.EnnemiPlus();
        }
    }
    public void TrueYukari()
    {
        if (!Yukari)
        {
            Yukari = true;
            Manager.Instance.cardReader.EnnemiPlus();
        }
    }
    public void TrueRemilia()
    {
        if (!Remilia)
        {
            Remilia = true;
            Manager.Instance.cardReader.EnnemiPlus();
        }
    }

    public void AmeliorationCirno()
    {
        if (spellCard >= prixUpgradeCirno)
        {
            spellCard -= prixUpgradeCirno;
            Debug.Log(spellCard);
            spellCardText.text = "SpellCard : " + spellCard.ToString();
            prixUpgradeCirno += 2;
            PrixupgradeCirno.text = prixUpgradeCirno.ToString();
            cashCirno += 2;
            upgradeCirno.text = "Am�lioration de la Cirno Fumo : +2 (" + cashCirno + ")".ToString();
        }
    }

    public void AmeliorationAya()
    {
     
        if (spellCard >= prixUpgradeAya && Aya)
        {
            spellCard -= prixUpgradeAya;
            Debug.Log(spellCard);
            spellCardText.text = "SpellCard : " + spellCard.ToString();
            prixUpgradeAya += 4;
            PrixupgradeAya.text = prixUpgradeAya.ToString();
            cashAya += 4;
            upgradeAya.text = "Am�lioration de la Aya Fumo : +4 (" + cashAya + ")".ToString();
        }
    }
    public void AmeliorationSuika()
    {
        if (spellCard >= prixUpgradeSuika)
        {
            spellCard -= prixUpgradeSuika;
            Debug.Log(spellCard);
            spellCardText.text = "SpellCard : " + spellCard.ToString();
            prixUpgradeSuika += 6;
            PrixupgradeSuika.text = prixUpgradeSuika.ToString();
            cashAya += 6;
            upgradeSuika.text = "Am�lioration de la Suika Fumo : +6 (" + cashSuika + ")".ToString();
        }
    }

    public void AmeliorationReimu()
    {
        if (spellCard >= prixUpgradeReimu)
        {
            spellCard -= prixUpgradeReimu;
            Debug.Log(spellCard);
            spellCardText.text = "SpellCard : " + spellCard.ToString();
            prixUpgradeReimu += 8;
            PrixupgradeReimu.text = prixUpgradeReimu.ToString();
            cashAya += 8;
            upgradeReimu.text = "Am�lioration de la Reimu Fumo : +8 (" + cashReimu + ")".ToString();
        }
    }

    public void AmeliorationKaguya()
    {
        if (spellCard >= prixUpgradeKaguya)
        {
            spellCard -= prixUpgradeKaguya;
            Debug.Log(spellCard);
            spellCardText.text = "SpellCard : " + spellCard.ToString();
            prixUpgradeKaguya += prixUpgradeKaguya + 10;
            PrixupgradeAya.text = prixUpgradeKaguya.ToString();
            cashAya += 10;
            upgradeKaguya.text = "Am�lioration de la Kaguya Fumo : +10 (" + cashKaguya + ")".ToString();
        }
    }

    public void AmeliorationYukari()
    {
        if (spellCard >= prixUpgradeYukari)
        {
            spellCard -= prixUpgradeYukari;
            Debug.Log(spellCard);
            spellCardText.text = "SpellCard : " + spellCard.ToString();
            prixUpgradeYukari += prixUpgradeYukari + 10;
            PrixupgradeYukari.text = prixUpgradeYukari.ToString();
            cashAya += 12;
            upgradeYukari.text = "Am�lioration de la Yukari Fumo : +12 (" + cashYukari + ")".ToString();
        }
    }

    public void AmeliorationRemilia()
    {
        if (spellCard >= prixUpgradeRemilia)
        {
            spellCard -= prixUpgradeRemilia;
            Debug.Log(spellCard);
            spellCardText.text = "SpellCard : " + spellCard.ToString();
            prixUpgradeRemilia += prixUpgradeRemilia + 10;
            PrixupgradeRemilia.text = prixUpgradeRemilia.ToString();
            cashAya += 14;
            upgradeRemilia.text = "Am�lioration de la Remilia Fumo : +14 (" + cashRemilia + ")".ToString();
        }
    }


    private IEnumerator WaitAndPrint()
    {
        
        while (true)
        {
            if(Cirno == true)
            {
                RiseArgent(cashCirno);
            }
            if (Aya == true)
            {
                RiseArgent(1);
            }
            if (Suika == true)
            {
                RiseArgent(1);
            }
            if (Reimu == true)
            {
                RiseArgent(1);
            }
            if (Kaguya == true)
            {
                RiseArgent(1);
            }
            if (Yukari == true)
            {
                RiseArgent(1);
            }
            if(Remilia == true)
            {
                RiseArgent(1);
            }

            yield return new WaitForSeconds(1);

        }
    }
    /*
    private IEnumerator WaitAndPrint(bool plush, int plushCash)
    {
        while (true)
        {
            if (plush == true)
            {
                RiseArgent(plushCash);
            }
            yield return new WaitForSeconds(1);

        }
    }
    */
}
