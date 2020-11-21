# ChemiChemicalsDemo

A web application built with asp.net core , react js and used Mysql server as a persistent data source .

It's an interface for viewing a list of products , edit , delete and add product with its attributes , one of those attributes is the data sheet which is a downloadable file .

the datasheet saved in the database as base64 to track any change happpened for the content and to avoid missing urls further more.

Steps to run The application:

1-clone the project
2-back up the .bacpac file in your server
3-change the appsetting.json with your connection string
4-make sure to install all the required npm packages
5-run the asp.net core on your host and then run the reactjs UI application
