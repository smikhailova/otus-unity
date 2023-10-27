public static class WeaponHelpers
{
	public static string GetAnimationName(WeaponType weaponType)
	{
        return weaponType switch
        {
            WeaponType.Gun => "Shoot",
            WeaponType.Bat => "Strike",
            WeaponType.Fist => "Punch",
            _ => null,
        };
    }
}
