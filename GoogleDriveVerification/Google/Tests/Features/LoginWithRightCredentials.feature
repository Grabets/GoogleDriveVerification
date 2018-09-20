Feature: LoginWithRightCredentials
	To have a possibility of document creation 
	You should login into your account

@smoke
Scenario Outline: Google account login
	When I open google start page
	And push login button
	And in opened login page user enter <userName> 
	And click proceed to password button
	And in opened password page user enter <password>
	And click submit button  
	Then Home page should be created

	Examples: 
	| userName                  | password      |
	| SeleniumWebDriverAutoTest | zxcvbnm,./123 |
