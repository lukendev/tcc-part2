using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Counter : MonoBehaviour
{
    public Slider marcadorDeVida;
    public float vida = 100;
    private int vidaMax = 100;

    public float buff = 1;
    public float debuff = 1;
    private float tempoDeBuffs;
    // Start is called before the first frame update
    void Start()
    {
        marcadorDeVida.maxValue = vida;
        //vidaMax = vida;
        marcadorDeVida.value = vida;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void recuperarVida(int cura)
    {
        vida += cura;
        if (vida > vidaMax) vida = vidaMax;
        marcadorDeVida.value = vida;

    }

    public void debuffer(Button info) /////dar debuff no inimigo e, conseguentemente, levar menos dano
    {
        StopCoroutine(tempoDoDebuff());

        tempoDeBuffs = info.GetComponent<Attack_Button>().tempoDeEfeitoBuffs;
        debuff = info.GetComponent<Attack_Button>().intensidadeDebuff;

        StartCoroutine(tempoDoDebuff());
    }

    IEnumerator tempoDoDebuff()
    {

        yield return new WaitForSeconds(tempoDeBuffs);
        debuff = 1;

    }

    public void buffer(Button info) /////inimigo recebeu um buff e, conseguentemente, tomar mais dano
    {
        StopCoroutine(tempoDoBuff());

        tempoDeBuffs = info.GetComponent<Attack_Button>().tempoDeEfeitoBuffs;
        buff = info.GetComponent<Attack_Button>().intensidadeBuff;

        StartCoroutine(tempoDoBuff());
    }


    IEnumerator tempoDoBuff()
    {

        yield return new WaitForSeconds(tempoDeBuffs);
        buff = 1;

    }

    public void tomarDano(float dano) {
        vida -= dano*buff*debuff;
        marcadorDeVida.value = vida;
    }
}
