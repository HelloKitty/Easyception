# Easyception

A library that provides a fluent API for managing exceptions.

## Setup

To use this project you'll first need a couple of things:
  - Visual Studio 2015

## How To Use

Using Easyception is easy. The below sections will dicuss how to utilize the Easyception API to manage exceptions in different ways.

##### How to throw

Throwing exceptions using Easyception is done using semantics that feel like an English sentence. The below example will show how to do this using the most basic version of the **Throw<T>** API to throw an InvalidOperationException.

```
using Easyception;

public class Demo
{
  public void TestMethod(int val)
  {
    Throw<InvalidOperationException>.If.IsTrue(val < 0);
  }
}
```

The above example will throw an **InvalidOperationException** if the provided int **val** is negative. There are various other ways to throw using Throw<T>.If. Explore intellisense to get a feeling for the various methods.

## Builds

Available on a Nuget Feed: https://www.myget.org/F/hellokitty/api/v2 [![hellokitty MyGet Build Status](https://www.myget.org/BuildSource/Badge/hellokitty?identifier=48dd3f2a-4278-4376-b211-65ca50a5db76)](https://www.myget.org/)

Offical Nuget: [TBA]

##Tests

#### Linux/Mono - Unit Tests
||Debug x86|Debug x64|Release x86|Release x64|
|:--:|:--:|:--:|:--:|:--:|:--:|
|**master**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/Easyception.svg?branch=master)](https://travis-ci.org/HelloKitty/Easyception) |
|**dev**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/HelloKitty/Easyception.svg?branch=dev)](https://travis-ci.org/HelloKitty/Easyception)|

#### Windows - Unit Tests

(Done locally)

##Licensing

This project is licensed under the MIT license.
