using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{


    [SerializeField]
    private float _spellCard;
    [SerializeField]
    private float _argent;
    [SerializeField]
    private TextMeshProUGUI spellCardText;
    [SerializeField]
    private TextMeshProUGUI argentText;
    [SerializeField]
    private TextMeshProUGUI upgradeCirno;
    [SerializeField]
    private TextMeshProUGUI upgradeAya;

    public float ennemiNomber;

    public bool Cirno = false;
    private int prixUpgradeCirno = 2;
    private int cashCirno = 1;

    //private bool plush;

    private bool Aya = false;
    private int prixUpgradeAya = 2;
    private int cashAya = 1;

    private bool Suika = false;
    private int prixUpgradeSuika= 2;
    private int cashSuika = 1;

    private bool Reimu = false;
    private int prixUpgradeReimu = 2;
    private int cashReimu = 1;

    private bool Kaguya = false;
    private int prixUpgradeKaguya = 2;
    private int cashKaguya = 1;

    private bool Yukari = false;
    private int prixUpgradeYukari = 2;
    private int cashYukari = 1;

    private bool Remilia = false;
    private int prixUpgradeRemilia = 2;
    private int cashRemilia = 1;

    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = WaitAndPrint();
        StartCoroutine(coroutine);


        upgradeCirno.text = prixUpgradeCirno.ToString();
    }


    public void ChangeSpellCard(float moreSpellCard)
    {
        _spellCard += moreSpellCard;
        spellCardText.text = _spellCard.ToString();
    }

    public void RiseSpellCard(float spellCard)
    {
        ChangeSpellCard(spellCard);
    }

    public void ChangeArgent(float moreArgent)
    {
        _argent += moreArgent;
        argentText.text = _argent.ToString();
    }

    public void RiseArgent(float argent)
    {
        ChangeArgent(argent);
    }

    public void TrueCirno()
    {
        Cirno = true;
    }
    public void TrueAya()
    {
        Aya = true;
    }
    public void TrueSuika()
    {
        Suika = true;
    }
    public void TrueReimu()
    {
        Reimu = true;
    }
    public void TrueKaguya()
    {
        Kaguya = true;
    }
    public void TrueYukari()
    {
        Yukari = true;
    }
    public void TrueRemilia()
    {
        Remilia = true;
    }

    public void AmeliorationCirno()
    {
        if (_spellCard >= prixUpgradeCirno)
        {
            _spellCard -= prixUpgradeCirno;
            Debug.Log(_spellCard);
            spellCardText.text = _spellCard.ToString();
            prixUpgradeCirno += prixUpgradeCirno + 2;
            upgradeCirno.text = prixUpgradeCirno.ToString();
            cashCirno += 1;
        }
    }

    public void AmeliorationAya()
    {
        if (_spellCard >= prixUpgradeAya)
        {
            _spellCard -= prixUpgradeAya;
            Debug.Log(_spellCard);
            spellCardText.text = _spellCard.ToString();
            prixUpgradeAya += prixUpgradeAya + 2;
            upgradeAya.text = prixUpgradeAya.ToString();
            cashAya += 1;
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
