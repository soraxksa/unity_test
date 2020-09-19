using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour {

    #region Private members

    private bool _isCausingDamage = false;

    #endregion

    #region Public Members

    public float DamageRepeatRate = 0.1f;

    public int DamageAmount = 1;

    public bool Repeating = true;

    #endregion




    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            _isCausingDamage = false;
        }
    }
}
