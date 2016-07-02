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
		public static void IsNull<TRefType>(this IIfSemanticChainer<ArgumentNullException> ifChainer, TRefType obj)
			where TRefType : class
		{
			//Check if the ifChainer is null.
			Throw<NullReferenceException>.If.IsTrue(ifChainer == null);

			//Delegate the throwing logic in this case to the ifChainer
			ifChainer.IsTrue(obj == null);
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
		public static void IsNull<TRefType>(this IIfSemanticChainer<ArgumentNullException> ifChainer, TRefType obj, string paramName)
			where TRefType : class
		{
			//Check if the ifChainer is null.
			Throw<NullReferenceException>.If.IsTrue(ifChainer == null);

			if(obj == null)
				//Just throw with the provided arguments
				throw new ArgumentNullException(paramName);
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
		public static void IsNull<TRefType>(this IIfSemanticChainer<ArgumentNullException> ifChainer, TRefType obj, string paramName, string message)
			where TRefType : class
		{
			//Check if the ifChainer is null.
			Throw<NullReferenceException>.If.IsTrue(ifChainer == null);

			if(obj == null)
				//Just throw with the provided arguments
				throw new ArgumentNullException(paramName, message);
		}
	}
}
