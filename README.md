# Test application for AON
## Synopsis

WebService uses n-tier architecture. With Core as its domain project. Infrastructure allows for data base access using Entity Framework. Api is an ASP.NET Web API project that exposes domain methods over the http.  
WebSite is built using React with the create-react-app as its jump-start. For testing it uses Jest.

## Builds

**Travis CI** build status for WebSite: ![status](https://img.shields.io/travis/groozin/testforaon.svg) https://travis-ci.org/groozin/testforaon  
**Visual Studio TS** build status for WebService: ![status](https://groozin.visualstudio.com/_apis/public/build/definitions/04f14996-2086-4e5c-872f-50893dd35297/1/badge) https://groozin.visualstudio.com/test-for-aon/_build  
**Visual Studio TS** build status for WebSite: ![status](https://groozin.visualstudio.com/_apis/public/build/definitions/04f14996-2086-4e5c-872f-50893dd35297/2/badge)https://groozin.visualstudio.com/test-for-aon/_build  
  
*VSTS* builds are only accessible for *authorized* users.

## Deployments

Both WebSite and WebService are deployed to Azure App Service.  
WebSite: http://app-testforaon.azurewebsites.net/  
WebService: http://testforaon.azurewebsites.net/ - this is just a host for web service. Doesn't contain any service endpoint.

## Installation

To run WebService component use *Visual Studio 2013*.  
To run WebSite use node and npm. Inside WebSite folder run:  
`npm install`  
`npm start`

## API Reference

To query web service use the following: http://testforaon.azurewebsites.net/api/customers. It returns json.

## Tests

Unit tests in WebService are using NUnit.  
Unit tests in WebSite are using Jest. To run tests use npm:  
`npm test`
