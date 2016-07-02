using System;

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
	/// <typeparam name="TExceptionType">The <see cref="Type"/> of exception to throw.</typeparam>
	/// </summary>
	internal class IfSemanticChainer<TExceptionType> : IIfSemanticChainer<TExceptionType>
		where TExceptionType : Exception, new()
	{
		private IExceptionInstanceFactory<TExceptionType> exceptionFactoryService { get; }

		public IfSemanticChainer(IExceptionInstanceFactory<TExceptionType> exceptionFactory)
		{
			if (exceptionFactory == null)
				throw new ArgumentNullException(nameof(exceptionFactory),
					$"{nameof(IfSemanticChainer<TExceptionType>)} must be provided a non-null instance of a the {nameof(IExceptionInstanceFactory<TExceptionType>)} service.");

			exceptionFactoryService = exceptionFactory;
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
				throw exceptionFactoryService.Create();
		}
	}
}
