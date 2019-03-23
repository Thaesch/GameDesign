﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RBSkillSlot : MonoBehaviour {

    public Text HotkeyText;
    public Image ImageCD;
    public Image IconImage;

    private KeyCode _hotkey;

    void Awake()
    {
        RBAbilityActivityControl.UpdateUISlotsEvent += UpdateSlot;
    }

    public void UpdateSlot(KeyCode kc, RBAbilityActivityControl.RBAbilityHandler handler)
    {
        if (kc != _hotkey) return;

        if (IconImage.sprite == null)
            IconImage.sprite = handler.Prefab.AbilityIcon;

        ImageCD.fillAmount = 1 - (handler.GetCurrentCooldown() / handler.GetMaxCooldown());
    }

    public void SetHotkey(KeyCode keycode)
    {
        _hotkey = keycode;
        HotkeyText.text = _hotkey.ToString();
    }
}
