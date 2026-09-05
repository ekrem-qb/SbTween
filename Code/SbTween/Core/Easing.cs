using System;
using System.Text.Json.Serialization;
using Sandbox;

namespace SbTween;

[JsonConverter(typeof(EaseTypeConverter))]
public enum EaseType
{
	Linear,
	InSine,
	OutSine,
	InOutSine,
	InQuad,
	OutQuad,
	InOutQuad,
	InCubic,
	OutCubic,
	InOutCubic,
	InQuart,
	OutQuart,
	InOutQuart,
	InQuint,
	OutQuint,
	InOutQuint,
	InExpo,
	OutExpo,
	InOutExpo,
	InCirc,
	OutCirc,
	InOutCirc,
	InElastic,
	OutElastic,
	InOutElastic,
	InBack,
	OutBack,
	InOutBack,
	InBounce,
	OutBounce,
	InOutBounce,
}

public static class Easing
{
	public static float Apply(EaseType type, float t)
	{
		return type switch
		{
			EaseType.Linear => Sandbox.Utility.Easing.Linear(t),
			EaseType.InSine => Sandbox.Utility.Easing.SineEaseIn(t),
			EaseType.OutSine => Sandbox.Utility.Easing.SineEaseOut(t),
			EaseType.InOutSine => Sandbox.Utility.Easing.SineEaseInOut(t),
			EaseType.InQuad => Sandbox.Utility.Easing.QuadraticIn(t),
			EaseType.OutQuad => Sandbox.Utility.Easing.QuadraticOut(t),
			EaseType.InOutQuad => Sandbox.Utility.Easing.QuadraticInOut(t),
			EaseType.InCubic => InCubic(t),
			EaseType.OutCubic => OutCubic(t),
			EaseType.InOutCubic => InOutCubic(t),
			EaseType.InQuart => InQuart(t),
			EaseType.OutQuart => OutQuart(t),
			EaseType.InOutQuart => InOutQuart(t),
			EaseType.InQuint => InQuint(t),
			EaseType.OutQuint => OutQuint(t),
			EaseType.InOutQuint => InOutQuint(t),
			EaseType.InExpo => Sandbox.Utility.Easing.ExpoIn(t),
			EaseType.OutExpo => Sandbox.Utility.Easing.ExpoOut(t),
			EaseType.InOutExpo => Sandbox.Utility.Easing.ExpoInOut(t),
			EaseType.InCirc => InCirc(t),
			EaseType.OutCirc => OutCirc(t),
			EaseType.InOutCirc => InOutCirc(t),
			EaseType.InElastic => InElastic(t),
			EaseType.OutElastic => OutElastic(t),
			EaseType.InOutElastic => InOutElastic(t),
			EaseType.InBack => InBack(t),
			EaseType.OutBack => OutBack(t),
			EaseType.InOutBack => InOutBack(t),
			EaseType.InBounce => Sandbox.Utility.Easing.BounceIn(t),
			EaseType.OutBounce => Sandbox.Utility.Easing.BounceOut(t),
			EaseType.InOutBounce => Sandbox.Utility.Easing.BounceInOut(t),
			_ => t
		};
	}

	private static float InCubic(float f) => f * f * f;

	private static float OutCubic(float f) => 1 - MathF.Pow(1 - f, 3);

	private static float InOutCubic(float f) => f < 0.5f ? 4 * f * f * f : 1 - MathF.Pow(-2 * f + 2, 3) / 2;

	private static float InQuart(float f) => f * f * f * f;

	private static float OutQuart(float f) => 1 - MathF.Pow(1 - f, 4);

	private static float InOutQuart(float f) => f < 0.5 ? 8 * f * f * f * f : 1 - MathF.Pow(-2 * f + 2, 4) / 2;

	private static float InQuint(float f) => f * f * f * f * f;

	private static float OutQuint(float f) => 1 - MathF.Pow(1 - f, 5);

	private static float InOutQuint(float f) => f < 0.5f ? 16 * f * f * f * f * f : 1 - MathF.Pow(-2 * f + 2, 5) / 2;

	private static float InCirc(float f) => 1 - MathF.Sqrt(1 - MathF.Pow(f, 2));

	private static float OutCirc(float f) => MathF.Sqrt(1 - MathF.Pow(f - 1, 2));

	private static float InOutCirc(float f)
	{
		return f < 0.5 ?
			(1 - MathF.Sqrt(1 - MathF.Pow(2 * f, 2))) / 2 :
			(MathF.Sqrt(1 - MathF.Pow(-2 * f + 2, 2)) + 1) / 2;
	}

	private static float InElastic(float f)
	{
		const float c4 = 2 * MathF.PI / 3;

		return f == 0 ? 0 :
			f == 1 ? 1 :
			-MathF.Pow(2, 10 * f - 10) * MathF.Sin((f * 10 - 10.75f) * c4);
	}

	private static float OutElastic(float f)
	{
		const float c4 = 2 * MathF.PI / 3;

		return f == 0 ? 0 :
			f == 1 ? 1 :
			MathF.Pow(2, -10 * f) * MathF.Sin((f * 10 - 0.75f) * c4) + 1;
	}

	private static float InOutElastic(float f)
	{
		const float c5 = 2 * MathF.PI / 4.5f;

		return f == 0 ? 0 :
			f == 1 ? 1 :
			f < 0.5f ?
			-(MathF.Pow(2, 20 * f - 10) * MathF.Sin((20 * f - 11.125f) * c5)) / 2 :
			MathF.Pow(2, -20 * f + 10) * MathF.Sin((20 * f - 11.125f) * c5) / 2 + 1;
	}

	private static float InBack(float f)
	{
		const float c1 = 1.70158f;
		const float c3 = c1 + 1;
		return c3 * f * f * f - c1 * f * f;
	}

	private static float OutBack(float f)
	{
		const float c1 = 1.70158f;
		const float c3 = c1 + 1;
		return 1 + c3 * MathF.Pow(f - 1, 3) + c1 * MathF.Pow(f - 1, 2);
	}

	private static float InOutBack(float f)
	{
		const float c1 = 1.70158f;
		const float c2 = c1 * 1.525f;

		return f < 0.5f
			? MathF.Pow(2 * f, 2) * ((c2 + 1) * 2 * f - c2) / 2
			: (MathF.Pow(2 * f - 2, 2) * ((c2 + 1) * (f * 2 - 2) + c2) + 2) / 2;
	}
}
