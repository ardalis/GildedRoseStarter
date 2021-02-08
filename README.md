# Gilded Rose Starter

A starting point for the Gilded Rose kata using dotnet core, C#, and xunit.

## Give a Star! :star:

If you like or are using this project to learn, please give it a star. Thanks!

## Watch online

If you'd like to see how I complete this kata, I use it to demonstrate several refactoring techniques in my [Pluralsight Refactoring Fundamentals course](https://www.pluralsight.com/courses/refactoring-fundamentals).

# More Katas

https://github.com/ardalis/kata-catalog

Gilded Rose Kata
============
Source: [https://github.com/ardalis/kata-catalog](https://github.com/ardalis/kata-catalog)

# Background #

This kata puts you in the role of having to work with someone else's code. It is highly suggested that you use test-first development with this kata.

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a prominent city run by a friendly innkeeper named Allison. We also buy and sell only the finest goods. Unfortunately, our goods are constantly degrading in quality as they approach their sell by date. We have a system in place that updates our inventory for us. It was developed by a no-nonsense type named Leeroy, who has moved on to new adventures. The UpdateQuality() method is called each morning by another part of our system. Your task is to add the new feature to our system so that we can begin selling a new category of items. First an introduction to our system:

- All items have a SellIn value which denotes the number of days we have to sell the item
- All items have a Quality value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well, this is where it gets interesting:

- Once the sell by date has passed, Quality degrades twice as fast
- The Quality of an item is never negative
- "Aged Brie" actually increases in Quality the older it gets
- The Quality of an item is never more than 50
- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches
	- Quality increases by 2 when there are 10 days or less 
	- Quality increases by 3 when there are 5 days or less
	- but Quality drops to 0 after the concert

# Instructions #

We have recently signed a supplier of conjured items. This requires an update to our system:

- "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any new code as long as everything still works correctly. However, **do not alter the Item class or Items property** as those belong to the goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code ownership (you can make the UpdateQuality method and Items property static if you like, we'll cover for you).

Just for clarification, an item can never have its Quality increased above 50, however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.

## Extra Credit ##

- Item categories are determined by whether they contain a given string in their name (e.g. "Aged Brie" or "Sulfuras" or "Backstage passes")
- Any item can thus be conjured, with the resulting effects (e.g. "Conjured Backstage passes")

# Resources #
- [Original Source by Bobby Johnson (NotMyself) on GitHub](https://github.com/NotMyself/GildedRose)
- [Starting code in many languages](https://github.com/emilybache/GildedRose-Refactoring-Kata)
