Feature: News
As a user I want to see articles on current topics to keep abreast of world events.
As a user I want to send a question to always have a connection to BBC.

Scenario: Check secondary article titles
	Given I have gone to BBC main page
	And I have opened News page
	Then there are correct names of secondary articles on the News page
		| Title                                              |
		| Key Trump adviser tests positive for Covid-19      |
		| Spain races to save tourism as cases surge         |
		| Israel 'thwarts Hezbollah border attack'           |
		| The gravedigger’s truth: Hidden coronavirus deaths |
		| US senator defends remarks on slavery              |

Scenario: Check the name of the headline article
	Given I have gone to BBC main page
	And I have opened News page
	Then name of the headline article is German officials 'very concerned' by rising cases

Scenario: Check the name of the first article
	Given I have gone to BBC main page
	And I have opened News page
	When I look for articles by headline article category using Search bar
	Then name of the first article is D-Block Europe

Scenario Outline: Verify that user can submit a question to BBC
	Given I have gone to BBC main page
	When I go to Do you have a question for BBC news?
	And I fill the question field with <SomeCharacters> characters of Lorem ipsum
	And I fill fields with user contact info
		| Name | Email address     | Age | Postcode |
		| user | malutka@gmail.com | 20  | 03141    |
	And I take a screenshot
	Then I can find this screenshot on my PC

	Examples:
		| SomeCharacters |
		| 140            |
		| 141            |

Scenario Outline: Check for red error text when user tries to send a question with a empty field
	Given I have gone to BBC main page
	When I go to Do you have a question for BBC news?
	And I fill the question field with 100 characters of Lorem ipsum
	And I fill fields with user contact info
		| Name   | Email address   | Age   | Postcode   |
		| <Name> | <Email address> | <Age> | <Postcode> |
	And I click on Submit button
	Then there is error text under empty <Empty field> field

	Examples:
		| Name  | Email address     | Age | Postcode | Empty field   |
		|       | malutka@gmail.com | 20  | 03141    | Name          |
		| user1 |                   | 20  | 03141    | Email address |