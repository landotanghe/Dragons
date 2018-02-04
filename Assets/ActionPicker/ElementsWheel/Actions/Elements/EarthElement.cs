﻿namespace Assets.ActionPicker.ElementsWheel.Actions.Scripts
{
    public class EarthElement : WheelElementAction
    {
        protected override AvailableOptions[] GetAvailableOptions()
        {
            return new[]
            {
                AvailableOptions.AnyMove(),
                AvailableOptions.Are(Option.AttackWithWater, Option.ConsumeWater, Option.NoOperation)
            };
        }
    }
}
