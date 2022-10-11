using System;

namespace Task9._1
{
	public class JsonCreator
	{
		public JsonCreator(string json)
		{
            File.WriteAllText($"UserData.json", json);
        }
	}
}

