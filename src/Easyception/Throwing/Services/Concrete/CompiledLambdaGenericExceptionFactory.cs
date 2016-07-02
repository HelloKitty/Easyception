using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Easyception
{
	internal class CompiledLambdaGenericExceptionFactory<TExceptionType> : IExceptionInstanceFactory<TExceptionType>
		where TExceptionType : Exception, new()
	{
		/// <summary>
		/// Internal compiled lambda <see cref="Func{TResult}"/> that should produce
		/// an exception of <see cref="Type"/> <typeparamref name="TExceptionType"/>.
		/// </summary>
		private static readonly Func<TExceptionType> exceptionCtorParameterless;

		/// <summary>
		/// Initializes static members of <see cref="IfSemanticChainer"/>
		/// particularly the internal ctor Func properties.
		/// </summary>
		static CompiledLambdaGenericExceptionFactory()
		{
			//We need a static ctor to prepare a compiled lambda for
			//creating a new exception of TExceptionType.
			//We need this for preformance reasons: http://www.marccostello.com/newing-up-t/
			exceptionCtorParameterless = CreateParameterlessCtorFunc();

			//We should probably check this; would be a critical error though
			if (exceptionCtorParameterless == null)
				throw new Exception($"Easyception type: {nameof(IfSemanticChainer<TExceptionType>)} failed to compile parameterless ctor lambda with field name {nameof(exceptionCtorParameterless)}.");
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
		/// Creates a new instance of <see cref="Type"/> <typeparamref name="TExceptionType"/>
		/// using the <see cref="Type"/>'s parameterless constructor.
		/// </summary>
		/// <returns>A new non-null instance of <typeparamref name="TExceptionType"/>.</returns>
		public TExceptionType Create()
		{
			return exceptionCtorParameterless();
		}
	}
}
