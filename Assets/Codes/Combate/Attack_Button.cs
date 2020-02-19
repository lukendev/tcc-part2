using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack_Button : MonoBehaviour
{
    public bool npc;

    public GameObject tiposDeAtaque;

    public string nomeDoAtaque;

    public float tempoDeRecarga;

    public float danoDoAtaque;

    public int vidaCurada;

    public float intensidadeBuff;

    public float intensidadeDebuff;

    public float tempoDeEfeitoBuffs;

    // Start is called before the first frame update
    void Start()
    {
        if (npc) StartCoroutine(AtaqueAutomatico());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desligar()
    {
        StartCoroutine(Desabilitar());
    }

    IEnumerator Desabilitar()
    {
        yield return new WaitForSeconds(tempoDeRecarga);
        gameObject.GetComponent<Button>().interactable = true;
        if (npc) StartCoroutine(AtaqueAutomatico());

    }

    IEnumerator AtaqueAutomatico()
    {
        yield return new WaitForSeconds(Random.Range(0.3f,0.9f));
        gameObject.GetComponent<Button>().onClick.Invoke();
    }
}
