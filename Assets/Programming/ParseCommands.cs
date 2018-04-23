using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using MoonSharp.Interpreter;

public class ParseCommands : MonoBehaviour {
	string code = @"
		-- defines a factorial function
		function loop ()
			SetMotor(25, 0.5);
		end";

	void Update() {
		Script script = new Script();
		script.DoString(code);

		script.Globals["SetMotor"] = (Action<int, double>)SetMotor;
		script.Globals["GetSensorValue"] = (Func<int, double>)GetSensorValue;

		script.Call(script.Globals["loop"]);
	}

	void SetMotor(int pin, double speed)
	{
		Debug.Log(pin + " | " + speed);
	}

	double GetSensorValue(int pin)
	{
		return pin;
	}
}