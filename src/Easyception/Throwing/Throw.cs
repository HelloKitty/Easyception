using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Easyception
{
	//Based slightly on http://www.codeducky.org/10-utilities-c-developers-should-know-part-one/ but bit more clever
	/// <summary>
	/// Throws an exception of type <typeparamref name="TExceptionType"/> depending on the built
	/// chain of fluent semantics.
	/// </summary>
	/// <typeparam name="TExceptionType">The <see cref="Type"/> of exception to throw.</typeparam>
	public static class Throw<TExceptionType>
		where TExceptionType : Exception, new() //we naturally constrain to exception because we want to throw this type
	{
		/// <summary>
		/// Continues the semantic chain for <see cref="Throw{TExceptionType}"/>
		/// using if-like semantics.
		/// </summary>
		public static IIfSemanticChainer<TExceptionType> If { get; }

		//We need this static ctor to populate If as soon as the type is accessed
		//in a thread safe way.
		/// <summary>
		/// Initializes static members of the <see cref="Throw{TExceptionType}"/> type.
		/// </summary>
		static Throw()
		{
			//After all that we need to populate the IfSemanticChainer
			//This is the only real reason anyone is accessing this class
			//Read some comments below on why this is an instance and not a static
			If = new IfSemanticChainer<TExceptionType>();
		}
	}
}
