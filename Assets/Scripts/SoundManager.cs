using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Monsters")]
    public AudioClip monsterDeath;
    public AudioClip monsterAttack;

    [Header("Turrets")]
    public AudioClip turretShoot;


    [Header("GameState")]
    public AudioClip win;

    [Header("Castle")]
    public AudioClip castleDmg;

    [Header("UI")]
    public AudioClip pickUpTurret;
    public AudioClip buildTurret;
    public AudioClip levelUp;
    public AudioClip refresh;


    private void Awake()
    {
        Instance = this;
    }

}
