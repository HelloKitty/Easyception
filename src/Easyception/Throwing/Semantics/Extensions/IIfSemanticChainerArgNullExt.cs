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
	/// a <see cref="ArgumentNullException"/>.
	/// </summary>
	public static class IIfSemanticChainerArgNullExt
	{
		//These methods are generic, sadly, because we can't use System.Object as the parameter type.
		//.Net will implictly box the values and we'll be checking non-reference types.
		//Don't worry about preformance though, .Net will only compile the methods once.

		/// <summary>
		/// Checks if the provided <paramref name="obj"/> is null.
		/// If null it will throw an <see cref="ArgumentNullException"/>.
		/// </summary>
		/// <typeparam name="TRefType">The type of reference.</typeparam>
		/// <param name="ifChainer">The semantic if object.</param>
		/// <param name="obj">Reference object to be checked for null.</param>
		/// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if <paramref name="obj"/> is null.</exception>
		public static IIfSemanticChainer<ArgumentNullException> IsNull<TRefType>(this IIfSemanticChainer<ArgumentNullException> ifChainer, TRefType obj)
			where TRefType : class
		{
			//The idea here is we'll chain using ?. to an extension method for Now()
			if (obj == null)
				return ifChainer;
			else
				return null;
		}

		/// <summary>
		/// Checks if the provided <paramref name="obj"/> is null.
		/// If null it will throw an <see cref="ArgumentNullException"/>.
		/// </summary>
		/// <typeparam name="TRefType">The type of reference.</typeparam>
		/// <param name="ifChainer">The semantic if object.</param>
		/// <param name="obj">Reference object to be checked for null.</param>
		/// <param name="paramName">Name of the parameter in the current scope of the call stack.</param>
		/// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if <paramref name="obj"/> is null.</exception>
		public static void Now(this IIfSemanticChainer<ArgumentNullException> ifChainer, string paramName)
		{
#if DEBUG
			//We need to check this because someone may mess up and not call ?.Now(). Big preformance impact if they don't
			if (ifChainer != null)
				//Just throw with the provided arguments
				throw new ArgumentNullException(paramName);
			else
				throw new InvalidOperationException($"You should not call Now when the chain is null. Use null-conditional operator like this: ?.Now(...)");
#else
			//We need to check this because someone may mess up and not call ?.Now(). Big preformance impact if they don't
			if (ifChainer != null)
				//Just throw with the provided arguments
				throw new ArgumentNullException(paramName);
#endif
		}

		/// <summary>
		/// Checks if the provided <paramref name="obj"/> is null.
		/// If null it will throw an <see cref="ArgumentNullException"/>.
		/// </summary>
		/// <typeparam name="TRefType">The type of reference.</typeparam>
		/// <param name="ifChainer">The semantic if object.</param>
		/// <param name="obj">Reference object to be checked for null.</param>
		/// <param name="paramName">Name of the parameter in the current scope of the call stack to be provided to the <see cref="ArgumentNullException"/>.</param>
		/// <param name="message">Message to be provided to the <see cref="ArgumentNullException"/>.</param>
		/// <exception cref="ArgumentNullException">Throws <see cref="ArgumentNullException"/> if <paramref name="obj"/> is null.</exception>
		public static void Now(this IIfSemanticChainer<ArgumentNullException> ifChainer, string paramName, string message)
		{
#if DEBUG
			//We need to check this because someone may mess up and not call ?.Now(). Big preformance impact if they don't
			if (ifChainer != null)
				//Just throw with the provided arguments
				throw new ArgumentNullException(paramName, message);
			else
				throw new InvalidOperationException($"You should not call Now when the chain is null. Use null-conditional operator like this: ?.Now(...)");
#else
			//We need to check this because someone may mess up and not call ?.Now(). Big preformance impact if they don't
			if (ifChainer != null)
				//Just throw with the provided arguments
				throw new ArgumentNullException(paramName, message);
#endif
		}
	}
}
