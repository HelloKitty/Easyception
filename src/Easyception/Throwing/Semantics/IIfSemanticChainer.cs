using System;

namespace Easyception
{
	/// <summary>
	/// Contract for types that implement If semantic behaviour for fluent throwing.
	/// </summary>
	/// <typeparam name="TExceptionType">The <see cref="Type"/> of exception to throw.</typeparam>
	public interface IIfSemanticChainer<TExceptionType> : IIfSemanticChainer
		where TExceptionType : Exception, new()
	{

	}

	/// <summary>
	/// Contract for types that implement If semantic behaviour for fluent throwing.
	/// </summary>
	public interface IIfSemanticChainer
	{
		/// <summary>
		/// Throws an exception of type <typeparamref name="TExceptionType"/>
		/// if the provided <see cref="bool"/> <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Indicates if an exception should be thrown.</param>
		/// <exception cref="Exception">Throws a new parameterless instance of this exception if the <paramref name="condition"/> is true.</exception>
		void IsTrue(bool condition);
	}
}
