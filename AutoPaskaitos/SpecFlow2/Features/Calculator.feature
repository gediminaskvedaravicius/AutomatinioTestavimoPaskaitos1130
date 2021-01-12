Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
	In order to avoid silly mistakes
	As a math idiot
	I *want* to be told the **sum** of ***two*** numbers

Link to a feature: [Calculator](SpecFlow2/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Sudek du skaicius
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Testas ar ivedus zodi tekstas jis atsivaizduoja
   Given naudojas yra selenium easy puslapyje
   When naudojas ives "Tekstas" i laukeli
   And naudojas paspaus mygtuka
   Then tekstas turi atsivaizduoti apacioje
   Then naudotojas uzdaro narsykle

Scenario: Testas ar ivedus zodi zodis jis atsivaizduoja
   Given naudojas yra selenium easy puslapyje
   When naudojas ives "Zodis" i laukeli
   And naudojas paspaus mygtuka
   Then tekstas turi atsivaizduoti apacioje
   Then naudotojas uzdaro narsykle