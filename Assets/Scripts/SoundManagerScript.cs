using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
    public static AudioClip enemy, rook, gameOver;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        enemy = Resources.Load<AudioClip>("enemy");
        rook = Resources.Load<AudioClip>("rook");
        gameOver = Resources.Load<AudioClip>("gameover");
        audioSrc = GetComponent<AudioSource>();
    }
	
	public static void playSoundEnemy()
    {
        audioSrc.PlayOneShot(enemy);
    }

    public static void playSoundRook()
    {
        audioSrc.PlayOneShot(rook);
    }

    public static void soundGameOver()
    {
        audioSrc.PlayOneShot(gameOver);
    }
}
