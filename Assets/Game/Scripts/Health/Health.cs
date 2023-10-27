using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Health
{
    public Action OnDeath;

	[SerializeField]
	private float _max;

	[SerializeField]
	private float _current;

    [SerializeField]
    private BloodController _blood;

    [SerializeField]
    private DamagePopUpController _damagePopUp;

    [SerializeField]
    private HealthBarController _healthBar;

    [SerializeField]
    private Animator _animator;

    public bool IsAlive => _current > 0;


    public IEnumerator TakeDamage(Transform targetTransform, int damage)
    {
        if (!IsAlive) yield break;

        _current -= damage;

        _healthBar.UpdateHealthBar(_current / _max);
        _damagePopUp.CreatePopUp(targetTransform, damage.ToString());
        _blood.GenerateBloodDrops(targetTransform);

		if (_current <= 0) {
            Die();
			yield break;
		}

        yield return new WaitForSeconds(.5f);

        yield break;
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
}
