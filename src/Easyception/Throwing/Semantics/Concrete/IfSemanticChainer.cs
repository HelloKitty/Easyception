using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Easyception
{
	//This is where the cleverness comes in.
	//This type is technically Throw<TExceptionType>.If so we can do something similar
	//to C++ template speciailization through extension methods where otherwise
	//We'd need a single, or a couple, of signatures for an If method that may not
	//fit the ctor of the exception.
	//Also, activiator in net35 is very very slow
	/// <summary>
	/// Type provides if fluent chain-like semantics for users of
	/// the <see cref="Throw{TExceptionType}"/> static type.
	/// </summary>
	public class IfSemanticChainer<TExceptionType> : IIfSemanticChainer<TExceptionType>
		where TExceptionType : Exception, new()
	{
		/// <summary>
		/// Internal compiled lambda <see cref="Func{TResult}"/> that should produce
		/// an exception of <see cref="Type"/> <typeparamref name="TExceptionType"/>.
		/// </summary>
		private static readonly Func<TExceptionType> exceptionCtorParameterless;

		/// <summary>
		/// Internal compiled lambda <see cref="Func{T, TResult}"/> that should produce
		/// an exception of <see cref="Type"/> <typeparamref name="TExceptionType"/>.
		/// </summary>
		private static readonly Func<string, TExceptionType> exceptionCtorWithMessage;

		/// <summary>
		/// Initializes static members of <see cref="IfSemanticChainer"/>
		/// particularly the internal ctor Func properties.
		/// </summary>
		static IfSemanticChainer()
		{
			//We need a static ctor to prepare a compiled lambda for
			//creating a new exception of TExceptionType.
			//We need this for preformance reasons: http://www.marccostello.com/newing-up-t/
			exceptionCtorParameterless = CreateParameterlessCtorFunc();
			exceptionCtorWithMessage = CreateCtorFuncWithStringParameter();

			//We should probably check this; would be a critical error though
			if (exceptionCtorParameterless == null)
				throw new Exception($"Easyception type: {nameof(IfSemanticChainer<TExceptionType>)} failed to compile parameterless ctor lambda with field name {nameof(exceptionCtorParameterless)}.");

			//We should probably check this; would be a critical error though
			if (exceptionCtorWithMessage == null)
				throw new Exception($"Easyception type: {nameof(IfSemanticChainer<TExceptionType>)} failed to compile ctor lambda with field name {nameof(exceptionCtorWithMessage)}.");
		}

		/// <summary>
		/// Creates a new <see cref="Func{TResult}"/> object that points to a parameterless ctor
		/// method for the <typeparamref name="TExceptionType"/> type.
		/// </summary>
		/// <returns>A valid non-null <see cref="Func{TResult}"/> that produces new instances of <typeparamref name="TExceptionType"/>.</returns>
		private static Func<TExceptionType> CreateParameterlessCtorFunc()
		{
			//We need to create a Lambda for the creation of this exception
			return Expression
				.Lambda<Func<TExceptionType>>(Expression.New(typeof(TExceptionType)))
				.Compile();
		}

		/// <summary>
		/// Creates a new <see cref="Func{T, TResult}"/> object that points to a ctor
		/// method for the <typeparamref name="TExceptionType"/> type that takes a single string parameter.
		/// </summary>
		/// <returns>A valid non-null <see cref="Func{T, TResult}"/> that produces new instances of <typeparamref name="TExceptionType"/>.</returns>
		private static Func<string, TExceptionType> CreateCtorFuncWithStringParameter()
		{
			ParameterExpression paramExpression = Expression.Parameter(typeof(string), "message");

			//We need to create a Lambda for the creation of this exception with the basic string message
			return Expression
				.Lambda<Func<string, TExceptionType>>(Expression.New(typeof(TExceptionType).GetConstructor(new Type[] { typeof(string) }), paramExpression), paramExpression)
				.Compile();
		}

		/// <summary>
		/// Throws an exception of type <typeparamref name="TExceptionType"/>
		/// if the provided <see cref="bool"/> <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Indicates if an exception should be thrown.</param>
		/// <exception cref="TExceptionType">Throws a new parameterless instance of this exception if the <paramref name="condition"/> is true.</exception>
		public void IsTrue(bool condition)
		{
			//We simply check the condition and if it's true then
			//we throw using the compiled lambda ctor func
			if (condition)
				throw exceptionCtorParameterless();
		}

		/// <summary>
		/// Throws an exception of type <typeparamref name="TExceptionType"/>
		/// if the provided <see cref="bool"/> <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Indicates if an exception should be thrown.</param>
		/// <param name="message">The message to provide to the exception if the <paramref name="condition"/> is true.</param>
		/// <exception cref="TExceptionType">Throws a new instance of this exception if the <paramref name="condition"/> is true with the provided <paramref name="message"/>.</exception>
		public void IsTrue(bool condition, string message)
		{
			//We simply check the condition and if it's true then
			//we throw using the compiled lambda ctor func that includes
			//the message parameter.
			if (condition)
				throw exceptionCtorWithMessage(message);
		}
	}
}
