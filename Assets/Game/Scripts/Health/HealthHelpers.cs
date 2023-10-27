public static class HealthHelpers
{
    public static string GetAnimationName(HealthActionType actionType)
    {
        return actionType switch
        {
            HealthActionType.Die => "Die",
            _ => null,
        };
    }
}

