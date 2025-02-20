﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvencibleEffect : Invencibility
{
    [SerializeField]
    private int timeNormal;

    private float timer;

    protected override void Awake()
    {
        timer = timeNormal;

        base.Awake();

        StartCoroutine( SetNormal() );
    }

    private IEnumerator SetNormal()
    {
        mySprite.color = new Color( 1, 1, 1, 1 );

        isInvencible = false;

        int n = Random.Range( timeNormal - 1, timeNormal + 2 );

        yield return new WaitForSeconds( n );

        StartCoroutine( InvencibilityEffect() );
    }

    protected override IEnumerator InvencibilityEffect()
    {
        isInvencible = true;

        mySprite.color = new Color( 1, 1, 1, 0.2f );
        
        yield return new WaitForSeconds( timer );

        StartCoroutine( SetNormal() );
    }
}
