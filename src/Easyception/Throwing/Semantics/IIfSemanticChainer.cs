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
		/// <summary>
		/// Throws an exception of type <typeparamref name="TExceptionType"/>
		/// if the provided <see cref="bool"/> <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Indicates if an exception should be thrown.</param>
		/// <exception cref="Exception">Throws a new parameterless instance of this exception if the <paramref name="condition"/> is true.</exception>
		new IIfSemanticChainer<TExceptionType> IsTrue(bool condition);
	}

	/// <summary>
	/// Contract for types that implement If semantic behaviour for fluent throwing.
	/// </summary>
	public interface IIfSemanticChainer : IThrowable
	{
		/// <summary>
		/// Throws an exception of type <typeparamref name="TExceptionType"/>
		/// if the provided <see cref="bool"/> <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Indicates if an exception should be thrown.</param>
		/// <exception cref="Exception">Throws a new parameterless instance of this exception if the <paramref name="condition"/> is true.</exception>
		IIfSemanticChainer IsTrue(bool condition);
	}
}
