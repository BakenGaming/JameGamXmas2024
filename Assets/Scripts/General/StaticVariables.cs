using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StaticVariables : MonoBehaviour
{
    public static StaticVariables i;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer, whatIsEnemy, 
        collectable, whatIsUI, whatIsCookie, whatIsSnowball, whatIsPresent;
    [SerializeField] private AudioMixerGroup masterMixer, sfxMixer, musicMixer;

    private void Awake() 
    {
        i = this;
    }

    public LayerMask GetGroundLayer() { return whatIsGround; }
    public LayerMask GetPlayerLayer() { return whatIsPlayer; }
    public LayerMask GetEnemyLayer() { return whatIsEnemy; }
    public LayerMask GetCollectableLayer() { return collectable; }
    public LayerMask GetUILayer(){ return whatIsUI; }
    public LayerMask GetCookieLayer(){ return whatIsCookie;}
    public LayerMask GetSnowballLayer(){ return whatIsSnowball;}
    public LayerMask GetPresentLayer(){ return whatIsPresent;}
    
    public AudioMixerGroup GetMasterMixer(){ return masterMixer; }
    public AudioMixerGroup GetSFXMixer(){ return sfxMixer; }
    public AudioMixerGroup GetMusicMixer(){ return musicMixer; }

}
