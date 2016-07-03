using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyception
{
	/// <summary>
	/// Objects offers serivce that will throw when requested.
	/// </summary>
	public interface IThrowable
	{
		//We define this as an extension method so we can do special null handling
		void Now();
	}
}
