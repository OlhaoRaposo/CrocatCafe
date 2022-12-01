using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Armazen : MonoBehaviour
{
    [Header("Lvl")]
    [SerializeField]
    public static int lvl = 1;

    public int money;
    public Text[] moneyText;

    //Materiais
    [Header("Massas")]
    public int massasAtual;
    public int massasMax = lvl * 10;
    [Header("Massa Text")]
    public Text[] massastxt;

    [Header("Fruta Café")]
    public int frutaCafeAtual;
    public int frutaCafeMax = lvl * 10;
    [Header("Fruta Café Text")]
    public Text[] frutasCafeText;

    [Header("Laranja")]
    public int laranjaAtual;
    public int laranjaMax = lvl * 10;
    [Header("Laranja Text")]
    public Text[] laranjaText;

    [Header("Frango")]
    public int frangoAtual;
    public int frangoMax = lvl * 10;
    [Header("Frango Text")]
    public Text[] frangoText;

    [Header("Acucar")]
    public int acucarAtual;
    public int acucarMax = lvl * 10;
    [Header("Acucar Text")]
    public Text[] acucarText;

    [Header("Leite")]
    public int leiteAtual;
    public int leiteMax = lvl * 10;
    [Header("Leite Text")]
    public Text[] leiteText;

    [Header("Queijo")]
    public int queijoAtual;
    public int queijoMax = lvl * 10;
    [Header("Queijo Text")]
    public Text[] queijoText;

    //Pratos
    [Header("Coxinha")]
    public int coxinhaAtual;
    public int coxinhaMax = lvl * 10;
    [Header("Coxinha Text")]
    public Text[] coxinhaText;

    [Header("Bolos")]
    public int boloAtual;
    public int boloMax = lvl * 10;
    [Header("Bolos Text")]
    public Text[] bolosText;

    [Header("Suco")]
    public int sucosAtual;
    public int sucosMax = lvl * 10;
    [Header("Suco Text")]
    public Text[] sucosText;

    [Header("Café")]
    public int cafeAtual;
    public int cafeMax = lvl * 10;
    [Header("Cafe Text")]
    public Text[] cafeText;

    [Header("Pao")]
    public int breads;
    public int maxBreads = lvl * 10;
    [Header("Pao Text")]
    public Text[] breadstxt;

    [Header("Pao De queijo")]
    public int paoDeQueijoAtual;
    public int paoDeQueijoMax = lvl * 10;
    [Header("Pao De Queijo Text")]
    public Text[] paoDeQueijoText;

    [Header("Massa De Coxinha")]
    public int massaCoxinhaAtual;
    public int massaCoxinhaMax = lvl * 10;
    [Header("Massa de coxinha Text")]
    public Text[] massaCoxinhaText;

    [Header("Massa De Bolo")]
    public int massaBoloAtual;
    public int massaBoloMax = lvl * 10;
    [Header("Massa de bolo Text")]
    public Text[] massaBoloText;

    [Header("Bola De Queijo")]
    public int bolaQueijoAtual;
    public int bolaQueijoMax = lvl * 10;
    [Header("Bola De Queijo Text")]
    public Text[] bolaQueijoText;

    public static Armazen instance;

    private void Start()
    {
        AtualizaTxt();
        instance = this;
    }
    //Materiais
    //Massas
    public void AdicionaMassas(int quant)
    {
        if (massasAtual < massasMax) {
            massasAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveMassas(int quant)
    {
        if (massasAtual - quant >= 0) {
            massasAtual -= quant;
        }
        AtualizaTxt();
    }
    //Café fruta
    public void AdicionaFrutaCafe(int quant)
    {
        if (frutaCafeAtual < frutaCafeMax) {
            frutaCafeAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveFrutaCafe(int quant)
    {
        if (frutaCafeAtual - quant > 0) {
            frutaCafeAtual -= quant;
        }
        AtualizaTxt();
    }
    //Laranja
    public void AdicionaLaranjas(int quant)
    {
        if (laranjaAtual + quant <= laranjaMax) {
            laranjaAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveLaranjas(int quant)
    {
        if (laranjaAtual - quant >= 0) {
            laranjaAtual -= quant;
        }
        AtualizaTxt();
    }
    //Frango
    public void AdicionaFrango(int quant)
    {
        if (frangoAtual + quant <= frangoMax) {
            frangoAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveFrango(int quant)
    {
        if (frangoAtual - quant >= 0) {
            frangoAtual -= quant;
        }
        AtualizaTxt();
    }
    //Açucar
    public void AdicionaAcucar(int quant)
    {
        if (acucarAtual + quant <= acucarMax) {
            acucarAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveAcucar(int quant)
    {
        if (acucarAtual - quant >= 0) {
            acucarAtual -= quant;
        }
        AtualizaTxt();
    }

    //Leite
    public void AdicionaLeite(int quant)
    {
        if (leiteAtual + quant <= leiteMax) {
            leiteAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveLeite(int quant)
    {
        if (leiteAtual - quant >= 0) {
            leiteAtual -= quant;
        }
        AtualizaTxt();
    }

    //Queijo
    public void AdicionaQueijo(int quant)
    {
        if (queijoAtual + quant <= queijoMax) {
            queijoAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveQueijo(int quant)
    {
        if (queijoAtual - quant >= 0) {
            queijoAtual -= quant;
        }
        AtualizaTxt();
    }

    //Massa de Coxinha
    public void AdicionaMassaCoxinha(int quant)
    {
        if (massaCoxinhaAtual + quant <= massaCoxinhaMax) {
            massaCoxinhaAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveMassaCoxinha(int quant)
    {
        if (massaCoxinhaAtual - quant >= 0){
            massaCoxinhaAtual -= quant;
        }
        AtualizaTxt();
    }

    //Massa de Bolo
    public void AdicionaMassaBolo(int quant)
    {
        if (massaBoloAtual + quant <= massaBoloMax) {
            massaBoloAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveMassaBolo(int quant)
    {
        if (massaBoloAtual - quant >= 0) {
            massaBoloAtual -= quant;
        }
        AtualizaTxt();
    }

    //Bola de Queijo
    public void AdicionaBolaQueijo(int quant)
    {
        if (bolaQueijoAtual + quant <= bolaQueijoMax) {
            bolaQueijoAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveBolaQueijo(int quant)
    {
        if (bolaQueijoAtual - quant >= 0) {
            bolaQueijoAtual -= quant;
        }
        AtualizaTxt();
    }

    //Pratos
    //Pao
    public void AdicionaPao(int quant)
    {
        if (breads < maxBreads) {
            breads += quant;
        }
        AtualizaTxt();
    }
    public void RemovePao(int quant)
    {
        if (breads - quant >= 0) {
            breads -= quant;
        }
        AtualizaTxt();
    }
    //Coxinha
    public void AdicionaCoxinha(int quant)
    {
        if (coxinhaAtual + quant < coxinhaMax) {
            coxinhaAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveCoxinha(int quant)
    {
        if (coxinhaAtual - quant >= 0) {
            coxinhaAtual -= quant;
        }
        AtualizaTxt();
    }
    //Café
    public void AdicionaCafé(int quant)
    {
        if (cafeAtual < cafeMax) {
            cafeAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveCafé(int quant)
    {
        if (cafeAtual - quant >= 0) {
            cafeAtual -= quant;
        }
        AtualizaTxt();
    }
    //Pao de queijo
    public void AdicionaPaoDeQueijo(int quant)
    {
        if (paoDeQueijoAtual + quant < paoDeQueijoMax) {
            paoDeQueijoAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemovePaoDeQueijo(int quant)
    {
        if (paoDeQueijoAtual - quant >= 0) {
            paoDeQueijoAtual -= quant;
        }
        AtualizaTxt();
    }
    //Suco
    public void AdicionaSucos(int quant)
    {
        if (sucosAtual + quant < sucosMax) {
            sucosAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveSucos(int quant)
    {
        if (sucosAtual - quant >= 0) {
            sucosAtual -= quant;
        }
        AtualizaTxt();
    }
    //Bolos
    public void AdicionaBolos(int quant)
    {
        if (boloAtual + quant <= boloMax) {
            boloAtual += quant;
        }
        AtualizaTxt();
    }
    public void RemoveBolos(int quant)
    {
        if (boloAtual - quant >= 0) {
            boloAtual -= quant;
        }
        AtualizaTxt();
    }
    //AtualizaTxt
    public void AtualizaTxt()
    {
        //Materiais
        AtualizaMateriais();
        //Dinheiro
        AtualizaDinheiro();
        //Pratos
        AtualizaPratos();
    }
    private void AtualizaDinheiro()
    {
        for (int i = 0; i < moneyText.Length; i++)
        {
            moneyText[i].text = "X" + money;
        }
    }
    private void AtualizaPratos()
    {
        //Pratos
        for (int i = 0; i < breadstxt.Length; i++)
        {
            breadstxt[i].text = "X " + breads;
        }
        for (int i = 0; i < cafeText.Length; i++)
        {
            cafeText[i].text = "X " + cafeAtual;
        }
        for (int i = 0; i < coxinhaText.Length; i++)
        {
            coxinhaText[i].text = "X " + coxinhaAtual;
        }
        for (int i = 0; i < paoDeQueijoText.Length; i++)
        {
            paoDeQueijoText[i].text = "X " + paoDeQueijoAtual;
        }
        for (int i = 0; i < sucosText.Length; i++)
        {
            sucosText[i].text = "X " + sucosAtual;
        }
        for (int i = 0; i < bolosText.Length; i++)
        {
            bolosText[i].text = "X " + boloAtual;
        }
    }
    private void AtualizaMateriais()
    {
        //Materiais
        for (int i = 0; i < frutasCafeText.Length; i++)
        {
            frutasCafeText[i].text = "X " + frutaCafeAtual;
        }
        for (int i = 0; i < massastxt.Length; i++)
        {
            massastxt[i].text = "X " + massasAtual;
        }
        for (int i = 0; i < laranjaText.Length; i++)
        {
            laranjaText[i].text = "X " + laranjaAtual;
        }
        for (int i = 0; i < frangoText.Length; i++)
        {
            frangoText[i].text = "X " + frangoAtual;
        }
        for (int i = 0; i < acucarText.Length; i++)
        {
            acucarText[i].text = "X " + acucarAtual;
        }
        for (int i = 0; i < leiteText.Length; i++)
        {
            leiteText[i].text = "X " + leiteAtual;
        }
        for (int i = 0; i < queijoText.Length; i++)
        {
            queijoText[i].text = "X " + queijoAtual;
        }
        for (int i = 0; i < massaCoxinhaText.Length; i++)
        {
            massaCoxinhaText[i].text = "X " + massaCoxinhaAtual;
        }
        for (int i = 0; i < massaBoloText.Length; i++)
        {
            massaBoloText[i].text = "X " + massaBoloAtual;
        }
        for (int i = 0; i < bolaQueijoText.Length; i++)
        {
            bolaQueijoText[i].text = "X " + bolaQueijoAtual;
        }
    }
}
