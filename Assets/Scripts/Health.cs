using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnDeath = new();
    [SerializeField] AudioClip deathSound;
    [SerializeField] int MaxHP;
    [SerializeField] float deathTime = 1;
    int currentHP;
    Coroutine coroutine;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHP = MaxHP;
    }
    public void TakeDamage(int damage)
    {
        if (coroutine != null) return;
        currentHP -= damage;
        if (currentHP <= 0) coroutine = StartCoroutine(death());
    }
    IEnumerator death()
    {
        anim.SetTrigger("Death");
        SoundPlayer.Play.Invoke(deathSound);
        yield return new WaitForSeconds(deathTime);
        OnDeath.Invoke();
    }
    public void Destroy() => Destroy(gameObject);
}
