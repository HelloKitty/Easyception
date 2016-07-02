using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyception
{
	public interface IIfSemanticChainer<TExceptionType>
		where TExceptionType : Exception, new()
	{
		/// <summary>
		/// Throws an exception of type <typeparamref name="TExceptionType"/>
		/// if the provided <see cref="bool"/> <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Indicates if an exception should be thrown.</param>
		/// <exception cref="TExceptionType">Throws a new parameterless instance of this exception if the <paramref name="condition"/> is true.</exception>
		void IsTrue(bool condition);

		/// <summary>
		/// Throws an exception of type <typeparamref name="TExceptionType"/>
		/// if the provided <see cref="bool"/> <paramref name="condition"/> is true.
		/// </summary>
		/// <param name="condition">Indicates if an exception should be thrown.</param>
		/// <param name="message">The message to provide to the exception if the <paramref name="condition"/> is true.</param>
		/// <exception cref="TExceptionType">Throws a new instance of this exception if the <paramref name="condition"/> is true with the provided <paramref name="message"/>.</exception>
		void IsTrue(bool condition, string message);
	}
}
