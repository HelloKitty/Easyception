using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyception
{
	//This is the C++ style template specialization you may have seen mentioned in comments around this project
	//The idea here is to bring C++ template specialization semantics using C# extension methods against specific
	//generic implementations of Exception type.
	/// <summary>
	/// Extension methods for <see cref="IIfSemanticChainer{TExceptionType}"/> when TExceptionType is
	/// a <see cref="ArgumentException"/>.
	/// </summary>
	public static class IIfSemanticChainerArgExExt
	{
		/// <summary>
		/// Checks if the provided condition is true or false.
		/// If true it will throw an <see cref="ArgumentException"/>.
		/// </summary>
		/// <param name="ifChainer">The semantic if object.</param>
		/// <param name="obj">Reference object to be checked for null.</param>
		/// <param name="message">Message to be provided to the <see cref="ArgumentException"/>.</param>
		/// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/> if <paramref name="obj"/> is null.</exception>
		public static IIfSemanticChainer<ArgumentException> Now(this IIfSemanticChainer<ArgumentException> ifChainer, string message)
		{
#if DEBUG
			//We need to check this because someone may mess up and not call ?.Now(). Big preformance impact if they don't
			if (ifChainer != null)
				//Just throw with the provided arguments
				throw new ArgumentException(message);
			else
				throw new InvalidOperationException($"You should not call Now when the chain is null. Use null-conditional operator like this: ?.Now(...)");
#else
			//We need to check this because someone may mess up and not call ?.Now(). Big preformance impact if they don't
			if (ifChainer != null)
				//Just throw with the provided arguments
				throw new ArgumentException(message);
#endif
		}

		/// <summary>
		/// Checks if the provided condition is true or false.
		/// If true it will throw an <see cref="ArgumentException"/>.
		/// </summary>
		/// <param name="ifChainer">The semantic if object.</param>
		/// <param name="obj">Reference object to be checked for null.</param>
		/// <param name="message">Message to be provided to the <see cref="ArgumentException"/>.</param>
		/// <param name="paramName">Name of the parameter in the current scope of the call stack to be provided to the <see cref="ArgumentException"/>.</param>
		/// <exception cref="ArgumentException">Throws <see cref="ArgumentException"/> if <paramref name="obj"/> is null.</exception>
		public static void Now(this IIfSemanticChainer<ArgumentException> ifChainer, string message, string paramName)
		{
#if DEBUG
			//We need to check this because someone may mess up and not call ?.Now(). Big preformance impact if they don't
			if (ifChainer != null)
				//Just throw with the provided arguments
				throw new ArgumentException(message, paramName);
			else
				throw new InvalidOperationException($"You should not call Now when the chain is null. Use null-conditional operator like this: ?.Now(...)");
#else
			//We need to check this because someone may mess up and not call ?.Now(). Big preformance impact if they don't
			if (ifChainer != null)
				//Just throw with the provided arguments
				throw new ArgumentException(message, paramName);
#endif
		}
	}
}
