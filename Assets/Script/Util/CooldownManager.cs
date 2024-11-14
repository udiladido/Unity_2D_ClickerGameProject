using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownManager : Singleton<CooldownManager>
{
    private Dictionary<Slot, Coroutine> activeCoroutines = new Dictionary<Slot, Coroutine>();
    private Dictionary<Slot, CooldownData> cooldownStates = new Dictionary<Slot, CooldownData>();


    public class CooldownData
    {
        public Image cooldownImage;
        public float totalTime;
        public float remainingTime;
        public bool isCooldown;
    }

    public void StartCooldown(Slot slot, float cooldownTime, Image cooldownImage)
    {
        if (activeCoroutines.ContainsKey(slot))
        {
            StopCoroutine(activeCoroutines[slot]);
            activeCoroutines.Remove(slot);
        }

        CooldownData data = new CooldownData
        {
            cooldownImage = cooldownImage,
            totalTime = cooldownTime,
            remainingTime = cooldownTime,
            isCooldown = true
        };

        cooldownStates[slot] = data;
        activeCoroutines[slot] = StartCoroutine(CooldownCoroutine(slot));
    }

    private IEnumerator CooldownCoroutine(Slot slot)
    {
        CooldownData data = cooldownStates[slot];

        while (data.remainingTime > 0)
        {
            data.remainingTime -= Time.deltaTime;
            // UI는 항상 업데이트 (SetActive 상태와 무관하게)
            data.cooldownImage.fillAmount = data.remainingTime / data.totalTime;
            yield return null;
        }

        data.remainingTime = 0;
        data.isCooldown = false;
        data.cooldownImage.fillAmount = 1;

        slot.SetCooldownComplete();
        activeCoroutines.Remove(slot);
        cooldownStates.Remove(slot);
    }

    public bool IsInCooldown(Slot slot)
    {
        return cooldownStates.ContainsKey(slot) && cooldownStates[slot].isCooldown;
    }

}
