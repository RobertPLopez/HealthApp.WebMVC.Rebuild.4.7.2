# HealthApp.WebMVC.Rebuild.4.7.2

This is the rebuild for my WebMVC Application. Durring this application the goal was to create the backend and some of the front for a health based MVC application. There are three major categories within the app. They are tracking your food, fitness, and spiritual health. Each of these categories plays a huge role in one overall health. The application was also deployed to Azure (the free account) at https://healthappwebmvctest.azurewebsites.net.

Backend: The backend of the applciation consists of seven data tables. There are three primary tables for food fitness and spirit. These three data tables have the full crud built out for them. In addition to there there are four sub tables attached to the fitness table. Each of these subtable have the full CRUD built out for them. During the inital build out I really wanted to challenge myself with over seven table and building out the connections between them. Within the backend I utilize icollections, ienumerables, and forgeign keys to help build out the backend. 

Frontend: The frontend utilizes Razor, HTML, and CSS. Link and button do work. Some of the challenges in this section include the deployment to azure breaking some of page loading. I dont quite know why but it did brake. 

Future Plans: In the future there are two major goals. The first is to build out some sub table for both the spirit. This will allow users to deleve deeper into there overall fitness. In addition to this I need to understand whyt he azure deployment broke the app in certain areas. 
