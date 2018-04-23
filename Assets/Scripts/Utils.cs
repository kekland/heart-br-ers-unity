using UnityEngine;

public static class Utils
{
	public static Vector3 VectorMultiply(Vector3 v1, Vector3 v2)
	{
		return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
	}

	public static string DeserializeVector3(Vector3 v3)
	{
		return string.Format("{0},{1},{2}", v3.x, v3.y, v3.z);
	}

	public static string DeserializeVector2(Vector2 v2) {
		return string.Format("{0},{1}", v2.x, v2.y);
	}

	public static string DeserializeQuaternion(Quaternion q)
	{
		return string.Format("{0},{1},{2},{3}", q.x, q.y, q.z, q.w);
	}

	public static Vector2 SerializeVector2(string str)
	{
		string[] numbers = str.Split(',');
		Vector2 v2 = Vector2.zero;
		try
		{
			float.TryParse(numbers[0], out v2.x);
			float.TryParse(numbers[1], out v2.y);
		}
		catch
		{
			return Vector2.zero;
		}
		return v2;
	}

	public static Vector3 SerializeVector3(string str) {
		string[] numbers = str.Split(',');
		Vector3 v3 = Vector3.zero;
		try {
			float.TryParse(numbers[0], out v3.x);
			float.TryParse(numbers[1], out v3.y);
			float.TryParse(numbers[2], out v3.z);
		}
		catch {
			return Vector3.zero;
		}
		return v3;
	}

	public static Quaternion SerializeQuaternion(string str)
	{
		string[] numbers = str.Split(',');
		Quaternion v3 = Quaternion.identity;
		try
		{
			float.TryParse(numbers[0], out v3.x);
			float.TryParse(numbers[1], out v3.y);
			float.TryParse(numbers[2], out v3.z);
			float.TryParse(numbers[3], out v3.w);
		}
		catch
		{
			return Quaternion.identity;
		}
		return v3;
	}
}