﻿Feature: GroceryShopper
	In order to go shopping
	As a customer of the grocery shopper app
	I want to add and delete shopping items

Scenario: I want to add an item
	Given I am on the overview screen
	When I click on the add item button
		And I enter data like "7kg" for amount and "Apples" as type
	Then I expect that the item with "7kg" and "Apples" has been added

Scenario: I want to delete an item
	Given I am on the overview screen
	When I want to delete the "A nice Roastbeef" item
	Then I expect that the item with "A nice Roastbeef" has been deleted


Scenario: I want to add an not valid item
	Given I am on the overview screen
	When I click on the add item button
		And I enter not valid data
	Then I expect to see an error message

