# Sales Tax Console Application

This project is a console application that accepts user input, in English, and emulates a minimal point of sale application. If you run the console app, hit enter on an empty line to complete a sale and see the receipt it produces.

The app applies some tax rules to the products being sold:
* Books, medical items, and food should be free of sales tax
* A 10% sales tax must be applied to all other products
* Any imported product attracts a separate 5% import tax, regardless of its tax free status
* Import tax is combined with the sales tax amount per line
* Tax is calculated at the time of sale
* Tax is rounded per line to the nearest 5 cents (just because we decided to)

You being asked to do two things

#### 1 - Fix it

The previous developer left the code in a broken state. Yay.

You need to get it working and not crash when our users make mistakes on the keyboard.

The first 2 tests in the test project are a helpful starting point.

#### 2 - Improve it

You'll see that the product name lookup is hard coded. You need to make this a little more flexible.

* Implement the `TaxFreeProductRegistry` class and make sure it's used by the application.
* The `Includes()` method must handle singular and plural forms for product names.
* There is an unused package in the project that might help you
* The class needs a default public constructor (so we can validate your code)

The 3rd unit test shows you an expected behaviour for the registry.

#### Notes

Yes, we are aware that this code is far from ideal. It's got bugs, logic in the wrong place, patchy validation, and repetitive code. It's like this on purpose. Don't worry - at Willow we try to write _much_ better code than this! If you have time and want to refactor it, go for it whilst keeping in mind that we value functional completeness and speed over coding style and refactoring code that was already working.

Additionally, your code will be validated by automated unit tests that we don't show you. If you fix all the bugs, validate user input, and implement the business rules you'll do well.

Have fun with it and good luck!