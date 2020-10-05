# SocialNetworkAnalyser
The goal of this test is to create a web application which will analyze data from a social network.
The attached file network-data.txt comprises of anonymized information about friendships between users of a real social network where each line includes a pair of “friends” represented by their user ID, divided by a space.
Task
    1. The basic goal is to create a web app using C#, ASP.NET or ASP.NET Core, as an MVC app or single-page app with WebAPI and e.g. React or Angular.
    2. At start the app automatically creates a database, if it doesn't exist yet, and creates all the needed tables as per the database model that you have designed.
    3. Using the web app it will be possible to create a new dataset and import the data from the file network-data.txt. One dataset will have the imported data only once. Data from the import is saved into the database. 
    4. Using a webpage display an analysis, which will allow you to select a dataset and show at least these statistics for the data within: 
        ◦ On average, how many friends has each user?
        ◦ How many users are in the dataset?
Additional tasks:
Choose one of the following tasks:
    1. Include these statistics for the datasets:
        ◦ How many people, on average, do people know via 1 user, 2 users, etc. (up to the max “distance” in imported data)?
        ◦ On average, how big are groups of people where everyone is friends with all other members of the group? (E.g. if users 1, 2, 3 and 4 know each other and users 4, 5, 6 know each other, but there is no connection between 1, 2, 3 and 5, 6, there are two groups: 1, 2, 3, 4 and 4, 5, 6, i.e. the resulting average group size is 3.5)
    2. Graphically show data for the dataset.
